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
    public class CourierService
    {
        public static List<CourierDTO> GetCouriers()
        {
            var data = DataAccessFactory.CourierDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Courier, CourierDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CourierDTO>>(data);
        }
        public static CourierDTO GetCourier(int id)
        {
            var data = DataAccessFactory.CourierDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Courier, CourierDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CourierDTO>(data);
        }
        public static bool DeleteCourier(int id)
        {
            return DataAccessFactory.CourierDataAccess().Delete(id);
        }
        public static bool AddCourier(CourierDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CourierDTO, Courier>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Courier>(Data);
            return DataAccessFactory.CourierDataAccess().Add(value);
        }
        public static bool CourierUpdate(CourierDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CourierDTO, Courier>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Courier>(data);
            return DataAccessFactory.CourierDataAccess().Update(value);
        }
    }
}
