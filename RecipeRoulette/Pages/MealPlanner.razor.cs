using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class MealPlanner
    {
        private RecipeManager _recipeMgr;
        private RecipeModel recipe = null;
        private List<RecipeModel> _filteredRecipes = new List<RecipeModel>();
        private bool _hideHelpForm = true;
        private string[] meals = new string[31];
        private string selectedRecipe = "pancakes";
        private void UpdateMeal(int day){
            meals[day - 1] = selectedRecipe;
        }
        private void UpdateSelectedRecipe(string recipe){
            selectedRecipe = recipe;
        }
        public MealPlanner()
        {
            _recipeMgr = new RecipeManager();
            _filteredRecipes = new List<RecipeModel>(_recipeMgr.Recipes);
            for(int i = 0; i < 31; i++){
                meals[i] = string.Empty;
            }
        }
        private void ToggleHelpForm()
        {
            _hideHelpForm = !_hideHelpForm;
            StateHasChanged();
        }
    }
}