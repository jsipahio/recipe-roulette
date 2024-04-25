using Microsoft.VisualBasic;
using RecipeRoulette.Data.Models;
using System.Linq;

namespace RecipeRoulette.Data.Access
{
    public class ForumPostManager
    {
        // path to json data, as long as you put your json in the JSONData
        // folder, you can just change the file name as needed
        private const string FILEPATH = "./Data/JSONData/forumPosts.json";
        private List<ForumPostModel> _posts;
        // list of example models
        public List<ForumPostModel> ForumPosts{ 
            get
            {
                _posts.Sort((a, b) => b.Date.CompareTo(a.Date));
                return _posts;
            } 
            private set
            {
                _posts = value;
            } 
        }
        // constructor that calls utility function ReadJSON to fetch and
        // deserialize json data
        public ForumPostManager()
        {
            try
            {
                ForumPosts = Utilities.ReadJSON<List<ForumPostModel>>(FILEPATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public bool AddForumPost(ForumPostModel model)
        {
            bool success = false;
            try
            {
                model.Date = DateTime.Now;
                model.NumReplies = 0;
                var topID = ForumPosts.Max(x => x.ID);
                int nextID = topID + 1;
                model.ID = nextID;
                ForumPosts.Add(model);
                Utilities.WriteJSON<List<ForumPostModel>>(ForumPosts, FILEPATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return success;
        }
    }
}