using System;
using System.ComponentModel.DataAnnotations;

namespace _04_ServiceMocking_Models.NoteModels
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Title { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Important")]
        public bool IsStarred { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => Title;
    }
}
