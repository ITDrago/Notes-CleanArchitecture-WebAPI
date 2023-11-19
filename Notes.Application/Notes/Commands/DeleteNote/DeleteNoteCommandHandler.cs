using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _context;
        public DeleteNoteCommandHandler(INotesDbContext dbContext) => _context = dbContext;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
           var entity = await _context.Notes.FindAsync(new object[] { request.Id}, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
