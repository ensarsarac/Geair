﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.CategoryResults
{
    public class GetCategoryQueryResult:IRequest<List<GetCategoryQueryResult>>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
