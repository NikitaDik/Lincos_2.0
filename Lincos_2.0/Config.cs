using System.Text;
using System.Text.Json;

namespace Lincos;

[Serializable]
public class Config {
    private const string ConfigPath = "config.cfg";

    public string[] TargetPaths { get; set; } = [];
    public string DictPath { get; set; } = string.Empty;
    public string ResultPath { get; set; } = string.Empty;
    
    public static Config Load() {
        if (!File.Exists(ConfigPath)) {
            Console.WriteLine("Файл конфига не найден.");
            return new Config();
        }

        string json = File.ReadAllText(ConfigPath);
        Console.WriteLine("Конфиг загружен.");
        return JsonSerializer.Deserialize<Config>(json)!;
    }

    public void UpdateFile() {
        JsonSerializerOptions options = new() {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(ConfigPath, json);
    }

    public Dictionary<string, string> GetTranslationRules() {
        Dictionary<string, string> result = new();

        string dict = File.ReadAllText(DictPath).Replace("\\", null);
        
        foreach (string str in dict.Split('\n', StringSplitOptions.TrimEntries)) {
            string[] split = str.Split("->", StringSplitOptions.TrimEntries);
            if (split.Length < 2) continue;
            
            result.Add(split[0], split[1]);
        }

        return result;
    }
}