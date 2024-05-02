using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class RecipeGenerator
    {

        private IngredManager _ingredientMgr;
        private AllergyManager _allergyMgr;
        private AllergyModel _allergyMod;
        private IngredientModel _ingredient;
        private RecipeManager _recipeMgr;
        private RecipeModel _recipe;
        
        private int chosenIngredientID;
        private int chosenAllergyID;
        private int count = 3;
        private bool genRecipe = false;

        private List<IngredientModel> _ingredientsList;
        private List<AllergyModel> _allergyList;
        private List<IngredientModel> _chosenIngredientsList;
        private List<AllergyModel> _chosenAllergyList;
        private List<RecipeModel> _recipeList;
        private List<RecipeModel> _matchingRecipesList;
        private List<string> _servingsList;
        private string _selectedServing;
        private List<string> _mealTypes;
        private string _selectedType;

        // constructor that is called when page is loaded
        public RecipeGenerator()
        {
            _ingredientMgr = new IngredManager();
            _ingredient = _ingredientMgr.Ingredients.ElementAt<IngredientModel>(0);

            _ingredientsList = new List<IngredientModel>(_ingredientMgr.Ingredients);
            _chosenIngredientsList = new List<IngredientModel>();

            _recipeMgr = new RecipeManager();
            _recipe = _recipeMgr.Recipes.ElementAt<RecipeModel>(0);
            _recipeList = new List<RecipeModel>(_recipeMgr.Recipes);
            _matchingRecipesList = new List<RecipeModel>();
            _allergyMgr = new AllergyManager();
            _allergyList = new List<AllergyModel>(_allergyMgr.Allergy);

            _servingsList = new List<string>() {"1-2", "2-4", "4-6", "6-8", "8-10", "10+"};
            _mealTypes = _recipeMgr.GetTypes();
        }

        private void OnAllergyChange()
        { 
            //this prints like one behind sooo...
           if(chosenAllergyID != 0)
           {
                _allergyMod = _allergyMgr.Allergy[chosenAllergyID -1];
                _allergyList.Add(_allergyMod);
           }
           StateHasChanged();
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
            if (!string.IsNullOrEmpty(_selectedType))
                temp.RemoveAll(x => x.Type != _selectedType);
            // if (!string.IsNullOrEmpty(_chosenAllergyList[0].Allergy))
            //     temp.RemoveAll(x => x.Restrictions == _chosenAllergyList[0].Allergy);
        }
    }
}