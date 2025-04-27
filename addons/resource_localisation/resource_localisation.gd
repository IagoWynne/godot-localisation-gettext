@tool
extends EditorPlugin

var resource_parser: EditorTranslationParserPlugin

func _enter_tree() -> void:
	# Initialization of the plugin goes here.
	resource_parser = load("res://addons/resource_localisation/resource_translation_parser.gd").new()
	add_translation_parser_plugin(resource_parser)
	pass


func _exit_tree() -> void:
	# Clean-up of the plugin goes here.
	remove_translation_parser_plugin(resource_parser)
	pass
