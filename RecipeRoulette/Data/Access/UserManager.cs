using System;
using RecipeRoulette.Data;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Data.Access
{
    public class UserManager
    {
        // path to json data, as long as you put your json in the JSONData
        // folder, you can just change the file name as needed
        private const string FILEPATH = "./Data/JSONData/users.json";
        // list of example models
        public List<UserModel> Users { get; }
        // constructor that calls utility function ReadJSON to fetch and
        // deserialize json data
        public UserManager()
        {
            try
            {
                Users = Utilities.ReadJSON<List<UserModel>>(FILEPATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool FindUser(UserModel user)
        {
            bool success = false;
            try{
                for(int i = 0; i < Users.Count; i++)
                {
                    if(Users[i].Email == user.Email && Users[i].Password == user.Password)
                    {
                        return true;
                    }

                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return false;
        }

        public void AddUser(UserModel user)
        {
            
        }
    }
}