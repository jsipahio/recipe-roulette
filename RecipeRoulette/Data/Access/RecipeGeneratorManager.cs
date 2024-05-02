using RecipeRoulette.Data.Models;
using RecipeRoulette.Data;

namespace RecipeRoulette.Data.Access
{
    public class IngredManager
    {
        
        private const string FILEPATH = "./Data/JSONData/ingredients.json";

        private List<IngredientModel> _ingredients;
        public List<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            private set { _ingredients = value; }
        }
        public IngredManager(){

            _ingredients = Utilities.ReadJSON<List<IngredientModel>>(FILEPATH);
        }
    }

    public class AllergyManager
    {
        
        private const string FILEPATH = "./Data/JSONData/recipegenerator.json";

        private List<AllergyModel> _allergy;
        public List<AllergyModel> Allergy
        {
            get { return _allergy; }
            private set { _allergy = value; }
        }
        public AllergyManager(){

            _allergy = Utilities.ReadJSON<List<AllergyModel>>(FILEPATH);
        }
    }
}