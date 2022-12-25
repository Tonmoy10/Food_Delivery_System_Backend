using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerOrder
    {
        List<Order> CustomerOrder(int id);
    }
}
