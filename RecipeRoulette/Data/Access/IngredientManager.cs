using RecipeRoulette.Data.Models;
using RecipeRoulette.Data;

namespace RecipeRoulette.Data.Access
{
    public class IngredientManager
    {
        
        private const string FILEPATH = "./Data/JSONData/ingredients.json";

        private List<IngredientModel> _ingredients;
        public List<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            private set { _ingredients = value; }
        }
        public IngredientManager(){

            _ingredients = Utilities.ReadJSON<List<IngredientModel>>(FILEPATH);
        }
    }
}