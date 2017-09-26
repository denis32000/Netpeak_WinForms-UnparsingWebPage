using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using webpageParserShvetsovDenis.Models;

namespace webpageParserShvetsovDenis
{
    /// <summary>
    /// DbContext of application.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")//(string connectionString) : base(connectionString)
        {
        }
        public DbSet<ResponseModel> ResponseModels { get; set; }
    }

    /// <summary>
    /// Keeps singleton object of database connection.
    /// </summary>
    public class DbConnectionManager : IDbContextFactory<ApplicationContext>
    {
        private static ApplicationContext _instance;

        public static ApplicationContext Instance
        {
            get
            {
                if (_instance != null) return _instance;
                return _instance = new DbConnectionManager().Create();
            }
            private set { }
        }

        public ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}