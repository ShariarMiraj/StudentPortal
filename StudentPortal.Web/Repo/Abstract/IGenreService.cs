using StudentPortal.Web.Models.Domain;

namespace StudentPortal.Web.Repo.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre book);
        bool Update(Genre book);

        bool Delete(int id);
        Genre FindById(int id);

        IEnumerable<Genre> GetAll();
    }
}
