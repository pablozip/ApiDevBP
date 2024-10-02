using ApiDevBP.Data;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.DeleteUser;

public class DeleteUserHandler(IMapper mapper) : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var dbusers = new DbUsers(_mapper);

        var result = await dbusers.Delete(request.Id);

        return result;

    }
}
