using ApiDevBP.Data;
using ApiDevBP.Models;
using AutoMapper;
using MediatR;

namespace ApiDevBP.Application.GetUsers
{
    public class GetUsersHandler(IMapper mapper) : IRequestHandler<GetUsersQuery, List<UserModel>>
    {
        public async Task<List<UserModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var dbusers = new DbUsers(mapper);
            var result = await dbusers.GetAll();

            return result;
        }
    }
}
