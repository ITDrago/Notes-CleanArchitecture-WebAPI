using MediatR;
using System;


namespace Notes.Application.Notes.Queires.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
