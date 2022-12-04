using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Role, int, Role> RoleDataAccess()
        {
            return new RoleRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IRepo<Book, int, Book> BookDataAccess()
        {
            return new BookRepo();
        }
        public static IRepo<BookStore, int, BookStore> BookStoreDataAccess()
        {
            return new BookStoreRepo(); 
        }
        public static IRepo<Buy, int, Buy> BuyDataAccess()
        {
            return new BuyRepo();
        }
        public static IRepo<Language, int, Language> LanguageDataAccess()
        {
            return new LanguageRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }

        
    }
}
