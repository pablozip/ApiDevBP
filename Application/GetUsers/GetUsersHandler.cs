using ApiDevBP.Data;
using ApiDevBP.Models;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.GetUsers
{
    public class GetUsersHandler(IMapper mapper, IDbUsers dbUsers) : IRequestHandler<GetUsersQuery, List<UserModelUpdate>>
    {
        public async Task<List<UserModelUpdate>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {

            var result = await dbUsers.GetAll();
            
            return result;
        }
    }
}
