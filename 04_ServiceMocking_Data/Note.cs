using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _04_ServiceMocking_Data
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
