using ApiDevBP.Data;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.UpdateUser;

public class UpdateUserHandler(ILogger<UpdateUserHandler> logger, IMapper mapper, IDbUsers dbUsers) : IRequestHandler<UpdateUserCommand, bool>
{
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Inicio UpdateUserHandler");

        var result = false;
        try
        {
            result = await dbUsers.Update(request);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Ha ocurrido un error al actualizar un usuario");
        }

        logger.LogInformation("Fin UpdateUserHandler");
        return result;
    }
}
