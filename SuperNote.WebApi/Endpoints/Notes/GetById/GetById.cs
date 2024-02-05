﻿using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Queries.GetNoteById;
using SuperNote.WebApi.Extensions;

namespace SuperNote.WebApi.Endpoints.Notes.GetById;

public class GetById(IMediator mediator) : Endpoint<GetNoteByIdRequest, NoteDto>
{
    public override void Configure()
    {
        AllowAnonymous();
        
        Get(ApiRoutes.Notes.GetById);
        
        Summary(s =>
        {
            s.Summary = "Retrieve a note by its ID.";
        });
    }

    public override async Task HandleAsync(GetNoteByIdRequest req, CancellationToken ct)
    {
        var note = await mediator.Send(new GetNoteByIdQuery(req.NoteId), ct);

        if (note.IsSuccess)
        {
            await SendOkAsync(note.Value, ct);
        }
        else
        {
            await this.SendErrorResponse(note, ct);
        }
    }
}