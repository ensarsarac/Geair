using Geair.Application.Mediator.Results.AskedQuestionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.AskedQuestionQueries
{
    public class GetAskedQuestionByIdQuery:IRequest<GetAskedQuestionByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAskedQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
