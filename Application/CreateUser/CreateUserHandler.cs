using ApiDevBP.Data;
using ApiDevBP.Entities;
using ApiDevBP.Models;

using AutoMapper;
using MediatR;
using SQLite;
using System.Reflection;

namespace ApiDevBP.Application.CreateUser
{
    public class CreateUserHandler(IMapper mapper ) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            //string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "localDb");
            //_db = new SQLiteConnection(localDb);
            //_db.CreateTable<UserEntity>();
            var dbusers = new DbUsers(mapper);

            
            var user = mapper.Map<UserModel> (request);

            var result = await dbusers.Create(user);

            return result;
        }
    }
}
