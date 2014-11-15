using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateClass1.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using NHibernate;
using NHibernateClass1.Repositories;

namespace NHibernateClass1.Tests
{
    [TestFixture]
    class GenerateSchema_Fixture
    {
        [Test]
        public void Can_generate_schema()
        { 
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }

        

    }
    [TestFixture]
    public class ProductRepository_Fixture
    {
        private Product[] products = new Product []
        {
            new Product{Name="Melon", Category="Fruits"},
            new Product{Name="Pear", Category="Fruits"},
            new Product{Name="Milk", Category="Beverages"},
            new Product{Name="Coca Cola", Category="Beverages"},
            new Product{Name="Pepsi Cola", Category="Beverages"},
        };
        
        

        
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();

        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }

        private void CreateInitialData()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var product in products)
                    {
                        session.Save(product);
                    }
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void CanAddNewProduct()
        {
            var Product = new Product {Name = "Apple", Category = "Fruits" };
            IProductRepository repository = new ProductRepositories();
            repository.Add(Product);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(Product.Id);
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(Product ,fromDb);
                Assert.AreEqual(Product.Name, fromDb.Name);
                Assert.AreEqual(Product.Category, fromDb.Category);
            }
        }

        [Test]
        public void CanUpdateExistingProduct()
        {
            var product = products[0];
            product.Name = "Yellow Pear";
            IProductRepository repository = new ProductRepositories();
            repository.Update(product);

            using(ISession session = _sessionFactory.OpenSession())
	        {
	            var fromDb = session.Get<Product>(product.Id);
                Assert.AreEqual(product.Name, fromDb.Name);
	        }
        }

        [Test]
        public void CanDeleteExistingProduct()
        {
            var product = products[0];
            product.Name = "Yellow Pear";
            IProductRepository repository = new ProductRepositories();
            repository.Remove(product);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.IsNull(fromDb);
            }
        }

        [Test]
        public void CanGetExistingProductById()
        {
            IProductRepository repository = new ProductRepositories();
            var fromDb = repository.GetById(products[1].Id);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(products[1], fromDb);
            Assert.AreEqual(products[1].Name, fromDb.Name);
        }

        [Test]
        public void CanGetExistingProductByName()
        {
            IProductRepository repository = new ProductRepositories();
            var fromDb = repository.GetByName(products[1].Name);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(products[1], fromDb);
            Assert.AreEqual(products[1].Id, fromDb.Id);
        }

        [Test]
        public void CanGetExistingProductsByCategory()
        {
            IProductRepository repository = new ProductRepositories();
            var fromDb = repository.GetByCategory(products[1].Category);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(2, fromDb.Count);
            Assert.IsTrue(IsInCollection(products[0], fromDb));
            Assert.IsTrue(IsInCollection(products[1], fromDb));
        }

        private bool IsInCollection(Product product, ICollection<Product> fromDb)
        {
            foreach (var item in fromDb)
            {
                if (product.Id == item.Id)
                    return true;
            }
            return false;
        }
    }

    public class UserRepository_Fixture
    {
        private User[] users = new User[]
        {
            new User{Name="Adam", Email="Adam@op.pl"},
            new User{Name="bohdan", Email="bohdan@bh.pl"},
            new User{Name="ziomek", Email="ziom"},
        };


        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(User).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();

        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }

        private void CreateInitialData()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var product in users)
                    {
                        session.Save(product);
                    }
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void CanAddNewUser()
        {
            var user = new User { Name = "Dominik", Email = "Dt@dt.pl" };
            IUserRepository repository = new UserRepositories();
            repository.Add(user);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<User>(user.Id);
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(user, fromDb);
                Assert.AreEqual(user.Name, fromDb.Name);
                Assert.AreEqual(user.Email, fromDb.Email);
            }
        }

        [Test]
        public void CanUpdateExistingUser()
        {
            var user = users[0];
            user.Name = "yyy mleko";
            IUserRepository repository = new UserRepositories();
            repository.Update(user);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(user.Id);
                Assert.AreEqual(user.Name, fromDb.Name);
            }
        }

        [Test]
        public void CanDeleteExistingUser()
        {
            var product = users[0];
            IUserRepository repository = new UserRepositories();
            repository.Remove(product);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.IsNull(fromDb);
            }
        }

        [Test]
        public void CanGetExistingUserById()
        {
            IUserRepository repository = new UserRepositories();
            var fromDb = repository.GetById(users[1].Id);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(users[1], fromDb);
            Assert.AreEqual(users[1].Name, fromDb.Name);
        }

        [Test]
        public void CanGetExistingUserByEmail()
        {
            IUserRepository repository = new UserRepositories();
            var fromDb = repository.GetByEmail(users[1].Email);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(users[1], fromDb);
            Assert.AreEqual(users[1].Id, fromDb.Id);
        }

        [Test]
        public void CanGetExistingUserByName()
        {
            IUserRepository repository = new UserRepositories();
            var fromDb = repository.GetByEmail(users[1].Name);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(users[1], fromDb);
            Assert.AreEqual(users[1].Id, fromDb.Id);
        }

        private bool IsInCollection(User user, ICollection<User> fromDb)
        {
            foreach (var item in fromDb)
            {
                if (user.Id == item.Id)
                    return true;
            }
            return false;
        }
    }

    
}
