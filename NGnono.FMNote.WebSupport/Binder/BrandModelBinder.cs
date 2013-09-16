using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGnono.FMNote.Datas.Models;
using NGnono.Framework.Data;
using NGnono.Framework.Web.Mvc.Binders;

namespace NGnono.FMNote.WebSupport.Binder
{
    public class BrandModelBinder : ModelBinderBase
    {
        private readonly IRepository<BrandEntity,int> _brandRepository;

        public BrandModelBinder(IRepository<BrandEntity, int> service)
        {
            _brandRepository = service;
        }

        #region Overrides of ModelBinderBase

        /// <summary>
        /// 根据模型标识获取模型实例
        /// </summary>
        /// <param name="modelId">
        /// 模型标识
        /// </param>
        /// <returns>
        /// 模型实例
        /// </returns>
        protected override object GetModelInstance(string modelId)
        {
            return _brandRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchBrandAttribute : UseBinderAttribute
    {
        public FetchBrandAttribute()
            : base(typeof(BrandModelBinder))
        {
        }
    }
}
