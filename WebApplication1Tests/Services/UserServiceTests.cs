using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.Services;
using Xunit;

namespace WebApplication1Tests.Services
{
    public class UserServiceTests : InMemoryServiceTest
    {
        public UserServiceTests() : base()
        {
            InitServices();
        }


        [Fact]
        public async Task TestAddUser()
        {
            var scope = this.ServiceProvider.CreateScope();
            var service = scope.ServiceProvider.GetService<UserService>();

            // arrange
            var user = new User
            {
                Name = "Test",
                LastName = "LastName",
                PhoneNo = "123"
            };

            // test
            var savedUser = await service.AddUser(user);

            // check fact
            Assert.NotNull(savedUser);
            Assert.NotEqual(0, savedUser.Id);
        }


        protected override void RegisterServices(ServiceCollection services)
        {
            base.RegisterServices(services);
            services.AddScoped<UserService>();
        }
    }
}

