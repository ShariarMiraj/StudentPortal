using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Repo.Abstract;

namespace StudentPortal.Web.Repo.Implementation
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Book model)
        {
            try
            {
                dbContext.Books.Add(model);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                dbContext.Books.Remove(data);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return dbContext.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return dbContext.Books.ToList();
        }

        public bool Update(Book model)
        {
            try
            {
                dbContext.Books.Update(model);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
