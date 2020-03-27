using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace IOTCore
{
    public class Deserializer
    {
        public static List<string> InvalidJson;

        public static IList<T> DeserializedToList<T>(string jsonString)
        {
            InvalidJson = null;
            var array = JArray.Parse(jsonString);
            IList<T> objectList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    objectList.Add(item.ToObject<T>());
                }
                catch (Exception e)
                {
                    InvalidJson = InvalidJson ?? new List<string>();
                    InvalidJson.Add(item.ToString());
                }
            }

            return objectList;
        }
        

    }
}