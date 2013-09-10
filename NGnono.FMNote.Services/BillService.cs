using NGnono.FMNote.Contracts;
using NGnono.FMNote.Datas.Models;
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

        public dynamic Insert(dynamic model)
        {
            return FMNoteUnitOfWork.BillRepository.Insert(Mapper.Map<BillEntity, dynamic>(model));
        }
    }
}
