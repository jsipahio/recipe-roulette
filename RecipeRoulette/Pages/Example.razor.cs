using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Example
    {
        // create manager for data
        private ExampleManager _exampleMgr;
        // create a variable to hold the specific data being displayed
        private ExampleModel _example;
        // constructor that is called when page is loaded
        public Example()
        {
            // create instance of example manager
            _exampleMgr = new ExampleManager();
            // set single example equal to the first (and only) examplemodel object in the list
            _example = _exampleMgr.Examples.ElementAt<ExampleModel>(0);
        }
    }
}