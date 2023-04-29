using OnlineBookstore.API.Models;
using OnlineBookstore.API.Models.BookModels;

namespace OnlineBookstore.API.Interfaces
{
    public interface IBookService
    {
        Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll();
        Task<CustomResponseModel<ViewBookModel>> GetById(int id);
        Task<CustomResponseModel<ViewBookModel>> Create(CreateBookModel model);
        Task<CustomResponseModel<ViewBookModel>> Update(UpdateBookModel model);
        Task<CustomResponseModel<ViewBookModel>> Delete(int id);
    }
}
