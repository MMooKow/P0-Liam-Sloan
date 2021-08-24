using System;
using Xunit;
using Model;
using Model.Entities;
using View;
using Controller;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;

namespace AppTesting
{
    public class UnitTest1
    {
        [Fact]
        public void TestIfAdmin()
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            MainMenu menu = new MainMenu(new AppController(new Model.AppRepo(context)));
            var adminStatus = menu.GetAdminStatus("admin");

            bool expectedResult = true;

            Assert.Equal(expectedResult, adminStatus);
        }

        [Fact]
        public void CheckExceptionHandlingAdminTest(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);


            MainMenu menu = new MainMenu(new AppController(new Model.AppRepo(context)));
            var adminStatus = menu.GetAdminStatus("none");

            bool expectedResult = false;

            Assert.Equal(expectedResult, adminStatus);
        }

        [Fact]
        public void CouldNotLocateRestaurant(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);


            AppController appController = new AppController(new Model.AppRepo(context));
            var findRestaurant = appController.RecommendRestaurant(00000);

            string expectedResult = "There aren't any highly reviews restaurants in your area.";

            Assert.Equal(expectedResult, findRestaurant);
        }

        [Fact]
        public void FindUser(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            AppController appController = new AppController(new Model.AppRepo(context));
            var user = appController.FindUser(99);

            string? expectedResult = "This user cannot be found.";

            Assert.Equal(expectedResult, user);
        }

        [Fact]
        public void LogInError(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);


            AppController appController = new AppController(new Model.AppRepo(context));
            var loginAttempt = appController.LogIn("none", "none");

            bool expectedResult = false;

            Assert.Equal(expectedResult, loginAttempt);
        }

        [Fact]
        public void FindValidUser(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            AppController appController = new AppController(new Model.AppRepo(context));
            var user = appController.FindUser(1);

            string? expectedResult = "sloanliam";

            Assert.Equal(expectedResult, user);
        }

        [Fact]
        public void TestForAdminFail()
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            MainMenu menu = new MainMenu(new AppController(new Model.AppRepo(context)));
            var adminStatus = menu.GetAdminStatus("none");

            bool expectedResult = false;

            Assert.Equal(expectedResult, adminStatus);
        }

        [Fact]
        public void FindRestaurantSuccess(){
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            MainMenu menu = new MainMenu(new AppController(new Model.AppRepo(context)));
            var adminStatus = menu.RecommendRestaurant(90909);

            string expectedResult = "jim has high reviews.";
            Assert.Equal(expectedResult, adminStatus);
        }

        [Fact]
        public void LogInSuccess(){

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            AppController appController = new AppController(new Model.AppRepo(context));
            var loginAttempt = appController.LogIn("sloanliam", "password");

            bool expectedResult = true;

            Assert.Equal(expectedResult, loginAttempt);
        }

        [Fact]
        public void UserSelectInvalid(){
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("petadmin");

            DbContextOptions<revtrainingdbContext> options = new DbContextOptionsBuilder<revtrainingdbContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new revtrainingdbContext(options);

            AppController appController = new AppController(new Model.AppRepo(context));
            var findUser = appController.SelectUser("sloanliam");

            Model.User expectedResult = new Model.User(0, "liam", "sloanliam", "password", null);

            Assert.Equal(expectedResult, findUser);

        }
    }
}
