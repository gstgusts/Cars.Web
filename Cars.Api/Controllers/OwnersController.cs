using Cars.Api.Models;
using Cars.Data;
using Cars.Data.Interfaces;
using Cars.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ILogger<OwnersController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IDataRepository _repo;

        public OwnersController(ILogger<OwnersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _repo = new DataRepository(context);
        }

        [HttpGet]
        public OwnerSearchResult Get(string? search)
        {
            if(string.IsNullOrEmpty(search))
            {
                return new OwnerSearchResult();
            }

            var result = new OwnerSearchResult();

            result.Results = _repo.GetOwners(search).Select(o => new OwnerSearchDto()
            {
                Id = o.Id,
                Text = o.Surname + " " + o.Name
            }).ToList();

            return result;
        }

        [HttpPost]
        public Owner Create(OwnerDto model)
        {

            var result = _repo.Create(new Owner()
            {
                Id = 0,
                Name = model.Name,
                Surname = model.Surname
            });

            return result;
        }
    }
}