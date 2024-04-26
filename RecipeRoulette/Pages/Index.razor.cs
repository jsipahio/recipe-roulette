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
        #region Boolean Classes For Checkboxes
        public class Type 
        { 
            public bool All { get; set; } = false;
            public bool Breakfast { get; set; } = false;
            public bool Lunch { get; set; } = false;
            public bool Dinner { get; set; } = false;
            public bool Side { get; set; } = false;
            public bool Dessert { get; set; } = false;
        }
        public class Cuisine 
        {
            public bool All { get; set; } = false;
            public bool American { get; set; } = false;
            public bool Asian { get; set; } = false;
            public bool Indian { get; set; } = false;
            public bool Italian { get; set; } = false;
            public bool Mexican { get; set; } = false;
        }
        public class Diet 
        {
            public bool None { get; set; } = false;
            public bool Vegan { get; set; } = false;
            public bool Dairy { get; set; } = false;
            public bool Nuts { get; set; } = false;
            public bool Gluten { get; set; } = false;
        }
        #endregion
        private int rotationStart = 0;
        public Type type = new Type();
        public Cuisine cuisine = new Cuisine();
        public Diet diet = new Diet();
        private void SpinWheel()
        {
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
            List<RecipeModel> filteredRecipes = new List<RecipeModel>();
            filteredRecipes.AddRange(_recipeMgr.Recipes);
            List<string> restrictions = GetRestrictions();
            foreach(string restr in restrictions){
                Console.WriteLine(restr);
                int x = filteredRecipes.RemoveAll(x => x.Restrictions.Contains(restr));
                Console.WriteLine(x);
            }
            List<string> types = GetTypes();
            foreach(string type in types){
                filteredRecipes.RemoveAll(x => x.Type != type);
            }
            List<string> cuisines = GetCuisines();
            foreach(string cuisine in cuisines) {
                filteredRecipes.RemoveAll(x => x.Cuisine != cuisine);
            }
            foreach(var recipe in filteredRecipes){
                Console.WriteLine(recipe.RecipeName);
            }
            Console.WriteLine(filteredRecipes.Count);
            int index = r.Next(filteredRecipes.Count);
            _filteredRecipes = filteredRecipes;
            System.Threading.Thread.Sleep(2000);
            recipe = filteredRecipes[index];
        }
        private List<string> GetRestrictions()
        {
            List<string> restrictions = new List<string>();
            if(diet.None) return restrictions;
            if(diet.Dairy) {
                restrictions.Add("Dairy");
            }
            if(diet.Nuts){
                restrictions.Add("Nuts");
            }
            if(diet.Vegan) {
                restrictions.Add("NotVegan");
            }
            if(diet.Gluten){
                restrictions.Add("Gluten");
            }
            return restrictions;
        }
        private List<string> GetTypes()
        {
            List<string> types = new List<string>();
            if(type.Breakfast) {
                types.Add("Breakfast");
            }
            if (type.Dessert) {
                types.Add("Dessert");
            }
            if (type.Dinner) {
                types.Add("Dinner");
            }
            if (type.Lunch) {
                types.Add("Lunch");
            }
            if (type.Side) {
                types.Add("Side");
            }
            return types;
        }
        private List<string> GetCuisines(){
            List<string> cuisines = new List<string>();
            if(cuisine.American) {
                cuisines.Add("American");
            }
            if(cuisine.Asian) {
                cuisines.Add("Asian");
            }
            if(cuisine.Indian) {
                cuisines.Add("Indian");
            }
            if(cuisine.Italian) {
                cuisines.Add("Italian");
            }
            if(cuisine.Mexican){
                cuisines.Add("Mexican");
            }
            return cuisines;
        }
        private RecipeManager _recipeMgr;
        private RecipeModel recipe = null;
        private List<RecipeModel> _filteredRecipes = new List<RecipeModel>();
        public Index()
        {
            _recipeMgr = new RecipeManager();
            _filteredRecipes = new List<RecipeModel>(_recipeMgr.Recipes);
        }

    }
}