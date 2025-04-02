using System.ComponentModel.DataAnnotations;
using test.Data;

namespace test.Entities
{
	public class BaseEntity : IEntity
	{
		[Key]
		public int Id { get; set; }
		public bool IsActive { get; set; } = true;
		public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
