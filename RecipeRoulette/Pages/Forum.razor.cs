using Microsoft.AspNetCore.Components.Web;
using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Forum
    {
        private bool _hideInputForm = true;
        private bool _showTitleMsg = false;
        private bool _showAuthorMsg = false;
        private ForumPostModel inputModel;
        // description gets discarded as entire forum post is not part of project
        private string description;
        private string searchText;
        // create manager for data
        private ForumPostManager _forumPostMgr;
        private List<ForumPostModel> _filteredPosts;
        public Forum()
        {
            _forumPostMgr = new ForumPostManager();
            inputModel = new ForumPostModel();
            _filteredPosts = new List<ForumPostModel>(_forumPostMgr.ForumPosts);
        }
        private void ToggleInputForm()
        {
            _hideInputForm = !_hideInputForm;
            StateHasChanged();
        }
        private void SavePost()
        {
            if (string.IsNullOrEmpty(inputModel.Title)){
                Console.WriteLine("title is null or empty");
                _showTitleMsg = true;
                return;
            }
            else{
                _showTitleMsg = false;
            }
            if (string.IsNullOrEmpty(inputModel.Author)){
                Console.WriteLine("author is null or empty");
                _showAuthorMsg = true;
                return;
            }
            else{
                _showAuthorMsg = false;
            }
            _forumPostMgr.AddForumPost(inputModel);
        }
        private void FilterPosts(){
            try {
                if (string.IsNullOrEmpty(searchText)){
                    _filteredPosts = new List<ForumPostModel>(_forumPostMgr.ForumPosts);
                    return;
                }
                foreach (var x in _forumPostMgr.ForumPosts){
                    Console.WriteLine(x.Title);
                }
                Console.WriteLine(_forumPostMgr.ForumPosts.Count);
                _filteredPosts = _forumPostMgr.ForumPosts.Where((x) => {
                    Console.WriteLine("hello");
                    return x.Title.ToLower().Contains(searchText.ToLower());}
                    ).ToList();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        private void HandleKeyUp(KeyboardEventArgs e){
            if (e.Key == "Enter"){
                FilterPosts();
            }
        }
    }
}