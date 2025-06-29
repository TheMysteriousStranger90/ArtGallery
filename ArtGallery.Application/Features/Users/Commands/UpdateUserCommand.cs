﻿using MediatR;

namespace ArtGallery.Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}