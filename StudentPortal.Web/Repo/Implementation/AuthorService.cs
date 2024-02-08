using Microsoft.AspNetCore.Authorization;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Repo.Abstract;
using System.Security.Claims;

namespace StudentPortal.Web.Repo.Implementation
{
    public class AuthorService : IAuthService
    {
        private readonly ApplicationDbContext dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Author model)
        {
            try
            {
                dbContext.Authors.Add(model);
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
                dbContext.Authors.Remove(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindById(int id)
        {
            return dbContext.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return dbContext.Authors.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                dbContext.Authors.Update(model);

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
