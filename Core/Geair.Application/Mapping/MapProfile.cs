﻿using AutoMapper;
using Geair.Application.Mediator.Commands.AboutCommands;
using Geair.Application.Mediator.Commands.AskedQuestionCommands;
using Geair.Application.Mediator.Commands.BannerCommands;
using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Commands.CategoryCommands;
using Geair.Application.Mediator.Commands.CompanyAddressCommands;
using Geair.Application.Mediator.Commands.ContactCommands;
using Geair.Application.Mediator.Commands.DestinationCommands;
using Geair.Application.Mediator.Commands.FeatureCommands;
using Geair.Application.Mediator.Commands.FlightOptionCommands;
using Geair.Application.Mediator.Commands.NewsletterCommands;
using Geair.Application.Mediator.Commands.SocialMediaCommands;
using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Application.Mediator.Results.AskedQuestionResults;
using Geair.Application.Mediator.Results.BannerResults;
using Geair.Application.Mediator.Results.BlogResults;
using Geair.Application.Mediator.Results.BrandResults;
using Geair.Application.Mediator.Results.CategoryResults;
using Geair.Application.Mediator.Results.CompanyAddressResults;
using Geair.Application.Mediator.Results.ContactResults;
using Geair.Application.Mediator.Results.DestinationResults;
using Geair.Application.Mediator.Results.FeatureResults;
using Geair.Application.Mediator.Results.FlightOptionResults;
using Geair.Application.Mediator.Results.NewsletterResults;
using Geair.Application.Mediator.Results.SocialMediaResults;
using Geair.Application.Mediator.Results.TravelResults;
using Geair.Domain.Entities;

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

            CreateMap<Destination,GetDestinationByIdQueryResult>().ReverseMap();
            CreateMap<Destination,GetDestinationListQueryResult>().ReverseMap();
            CreateMap<Destination,CreateDestinationCommand>().ReverseMap();

            CreateMap<Feature, GetFeatureListQueryResult>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQueryResult>().ReverseMap();
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();

            CreateMap<AskedQuestion, GetAskedQuestionListQueryResult>().ReverseMap();
            CreateMap<AskedQuestion, GetAskedQuestionByIdQueryResult>().ReverseMap();
            CreateMap<AskedQuestion, CreateAskedQuestionCommand>().ReverseMap();

            CreateMap<Brand, GetBrandListQueryResult>().ReverseMap();
            CreateMap<Brand, GetBrandByIdQueryResult>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();

            CreateMap<FlightOptions, GetFlightOptionByIdQueryResult>().ReverseMap();
            CreateMap<FlightOptions, GetFlightOptionListQueryResult>().ReverseMap();
            CreateMap<FlightOptions, CreateFlightOptionCommand>().ReverseMap();

            CreateMap<CompanyAddress, GetCompanyAddressByIdQueryResult>().ReverseMap();
            CreateMap<CompanyAddress, GetCompanyAddressListQueryResult>().ReverseMap();
            CreateMap<CompanyAddress, CreateCompanyAddressCommand>().ReverseMap();

            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaQueryResult>().ReverseMap();

            CreateMap<Newsletter, CreateNewsletterCommand>().ReverseMap();
            CreateMap<Newsletter, GetNewsletterByIdQueryResult>().ReverseMap();
            CreateMap<Newsletter, GetNewsletterQueryResult>().ReverseMap();

            CreateMap<Contact, GetContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact, GetContactQueryResult>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();

            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogQueryResult>().ReverseMap();

            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Travel, CreateTravelCommand>().ReverseMap();
            CreateMap<Travel, GetTravelByIdQueryResult>().ReverseMap();
            CreateMap<Travel, GetTravelQueryResult>().ReverseMap();
        }
    }
}
