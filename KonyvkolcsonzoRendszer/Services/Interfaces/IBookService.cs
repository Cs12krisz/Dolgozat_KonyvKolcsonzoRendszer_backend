using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;

namespace KonyvkolcsonzoRendszer.Services.Interfaces
{
    public interface IBookService
    {
        Task<object> PostNewBook(NewBookDto newBook);

        Task<object> PutBorrowBook(int id, int bookId);
        Task<object> GetBorrowedBook();
    }
}
