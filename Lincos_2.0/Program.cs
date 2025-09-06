namespace Lincos;

public static class Program {
    public static void Main(string[] args) {
        Config config = Config.Load();
        config.UpdateFile();

        TranslationService translation = new(config);
        string translationString = translation.GetTranslationString();
        string translated = translation.Translate(translationString);
        translation.WriteTranslated(translated);

        Console.WriteLine("\nНажмите любую клавишу, чтобы закрыть.");
        Console.ReadKey();
    }
}