namespace Geair.WebUI.Areas.Admin.Dtos.AskedQuestionDtos
{
    public class UpdateAskedQuestionDto
    {
        public int AskedQuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RowNumber { get; set; }
    }
}
