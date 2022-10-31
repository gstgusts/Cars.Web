using Cars.Data;
using Cars.Data.Models;
using Cars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cars.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public CarSearchModel SearchModel { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var result = _context.Cars.Where(c => c.VinNumber.ToLower().Contains(SearchModel.VinNumber.ToLower()));
            Cars = result.ToList(); 
        }
    }
}