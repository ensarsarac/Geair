using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.DTOLayer.BlogDtos;
public class ResultBlogHomeDto
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime Date { get; set; }
    public string UserName { get; set; }
}
