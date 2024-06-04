﻿using System.Text.Json;
using System.IO;

using TestRail.Models;


namespace TestRail.Helper
{
    public class JsonHelper
    {
        public T FromJson<T>(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open);
            return JsonSerializer.Deserialize<T>(fs);
        }
        public string ToJson<T>(T objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize);
        }
    }
}
