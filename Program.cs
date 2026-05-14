using Microsoft.EntityFrameworkCore;
using samplewebsite.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<BakeryContext>(options =>
    options.UseInMemoryDatabase("BakeryDemo"));

var app = builder.Build();

// Seed demo data on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BakeryContext>();
    SeedDemoData(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


// Seed demo data function
void SeedDemoData(BakeryContext db)
{
    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new samplewebsite.Models.Product { Name = "Chocolate Cake", Description = "Rich chocolate layer cake with fudge frosting", Price = 24.99m, ImageName = "cake.jpg" },
            new samplewebsite.Models.Product { Name = "Croissant", Description = "Buttery French croissant, flaky and delicious", Price = 4.99m, ImageName = "croissant.jpg" },
            new samplewebsite.Models.Product { Name = "Espresso", Description = "Strong Italian espresso shot", Price = 3.50m, ImageName = "espresso.jpg" },
            new samplewebsite.Models.Product { Name = "Blueberry Muffin", Description = "Freshly baked with plump blueberries", Price = 5.99m, ImageName = "muffin.jpg" },
            new samplewebsite.Models.Product { Name = "Cappuccino", Description = "Smooth espresso with steamed milk and foam", Price = 5.50m, ImageName = "cappuccino.jpg" },
            new samplewebsite.Models.Product { Name = "Cheesecake", Description = "Classic New York style cheesecake", Price = 6.99m, ImageName = "cheesecake.jpg" }
        );
        db.SaveChanges();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
