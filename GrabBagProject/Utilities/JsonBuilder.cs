using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GrabBagProject.Utilities
{
    public class JsonBuilder
    {
        public static string ToJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T? FromJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
