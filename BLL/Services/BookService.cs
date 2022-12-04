using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService
    {
        public static List<BookDTO> Get()
        {
            var dbdata = DataAccessFactory.BookDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookDTO>>(dbdata);
            return data;
        }
        public static BookDTO Get(int id)
        {
            var dbdata = DataAccessFactory.BookDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BookDTO>(dbdata);
            return data;
        }
        public static BookDTO Add(BookDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Book>(dto);
            var result = DataAccessFactory.BookDataAccess().Add(data);
            return mapper.Map<BookDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BookDataAccess().Delete(id);
        }
    }
}
