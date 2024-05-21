using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService contactService)
        {
            _ContactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _ContactService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(Contact Contact)
        {
            _ContactService.TInsert(Contact);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _ContactService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact Contact)
        {
            _ContactService.TUpdate(Contact);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            return Ok(_ContactService.TGetById(id));
        }
    }
}
