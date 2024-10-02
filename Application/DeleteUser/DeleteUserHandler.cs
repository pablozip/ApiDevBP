using ApiDevBP.Data;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.DeleteUser;

public class DeleteUserHandler(ILogger<DeleteUserHandler> logger, IMapper mapper, IDbUsers dbUsers) : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = false;
        try
        {
            logger.LogInformation("Inicio DeleteUserHandler");

            result = await dbUsers.Delete(request.Id);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Ha ocurrido un error al eliminar un usuario");
        }

        logger.LogInformation("Fin DeleteUserHandler");
        return result;
    }
}
