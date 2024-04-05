namespace RecipeRoulette.Data.Models
{
    // basic model class that mathces key names and data types of JSON data
    // (when in doubt use string as the data type)
    public class ExampleModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string[] Attributes { get; set; }
    }
}
