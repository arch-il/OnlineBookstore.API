using OnlineBookstore.API.Models;
using OnlineBookstore.API.Models.AuthorModels;

namespace OnlineBookstore.API.Interfaces
{
    public interface IAuthorService
    {
        Task<CustomResponseModel<IEnumerable<ViewAuthorModel>>> GetAll();
        Task<CustomResponseModel<ViewAuthorModel>> GetById(int id);
        Task<CustomResponseModel<ViewAuthorModel>> Create(CreateAuthorModel model);
        Task<CustomResponseModel<ViewAuthorModel>> Update(UpdateAuthorModel model);
        Task<CustomResponseModel<ViewAuthorModel>> Delete(int id);
    }
}
