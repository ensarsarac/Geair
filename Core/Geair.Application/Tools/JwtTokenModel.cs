using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Tools
{
    public class JwtTokenModel
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "GeairJWT123456789.Asp.NetCoreJWTKey";
        public const int Expire = 60;
    }
}
