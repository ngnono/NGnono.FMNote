using NGnono.FMNote.Contracts;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.Framework.Data.EF;
using NGnono.Framework.Mapping;
using System;

namespace NGnono.FMNote.Services
{
    public class BillService : FMNoteBaseService, IBillService
    {
        public BillService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }



    }
}
