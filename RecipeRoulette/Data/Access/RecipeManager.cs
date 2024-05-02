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
        public List<string> GetTypes(){
            try{
                HashSet<string> output = new HashSet<string>();
                foreach(var recipe in _recipes) {
                    output.Add(recipe.Type);
                }
                List<string> retval = new List<string>(output.ToList());
                return retval;
            }
            catch(Exception ex) {
                System.Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public RecipeManager(){

            _recipes = Utilities.ReadJSON<List<RecipeModel>>(FILEPATH);
        }
    }
}