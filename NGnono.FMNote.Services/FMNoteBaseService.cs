using NGnono.FMNote.Repository;
using NGnono.Framework.Data.EF;

namespace NGnono.FMNote.Services
{
    public abstract class FMNoteBaseService : BaseService
    {
        protected FMNoteBaseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected INGnono_FMNoteContextEFUnitOfWork FMNoteUnitOfWork
        {
            get { return (INGnono_FMNoteContextEFUnitOfWork)UnitOfWork; }
        }
    }
}