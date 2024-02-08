using StudentPortal.Web.Models.Domain;

namespace StudentPortal.Web.Repo.Abstract
{
    public interface IAuthService
    {
        bool Add(Author model);
        bool Update(Author model);

        bool Delete(int id);
         Author  FindById(int id);

        IEnumerable<Author> GetAll();
    }
}
