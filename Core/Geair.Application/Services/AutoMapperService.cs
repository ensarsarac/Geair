using AutoMapper;
using Geair.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Services
{
    public static class AutoMapperService
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            var automapper = new MapperConfiguration(x => x.AddProfile(new MapProfile()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
