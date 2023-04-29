using OnlineBookstore.API.Database.Context;
using OnlineBookstore.API.Database.Entities;
using OnlineBookstore.API.Models.AuthorModels;
using OnlineBookstore.API.Models;
using OnlineBookstore.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.API.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly ILogger<AuthorService> _logger;
        public readonly OnlineBookstoreContext _db;

        public AuthorService(ILogger<AuthorService> logger, OnlineBookstoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<CustomResponseModel<ViewAuthorModel>> Create(CreateAuthorModel model)
        {
            try
            {
                if (model == null)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var author = new Author()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                await _db.AddAsync(author);
                await _db.SaveChangesAsync();

                var viewAuthorModel = new ViewAuthorModel()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };

                return new()
                {
                    Status = 200,
                    Result = viewAuthorModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new()
                {
                    Status = 400,
                    Message = "Something went wrong"
                };
            }
        }

        public async Task<CustomResponseModel<ViewAuthorModel>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var author = await _db.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);

                if (author == null)
                    return new()
                    {
                        Status = 404,
                        Message = "Not Found"
                    };

                _db.Authors.Remove(author);
                await _db.SaveChangesAsync();

                var viewAuthorModel = new ViewAuthorModel()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };

                return new()
                {
                    Status = 200,
                    Result = viewAuthorModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new()
                {
                    Status = 400,
                    Message = "Something went wrong"
                };
            }
        }

        public async Task<CustomResponseModel<IEnumerable<ViewAuthorModel>>> GetAll()
        {
            try
            {
                var authors = await _db.Authors.ToListAsync();

                var viewAuthorModels = new List<ViewAuthorModel>();

                foreach (var author in authors)
                {
                    viewAuthorModels.Add(new()
                    {
                        AuthorId = author.AuthorId,
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    });
                }

                return new()
                {
                    Status = 200,
                    Result = viewAuthorModels
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new()
                {
                    Status = 400,
                    Message = "Something went wrong"
                };
            }
        }

        public async Task<CustomResponseModel<ViewAuthorModel>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var author = await _db.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);

                if (author == null)
                    return new()
                    {
                        Status = 404,
                        Message = "Not Found"
                    };

                var viewAuthorModel = new ViewAuthorModel()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };

                return new()
                {
                    Status = 200,
                    Result = viewAuthorModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new()
                {
                    Status = 400,
                    Message = "Something went wrong"
                };
            }
        }

        public async Task<CustomResponseModel<ViewAuthorModel>> Update(UpdateAuthorModel model)
        {
            try
            {
                if (model == null)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var author = new Author()
                {
                    AuthorId = model.AuthorId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                _db.Update(author);
                await _db.SaveChangesAsync();

                var viewAuthorModel = new ViewAuthorModel()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };

                return new()
                {
                    Status = 200,
                    Result = viewAuthorModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return new()
                {
                    Status = 400,
                    Message = "Something went wrong"
                };
            }
        }
    }
}
