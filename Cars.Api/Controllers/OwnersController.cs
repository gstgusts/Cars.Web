using Cars.Api.Models;
using Cars.Data;
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

        public OwnersController(ILogger<OwnersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OwnerDto> Get(string? query)
        {
            if(string.IsNullOrEmpty(query))
            {
                return new List<OwnerDto>();
            }

            return _context.Owners.Where(o => o.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase)
            || o.Surname.Contains(query, StringComparison.InvariantCultureIgnoreCase)).ToArray()
            .Select(o => new OwnerDto()
            {
                Id = o.Id,
                Name = o.Name,
                Surname = o.Surname
            });
        }
    }
}