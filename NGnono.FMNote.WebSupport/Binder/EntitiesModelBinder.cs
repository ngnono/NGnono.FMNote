using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.Framework.Data;
using NGnono.Framework.Web.Mvc.Binders;
using System;

namespace NGnono.FMNote.WebSupport.Binder
{

    #region mvc modelbinder

    #region AdminAccessRightModelBinder

    public class AdminAccessRightModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _adminaccessrightdminAccessRight;

        public AdminAccessRightModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _adminaccessrightdminAccessRight = service;
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
            var disposable = _adminaccessrightdminAccessRight as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _adminaccessrightdminAccessRight.AdminAccessRightRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _adminaccessrightdminAccessRight.AdminAccessRightRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchAdminAccessRightAttribute : UseBinderAttribute
    {
        public FetchAdminAccessRightAttribute()
            : base(typeof(AdminAccessRightModelBinder))
        {
        }
    }

    #endregion

    #region BillModelBinder

    public class BillModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _billill;

        public BillModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _billill = service;
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
            var disposable = _billill as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _billill.BillRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _billill.BillRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchBillAttribute : UseBinderAttribute
    {
        public FetchBillAttribute()
            : base(typeof(BillModelBinder))
        {
        }
    }

    #endregion

    #region BillTagRelationModelBinder

    public class BillTagRelationModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _billtagrelationillTagRelation;

        public BillTagRelationModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _billtagrelationillTagRelation = service;
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
            var disposable = _billtagrelationillTagRelation as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _billtagrelationillTagRelation.BillTagRelationRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _billtagrelationillTagRelation.BillTagRelationRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchBillTagRelationAttribute : UseBinderAttribute
    {
        public FetchBillTagRelationAttribute()
            : base(typeof(BillTagRelationModelBinder))
        {
        }
    }

    #endregion

    #region BrandModelBinder

    public class BrandModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _brandrand;

        public BrandModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _brandrand = service;
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
            var disposable = _brandrand as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _brandrand.BrandRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _brandrand.BrandRepository.GetItem(Int32.Parse(modelId));
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

    #endregion

    #region CategoryModelBinder

    public class CategoryModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _categoryategory;

        public CategoryModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _categoryategory = service;
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
            var disposable = _categoryategory as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _categoryategory.CategoryRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _categoryategory.CategoryRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchCategoryAttribute : UseBinderAttribute
    {
        public FetchCategoryAttribute()
            : base(typeof(CategoryModelBinder))
        {
        }
    }

    #endregion

    #region CommentModelBinder

    public class CommentModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _commentomment;

        public CommentModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _commentomment = service;
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
            var disposable = _commentomment as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _commentomment.CommentRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _commentomment.CommentRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchCommentAttribute : UseBinderAttribute
    {
        public FetchCommentAttribute()
            : base(typeof(CommentModelBinder))
        {
        }
    }

    #endregion

    #region FavoriteModelBinder

    public class FavoriteModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _favoriteavorite;

        public FavoriteModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _favoriteavorite = service;
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
            var disposable = _favoriteavorite as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _favoriteavorite.FavoriteRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _favoriteavorite.FavoriteRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchFavoriteAttribute : UseBinderAttribute
    {
        public FetchFavoriteAttribute()
            : base(typeof(FavoriteModelBinder))
        {
        }
    }

    #endregion

    #region FeedbackModelBinder

    public class FeedbackModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _feedbackeedback;

        public FeedbackModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _feedbackeedback = service;
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
            var disposable = _feedbackeedback as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _feedbackeedback.FeedbackRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _feedbackeedback.FeedbackRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchFeedbackAttribute : UseBinderAttribute
    {
        public FetchFeedbackAttribute()
            : base(typeof(FeedbackModelBinder))
        {
        }
    }

    #endregion

    #region GroupModelBinder

    public class GroupModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _grouproup;

        public GroupModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _grouproup = service;
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
            var disposable = _grouproup as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _grouproup.GroupRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _grouproup.GroupRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchGroupAttribute : UseBinderAttribute
    {
        public FetchGroupAttribute()
            : base(typeof(GroupModelBinder))
        {
        }
    }

    #endregion

    #region LikeModelBinder

    public class LikeModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _likeike;

        public LikeModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _likeike = service;
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
            var disposable = _likeike as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _likeike.LikeRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _likeike.LikeRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchLikeAttribute : UseBinderAttribute
    {
        public FetchLikeAttribute()
            : base(typeof(LikeModelBinder))
        {
        }
    }

    #endregion

    #region OutsiteUserModelBinder

    public class OutsiteUserModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _outsiteuserutsiteUser;

        public OutsiteUserModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _outsiteuserutsiteUser = service;
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
            var disposable = _outsiteuserutsiteUser as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _outsiteuserutsiteUser.OutsiteUserRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _outsiteuserutsiteUser.OutsiteUserRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchOutsiteUserAttribute : UseBinderAttribute
    {
        public FetchOutsiteUserAttribute()
            : base(typeof(OutsiteUserModelBinder))
        {
        }
    }

    #endregion

