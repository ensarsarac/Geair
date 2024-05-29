using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.UserResults
{
    public class GetUserImageAndNameQueryResult
    {
        public string ImageUrl { get; set; }
        public string NameSurname { get; set; }
    }
}
