using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace samplewebsite.Pages;

public class OrderSuccessModel : PageModel
{
    [FromQuery]
    public bool? NoEmail { get; set; }

    [FromQuery]
    public string? ProductName { get; set; }

    [FromQuery]
    public int? Quantity { get; set; }

    [FromQuery]
    public string? Total { get; set; }

    public void OnGet()
    {
    }
}
