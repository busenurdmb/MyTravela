using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IGaleryService _galeryService;

        public FileController(IGaleryService galeryService)
        {
            _galeryService = galeryService;
        }
        [HttpGet]
        public IActionResult List()
        {
            var values = _galeryService.TGetListAll();
            return Ok(values);
        }
        [HttpPost("upload1")]
        public async Task<IActionResult> Upload1(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yüklenmedi.");

            // Dosya uzantısını al
            var extension = Path.GetExtension(file.FileName);

            // Benzersiz dosya adı oluştur
            var imageName = Guid.NewGuid() + extension;

            // Dosya kaydedileceği yolu belirle
            var resource = "C:/Users/BUSE NUR/source/repos/MyTrevela/Travela.WebUI";
            var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);
            var imgurl = "/images/" + imageName;
            // Klasörün var olup olmadığını kontrol et ve gerekirse oluştur
            var directory = Path.GetDirectoryName(saveLocation);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Dosyayı oluştur ve kopyala
            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            Galery galery = new Galery();
            galery.İmageUrl = imgurl; 
            _galeryService.TInsert(galery);
            return Ok(new { filePath = saveLocation });
        }
    }
}

