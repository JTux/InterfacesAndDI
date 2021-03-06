﻿using System;
using System.ComponentModel.DataAnnotations;

namespace _04_ServiceMocking_Models.NoteModels
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{NoteId}] {Title}";
    }
}
