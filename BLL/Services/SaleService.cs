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
    public class SaleService
    {
        public static List<SaleDTO> GetSales()
        {
            var data = DataAccessFactory.SaleDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Sale, SaleDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<SaleDTO>>(data);
        }
        public static SaleDTO GetSale(int id)
        {
            var data = DataAccessFactory.SaleDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Sale, SaleDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<SaleDTO>(data);
        }
        public static bool DeleteSale(int id)
        {
            return DataAccessFactory.SaleDataAccess().Delete(id);
        }
        public static bool AddSale(SaleDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<SaleDTO, Sale>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Sale>(Data);
            return DataAccessFactory.SaleDataAccess().Add(value);
        }
        public static bool SaleUpdate(SaleDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<SaleDTO, Sale>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Sale>(data);
            return DataAccessFactory.SaleDataAccess().Update(value);
        }
    }
}
