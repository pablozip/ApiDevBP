using ApiDevBP.Data;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.UpdateUser;

public class UpdateUserHandler(IMapper mapper) : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dbusers = new DbUsers(mapper);

            var result = await dbusers.Update(request);

            return result;
        }
        catch (Exception ex) 
        { 
            //grabar log
        }

        return false;
    }
}
