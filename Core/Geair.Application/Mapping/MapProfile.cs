using AutoMapper;
using Geair.Application.Mediator.Commands.AboutCommands;
using Geair.Application.Mediator.Commands.BannerCommands;
using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Commands.FeatureCommands;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Application.Mediator.Results.BannerResults;
using Geair.Application.Mediator.Results.BrandResults;
using Geair.Application.Mediator.Results.FeatureResults;
using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<About,GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About,GetAboutListQueryResult>().ReverseMap();
            CreateMap<About,CreateAboutCommand>().ReverseMap();

            CreateMap<Banner,GetBannerByIdQueryResult>().ReverseMap();
            CreateMap<Banner,GetBannerListQueryResult>().ReverseMap();
            CreateMap<Banner,CreateBannerCommand>().ReverseMap();

            CreateMap<Feature, GetFeatureListQueryResult>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQueryResult>().ReverseMap();
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();

            CreateMap<Brand, GetBrandListQueryResult>().ReverseMap();
            CreateMap<Brand, GetBrandByIdQueryResult>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}
