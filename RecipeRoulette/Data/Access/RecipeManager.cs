using RecipeRoulette.Data.Models;
using RecipeRoulette.Data;

namespace RecipeRoulette.Data.Access
{
    public class RecipeManager
    {
        
        private const string FILEPATH = "./Data/JSONData/recipes.json";
        private List<RecipeModel> _recipes;
        public List<RecipeModel> Recipes
        {
            get { return _recipes; }
            private set { _recipes = value; }
        }
        public RecipeManager(){

            _recipes = Utilities.ReadJSON<List<RecipeModel>>(FILEPATH);
        }
    }
}