using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Models;
using OnlineBookstore.API.Models.AuthorModels;

namespace OnlineBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<CustomResponseModel<IEnumerable<ViewAuthorModel>>> GetAll() => await _service.GetAll();

        [HttpGet("[action]")]
        public async Task<CustomResponseModel<ViewAuthorModel>> GetById(int id) => await _service.GetById(id);

        [HttpPost("[action]")]
        public async Task<CustomResponseModel<ViewAuthorModel>> Create([FromQuery] CreateAuthorModel model) => await _service.Create(model);

        [HttpPut("[action]")]
        public async Task<CustomResponseModel<ViewAuthorModel>> Update(UpdateAuthorModel model) => await _service.Update(model);

        [HttpDelete("[action]")]
        public async Task<CustomResponseModel<ViewAuthorModel>> Delete(int id) => await _service.Delete(id);
    }
}
