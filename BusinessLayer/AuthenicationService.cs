using BusinessLayer.Model;
using DBLayer.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthenicationService
    {
        public UserModel Login(UserModel user)
        {
            UserModel loginUserInfromation = null;
            using (BlogDBEntities dbContext = new BlogDBEntities())
            {
                loginUserInfromation = (from m in dbContext.Users.Where(p => p.Email == user.Email && p.Password == user.Password)
                                        select new UserModel()
                                        {
                                            Id = m.PK_User_Id,
                                            Name = m.Name,
                                            Email = m.Email
                                        }).FirstOrDefault();

            }
            return loginUserInfromation;
        }
    }
}
