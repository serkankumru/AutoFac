using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:BaseRepository<Users>, IUserRepository
    {
        public UserRepository(ECommerceDb context):base(context)
        {  
        }
        public Users Login(Users users)
        {
            Users user = new ECommerceDb().Users.FirstOrDefault(x => x.Name == users.Name && x.Password == users.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }

    public interface IUserRepository : IGenericRepository<Users>
    {
        Users Login(Users users);

    }
}
