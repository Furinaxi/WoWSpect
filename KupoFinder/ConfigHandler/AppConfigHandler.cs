using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KupoFinder.ConfigHandler;

public static class AppConfigHandler
{
    private const string ConfigFileName = "KupoFinder.settings.json";

    public static void CheckConfigFile()
    {
        string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            ConfigFileName);
            
        if (!File.Exists(configFilePath))
        {
            using(FileStream fs = new(configFilePath, FileMode.OpenOrCreate))
            {
                StringBuilder sb = new();
                StringWriter sw = new(sb);
                    
                using(JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                        
                    writer.WriteStartObject();
                    writer.WritePropertyName("apiKey");
                    writer.WriteValue("");
                    writer.WriteEndObject();
                }
            }
        }
    }
        
    public static bool TryGetApiKey(out string key)
    {
        string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            ConfigFileName);
            
        using FileStream fs = new(configFilePath, FileMode.Open);
        using StreamReader sr = new(fs);
            
        string json = sr.ReadToEnd();
            
        JObject obj = JObject.Parse(json);
            
        if (obj.TryGetValue("apiKey", out JToken token) && token.Value<string>() != string.Empty)
        {
            key = token.Value<string>();
            return true;
        }
            
        key = string.Empty;
        return false;
    }
        
    public static void SetApiKey(string key)
    {
        string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            ConfigFileName);

        using FileStream fs = new(configFilePath, FileMode.Open);
        using StreamReader sr = new(fs);
            
        string json = sr.ReadToEnd();
            
        JObject obj = JObject.Parse(json);
            
        obj["apiKey"] = key;
    }
}