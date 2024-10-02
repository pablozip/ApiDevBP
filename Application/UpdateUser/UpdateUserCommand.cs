using ApiDevBP.Models;

using MediatR;

namespace ApiDevBP.Application.UpdateUser;

public class UpdateUserCommand(UserModelUpdate request) : IRequest<bool>
{
    public int Id { get; } = request.Id;
    public string Name { get; } = request.Name;
    public string LastName { get; } = request.Lastname;
}
