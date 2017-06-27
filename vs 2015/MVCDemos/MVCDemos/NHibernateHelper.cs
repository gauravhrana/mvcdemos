using MVCDemos.Models;
using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace MVCDemos
{
    public class NHibernateHelper
    {
        //public static ISession OpenSession()
        //{
        //    var configuration = new Configuration();

        //    var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
        //    configuration.Configure(configurationPath);

        //    var bookConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Book.hbm.xml");
        //    configuration.AddFile(bookConfigurationFile);

        //    ISessionFactory sessionFactory = configuration.BuildSessionFactory();
        //    return sessionFactory.OpenSession();
        //}

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Book).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
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