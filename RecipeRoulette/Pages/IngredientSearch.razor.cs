using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class IngredientSearch
    {
        private IngredientManager _ingredientMgr;
        private IngredientModel _ingredient;
        private RecipeManager _recipeMgr;
        private RecipeModel _recipe;
        
        private int chosenIngredientID;
        private int count = 3;
        private bool genRecipe = false;

        private List<IngredientModel> _ingredientsList;
        private List<IngredientModel> _chosenIngredientsList;
        private List<RecipeModel> _recipeList;
        private List<RecipeModel> _matchingRecipesList;


        // constructor that is called when page is loaded
        public IngredientSearch()
        {
            _ingredientMgr = new IngredientManager();
            _ingredient = _ingredientMgr.Ingredients.ElementAt<IngredientModel>(0);

            _ingredientsList = new List<IngredientModel>(_ingredientMgr.Ingredients);
            _chosenIngredientsList = new List<IngredientModel>();

            _recipeMgr = new RecipeManager();
            _recipe = _recipeMgr.Recipes.ElementAt<RecipeModel>(0);
            _recipeList = new List<RecipeModel>(_recipeMgr.Recipes);
            _matchingRecipesList = new List<RecipeModel>();
        }

        private void OnIngredientChange()
        { 
            //this prints like one behind sooo...
           if(chosenIngredientID != 0)
           {
                _ingredient = _ingredientMgr.Ingredients[chosenIngredientID -1];
                _chosenIngredientsList.Add(_ingredient);
                if(count >= 1)
                    count--;
           }
           StateHasChanged();
        }

        private void GetRecipe()
        {
            List<RecipeModel> temp = new List<RecipeModel>();
            foreach(IngredientModel ingredient in _chosenIngredientsList)
            {
                temp = _recipeList.FindAll(x => x.Ingredients.Contains(ingredient.Ingredient));
                
                foreach(RecipeModel recipe in temp)
                {
                    if(!_matchingRecipesList.Contains(recipe))
                    {
                        _matchingRecipesList.Add(recipe);
                    }
                }
                genRecipe = true;
            }
        }
    }
    
}
