using System.Threading.Tasks;

namespace Persons.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
