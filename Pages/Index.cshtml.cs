using Microsoft.AspNetCore.Mvc.RazorPages;
using samplewebsite.Data;
using samplewebsite.Models;

namespace samplewebsite.Pages;

public class IndexModel : PageModel
{
    private readonly BakeryContext _context;

    public IndexModel(BakeryContext context)
    {
        _context = context;
    }

    public List<Product> Products { get; set; } = new();
    public Product? Featured { get; set; }

    public void OnGet()
    {
        Products = _context.Products.ToList();
        if (Products.Any())
        {
            var random = new Random();
            Featured = Products[random.Next(Products.Count)];
        }
    }
}
