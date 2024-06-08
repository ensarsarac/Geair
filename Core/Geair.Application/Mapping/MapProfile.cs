using AutoMapper;
using Geair.Application.Mediator.Commands.AboutCommands;
using Geair.Application.Mediator.Commands.AircraftCommands;
using Geair.Application.Mediator.Commands.AirportCommands;
using Geair.Application.Mediator.Commands.AskedQuestionCommands;
using Geair.Application.Mediator.Commands.BannerCommands;
using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Commands.CategoryCommands;
using Geair.Application.Mediator.Commands.CompanyAddressCommands;
using Geair.Application.Mediator.Commands.ContactCommands;
using Geair.Application.Mediator.Commands.DestinationCommands;
using Geair.Application.Mediator.Commands.FeatureCommands;
using Geair.Application.Mediator.Commands.FlightCommands;
using Geair.Application.Mediator.Commands.FlightOptionCommands;
using Geair.Application.Mediator.Commands.NewsletterCommands;
using Geair.Application.Mediator.Commands.NotificationCommands;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using Geair.Application.Mediator.Commands.RoleCommands;
using Geair.Application.Mediator.Commands.SeatCommands;
using Geair.Application.Mediator.Commands.SocialMediaCommands;
using Geair.Application.Mediator.Commands.TicketCommands;
using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Application.Mediator.Results.AircraftResults;
using Geair.Application.Mediator.Results.AirportResults;
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
using Geair.Application.Mediator.Results.FlightResults;
using Geair.Application.Mediator.Results.NewsletterResults;
using Geair.Application.Mediator.Results.NotificationResults;
using Geair.Application.Mediator.Results.RoleResults;
using Geair.Application.Mediator.Results.SeatResults;
using Geair.Application.Mediator.Results.SocialMediaResults;
using Geair.Application.Mediator.Results.TicketResults;
using Geair.Application.Mediator.Results.TravelResults;
using Geair.Application.Mediator.Results.UserResults;
using Geair.Domain.Entities;

namespace Geair.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<About, GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About, GetAboutListQueryResult>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();

            CreateMap<Airport, GetAirportByIdQueryResult>().ReverseMap();
            CreateMap<Airport, GetAirportListQueryResult>().ReverseMap();
            CreateMap<Airport, CreateAirportCommand>().ReverseMap();

            CreateMap<Aircraft, GetAircraftByIdQueryResult>().ReverseMap();
            CreateMap<Aircraft, GetAircraftQueryResult>().ReverseMap();
            CreateMap<Aircraft, CreateAircraftCommand>().ReverseMap();
            CreateMap<Aircraft, GetAircraftAndSeatsQueryResult>().ReverseMap();

            CreateMap<Banner, GetBannerByIdQueryResult>().ReverseMap();
            CreateMap<Banner, GetBannerListQueryResult>().ReverseMap();
            CreateMap<Banner, CreateBannerCommand>().ReverseMap();

            CreateMap<Destination, GetDestinationByIdQueryResult>().ReverseMap();
            CreateMap<Destination, GetDestinationListQueryResult>().ReverseMap();
            CreateMap<Destination, CreateDestinationCommand>().ReverseMap();

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

            CreateMap<Seat, CreateSeatCommand>().ReverseMap();
            CreateMap<Seat, GetSeatByIdQueryResult>().ReverseMap();
            CreateMap<Seat, GetSeatQueryResult>().ReverseMap();

            CreateMap<Contact, GetContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact, GetContactQueryResult>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, GetUserQueryResult>().ReverseMap();

            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogQueryResult>().ReverseMap();
            CreateMap<Blog, GetLast4BlogQueryResult>().ReverseMap();

            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Travel, CreateTravelCommand>().ReverseMap();
            CreateMap<Travel, GetTravelByIdQueryResult>().ReverseMap();
            CreateMap<Travel, GetTravelQueryResult>().ReverseMap();
            CreateMap<Travel, GetLast4TravelQueryResult>().ReverseMap();
            CreateMap<Travel, GetTravelListOrderByQueryResult>().ReverseMap();
            CreateMap<Travel, GetTravelAndReservationsQueryResult>().ReverseMap();

            CreateMap<ReservationTravel, CreateReservationTravelCommand>().ReverseMap();

            CreateMap<Flight, CreateFlightCommand>().ReverseMap();

            CreateMap<Ticket, GetTicketByIdQueryResult>().ReverseMap();
            CreateMap<Ticket, GetTicketQueryResult>().ReverseMap();
            CreateMap<Ticket, CreateTicketCommand>().ReverseMap();

            CreateMap<Notification, GetNotificationByIdQueryResult>().ReverseMap();
            CreateMap<Notification, GetLast5NotificationQueryResult>().ReverseMap();
            CreateMap<Notification, GetNotificationQueryResult>().ReverseMap();
            CreateMap<Notification, CreateNotificationCommand>().ReverseMap();

            CreateMap<Role, GetRoleByIdQueryResult>().ReverseMap();
            CreateMap<Role, GetRoleQueryResult>().ReverseMap();
            CreateMap<Role, CreateRoleCommand>().ReverseMap();
        }
    }
}
