using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppCodeFirst.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<CodeFirstModel>
    {
        public override void InitializeDatabase(CodeFirstModel context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(CodeFirstModel context)
        {
            base.Seed(context);
            var user = new User() { Id = 1, Name = "admin", Password = "1qaz", AccountName = "admin", CreateDate = DateTime.Now, CreateUser = "admin" };
            context.Users.Add(user);
           // context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}