namespace UnitOfWork.UoW
{
    using Contracts;
    using Chess.Data;
    using Repository;
    using System;
    using Chess.Models.DataModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Collections.Generic;

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        private IRepository<User> appUsers;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<User> AppUsers
        {
            get { return this.appUsers ?? (appUsers = new Repository<User>(this.context)); }
        }


       
        public ICollection<IdentityRole> Roles
        {
            get
            {
                var roleStore = new RoleStore<IdentityRole>(this.context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                return roleManager.Roles.ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
