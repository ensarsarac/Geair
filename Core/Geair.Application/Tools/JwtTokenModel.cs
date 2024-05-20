using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Tools
{
    public class JwtTokenModel
    {
        public const string ValidAudience = "77.245.159.27";
        public const string ValidIssuer = "77.245.159.27";
        public const string Key = "GeairJWT123456789.Asp.NetCoreJWTKey";
        public const int Expire = 60;
    }
}
