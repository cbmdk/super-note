﻿using Optional;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.Domain.Notes;

public interface INotesRepository : IRepository<Note>
{
    Task<Option<Note>> GetByIdAsync(NoteId noteId);
}