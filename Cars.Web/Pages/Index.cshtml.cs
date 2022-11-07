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

        public string[] CarEngineTypes = {
            CarEngineTypeEnum.Petrol.ToString(),
            CarEngineTypeEnum.Diesel.ToString(),
            CarEngineTypeEnum.Electric.ToString()
        };

        public List<Car> Cars { get; set; } = new List<Car>();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            IQueryable<Car> result = _context.Cars;

            
            if(! string.IsNullOrEmpty(SearchModel.VinNumber))
            {
                result = result.Where(c => c.VinNumber.ToLower().Contains(SearchModel.VinNumber.ToLower()));
            }

            if(SearchModel.OwnerId.HasValue)
            {
                result = result.Where(o=>o.OwnerId == SearchModel.OwnerId.Value);
            }

            if(SearchModel.Type.HasValue)
            {
                result = result.Where(o => o.Type == SearchModel.Type.Value);
            }

            if(SearchModel.EngineType.HasValue)
            {
                result = result.Where(o => o.EngineType == SearchModel.EngineType);
            }

            Cars = result.ToList(); 
        }
    }
}