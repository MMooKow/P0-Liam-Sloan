using Controller;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Model;
using Model.Entities;
using System.IO;

namespace View
{
    public class Program
    {
        static void Main(string[] args){
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
            menu.Start();
        }
    }
}