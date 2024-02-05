using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Repo.Abstract;

namespace StudentPortal.Web.Repo.Implementation
{
    public class GenraServices : IGenreService
    {
        private readonly ApplicationDbContext dbContext;

        public GenraServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Genre book)
        {
            try
            {
                dbContext.Genres.Add(book);
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
                dbContext.Genres.Remove(data);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public Genre FindById(int id)
        {
            return dbContext.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return dbContext.Genres.ToList();
        }

        public bool Update(Genre book)
        {
            try
            {
                dbContext.Genres.Update(book);
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
