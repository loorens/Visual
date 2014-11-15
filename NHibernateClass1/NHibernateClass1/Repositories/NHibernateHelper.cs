using NHibernate;
using NHibernate.Cfg;
using NHibernateClass1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateClass1.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure();
                    cfg.AddAssembly(typeof(Product).Assembly);
                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
