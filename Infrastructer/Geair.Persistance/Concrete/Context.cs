using Geair.Domain;
using Geair.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Concrete
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> context):base(context)
        {
            
        }
       
        public DbSet<About> Abouts{ get; set; }
        public DbSet<Banner> Banners{ get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<CompanyAddress> CompanyAddresses{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Destination> Destinations{ get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<FlightOptions> FlightOptions{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Newsletter> Newsletters{ get; set; }
        public DbSet<AskedQuestion> AskedQuestions{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Travel> Travels{ get; set; }
    }
}
