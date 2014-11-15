using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateClass1.Domain
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
    }

    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Remove(User user);
        User GetById(int id);
        User GetByEmail(string email);
    }
}
