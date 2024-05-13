using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTravela.BusinessLayer.Abstract;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori ekleme işlemi başarıyla tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori silme işlemi başarıyla tamamlandı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Kategori güncelleme işlemi başarıyla tamamlandı");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }
    }
}
