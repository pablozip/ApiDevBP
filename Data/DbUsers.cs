using ApiDevBP.Application.UpdateUser;
using ApiDevBP.Entities;
using ApiDevBP.Models;
using AutoMapper;
using SQLite;
using System.Reflection;

namespace ApiDevBP.Data
{
    public class DbUsers
    {
        private readonly SQLiteConnection _db;
        private readonly IMapper _mapper;

        public DbUsers(IMapper mapper)
        {
            string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "localDb");
            _db = new SQLiteConnection(localDb);
            _db.CreateTable<UserEntity>();

            _mapper = mapper;
        }

        public async Task<int> Create(UserModel user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            var result = _db.Insert(entity);

            return result;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = _db.Query<UserEntity>($"Select * from Users").ToList();

            //var result = _mapper.Map<List<UserModel>>(users);

            var result = users.Select(x => new UserModel()
            {
                Name = x.Name,
                Lastname = x.Lastname
            }).ToList();

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var deleted = _db.Delete<UserEntity>(id);

            return deleted > 0;
        }

        public async Task<bool> Update(UpdateUserCommand user)
        {
            var entity = _db.Query<UserEntity>($"Select * from Users where id = {user.Id}").FirstOrDefault() 
                         ?? throw new Exception("Usuario no encontrado");

            entity.Name = user.Name;
            entity.Lastname= user.LastName;
            var result = _db.Update(entity);

            return result > 0;
        }
    }
}
