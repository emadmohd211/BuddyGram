using Buddiegram.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buddiegram.Data
{
    public class DbManager
    {
        IDatabaseService databaseService;

        public DbManager() { }

        public DbManager(IDatabaseService service)
        {
            databaseService = service;
        }

        public Task LoginTaskAsync(UserLogin userlogin)
        {
            return databaseService.LoginDataAsync(userlogin);
        }

        public Task RegisterTaskAsync(String userdetails)
        {
            return databaseService.RegisterDataAsync(userdetails);
        }
    }
}
