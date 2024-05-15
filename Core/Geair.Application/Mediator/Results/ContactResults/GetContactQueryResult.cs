using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.ContactResults
{
    public class GetContactQueryResult:IRequest<List<GetContactQueryResult>>
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
