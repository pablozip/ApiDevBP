using MediatR;

namespace ApiDevBP.Application.DeleteUser;

public class DeleteUserCommand (int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
