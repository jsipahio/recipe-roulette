using System;
using RecipeRoulette.Data;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Data.Access
{
    public class ExampleManager
    {
        // path to json data, as long as you put your json in the JSONData
        // folder, you can just change the file name as needed
        private const string FILEPATH = "./Data/JSONData/example.json";
        // list of example models
        public List<ExampleModel> Examples { get; }
        // constructor that calls utility function ReadJSON to fetch and
        // deserialize json data
        public ExampleManager()
        {
            try
            {
                Examples = Utilities.ReadJSON<List<ExampleModel>>(FILEPATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}