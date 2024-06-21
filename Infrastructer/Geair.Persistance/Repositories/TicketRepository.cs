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
	public class TicketRepository : ITicketRepository
	{

		private readonly Context _context;

		public TicketRepository(Context context)
		{
			_context = context;
		}

        public async Task<List<Ticket>> GetTicketListWithInclude()
		{
			var values = await _context.Tickets.Include(x=>x.Flight).ThenInclude(x=>x.ArrivalAirport).Include(y=>y.Flight).ThenInclude(x=>x.DepartureAirport).Include(x=>x.User).OrderByDescending(x=>x.TicketId).ToListAsync();
			return values;
		}
	}
}
