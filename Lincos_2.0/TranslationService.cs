using System.Text;

namespace Lincos;

public class TranslationService {
    private Config _config;
    
    public TranslationService(Config config) {
        _config = config;
    }

    public string GetTranslationString() {
        StringBuilder result = new();

        foreach (string filePath in _config.TargetPaths) {
            if (!File.Exists(filePath)) continue;

            result.Append(File.ReadAllText(filePath) + '\n');
        }

        return result.ToString();
    }

    public string Translate(string str) {
        foreach (KeyValuePair<string, string> rule in _config.GetTranslationRules()) {
            str = str.Replace(rule.Key, rule.Value);
        }

        return str;
    }

    public void WriteTranslated(string str) {
        File.WriteAllText(_config.ResultPath, str);
        Console.WriteLine("Переведённый текст записан в файл.");
    }
}