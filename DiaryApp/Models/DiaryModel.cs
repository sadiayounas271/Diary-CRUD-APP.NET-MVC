using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
	public class DiaryModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="Please Enter a Title")]
	//	[StringLength(100, MinimumLength=3, ErrorMessage ="Titles must be between 3 and 100 chars")]
		public string Title { get; set; } = string.Empty;
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Content must be between 3 and 100 chars")]
		public string Content { get; set; } = string.Empty;
		[Required]
		public DateTime Created { get; set; } = DateTime.Now;

	}
}
