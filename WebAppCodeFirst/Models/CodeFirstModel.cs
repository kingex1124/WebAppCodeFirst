namespace WebAppCodeFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeFirstModel : DbContext
    {
        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'CodeFirstModel' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'WebAppCodeFirst.Models.CodeFirstModel' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'CodeFirstModel' 連接字串。
        public CodeFirstModel()
            : base("name=CodeFirstModel")
        {
             Database.SetInitializer(new DatabaseInitializer());
        }

        // 針對您要包含在模型中的每種實體類型新增 DbSet。如需有關設定和使用
        // Code First 模型的詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                UpdateDateTime();
                return base.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        private void UpdateDateTime()
        {
            var creates = ChangeTracker.Entries<IDate>().Where(c => c.State == EntityState.Added).Select(c => c.Entity);
            var updates = ChangeTracker.Entries<IDate>().Where(c => c.State == EntityState.Modified).Select(c => c.Entity);

            DateTime dateTimeNow = DateTime.Now;
            string user = "Admin";
            //if (System.Web.HttpContext.Current != null)
            //    user = System.Web.HttpContext.Current.User.Identity.Name;
            
            foreach (var createItem in creates)
            {
                createItem.CreateDate = dateTimeNow;
                createItem.CreateUser = user;
            }

            foreach (var updatesItem in updates)
            {
                updatesItem.UpdateDate = dateTimeNow;
                updatesItem.UpdateUser = user;
            }
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}