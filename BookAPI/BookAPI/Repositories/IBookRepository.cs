using BookAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        
        Task<Book> Get(int id);
        
        Task<Book> Create (Book book);
        
        Task Delete(int Id);

        Task Update(Book book);
    }
}
