using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Porsche_CarDealerhip_Project.Data;
using Porsche_CarDealerhip_Project.Models;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly PorscheDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(PorscheDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public List<string> SelectedOptions { get; set; } = new();

    public List<Car> Cars { get; set; } = new();

    public async Task OnGetAsync()
    {
        var query = _context.Cars.AsQueryable();

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            query = query.Where(c => c.Model.Contains(SearchTerm));
        }

        if (SelectedOptions.Any())
        {
            foreach (var option in SelectedOptions)
            {
                query = option switch
                {
                    "Sun Roof" => query.Where(c => c.HasSunRoof),
                    "4 Wheel Drive" => query.Where(c => c.Has4WheelDrive),
                    "Low Miles" => query.Where(c => c.HasLowMiles),
                    "Power Windows" => query.Where(c => c.HasPowerWindows),
                    "Navigation" => query.Where(c => c.HasNavigation),
                    "Heated Seats" => query.Where(c => c.HasHeatedSeats),
                    _ => query
                };
            }
        }

        Cars = await query.ToListAsync();
    }
}
