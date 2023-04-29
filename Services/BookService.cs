using Microsoft.EntityFrameworkCore;
using OnlineBookstore.API.Database.Context;
using OnlineBookstore.API.Database.Entities;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Models;
using OnlineBookstore.API.Models.BookModels;

namespace OnlineBookstore.API.Services
{
    public class BookService : IBookService
    {
        public readonly ILogger<BookService> _logger;
        public readonly OnlineBookstoreContext _db;

        public BookService(ILogger<BookService> logger, OnlineBookstoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<CustomResponseModel<ViewBookModel>> Create(CreateBookModel model)
        {
            try
            {
                if (model == null)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var book = new Book()
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Genre = model.Genre,
                    ISBN = model.ISBN,
                    Price = model.Price,
                    PublicationYear = model.PublicationYear
                };

                await _db.AddAsync(book);
                await _db.SaveChangesAsync();

                var viewBookModel = new ViewBookModel()
                {
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear
                };

                return new()
                {
                    Status = 200,
                    Result = viewBookModel
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

        public async Task<CustomResponseModel<ViewBookModel>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var book = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);

                if (book == null)
                    return new()
                    {
                        Status = 404,
                        Message = "Not Found"
                    };

                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                var viewBookModel = new ViewBookModel()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear
                };

                return new()
                {
                    Status = 200,
                    Result = viewBookModel
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

        public async Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll()
        {
            try
            {
                var books = await _db.Books.ToListAsync();

                var viewBookModels = new List<ViewBookModel>();

                foreach (var book in books)
                {
                    viewBookModels.Add(new()
                    {
                        BookId = book.BookId,
                        Title = book.Title,
                        AuthorId = book.AuthorId,
                        Genre = book.Genre,
                        ISBN = book.ISBN,
                        Price = book.Price,
                        PublicationYear = book.PublicationYear
                    });
                }

                return new()
                {
                    Status = 200,
                    Result = viewBookModels
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

        public async Task<CustomResponseModel<ViewBookModel>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var book = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);

                if (book == null)
                    return new()
                    {
                        Status = 404,
                        Message = "Not Found"
                    };

                var viewBookModel = new ViewBookModel()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear
                };

                return new()
                {
                    Status = 200,
                    Result = viewBookModel
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

        public async Task<CustomResponseModel<ViewBookModel>> Update(UpdateBookModel model)
        {
            try
            {
                if (model == null)
                    return new()
                    {
                        Status = 400,
                        Message = "Invalid input"
                    };

                var book = new Book()
                {
                    BookId = model.BookId,
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Genre = model.Genre,
                    ISBN = model.ISBN,
                    Price = model.Price,
                    PublicationYear = model.PublicationYear
                };

                _db.Update(book);
                await _db.SaveChangesAsync();

                var viewBookModel = new ViewBookModel()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear
                };

                return new()
                {
                    Status = 200,
                    Result = viewBookModel
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
