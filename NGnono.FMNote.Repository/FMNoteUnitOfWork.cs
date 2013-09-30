using System;
using NGnono.FMNote.Datas.Models;
using NGnono.Framework.Data.EF;
using System.Data.Entity;

namespace NGnono.FMNote.Repository
{
    #region IEFUnitOfWork

    public interface IFMNoteEFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// AdminAccessRight
        /// </summary>
        EFRepository<AdminAccessRightEntity, int> AdminAccessRightRepository { get; }

        /// <summary>
        /// Bill
        /// </summary>
        EFRepository<BillEntity, int> BillRepository { get; }

        /// <summary>
        /// BillTagRelation
        /// </summary>
        EFRepository<BillTagRelationEntity, int> BillTagRelationRepository { get; }

        /// <summary>
        /// Brand
        /// </summary>
        EFRepository<BrandEntity, int> BrandRepository { get; }

        /// <summary>
        /// Category
        /// </summary>
        EFRepository<CategoryEntity, int> CategoryRepository { get; }

        /// <summary>
        /// Comment
        /// </summary>
        EFRepository<CommentEntity, int> CommentRepository { get; }

        /// <summary>
        /// Favorite
        /// </summary>
        EFRepository<FavoriteEntity, int> FavoriteRepository { get; }

        /// <summary>
        /// Feedback
        /// </summary>
        EFRepository<FeedbackEntity, int> FeedbackRepository { get; }

        /// <summary>
        /// Group
        /// </summary>
        EFRepository<GroupEntity, int> GroupRepository { get; }

        /// <summary>
        /// Like
        /// </summary>
        EFRepository<LikeEntity, int> LikeRepository { get; }

        /// <summary>
        /// OutsiteUser
        /// </summary>
        EFRepository<OutsiteUserEntity, int> OutsiteUserRepository { get; }

        /// <summary>
        /// PointHistory
        /// </summary>
        EFRepository<PointHistoryEntity, int> PointHistoryRepository { get; }

        /// <summary>
        /// PriceSetting
        /// </summary>
        EFRepository<PriceSettingEntity, int> PriceSettingRepository { get; }

        /// <summary>
        /// Product
        /// </summary>
        EFRepository<ProductEntity, int> ProductRepository { get; }

        /// <summary>
        /// ProductStage
        /// </summary>
        EFRepository<ProductStageEntity, int> ProductStageRepository { get; }

        /// <summary>
        /// ProductUploadJob
        /// </summary>
        EFRepository<ProductUploadJobEntity, int> ProductUploadJobRepository { get; }

        /// <summary>
        /// Promotion
        /// </summary>
        EFRepository<PromotionEntity, int> PromotionRepository { get; }

        /// <summary>
        /// Promotion2Product
        /// </summary>
        EFRepository<Promotion2ProductEntity, int> Promotion2ProductRepository { get; }

        /// <summary>
        /// PromotionBrandRelation
        /// </summary>
        EFRepository<PromotionBrandRelationEntity, int> PromotionBrandRelationRepository { get; }

        /// <summary>
        /// Remind
        /// </summary>
        EFRepository<RemindEntity, int> RemindRepository { get; }

        /// <summary>
        /// Resource
        /// </summary>
        EFRepository<ResourceEntity, int> ResourceRepository { get; }

        /// <summary>
        /// ResourceStage
        /// </summary>
        EFRepository<ResourceStageEntity, int> ResourceStageRepository { get; }

        /// <summary>
        /// Role
        /// </summary>
        EFRepository<RoleEntity, int> RoleRepository { get; }

        /// <summary>
        /// RoleAccessRight
        /// </summary>
        EFRepository<RoleAccessRightEntity, int> RoleAccessRightRepository { get; }

        /// <summary>
        /// Seed
        /// </summary>
        EFRepository<SeedEntity, int> SeedRepository { get; }

        /// <summary>
        /// ShareHistory
        /// </summary>
        EFRepository<ShareHistoryEntity, int> ShareHistoryRepository { get; }

        /// <summary>
        /// Store
        /// </summary>
        EFRepository<StoreEntity, int> StoreRepository { get; }

        /// <summary>
        /// Tag
        /// </summary>
        EFRepository<TagEntity, int> TagRepository { get; }

        /// <summary>
        /// User
        /// </summary>
        EFRepository<UserEntity, int> UserRepository { get; }

        /// <summary>
        /// UserAccount
        /// </summary>
        EFRepository<UserAccountEntity, int> UserAccountRepository { get; }

        /// <summary>
        /// UserRole
        /// </summary>
        EFRepository<UserRoleEntity, int> UserRoleRepository { get; }

