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

        protected IFMNoteEFUnitOfWork FMNoteUnitOfWork
        {
            get { return (IFMNoteEFUnitOfWork)UnitOfWork; }
        }
    }
}