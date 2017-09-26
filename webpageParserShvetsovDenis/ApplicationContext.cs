using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace webpageParserShvetsovDenis
{
    public class DbConnectionManager : IDbContextFactory<ApplicationContext>
    {
        //private static string ConnectionString = "";
        
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
            //if (string.IsNullOrEmpty(ConnectionString))
            //    throw new InvalidOperationException("Please set the connection parameters before trying to instantiate a database connection.");

            return new ApplicationContext(); //(ConnectionString);
        }
    }

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")//(string connectionString) : base(connectionString)
        {
        }
        public DbSet<ResponseModel> ResponseModels { get; set; }
    }
}