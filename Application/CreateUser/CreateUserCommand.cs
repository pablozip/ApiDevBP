using ApiDevBP.Models;
using MediatR;

namespace ApiDevBP.Application.CreateUser;

public class CreateUserCommand(UserModel request) : IRequest<int>
{
    public string Name { get; } = request.Name;
    public string Lastname { get; } = request.Lastname;
}
