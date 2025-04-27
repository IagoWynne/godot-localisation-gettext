@tool
extends EditorPlugin

var json_parser: EditorTranslationParserPlugin

func _enter_tree() -> void:
	# Initialization of the plugin goes here.
	json_parser = load("res://addons/json_localisation/json_translation_parser.gd").new()
	add_translation_parser_plugin(json_parser)
	pass


func _exit_tree() -> void:
	# Clean-up of the plugin goes here.
	remove_translation_parser_plugin(json_parser)
	pass