        /// <summary>
        /// VerifyCode
        /// </summary>
        EFRepository<VerifyCodeEntity, int> VerifyCodeRepository { get; }

    }

    #endregion

    #region unitOfWork

    public class FMNoteUnitOfWork : EFUnitOfWork, IFMNoteEFUnitOfWork
    {
        #region fields

        /// <summary>
        /// AdminAccessRightEntity _adminAccessRightRepository;
        /// </summary>
        private EFRepository<AdminAccessRightEntity, int> _adminAccessRightRepository;

        /// <summary>
        /// BillEntity _billRepository;
        /// </summary>
        private EFRepository<BillEntity, int> _billRepository;

        /// <summary>
        /// BillTagRelationEntity _billTagRelationRepository;
        /// </summary>
        private EFRepository<BillTagRelationEntity, int> _billTagRelationRepository;

        /// <summary>
        /// BrandEntity _brandRepository;
        /// </summary>
        private EFRepository<BrandEntity, int> _brandRepository;

        /// <summary>
        /// CategoryEntity _categoryRepository;
        /// </summary>
        private EFRepository<CategoryEntity, int> _categoryRepository;

        /// <summary>
        /// CommentEntity _commentRepository;
        /// </summary>
        private EFRepository<CommentEntity, int> _commentRepository;

        /// <summary>
        /// FavoriteEntity _favoriteRepository;
        /// </summary>
        private EFRepository<FavoriteEntity, int> _favoriteRepository;

        /// <summary>
        /// FeedbackEntity _feedbackRepository;
        /// </summary>
        private EFRepository<FeedbackEntity, int> _feedbackRepository;

        /// <summary>
        /// GroupEntity _groupRepository;
        /// </summary>
        private EFRepository<GroupEntity, int> _groupRepository;

        /// <summary>
        /// LikeEntity _likeRepository;
        /// </summary>
        private EFRepository<LikeEntity, int> _likeRepository;

        /// <summary>
        /// OutsiteUserEntity _outsiteUserRepository;
        /// </summary>
        private EFRepository<OutsiteUserEntity, int> _outsiteUserRepository;

        /// <summary>
        /// PointHistoryEntity _pointHistoryRepository;
        /// </summary>
        private EFRepository<PointHistoryEntity, int> _pointHistoryRepository;

        /// <summary>
        /// PriceSettingEntity _priceSettingRepository;
        /// </summary>
        private EFRepository<PriceSettingEntity, int> _priceSettingRepository;

        /// <summary>
        /// ProductEntity _productRepository;
        /// </summary>
        private EFRepository<ProductEntity, int> _productRepository;

        /// <summary>
        /// ProductStageEntity _productStageRepository;
        /// </summary>
        private EFRepository<ProductStageEntity, int> _productStageRepository;

        /// <summary>
        /// ProductUploadJobEntity _productUploadJobRepository;
        /// </summary>
        private EFRepository<ProductUploadJobEntity, int> _productUploadJobRepository;

        /// <summary>
        /// PromotionEntity _promotionRepository;
        /// </summary>
        private EFRepository<PromotionEntity, int> _promotionRepository;

        /// <summary>
        /// Promotion2ProductEntity _promotion2ProductRepository;
        /// </summary>
        private EFRepository<Promotion2ProductEntity, int> _promotion2ProductRepository;

        /// <summary>
        /// PromotionBrandRelationEntity _promotionBrandRelationRepository;
        /// </summary>
        private EFRepository<PromotionBrandRelationEntity, int> _promotionBrandRelationRepository;

        /// <summary>
        /// RemindEntity _remindRepository;
        /// </summary>
        private EFRepository<RemindEntity, int> _remindRepository;

        /// <summary>
        /// ResourceEntity _resourceRepository;
        /// </summary>
        private EFRepository<ResourceEntity, int> _resourceRepository;

        /// <summary>
        /// ResourceStageEntity _resourceStageRepository;
        /// </summary>
        private EFRepository<ResourceStageEntity, int> _resourceStageRepository;

        /// <summary>
        /// RoleEntity _roleRepository;
        /// </summary>
        private EFRepository<RoleEntity, int> _roleRepository;

        /// <summary>
        /// RoleAccessRightEntity _roleAccessRightRepository;
        /// </summary>
        private EFRepository<RoleAccessRightEntity, int> _roleAccessRightRepository;

        /// <summary>
        /// SeedEntity _seedRepository;
        /// </summary>
        private EFRepository<SeedEntity, int> _seedRepository;

        /// <summary>
        /// ShareHistoryEntity _shareHistoryRepository;
        /// </summary>
        private EFRepository<ShareHistoryEntity, int> _shareHistoryRepository;

        /// <summary>
        /// StoreEntity _storeRepository;
        /// </summary>
        private EFRepository<StoreEntity, int> _storeRepository;

        /// <summary>
        /// TagEntity _tagRepository;
        /// </summary>
        private EFRepository<TagEntity, int> _tagRepository;

        /// <summary>
        /// UserEntity _userRepository;
        /// </summary>
        private EFRepository<UserEntity, int> _userRepository;

        /// <summary>
        /// UserAccountEntity _userAccountRepository;
        /// </summary>
        private EFRepository<UserAccountEntity, int> _userAccountRepository;

        /// <summary>
        /// UserRoleEntity _userRoleRepository;
        /// </summary>
        private EFRepository<UserRoleEntity, int> _userRoleRepository;

        /// <summary>
        /// VerifyCodeEntity _verifyCodeRepository;
        /// </summary>
        private EFRepository<VerifyCodeEntity, int> _verifyCodeRepository;

        #endregion

        #region .ctor

        public FMNoteUnitOfWork(DbContext dbContext)
            : base(dbContext)
        {
        }

        #endregion

        #region porperties

        /// <summary>
        /// AdminAccessRightEntity
        /// </summary>
        public EFRepository<AdminAccessRightEntity, int> AdminAccessRightRepository { get { return _adminAccessRightRepository ?? (_adminAccessRightRepository = new EFRepository<AdminAccessRightEntity, int>(DbContext)); } }

        /// <summary>
        /// BillEntity
        /// </summary>
        public EFRepository<BillEntity, int> BillRepository { get { return _billRepository ?? (_billRepository = new EFRepository<BillEntity, int>(DbContext)); } }

        /// <summary>
        /// BillTagRelationEntity
        /// </summary>
        public EFRepository<BillTagRelationEntity, int> BillTagRelationRepository { get { return _billTagRelationRepository ?? (_billTagRelationRepository = new EFRepository<BillTagRelationEntity, int>(DbContext)); } }

        /// <summary>
        /// BrandEntity
        /// </summary>
        public EFRepository<BrandEntity, int> BrandRepository { get { return _brandRepository ?? (_brandRepository = new EFRepository<BrandEntity, int>(DbContext)); } }

        /// <summary>
        /// CategoryEntity
        /// </summary>
        public EFRepository<CategoryEntity, int> CategoryRepository { get { return _categoryRepository ?? (_categoryRepository = new EFRepository<CategoryEntity, int>(DbContext)); } }

        /// <summary>
        /// CommentEntity
        /// </summary>
        public EFRepository<CommentEntity, int> CommentRepository { get { return _commentRepository ?? (_commentRepository = new EFRepository<CommentEntity, int>(DbContext)); } }

        /// <summary>
        /// FavoriteEntity
        /// </summary>
        public EFRepository<FavoriteEntity, int> FavoriteRepository { get { return _favoriteRepository ?? (_favoriteRepository = new EFRepository<FavoriteEntity, int>(DbContext)); } }

        /// <summary>
        /// FeedbackEntity
        /// </summary>
        public EFRepository<FeedbackEntity, int> FeedbackRepository { get { return _feedbackRepository ?? (_feedbackRepository = new EFRepository<FeedbackEntity, int>(DbContext)); } }

        /// <summary>
        /// GroupEntity
        /// </summary>
        public EFRepository<GroupEntity, int> GroupRepository { get { return _groupRepository ?? (_groupRepository = new EFRepository<GroupEntity, int>(DbContext)); } }

        /// <summary>
        /// LikeEntity
        /// </summary>
        public EFRepository<LikeEntity, int> LikeRepository { get { return _likeRepository ?? (_likeRepository = new EFRepository<LikeEntity, int>(DbContext)); } }

        /// <summary>
        /// OutsiteUserEntity
        /// </summary>
        public EFRepository<OutsiteUserEntity, int> OutsiteUserRepository { get { return _outsiteUserRepository ?? (_outsiteUserRepository = new EFRepository<OutsiteUserEntity, int>(DbContext)); } }

        /// <summary>
        /// PointHistoryEntity
        /// </summary>
        public EFRepository<PointHistoryEntity, int> PointHistoryRepository { get { return _pointHistoryRepository ?? (_pointHistoryRepository = new EFRepository<PointHistoryEntity, int>(DbContext)); } }

        /// <summary>
        /// PriceSettingEntity
        /// </summary>
        public EFRepository<PriceSettingEntity, int> PriceSettingRepository { get { return _priceSettingRepository ?? (_priceSettingRepository = new EFRepository<PriceSettingEntity, int>(DbContext)); } }

        /// <summary>
        /// ProductEntity
        /// </summary>
        public EFRepository<ProductEntity, int> ProductRepository { get { return _productRepository ?? (_productRepository = new EFRepository<ProductEntity, int>(DbContext)); } }

        /// <summary>
        /// ProductStageEntity
        /// </summary>
        public EFRepository<ProductStageEntity, int> ProductStageRepository { get { return _productStageRepository ?? (_productStageRepository = new EFRepository<ProductStageEntity, int>(DbContext)); } }

        /// <summary>
        /// ProductUploadJobEntity
        /// </summary>
        public EFRepository<ProductUploadJobEntity, int> ProductUploadJobRepository { get { return _productUploadJobRepository ?? (_productUploadJobRepository = new EFRepository<ProductUploadJobEntity, int>(DbContext)); } }

        /// <summary>
        /// PromotionEntity
        /// </summary>
        public EFRepository<PromotionEntity, int> PromotionRepository { get { return _promotionRepository ?? (_promotionRepository = new EFRepository<PromotionEntity, int>(DbContext)); } }

        /// <summary>
        /// Promotion2ProductEntity
        /// </summary>
        public EFRepository<Promotion2ProductEntity, int> Promotion2ProductRepository { get { return _promotion2ProductRepository ?? (_promotion2ProductRepository = new EFRepository<Promotion2ProductEntity, int>(DbContext)); } }

        /// <summary>
        /// PromotionBrandRelationEntity
        /// </summary>
        public EFRepository<PromotionBrandRelationEntity, int> PromotionBrandRelationRepository { get { return _promotionBrandRelationRepository ?? (_promotionBrandRelationRepository = new EFRepository<PromotionBrandRelationEntity, int>(DbContext)); } }

        /// <summary>
        /// RemindEntity
        /// </summary>
        public EFRepository<RemindEntity, int> RemindRepository { get { return _remindRepository ?? (_remindRepository = new EFRepository<RemindEntity, int>(DbContext)); } }

        /// <summary>
        /// ResourceEntity
        /// </summary>
        public EFRepository<ResourceEntity, int> ResourceRepository { get { return _resourceRepository ?? (_resourceRepository = new EFRepository<ResourceEntity, int>(DbContext)); } }

        /// <summary>
        /// ResourceStageEntity
        /// </summary>
        public EFRepository<ResourceStageEntity, int> ResourceStageRepository { get { return _resourceStageRepository ?? (_resourceStageRepository = new EFRepository<ResourceStageEntity, int>(DbContext)); } }

        /// <summary>
        /// RoleEntity
        /// </summary>
        public EFRepository<RoleEntity, int> RoleRepository { get { return _roleRepository ?? (_roleRepository = new EFRepository<RoleEntity, int>(DbContext)); } }

        /// <summary>
        /// RoleAccessRightEntity
        /// </summary>
        public EFRepository<RoleAccessRightEntity, int> RoleAccessRightRepository { get { return _roleAccessRightRepository ?? (_roleAccessRightRepository = new EFRepository<RoleAccessRightEntity, int>(DbContext)); } }

        /// <summary>
        /// SeedEntity
        /// </summary>
        public EFRepository<SeedEntity, int> SeedRepository { get { return _seedRepository ?? (_seedRepository = new EFRepository<SeedEntity, int>(DbContext)); } }

        /// <summary>
        /// ShareHistoryEntity
        /// </summary>
        public EFRepository<ShareHistoryEntity, int> ShareHistoryRepository { get { return _shareHistoryRepository ?? (_shareHistoryRepository = new EFRepository<ShareHistoryEntity, int>(DbContext)); } }

        /// <summary>
        /// StoreEntity
        /// </summary>
        public EFRepository<StoreEntity, int> StoreRepository { get { return _storeRepository ?? (_storeRepository = new EFRepository<StoreEntity, int>(DbContext)); } }

        /// <summary>
        /// TagEntity
        /// </summary>
        public EFRepository<TagEntity, int> TagRepository { get { return _tagRepository ?? (_tagRepository = new EFRepository<TagEntity, int>(DbContext)); } }

        /// <summary>
        /// UserEntity
        /// </summary>
        public EFRepository<UserEntity, int> UserRepository { get { return _userRepository ?? (_userRepository = new EFRepository<UserEntity, int>(DbContext)); } }

        /// <summary>
        /// UserAccountEntity
        /// </summary>
        public EFRepository<UserAccountEntity, int> UserAccountRepository { get { return _userAccountRepository ?? (_userAccountRepository = new EFRepository<UserAccountEntity, int>(DbContext)); } }

        /// <summary>
        /// UserRoleEntity
        /// </summary>
        public EFRepository<UserRoleEntity, int> UserRoleRepository { get { return _userRoleRepository ?? (_userRoleRepository = new EFRepository<UserRoleEntity, int>(DbContext)); } }

        /// <summary>
        /// VerifyCodeEntity
        /// </summary>
        public EFRepository<VerifyCodeEntity, int> VerifyCodeRepository { get { return _verifyCodeRepository ?? (_verifyCodeRepository = new EFRepository<VerifyCodeEntity, int>(DbContext)); } }

        #endregion
    }

    #endregion
}
