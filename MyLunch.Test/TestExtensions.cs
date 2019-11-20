using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MyLunch.Test
{
    public static class TestExtensions
    {
        public static void PrettyPrint(this object o, System.IO.TextWriter writer)
        {
            writer.WriteLine(JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            }));
        }
    }
}
