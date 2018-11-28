using Persons.Core;

namespace Persons.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonsDbContext context;

        public UnitOfWork(PersonsDbContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
