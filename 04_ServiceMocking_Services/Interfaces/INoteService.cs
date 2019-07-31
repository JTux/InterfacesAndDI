using _04_ServiceMocking_Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ServiceMocking_Services.Interfaces
{
    public interface INoteService
    {
        bool CreateNote(NoteCreate model);
        IEnumerable<NoteListItem> GetNotes();
        NoteDetail GetNoteById(int noteId);
        bool UpdateNote(NoteEdit model);
        bool DeleteNote(int noteId);
    }
}
