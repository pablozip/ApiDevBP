using ApiDevBP.Data;
using ApiDevBP.Models;

using AutoMapper;

using MediatR;

namespace ApiDevBP.Application.CreateUser
{
    public class CreateUserHandler(ILogger<CreateUserHandler> logger, IMapper mapper, IDbUsers dbUsers) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = 0;
            try
            {
                logger.LogInformation("Entrando a Create");

                var user = mapper.Map<UserModel>(request);

                result = await dbUsers.Create(user);
                logger.LogInformation("Ejecución completada");

            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "Ocurrió un error al crear el user");
            }

            return result;
        }
    }
}
