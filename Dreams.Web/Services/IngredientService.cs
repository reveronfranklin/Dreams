using Dreams.Web.Data;
using Dreams.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Services
{
    public class IngredientService
    {
        private readonly DataContext _dataContext;

        public IngredientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task UpdateIngredient(IngredientEntity ingredientEntity)
        {
            IngredientEntity ingredientEntitySearch = new IngredientEntity();

            ingredientEntitySearch = _dataContext.Ingredients.FirstOrDefault(u => u.Code == ingredientEntity.Code);
            if (ingredientEntitySearch == null)
            {

                ingredientEntity.CreateDate = DateTime.UtcNow;

                _dataContext.Add(ingredientEntity);
               

            }
            else
            {
                ingredientEntitySearch.Descripcion = ingredientEntity.Descripcion;
                ingredientEntitySearch.Cost = ingredientEntity.Cost;
                ingredientEntitySearch.Unit = ingredientEntity.Unit;
                ingredientEntitySearch.UpdateDate = DateTime.UtcNow;

                _dataContext.Update(ingredientEntitySearch);
               
            }
            await _dataContext.SaveChangesAsync();

        }

    }
}
