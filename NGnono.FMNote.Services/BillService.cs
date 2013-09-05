using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGnono.FMNote.Contracts;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.Framework.Mapping;

namespace NGnono.FMNote.Services
{
    public class BillService : IBillService, IDisposable
    {
        private readonly FMNoteUnitOfWork _unitOfWork;

        public BillService(FMNoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public dynamic Insert(dynamic model)
        {
            return _unitOfWork.BillRepository.Insert(Mapper.Map<BillEntity, dynamic>(model));
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
