using NMHD_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Repositories
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);
        bool ValidateToken(string key, string issuer, string token);
    }
}
