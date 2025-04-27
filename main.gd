extends Node

func _ready():
	var language = ProjectSettings.get_setting("internationalization/locale/test")
	
	# Load here language from the user settings file
	if language == null:
		TranslationServer.set_locale(OS.get_locale_language())
	else:
		TranslationServer.set_locale(language)
