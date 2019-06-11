using System.Data.Entity;
using DataAcsess.Models;

namespace DataAcsess
{
    public interface IStudentDBContext
    {
        DbSet<BaseType> BaseTypes { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Hash> Hashes { get; set; }
        DbSet<Images> Images { get; set; }
        DbSet<Login> Logins { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<TypeSubject> TypeSubjects { get; set; }
        DbSet<User> Users { get; set; }

        void SaveChanges();
    }
}