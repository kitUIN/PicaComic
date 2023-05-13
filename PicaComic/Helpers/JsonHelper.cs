namespace PicaComic.Helpers
{
    public static class JsonHelper
    {
        public static string ToJson(this Dictionary<string, string> obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public static string ToJson(this PicaResponse obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(obj, options);
        }
        public static string ToJson(this PicaResponse obj, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(obj, options);
        }
        public static T ToObj<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
