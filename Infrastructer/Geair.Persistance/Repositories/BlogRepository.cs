using Geair.Application.Interfaces;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly Context _context;

        public BlogRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogByCategoryIdListHome(int id)
        {
            var values = await _context.Blogs.Where(x => x.CategoryId == id).Include(x => x.User).OrderByDescending(i => i.Date).ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogByIdWithUserAndCategoryByOrder(int id)
        {
            var value = await _context.Blogs.Include(x => x.Category).Include(x => x.User).Where(y=>y.BlogId==id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Blog>> GetBlogListHome()
        {
            var values = await _context.Blogs.Include(x => x.User).OrderByDescending(i => i.Date).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogListWithUserAndCategoryByOrder()
        {
            var values = await _context.Blogs.Include(x => x.Category).Include(x => x.User).OrderByDescending(x => x.Date).ToListAsync();
            return values;
        }
    }
}
