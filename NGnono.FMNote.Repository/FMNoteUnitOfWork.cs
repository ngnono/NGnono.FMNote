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
        public FMNoteUnitOfWork(DbContext dbContext)
            : base(dbContext)
        {
            AdminAccessRightRepository = new EFRepository<AdminAccessRightEntity, int>(DbContext);
            BillRepository = new EFRepository<BillEntity, int>(DbContext);
            BillTagRelationRepository = new EFRepository<BillTagRelationEntity, int>(DbContext);
            BrandRepository = new EFRepository<BrandEntity, int>(DbContext);
            CategoryRepository = new EFRepository<CategoryEntity, int>(DbContext);
            CommentRepository = new EFRepository<CommentEntity, int>(DbContext);
            FavoriteRepository = new EFRepository<FavoriteEntity, int>(DbContext);
            FeedbackRepository = new EFRepository<FeedbackEntity, int>(DbContext);
            GroupRepository = new EFRepository<GroupEntity, int>(DbContext);
            LikeRepository = new EFRepository<LikeEntity, int>(DbContext);
            OutsiteUserRepository = new EFRepository<OutsiteUserEntity, int>(DbContext);
            PointHistoryRepository = new EFRepository<PointHistoryEntity, int>(DbContext);
            PriceSettingRepository = new EFRepository<PriceSettingEntity, int>(DbContext);
            ProductRepository = new EFRepository<ProductEntity, int>(DbContext);
            ProductStageRepository = new EFRepository<ProductStageEntity, int>(DbContext);
            ProductUploadJobRepository = new EFRepository<ProductUploadJobEntity, int>(DbContext);
            PromotionRepository = new EFRepository<PromotionEntity, int>(DbContext);
            Promotion2ProductRepository = new EFRepository<Promotion2ProductEntity, int>(DbContext);
            PromotionBrandRelationRepository = new EFRepository<PromotionBrandRelationEntity, int>(DbContext);
            RemindRepository = new EFRepository<RemindEntity, int>(DbContext);
            ResourceRepository = new EFRepository<ResourceEntity, int>(DbContext);
            ResourceStageRepository = new EFRepository<ResourceStageEntity, int>(DbContext);
            RoleRepository = new EFRepository<RoleEntity, int>(DbContext);
            RoleAccessRightRepository = new EFRepository<RoleAccessRightEntity, int>(DbContext);
            SeedRepository = new EFRepository<SeedEntity, int>(DbContext);
            ShareHistoryRepository = new EFRepository<ShareHistoryEntity, int>(DbContext);
            StoreRepository = new EFRepository<StoreEntity, int>(DbContext);
            TagRepository = new EFRepository<TagEntity, int>(DbContext);
            UserRepository = new EFRepository<UserEntity, int>(DbContext);
            UserAccountRepository = new EFRepository<UserAccountEntity, int>(DbContext);
            UserRoleRepository = new EFRepository<UserRoleEntity, int>(DbContext);
            VerifyCodeRepository = new EFRepository<VerifyCodeEntity, int>(DbContext);
        }

        #region porperties

        /// <summary>
        /// AdminAccessRight
        /// </summary>
        public EFRepository<AdminAccessRightEntity, int> AdminAccessRightRepository { get; protected set; }

        /// <summary>
        /// Bill
        /// </summary>
        public EFRepository<BillEntity, int> BillRepository { get; protected set; }

        /// <summary>
        /// BillTagRelation
        /// </summary>
        public EFRepository<BillTagRelationEntity, int> BillTagRelationRepository { get; protected set; }

        /// <summary>
        /// Brand
        /// </summary>
        public EFRepository<BrandEntity, int> BrandRepository { get; protected set; }

        /// <summary>
        /// Category
        /// </summary>
        public EFRepository<CategoryEntity, int> CategoryRepository { get; protected set; }

        /// <summary>
        /// Comment
        /// </summary>
        public EFRepository<CommentEntity, int> CommentRepository { get; protected set; }

        /// <summary>
        /// Favorite
        /// </summary>
        public EFRepository<FavoriteEntity, int> FavoriteRepository { get; protected set; }

        /// <summary>
        /// Feedback
        /// </summary>
        public EFRepository<FeedbackEntity, int> FeedbackRepository { get; protected set; }

        /// <summary>
        /// Group
        /// </summary>
        public EFRepository<GroupEntity, int> GroupRepository { get; protected set; }

        /// <summary>
        /// Like
        /// </summary>
        public EFRepository<LikeEntity, int> LikeRepository { get; protected set; }

        /// <summary>
        /// OutsiteUser
        /// </summary>
        public EFRepository<OutsiteUserEntity, int> OutsiteUserRepository { get; protected set; }

        /// <summary>
        /// PointHistory
        /// </summary>
        public EFRepository<PointHistoryEntity, int> PointHistoryRepository { get; protected set; }

        /// <summary>
        /// PriceSetting
        /// </summary>
        public EFRepository<PriceSettingEntity, int> PriceSettingRepository { get; protected set; }

        /// <summary>
        /// Product
        /// </summary>
        public EFRepository<ProductEntity, int> ProductRepository { get; protected set; }

        /// <summary>
        /// ProductStage
        /// </summary>
        public EFRepository<ProductStageEntity, int> ProductStageRepository { get; protected set; }

        /// <summary>
        /// ProductUploadJob
        /// </summary>
        public EFRepository<ProductUploadJobEntity, int> ProductUploadJobRepository { get; protected set; }

        /// <summary>
        /// Promotion
        /// </summary>
        public EFRepository<PromotionEntity, int> PromotionRepository { get; protected set; }

        /// <summary>
        /// Promotion2Product
        /// </summary>
        public EFRepository<Promotion2ProductEntity, int> Promotion2ProductRepository { get; protected set; }

        /// <summary>
        /// PromotionBrandRelation
        /// </summary>
        public EFRepository<PromotionBrandRelationEntity, int> PromotionBrandRelationRepository { get; protected set; }

        /// <summary>
        /// Remind
        /// </summary>
        public EFRepository<RemindEntity, int> RemindRepository { get; protected set; }

        /// <summary>
        /// Resource
        /// </summary>
        public EFRepository<ResourceEntity, int> ResourceRepository { get; protected set; }

        /// <summary>
        /// ResourceStage
        /// </summary>
        public EFRepository<ResourceStageEntity, int> ResourceStageRepository { get; protected set; }

        /// <summary>
        /// Role
        /// </summary>
        public EFRepository<RoleEntity, int> RoleRepository { get; protected set; }

        /// <summary>
        /// RoleAccessRight
        /// </summary>
        public EFRepository<RoleAccessRightEntity, int> RoleAccessRightRepository { get; protected set; }

        /// <summary>
        /// Seed
        /// </summary>
        public EFRepository<SeedEntity, int> SeedRepository { get; protected set; }

        /// <summary>
        /// ShareHistory
        /// </summary>
        public EFRepository<ShareHistoryEntity, int> ShareHistoryRepository { get; protected set; }

        /// <summary>
        /// Store
        /// </summary>
        public EFRepository<StoreEntity, int> StoreRepository { get; protected set; }

        /// <summary>
        /// Tag
        /// </summary>
        public EFRepository<TagEntity, int> TagRepository { get; protected set; }

        /// <summary>
        /// User
        /// </summary>
        public EFRepository<UserEntity, int> UserRepository { get; protected set; }

        /// <summary>
        /// UserAccount
        /// </summary>
        public EFRepository<UserAccountEntity, int> UserAccountRepository { get; protected set; }

        /// <summary>
        /// UserRole
        /// </summary>
        public EFRepository<UserRoleEntity, int> UserRoleRepository { get; protected set; }

        /// <summary>
        /// VerifyCode
        /// </summary>
        public EFRepository<VerifyCodeEntity, int> VerifyCodeRepository { get; protected set; }

        #endregion
    }

    #endregion
}
