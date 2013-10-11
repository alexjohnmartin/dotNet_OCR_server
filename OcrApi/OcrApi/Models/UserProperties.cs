using System.Collections.Generic;

namespace OcrApi.Models
{
    public class UserProperties
    {
        public Dictionary<string, string> Vehicle;

        public UserProperties()
        {
            Vehicle = new Dictionary<string, string>();
        }
    }
}