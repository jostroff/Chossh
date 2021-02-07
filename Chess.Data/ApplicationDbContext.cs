namespace Chess.Data
{
    using Chess.Models.DataModels;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<User>, IDbContext
    {
        public ApplicationDbContext()
            : base("db7104debd2db64919851ea7e900baef51")
        {

        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
