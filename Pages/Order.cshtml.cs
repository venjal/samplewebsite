using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using samplewebsite.Data;
using samplewebsite.Models;

namespace samplewebsite.Pages;

public class OrderModel : PageModel
{
    private readonly BakeryContext _context;
    private readonly IConfiguration _config;

    public OrderModel(BakeryContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public Product? Product { get; set; }
    public string? ErrorMessage { get; set; }

    [BindProperty]
    public string OrderEmail { get; set; } = string.Empty;

    [BindProperty]
    public string OrderShipping { get; set; } = string.Empty;

    [BindProperty]
    public int OrderQty { get; set; } = 1;

    public IActionResult OnGet(int id)
    {
        Product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return RedirectToPage("Index");
        }
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        Product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return RedirectToPage("Index");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Email functionality (basic success message for now)
        // In production, integrate with SendGrid or similar
        // For now, just redirect to success page
        
        return RedirectToPage("OrderSuccess", new { productName = Product.Name, quantity = OrderQty, total = (Product.Price * OrderQty).ToString("F2") });
    }
}
