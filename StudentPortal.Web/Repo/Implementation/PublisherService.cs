using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Repo.Abstract;

namespace StudentPortal.Web.Repo.Implementation
{
    public class PublisherService : IPublisher
    {
        private readonly ApplicationDbContext dbContext;

        public PublisherService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Publisher model)
        {
            try
            {
                dbContext.Publishers.Add(model);
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
                var data = this.FindbyId(id);
                if (data == null)
                    return false;
                dbContext.Publishers.Remove(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public Publisher FindbyId(int id)
        {
            return dbContext.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return dbContext.Publishers.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                dbContext.Publishers.Update(model);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
    }
}