    #region PointHistoryModelBinder

    public class PointHistoryModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _pointhistoryointHistory;

        public PointHistoryModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _pointhistoryointHistory = service;
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
            var disposable = _pointhistoryointHistory as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _pointhistoryointHistory.PointHistoryRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _pointhistoryointHistory.PointHistoryRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchPointHistoryAttribute : UseBinderAttribute
    {
        public FetchPointHistoryAttribute()
            : base(typeof(PointHistoryModelBinder))
        {
        }
    }

    #endregion

    #region PriceSettingModelBinder

    public class PriceSettingModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _pricesettingriceSetting;

        public PriceSettingModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _pricesettingriceSetting = service;
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
            var disposable = _pricesettingriceSetting as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _pricesettingriceSetting.PriceSettingRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _pricesettingriceSetting.PriceSettingRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchPriceSettingAttribute : UseBinderAttribute
    {
        public FetchPriceSettingAttribute()
            : base(typeof(PriceSettingModelBinder))
        {
        }
    }

    #endregion

    #region ProductModelBinder

    public class ProductModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _productroduct;

        public ProductModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _productroduct = service;
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
            var disposable = _productroduct as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _productroduct.ProductRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _productroduct.ProductRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchProductAttribute : UseBinderAttribute
    {
        public FetchProductAttribute()
            : base(typeof(ProductModelBinder))
        {
        }
    }

    #endregion

    #region ProductStageModelBinder

    public class ProductStageModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _productstageroductStage;

        public ProductStageModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _productstageroductStage = service;
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
            var disposable = _productstageroductStage as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _productstageroductStage.ProductStageRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _productstageroductStage.ProductStageRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchProductStageAttribute : UseBinderAttribute
    {
        public FetchProductStageAttribute()
            : base(typeof(ProductStageModelBinder))
        {
        }
    }

    #endregion

    #region ProductUploadJobModelBinder

    public class ProductUploadJobModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _productuploadjobroductUploadJob;

        public ProductUploadJobModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _productuploadjobroductUploadJob = service;
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
            var disposable = _productuploadjobroductUploadJob as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _productuploadjobroductUploadJob.ProductUploadJobRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _productuploadjobroductUploadJob.ProductUploadJobRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchProductUploadJobAttribute : UseBinderAttribute
    {
        public FetchProductUploadJobAttribute()
            : base(typeof(ProductUploadJobModelBinder))
        {
        }
    }

    #endregion

    #region PromotionModelBinder

    public class PromotionModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _promotionromotion;

        public PromotionModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _promotionromotion = service;
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
            var disposable = _promotionromotion as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _promotionromotion.PromotionRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _promotionromotion.PromotionRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchPromotionAttribute : UseBinderAttribute
    {
        public FetchPromotionAttribute()
            : base(typeof(PromotionModelBinder))
        {
        }
    }

    #endregion

    #region Promotion2ProductModelBinder

    public class Promotion2ProductModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _promotion2productromotion2Product;

        public Promotion2ProductModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _promotion2productromotion2Product = service;
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
            var disposable = _promotion2productromotion2Product as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _promotion2productromotion2Product.Promotion2ProductRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _promotion2productromotion2Product.Promotion2ProductRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchPromotion2ProductAttribute : UseBinderAttribute
    {
        public FetchPromotion2ProductAttribute()
            : base(typeof(Promotion2ProductModelBinder))
        {
        }
    }

    #endregion

    #region PromotionBrandRelationModelBinder

    public class PromotionBrandRelationModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _promotionbrandrelationromotionBrandRelation;

        public PromotionBrandRelationModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _promotionbrandrelationromotionBrandRelation = service;
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
            var disposable = _promotionbrandrelationromotionBrandRelation as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _promotionbrandrelationromotionBrandRelation.PromotionBrandRelationRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _promotionbrandrelationromotionBrandRelation.PromotionBrandRelationRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchPromotionBrandRelationAttribute : UseBinderAttribute
    {
        public FetchPromotionBrandRelationAttribute()
            : base(typeof(PromotionBrandRelationModelBinder))
        {
        }
    }

    #endregion

    #region RemindModelBinder

    public class RemindModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _remindemind;

        public RemindModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _remindemind = service;
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
            var disposable = _remindemind as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _remindemind.RemindRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _remindemind.RemindRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchRemindAttribute : UseBinderAttribute
    {
        public FetchRemindAttribute()
            : base(typeof(RemindModelBinder))
        {
        }
    }

    #endregion

    #region ResourceModelBinder

    public class ResourceModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _resourceesource;

        public ResourceModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _resourceesource = service;
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
            var disposable = _resourceesource as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _resourceesource.ResourceRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _resourceesource.ResourceRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchResourceAttribute : UseBinderAttribute
    {
        public FetchResourceAttribute()
            : base(typeof(ResourceModelBinder))
        {
        }
    }

    #endregion

    #region ResourceStageModelBinder

    public class ResourceStageModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _resourcestageesourceStage;

