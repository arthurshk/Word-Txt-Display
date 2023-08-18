using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
	public class Word
	{
        [Key]
        public int Id { get; set; }
		public string Value { get; set; }
	}
}
