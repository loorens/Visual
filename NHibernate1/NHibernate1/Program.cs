using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Cfg;

namespace NHibernate1
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(User).Assembly);
            /*configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Data Source=DOMINIK\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            configuration.AddAssembly(Assembly.GetExecutingAssembly());*/
            var sessionFactory = configuration.BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var users = session.CreateCriteria<User>().List<User>();
                    foreach (var user in users)
                    {
                        Console.WriteLine("{0} {1}", user.Name, user.Email);
                    }
                    tx.Commit();
                }
                Console.ReadLine();
            }
        }
    }
}
