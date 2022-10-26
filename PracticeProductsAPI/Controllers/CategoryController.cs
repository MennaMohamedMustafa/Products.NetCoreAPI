using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCaregorysAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [EnableCors("AllowOrigin")]
    public class CategoryController : ControllerBase
    {
        private readonly IPracticeProductsRepository _practiceProductsRepository;
        public CategoryController(IPracticeProductsRepository practiceProductsRepository)
        {
            _practiceProductsRepository = practiceProductsRepository ??
                throw new ArgumentNullException(nameof(practiceProductsRepository));

        }

        [HttpGet()]
        public IActionResult GetCategories()

        {
            var categories = _practiceProductsRepository.GetCategories();
            return Ok(categories);
        }
    }
}
