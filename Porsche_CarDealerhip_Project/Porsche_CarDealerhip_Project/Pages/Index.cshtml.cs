using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Porsche_CarDealerhip_Project.Data;
using Porsche_CarDealerhip_Project.Models;

namespace Porsche_CarDealerhip_Project.Pages;

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
    public List<string> SelectedOptions { get; set; } = new List<string>();

    public List<Car> Cars { get; set; } = new List<Car>();

    public List<Option> AvailableOptions { get; set; } = new List<Option>();

    public async Task OnGetAsync()
    {
        AvailableOptions = await _context.Options.ToListAsync();

        var query = _context.Cars
            .Include(c => c.CarOptions)
            .ThenInclude(co => co.Option)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            query = query.Where(c => c.Model.Contains(SearchTerm));
        }

        if (SelectedOptions != null && SelectedOptions.Any())
        {
            query = query.Where(c => c.CarOptions
                .Any(co => SelectedOptions.Contains(co.Option.Name)));
        }

        Cars = await query.ToListAsync();

    }
}
