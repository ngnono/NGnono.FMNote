using NGnono.FMNote.Datas.Models;
using NGnono.Framework.Data;
using NGnono.Framework.Web.Mvc.Binders;
using System;

namespace NGnono.FMNote.WebSupport.Binder
{
    #region mvc modelbinder

    #region AdminAccessRightModelBinder

    public class AdminAccessRightModelBinder : ModelBinderBase
    {
        private readonly IRepository<AdminAccessRightEntity, int> _adminaccessrightdminAccessRight;

        public AdminAccessRightModelBinder(IRepository<AdminAccessRightEntity, int> service)
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
            return _adminaccessrightdminAccessRight.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<BillEntity, int> _billill;

        public BillModelBinder(IRepository<BillEntity, int> service)
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
            return _billill.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<BillTagRelationEntity, int> _billtagrelationillTagRelation;

        public BillTagRelationModelBinder(IRepository<BillTagRelationEntity, int> service)
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
            return _billtagrelationillTagRelation.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<BrandEntity, int> _brandrand;

        public BrandModelBinder(IRepository<BrandEntity, int> service)
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
            return _brandrand.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<CategoryEntity, int> _categoryategory;

        public CategoryModelBinder(IRepository<CategoryEntity, int> service)
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
            return _categoryategory.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<CommentEntity, int> _commentomment;

        public CommentModelBinder(IRepository<CommentEntity, int> service)
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
            return _commentomment.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<FavoriteEntity, int> _favoriteavorite;

        public FavoriteModelBinder(IRepository<FavoriteEntity, int> service)
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
            return _favoriteavorite.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<FeedbackEntity, int> _feedbackeedback;

        public FeedbackModelBinder(IRepository<FeedbackEntity, int> service)
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
            return _feedbackeedback.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<GroupEntity, int> _grouproup;

        public GroupModelBinder(IRepository<GroupEntity, int> service)
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
            return _grouproup.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<LikeEntity, int> _likeike;

        public LikeModelBinder(IRepository<LikeEntity, int> service)
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
            return _likeike.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<OutsiteUserEntity, int> _outsiteuserutsiteUser;

        public OutsiteUserModelBinder(IRepository<OutsiteUserEntity, int> service)
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
            return _outsiteuserutsiteUser.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<PointHistoryEntity, int> _pointhistoryointHistory;

        public PointHistoryModelBinder(IRepository<PointHistoryEntity, int> service)
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
            return _pointhistoryointHistory.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<PriceSettingEntity, int> _pricesettingriceSetting;

        public PriceSettingModelBinder(IRepository<PriceSettingEntity, int> service)
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
            return _pricesettingriceSetting.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ProductEntity, int> _productroduct;

        public ProductModelBinder(IRepository<ProductEntity, int> service)
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
            return _productroduct.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ProductStageEntity, int> _productstageroductStage;

        public ProductStageModelBinder(IRepository<ProductStageEntity, int> service)
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
            return _productstageroductStage.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ProductUploadJobEntity, int> _productuploadjobroductUploadJob;

        public ProductUploadJobModelBinder(IRepository<ProductUploadJobEntity, int> service)
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
            return _productuploadjobroductUploadJob.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<PromotionEntity, int> _promotionromotion;

        public PromotionModelBinder(IRepository<PromotionEntity, int> service)
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
            return _promotionromotion.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<Promotion2ProductEntity, int> _promotion2productromotion2Product;

        public Promotion2ProductModelBinder(IRepository<Promotion2ProductEntity, int> service)
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
            return _promotion2productromotion2Product.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<PromotionBrandRelationEntity, int> _promotionbrandrelationromotionBrandRelation;

        public PromotionBrandRelationModelBinder(IRepository<PromotionBrandRelationEntity, int> service)
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
            return _promotionbrandrelationromotionBrandRelation.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<RemindEntity, int> _remindemind;

        public RemindModelBinder(IRepository<RemindEntity, int> service)
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
            return _remindemind.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ResourceEntity, int> _resourceesource;

        public ResourceModelBinder(IRepository<ResourceEntity, int> service)
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
            return _resourceesource.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ResourceStageEntity, int> _resourcestageesourceStage;

        public ResourceStageModelBinder(IRepository<ResourceStageEntity, int> service)
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
            return _resourcestageesourceStage.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<RoleEntity, int> _roleole;

        public RoleModelBinder(IRepository<RoleEntity, int> service)
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
            return _roleole.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<RoleAccessRightEntity, int> _roleaccessrightoleAccessRight;

        public RoleAccessRightModelBinder(IRepository<RoleAccessRightEntity, int> service)
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
            return _roleaccessrightoleAccessRight.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<SeedEntity, int> _seedeed;

        public SeedModelBinder(IRepository<SeedEntity, int> service)
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
            return _seedeed.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<ShareHistoryEntity, int> _sharehistoryhareHistory;

        public ShareHistoryModelBinder(IRepository<ShareHistoryEntity, int> service)
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
            return _sharehistoryhareHistory.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<StoreEntity, int> _storetore;

        public StoreModelBinder(IRepository<StoreEntity, int> service)
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
            return _storetore.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<TagEntity, int> _tagag;

        public TagModelBinder(IRepository<TagEntity, int> service)
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
            return _tagag.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<UserEntity, int> _userser;

        public UserModelBinder(IRepository<UserEntity, int> service)
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
            return _userser.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<UserAccountEntity, int> _useraccountserAccount;

        public UserAccountModelBinder(IRepository<UserAccountEntity, int> service)
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
            return _useraccountserAccount.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<UserRoleEntity, int> _userroleserRole;

        public UserRoleModelBinder(IRepository<UserRoleEntity, int> service)
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
            return _userroleserRole.GetItem(Int32.Parse(modelId));
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
        private readonly IRepository<VerifyCodeEntity, int> _verifycodeerifyCode;

        public VerifyCodeModelBinder(IRepository<VerifyCodeEntity, int> service)
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
            return _verifycodeerifyCode.GetItem(Int32.Parse(modelId));
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
