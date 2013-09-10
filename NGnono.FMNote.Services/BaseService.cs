using NGnono.FMNote.Contracts;
using NGnono.Framework.Data.EF;
using System;

namespace NGnono.FMNote.Services
{
    public abstract class BaseService : IService
    {
        private bool _isDisposed;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; set; }

        #region dispose

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            //.NET Framework 类库
            // GC..::.SuppressFinalize 方法 
            //请求系统不要调用指定对象的终结器。
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Release managed resources
                }

                // Release unmanaged resources
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                    //Context = null;
                }

                _isDisposed = true;
            }
        }

        #endregion
    }
}
