using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;
using KonyvkolcsonzoRendszer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KonyvkolcsonzoRendszer.Services
{
    public class BookService : IBookService
    {
        private readonly KonyvKolcsonzoContext _context;
        public async Task<object> GetBorrowedBook()
        {
            var usersBooks = _context.Users.Include(u => u.Books).Select(u => new { u.Username });
            return new { Value = usersBooks, Message = "Sikeres lekérés" };
        }


        public async Task<object> PostNewBook(NewBookDto newBook)
        {
            if (newBook != null)
            {
                Book book = new Book() 
                { 
                    Id = newBook.Id,
                    Title = newBook.Title,
                    Author = newBook.Author,
                    UserId = newBook.UserId,
                };
                await _context.AddAsync(book);
                await _context.SaveChangesAsync();
                return new { Value = book, Message = "Sikeres feltöltés" };
            }
            return "Sikertelen feltöltés";
        }

        public Task<object> PutBorrowBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
