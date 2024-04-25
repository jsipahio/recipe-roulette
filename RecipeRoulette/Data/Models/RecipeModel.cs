namespace RecipeRoulette.Data.Models
{
    public class RecipeModel
    {
        public int ID { get; set;}
        public string RecipeName { get; set;}
        public string Type { get; set;}
        public string Cuisine { get; set;}
        public List<string> Restrictions { get; set;}
        public List<string> Ingredients {get; set;}
        // "ID": 1,
        // "RecipeName" : "Pancakes",
        // "Type": "Breakfast",
        // "Cuisine": "American",
        // "Restrictions": ["Dairy"],
        // "Ingredients": ["eggs", "milk", "flour"]
    }
}