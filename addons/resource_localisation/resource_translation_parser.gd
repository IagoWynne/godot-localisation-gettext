@tool
extends EditorTranslationParserPlugin

func _parse_file(path):
	var res = load(path)
	
	var item = load("res://Inventory/Items/item.gd").new();
	
	if res.get_class() == item.get_class():
		return parse_item_resouce(res)
	
	return []

func parse_item_resouce(item):
	var ret: Array[PackedStringArray] = []
	ret.append(PackedStringArray([item.name, "", "{str}S".format({"str": item.name})]))
	
	for t in item.traits:
		ret.append(PackedStringArray([t]))
	
	return ret

func _get_recognized_extensions():
	return ["tres"]
