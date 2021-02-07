namespace UnitOfWork.Contracts
{
    using Chess.Models.DataModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public interface IUnitOfWork
    {
        void SaveChanges();
        IRepository<User> AppUsers { get; }

        ICollection<IdentityRole> Roles { get; }

    }
}
