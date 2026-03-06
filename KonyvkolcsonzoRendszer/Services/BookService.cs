using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;
using KonyvkolcsonzoRendszer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KonyvkolcsonzoRendszer.Services
{
    public class BookService : IBookService
    {
        private readonly KonyvKolcsonzoContext _context;

        public BookService(KonyvKolcsonzoContext context)
        {
            _context = context;
        }

        public async Task<object> GetBorrowedBook()
        {
            var usersBooks = _context.Users.Include(u => u.Books).Select(u => new { u.Username, Books = u.Books.Select(b => new { b.Author, b.Title }) });
            return new { Value = usersBooks, Message = "Sikeres lekérés" };
        }


        public async Task<object> PostNewBook(NewBookDto newBook)
        {
            if (newBook != null)
            {
                Book book = new Book() 
                { 
                    Title = newBook.Title,
                    Author = newBook.Author,
                };
                await _context.AddAsync(book);
                await _context.SaveChangesAsync();
                return new { Value = book, Message = "Sikeres feltöltés" };
            }
            return "Sikertelen feltöltés";
        }

        public async Task<object> PutBorrowBook(int id, int bookId)
        {
            var foundBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (foundBook != null)
            {
                foundBook.UserId = id;

                _context.Update(foundBook);
                await _context.SaveChangesAsync();
                return new { Value = foundBook, Message = "Sikeres kölcsönzés" };
            }

            return "Sikertelen kölcsönzés";
        }
    }
}
