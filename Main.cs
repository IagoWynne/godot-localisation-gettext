using Godot;

public partial class Main : Node
{
	public override void _Ready()
	{
		// this grabs the language to use 
		// from Godot's internationalization test settings
		var testLanguage = ProjectSettings
			.GetSetting("internationalization/locale/test")
			.ToString();
		
		if (testLanguage != string.Empty)
		{
			// use the test language
			TranslationServer.SetLocale(testLanguage);
		}
		else
		{
			// use the language from the OS
			TranslationServer.SetLocale(OS.GetLocaleLanguage());
		}
	}
}
