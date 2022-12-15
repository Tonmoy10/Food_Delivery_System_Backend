using AutoMapper;
using BLL.DTO;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemService
    {
        public static List<ItemDTO> GetItems()
        {
            var data = DataAccessFactory.ItemDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Item, ItemDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ItemDTO>>(data);
        }
        public static ItemDTO GetItem(int id)
        {
            var data = DataAccessFactory.ItemDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Item, ItemDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ItemDTO>(data);
        }
        public static bool DeleteItem(int id)
        {
            return DataAccessFactory.ItemDataAccess().Delete(id);
        }
        public static bool AddItem(ItemDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<ItemDTO, Item>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Item>(Data);
            return DataAccessFactory.ItemDataAccess().Add(value);
        }
        public static bool ItemUpdate(ItemDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<ItemDTO, Item>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Item>(data);
            return DataAccessFactory.ItemDataAccess().Update(value);
        }
    }
}
