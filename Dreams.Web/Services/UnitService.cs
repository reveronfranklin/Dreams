using Dreams.Web.Data;
using Dreams.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Services
{
    public class UnitService
    {
        private readonly DataContext _dataContext;

        public UnitService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task UpdateUnit(UnitEntity unitEntity)
        {

            try
            {
                UnitEntity unitEntitySearch = new UnitEntity();

                unitEntitySearch = _dataContext.Units.FirstOrDefault(u => u.Code == unitEntity.Code);
                if (unitEntitySearch == null)
                {
                    unitEntity.CreateDate = DateTime.UtcNow;
                    _dataContext.Add(unitEntity);
                    await _dataContext.SaveChangesAsync();
                }
                else
                {
                    unitEntitySearch.Descripcion = unitEntity.Descripcion;
                    unitEntitySearch.UpdateDate = DateTime.UtcNow;
                    _dataContext.Update(unitEntitySearch);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                throw;
            }
          

           
             



        }

    }
}
