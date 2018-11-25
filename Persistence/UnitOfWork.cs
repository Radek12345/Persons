using System.Threading.Tasks;

namespace Persons.Persistence
{
    public class UnitOfWork
    {
        private readonly PersonsDbContext context;

        public UnitOfWork(PersonsDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
