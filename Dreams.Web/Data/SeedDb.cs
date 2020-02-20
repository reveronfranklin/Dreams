using Dreams.Web.Data.Entities;
using Dreams.Web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckUnitAsync();
        }

        private async Task CheckUnitAsync()
        {
            UnitService unitService = new UnitService(_dataContext);
            UnitEntity unitEntity = new UnitEntity();

            unitEntity.Descripcion = "Millar";
            unitEntity.Code = "Mill";
            await unitService.UpdateUnit(unitEntity);

            unitEntity.Descripcion = "Formas";
            unitEntity.Code = "Form";
            await unitService.UpdateUnit(unitEntity);

            unitEntity.Descripcion = "Unidad";
            unitEntity.Code = "Und";
            await unitService.UpdateUnit(unitEntity);


            unitEntity.Descripcion = "Kilogramo";
            unitEntity.Code = "Kg";
            await unitService.UpdateUnit(unitEntity);

            
            unitEntity = _dataContext.Units.FirstOrDefault(u => u.Code == "Kg");

            IngredientEntity ingredientEntity = new IngredientEntity();
            IngredientService ingredientService = new IngredientService(_dataContext);


            ingredientEntity.Code = "OPA050BL";
            ingredientEntity.Descripcion = "PAPEL OPACO 50 GR BLANCO";
            ingredientEntity.Cost = 5;
            ingredientEntity.Unit = unitEntity;
            await ingredientService.UpdateIngredient(ingredientEntity);

            ingredientEntity.Code = "OPA060BL";
            ingredientEntity.Descripcion = "PAPEL OPACO 60 GR BLANCO";
            ingredientEntity.Cost = 6;
            ingredientEntity.Unit = unitEntity;
            await ingredientService.UpdateIngredient(ingredientEntity);



        }
    }
}
