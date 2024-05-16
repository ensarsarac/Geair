using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class AskedQuestion
    {
        public int AskedQuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RowNumber { get; set; }
    }
}