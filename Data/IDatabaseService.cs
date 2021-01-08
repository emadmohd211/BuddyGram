using Buddiegram.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buddiegram.Data
{
    public interface IDatabaseService
    {
        Task LoginDataAsync(UserLogin userlogin);
        Task RegisterDataAsync(string userdetails);
    }
}
