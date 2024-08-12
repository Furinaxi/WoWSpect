using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KupoFinder.ConfigHandler;

public static class AppConfigHandler
{
    private const string ConfigFileName = "KupoFinder.settings.json";
    private const string FolderName = "KupoFinder";

    public static void CheckConfigFile()
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string kupoFinderFolderPath = Path.Combine(appDataPath, FolderName);
        
        if (!Directory.Exists(kupoFinderFolderPath))
        {
            Directory.CreateDirectory(kupoFinderFolderPath);
        }

        string configFilePath = Path.Combine(kupoFinderFolderPath, ConfigFileName);

        if (!File.Exists(configFilePath))
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

            using (FileStream fs = new(configFilePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter file = new(fs))
                {
                    file.Write(sb.ToString());
                }
            }
        }
    }
        
    public static bool TryGetApiKey(out string key)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string kupoFinderFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(kupoFinderFolderPath, ConfigFileName);
            
        string json = File.ReadAllText(configFilePath);
        JObject obj = JObject.Parse(json);
            
        if (obj.TryGetValue("apiKey", out JToken? token) && token.Value<string>() != string.Empty)
        {
            key = token.Value<string>();
            return true;
        }
            
        key = string.Empty;
        return false;
    }
        
    public static void SetApiKey(string key)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string kupoFinderFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(kupoFinderFolderPath, ConfigFileName);

        JObject obj;
        
        using (FileStream fs = new(configFilePath, FileMode.Open, FileAccess.Read))
        {
            string json;

            using (StreamReader sr = new(fs))
            {
                json = sr.ReadToEnd();
            }

            obj = JObject.Parse(json);

            obj["apiKey"] = key;
        }

        using (FileStream fs = new(configFilePath, FileMode.Truncate, FileAccess.Write))
        {
            using (StreamWriter sw = new(fs))
            {
                sw.Write(obj.ToString());
            }
        }
    }
}