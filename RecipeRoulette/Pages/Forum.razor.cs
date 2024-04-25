using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Forum
    {
        private bool _hideInputForm = true;
        private ForumPostModel inputModel;
        // description gets discarded as entire forum post is not part of project
        private string description;
        // create manager for data
        private ForumPostManager _forumPostMgr;
        // create a variable to hold the specific data being displayed
        //private ExampleModel _example;
        // constructor that is called when page is loaded
        public Forum()
        {
            // create instance of example manager
            _forumPostMgr = new ForumPostManager();
            // set single example equal to the first (and only) examplemodel object in the list
            //_example = _exampleMgr.Examples.ElementAt<ExampleModel>(0);
            inputModel = new ForumPostModel();
        }
        private void ToggleInputForm()
        {
            _hideInputForm = !_hideInputForm;
            StateHasChanged();
        }
        private void SavePost()
        {
            _forumPostMgr.AddForumPost(inputModel);
        }
    }
}