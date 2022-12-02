using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var user = mapper.Map<List<UserDTO>>(data);
            return user;
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var User = mapper.Map<UserDTO>(data);
            return User;
        }
        public static bool Delete(int id)
        {
            
            var data = DataAccessFactory.UserDataAccess().Delete(id);
            return data;
        }
        public static UserDTO Add(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            var result = DataAccessFactory.UserDataAccess().Add(data);
            return mapper.Map<UserDTO>(result);
        }
        /*public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }*/
        public static void Update(User dto)
        {
            /*return DataAccessFactory.UserDataAccess().Update(dto);*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(dto);
            DataAccessFactory.UserDataAccess().Update(data);
        }
        
    }
}
