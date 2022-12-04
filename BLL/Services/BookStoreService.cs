
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
    public class BookStoreService
    {
        public static List<BookStoreDTO> Get()
        {
            var dbdata = DataAccessFactory.BookStoreDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookStore, BookStoreDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookStoreDTO>>(dbdata);
            return data;
        }
        public static BookStoreDTO Get(int id)
        {
            var dbdata = DataAccessFactory.BookStoreDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookStore, BookStoreDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BookStoreDTO>(dbdata);
            return data;
        }
        public static BookStoreDTO Add(BookStoreDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookStore, BookStoreDTO>();
                cfg.CreateMap<BookStoreDTO, BookStore>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BookStore>(dto);
            var result = DataAccessFactory.BookStoreDataAccess().Add(data);
            return mapper.Map<BookStoreDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BookStoreDataAccess().Delete(id);
        }
    }
}
