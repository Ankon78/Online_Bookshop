using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService
    {
        public static List<RoleDTO> Get()
        {
            var dbdata = DataAccessFactory.RoleDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<RoleDTO>>(dbdata);
            return data;
        }
        public static RoleDTO Get(int id)
        {
            var dbdata = DataAccessFactory.RoleDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<RoleDTO>(dbdata);
            return data;
        }
        public static RoleDTO Add(RoleDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Role>(dto);
            var result = DataAccessFactory.RoleDataAccess().Add(data);
            return mapper.Map<RoleDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RoleDataAccess().Delete(id);
        }
    }
}
