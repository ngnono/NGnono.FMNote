using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using EFTracingProvider;
using EFProviderWrapperToolkit;
using NGnono.Framework.Data.EF;
using NGnono.Framework.Logger;
using NGnono.FMNote.Datas.Models.Mapping;
using NGnono.Framework.Web.Mvc.Binders;

namespace NGnono.FMNote.Datas.Models
{
    public partial class NGnono_FMNoteContext : DbContext
    {
	    private static readonly NGnono.Framework.Logger.ILog _log;

        static NGnono_FMNoteContext()
        {
            Database.SetInitializer<NGnono_FMNoteContext>(null);
			_log = LoggerManager.Current();
        }

		/// <summary>
        /// product ,no tracing
        /// </summary>
        public NGnono_FMNoteContext()
            : this("Name=NGnono_FMNoteContext" , true)
        {
        }

		/// <summary>
        /// product ,no tracing
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="product"></param>
        public NGnono_FMNoteContext(string nameOrConnectionString, bool product)
            : base(nameOrConnectionString)
        {
        }

		#region ef tracing

        public NGnono_FMNoteContext(string nameOrConnectionString)
            : base(NGnono.Framework.Data.EF.EFTracingUtil.GetConnection(nameOrConnectionString), true)
        {
			var ctx = ((IObjectContextAdapter)this).ObjectContext;

            this.ObjectContext = ctx;

            EFTracingConnection tracingConnection;
            if (ObjectContext.TryUnwrapConnection(out tracingConnection))
            {
                ctx.GetTracingConnection().CommandExecuting += (s, e) => _log.Debug(e.ToTraceString());
            }
        }

        #endregion

		#region Tracing Extensions

        private ObjectContext ObjectContext { get; set; }

        private EFTracingConnection TracingConnection
        {
            get { return ObjectContext.UnwrapConnection<EFTracingConnection>(); }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandExecuting
        {
            add { this.TracingConnection.CommandExecuting += value; }
            remove { this.TracingConnection.CommandExecuting -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFinished
        {
            add { this.TracingConnection.CommandFinished += value; }
            remove { this.TracingConnection.CommandFinished -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFailed
        {
            add { this.TracingConnection.CommandFailed += value; }
            remove { this.TracingConnection.CommandFailed -= value; }
        }

        #endregion


        public DbSet<AdminAccessRightEntity> AdminAccessRightsEntity { get; set; }
        public DbSet<BillEntity> BillsEntity { get; set; }
        public DbSet<BillTagRelationEntity> BillTagRelationsEntity { get; set; }
        public DbSet<BrandEntity> BrandsEntity { get; set; }
        public DbSet<CategoryEntity> CategoriesEntity { get; set; }
        public DbSet<CommentEntity> CommentsEntity { get; set; }
        public DbSet<FavoriteEntity> FavoritesEntity { get; set; }
        public DbSet<FeedbackEntity> FeedbacksEntity { get; set; }
        public DbSet<GroupEntity> GroupsEntity { get; set; }
        public DbSet<LikeEntity> LikesEntity { get; set; }
        public DbSet<OutsiteUserEntity> OutsiteUsersEntity { get; set; }
        public DbSet<PointHistoryEntity> PointHistoriesEntity { get; set; }
        public DbSet<PriceSettingEntity> PriceSettingsEntity { get; set; }
        public DbSet<ProductEntity> ProductsEntity { get; set; }
        public DbSet<ProductStageEntity> ProductStagesEntity { get; set; }
        public DbSet<ProductUploadJobEntity> ProductUploadJobsEntity { get; set; }
        public DbSet<PromotionEntity> PromotionsEntity { get; set; }
        public DbSet<Promotion2ProductEntity> Promotion2ProductEntity { get; set; }
        public DbSet<PromotionBrandRelationEntity> PromotionBrandRelationsEntity { get; set; }
        public DbSet<RemindEntity> RemindsEntity { get; set; }
        public DbSet<ResourceEntity> ResourcesEntity { get; set; }
        public DbSet<ResourceStageEntity> ResourceStagesEntity { get; set; }
        public DbSet<RoleEntity> RolesEntity { get; set; }
        public DbSet<RoleAccessRightEntity> RoleAccessRightsEntity { get; set; }
        public DbSet<SeedEntity> SeedsEntity { get; set; }
        public DbSet<ShareHistoryEntity> ShareHistoriesEntity { get; set; }
        public DbSet<StoreEntity> StoresEntity { get; set; }
        public DbSet<TagEntity> TagsEntity { get; set; }
        public DbSet<UserEntity> UsersEntity { get; set; }
        public DbSet<UserAccountEntity> UserAccountsEntity { get; set; }
        public DbSet<UserRoleEntity> UserRolesEntity { get; set; }
        public DbSet<VerifyCodeEntity> VerifyCodesEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
		            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AdminAccessRightEntityMap());
            modelBuilder.Configurations.Add(new BillEntityMap());
            modelBuilder.Configurations.Add(new BillTagRelationEntityMap());
            modelBuilder.Configurations.Add(new BrandEntityMap());
            modelBuilder.Configurations.Add(new CategoryEntityMap());
            modelBuilder.Configurations.Add(new CommentEntityMap());
            modelBuilder.Configurations.Add(new FavoriteEntityMap());
            modelBuilder.Configurations.Add(new FeedbackEntityMap());
            modelBuilder.Configurations.Add(new GroupEntityMap());
            modelBuilder.Configurations.Add(new LikeEntityMap());
            modelBuilder.Configurations.Add(new OutsiteUserEntityMap());
            modelBuilder.Configurations.Add(new PointHistoryEntityMap());
            modelBuilder.Configurations.Add(new PriceSettingEntityMap());
            modelBuilder.Configurations.Add(new ProductEntityMap());
            modelBuilder.Configurations.Add(new ProductStageEntityMap());
            modelBuilder.Configurations.Add(new ProductUploadJobEntityMap());
            modelBuilder.Configurations.Add(new PromotionEntityMap());
            modelBuilder.Configurations.Add(new Promotion2ProductEntityMap());
            modelBuilder.Configurations.Add(new PromotionBrandRelationEntityMap());
            modelBuilder.Configurations.Add(new RemindEntityMap());
            modelBuilder.Configurations.Add(new ResourceEntityMap());
            modelBuilder.Configurations.Add(new ResourceStageEntityMap());
            modelBuilder.Configurations.Add(new RoleEntityMap());
            modelBuilder.Configurations.Add(new RoleAccessRightEntityMap());
            modelBuilder.Configurations.Add(new SeedEntityMap());
            modelBuilder.Configurations.Add(new ShareHistoryEntityMap());
            modelBuilder.Configurations.Add(new StoreEntityMap());
            modelBuilder.Configurations.Add(new TagEntityMap());
            modelBuilder.Configurations.Add(new UserEntityMap());
            modelBuilder.Configurations.Add(new UserAccountEntityMap());
            modelBuilder.Configurations.Add(new UserRoleEntityMap());
            modelBuilder.Configurations.Add(new VerifyCodeEntityMap());
        }
    }



}
