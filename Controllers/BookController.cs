using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Models;
using OnlineBookstore.API.Models.BookModels;

namespace OnlineBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll() => await _service.GetAll();

        [HttpGet("[action]")]
        public async Task<CustomResponseModel<ViewBookModel>> GetById(int id) => await _service.GetById(id);

        [HttpPost("[action]")]
        public async Task<CustomResponseModel<ViewBookModel>> Create([FromQuery] CreateBookModel model) => await _service.Create(model);

        [HttpPut("[action]")]
        public async Task<CustomResponseModel<ViewBookModel>> Update(UpdateBookModel model) => await _service.Update(model);

        [HttpDelete("[action]")]
        public async Task<CustomResponseModel<ViewBookModel>> Delete(int id) => await _service.Delete(id);
    }
}
