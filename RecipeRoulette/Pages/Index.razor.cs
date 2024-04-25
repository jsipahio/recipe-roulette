using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Index
    {
        [Inject]
        protected IJSRuntime js {get; set;}
        public class Type 
        { 
            public bool All {get;set;} = false;
            public bool Breakfast {get;set;} = false;
            public bool Lunch {get;set;} = false;
        }
        public class Cuisine 
        {
            public bool All {get;set;} = false;
            public bool American {get;set;} = false;
            public bool Chinese {get;set;} = false;
        }
        public class Diet 
        {
            public bool None { get; set; } = false;
            public bool Vegan { get; set; } = false;
            public bool Dairy { get; set; } = false;
        }
        private int rotationStart = 0;
        public Type type = new Type();
        public Cuisine cuisine = new Cuisine();
        public Diet diet = new Diet();
        private void SpinWheel(){
            Random r = new Random();
            int end = r.Next(720) + rotationStart + 360;
            string startRotation = rotationStart.ToString() + "deg";
            string endRotation = end.ToString() + "deg";
            js.InvokeVoidAsync("spinWheel", startRotation, endRotation);
            rotationStart = end;
            GetRecipe();
        }
        private void GetRecipe()
        {
            Random r = new Random();
            List<RecipeModel> filteredRecipes = _recipeMgr.Recipes;
            filteredRecipes.RemoveAll(x => x.Restrictions.Contains("Breakfast"));
            foreach(var recipe in filteredRecipes){
                Console.WriteLine(recipe.RecipeName);
            }
            r.Next(filteredRecipes.Count);
            recipe = filteredRecipes[0];
        }
        private RecipeManager _recipeMgr;
        private RecipeModel recipe = null;
        public Index()
        {
            _recipeMgr = new RecipeManager();
        }

    }
}