        public ResourceStageModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _resourcestageesourceStage = service;
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
            var disposable = _resourcestageesourceStage as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _resourcestageesourceStage.ResourceStageRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _resourcestageesourceStage.ResourceStageRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchResourceStageAttribute : UseBinderAttribute
    {
        public FetchResourceStageAttribute()
            : base(typeof(ResourceStageModelBinder))
        {
        }
    }

    #endregion

    #region RoleModelBinder

    public class RoleModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _roleole;

        public RoleModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _roleole = service;
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
            var disposable = _roleole as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _roleole.RoleRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _roleole.RoleRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchRoleAttribute : UseBinderAttribute
    {
        public FetchRoleAttribute()
            : base(typeof(RoleModelBinder))
        {
        }
    }

    #endregion

    #region RoleAccessRightModelBinder

    public class RoleAccessRightModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _roleaccessrightoleAccessRight;

        public RoleAccessRightModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _roleaccessrightoleAccessRight = service;
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
            var disposable = _roleaccessrightoleAccessRight as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _roleaccessrightoleAccessRight.RoleAccessRightRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _roleaccessrightoleAccessRight.RoleAccessRightRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchRoleAccessRightAttribute : UseBinderAttribute
    {
        public FetchRoleAccessRightAttribute()
            : base(typeof(RoleAccessRightModelBinder))
        {
        }
    }

    #endregion

    #region SeedModelBinder

    public class SeedModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _seedeed;

        public SeedModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _seedeed = service;
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
            var disposable = _seedeed as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _seedeed.SeedRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _seedeed.SeedRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchSeedAttribute : UseBinderAttribute
    {
        public FetchSeedAttribute()
            : base(typeof(SeedModelBinder))
        {
        }
    }

    #endregion

    #region ShareHistoryModelBinder

    public class ShareHistoryModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _sharehistoryhareHistory;

        public ShareHistoryModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _sharehistoryhareHistory = service;
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
            var disposable = _sharehistoryhareHistory as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _sharehistoryhareHistory.ShareHistoryRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _sharehistoryhareHistory.ShareHistoryRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchShareHistoryAttribute : UseBinderAttribute
    {
        public FetchShareHistoryAttribute()
            : base(typeof(ShareHistoryModelBinder))
        {
        }
    }

    #endregion

    #region StoreModelBinder

    public class StoreModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _storetore;

        public StoreModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _storetore = service;
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
            var disposable = _storetore as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _storetore.StoreRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _storetore.StoreRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchStoreAttribute : UseBinderAttribute
    {
        public FetchStoreAttribute()
            : base(typeof(StoreModelBinder))
        {
        }
    }

    #endregion

    #region TagModelBinder

    public class TagModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _tagag;

        public TagModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _tagag = service;
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
            var disposable = _tagag as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _tagag.TagRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _tagag.TagRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchTagAttribute : UseBinderAttribute
    {
        public FetchTagAttribute()
            : base(typeof(TagModelBinder))
        {
        }
    }

    #endregion

    #region UserModelBinder

    public class UserModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _userser;

        public UserModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _userser = service;
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
            var disposable = _userser as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _userser.UserRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _userser.UserRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchUserAttribute : UseBinderAttribute
    {
        public FetchUserAttribute()
            : base(typeof(UserModelBinder))
        {
        }
    }

    #endregion

    #region UserAccountModelBinder

    public class UserAccountModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _useraccountserAccount;

        public UserAccountModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _useraccountserAccount = service;
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
            var disposable = _useraccountserAccount as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _useraccountserAccount.UserAccountRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _useraccountserAccount.UserAccountRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchUserAccountAttribute : UseBinderAttribute
    {
        public FetchUserAccountAttribute()
            : base(typeof(UserAccountModelBinder))
        {
        }
    }

    #endregion

    #region UserRoleModelBinder

    public class UserRoleModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _userroleserRole;

        public UserRoleModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _userroleserRole = service;
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
            var disposable = _userroleserRole as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _userroleserRole.UserRoleRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _userroleserRole.UserRoleRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchUserRoleAttribute : UseBinderAttribute
    {
        public FetchUserRoleAttribute()
            : base(typeof(UserRoleModelBinder))
        {
        }
    }

    #endregion

    #region VerifyCodeModelBinder

    public class VerifyCodeModelBinder : ModelBinderBase
    {
        private readonly INGnono_FMNoteContextEFUnitOfWork _verifycodeerifyCode;

        public VerifyCodeModelBinder(INGnono_FMNoteContextEFUnitOfWork service)
        {
            _verifycodeerifyCode = service;
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
            var disposable = _verifycodeerifyCode as IDisposable;

            if (disposable != null)
            {
                using (disposable)
                {
                    return _verifycodeerifyCode.VerifyCodeRepository.GetItem(Int32.Parse(modelId));
                }
            }

            return _verifycodeerifyCode.VerifyCodeRepository.GetItem(Int32.Parse(modelId));
        }

        #endregion
    }

    public class FetchVerifyCodeAttribute : UseBinderAttribute
    {
        public FetchVerifyCodeAttribute()
            : base(typeof(VerifyCodeModelBinder))
        {
        }
    }

    #endregion


    #endregion
}
