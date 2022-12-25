using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static ICrud<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IEmployee<Courier, int, bool> EmployeeDataAccess()
        {
            return new AdminRepo();
        }
        public static ICrud<Cart, int, bool> CartDataAccess()
        {
            return new CartRepo();
        }
        public static ICrud<Courier, int, bool> CourierDataAccess()
        {
            return new CourierRepo();
        }
        public static ICrud<Customer, int, bool> CustomerDataAccess()
        {
            return new CustomerRepo();
        }
        public static ICrud<Item, int, bool> ItemDataAccess()
        {
            return new ItemRepo();
        }
        public static ICrud<Order, int, bool> OrderDataAccess()
        {
            return new OrderRepo();
        }
        public static ICrud<Sale, int, bool> SaleDataAccess()
        {
            return new SaleRepo();
        }
        public static ICrud<User, int, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static ICrud<Token, int, bool> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static ICustomerOrder CustomerOrderAccess()
        {
            return new OrderRepo();
        }

        public static IDeleteCart OrderCartAccess()
        {
            return new CartRepo();
        }
    }
}
