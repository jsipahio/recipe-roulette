using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class MealPlanner
    {
        private RecipeManager _recipeMgr;
        private RecipeModel recipe = null;
        private List<RecipeModel> _filteredRecipes = new List<RecipeModel>();

        public MealPlanner()
        {
            _recipeMgr = new RecipeManager();
            _filteredRecipes = new List<RecipeModel>(_recipeMgr.Recipes);
        }
    }
}