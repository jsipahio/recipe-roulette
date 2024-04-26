using System;
using System.Text.Json;

namespace RecipeRoulette.Data
{
    /// <summary>
    /// Utilities Class
    /// Provides utility functions that may be useful in a variety of circumstances
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Reads JSON data from file at path filePath
        /// Returns data deserialized to whatever type is passed for T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T ReadJSON<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Converts object or list of objects
        /// Creates or overwrites file at filePath with new JSON data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool WriteJSON<T>(T obj, string filePath)
        {
            bool success = false;
            try
            {
                string json = JsonSerializer.Serialize<T>(obj);
                System.Console.WriteLine(json);
                File.WriteAllText(filePath, json);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return success;
        }
    }
}