using Microsoft.AspNetCore.Mvc;
using API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly DataContext _context;

        public BaseController(DataContext context)
        {
            _context = context;
        }
    }
}