using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;

namespace WebApplication1Tests.Services
{
    public class InMemoryServiceTest : BaseTestService
    {
        public InMemoryServiceTest()
        {
            var dbBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            InitDbOptions(dbBuilder);
            Options = dbBuilder.Options;
        }


        protected virtual string DbName => this.GetType().Name;


        protected override void InitDbOptions(DbContextOptionsBuilder builder) =>
            builder.EnableSensitiveDataLogging().UseInMemoryDatabase(databaseName: DbName);
    }
}

