using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheFirst.Models
{
	public class Category
	{
		[Key] // for sql, to say that ID is a key, and an Identity column
		// Properties
		public int Id { get; set; }

		[Required] // Makes name a required property
		public string Name { get; set; }

		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100!")]
		public int DisplayOrder { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;

	}
}

