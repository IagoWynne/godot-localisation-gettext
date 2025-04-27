extends EditorTranslationParserPlugin

func _parse_file(path: String):
	var file = FileAccess.open(path, FileAccess.READ)

	var data = JSON.parse_string(file.get_as_text())
	
	# check if there's a Monsters key at the top level
	if data.has("Monsters"):
		# if so, assume it's the bestiary data and parse it
		# note: this is not foolproof - if there's another json file with monsters
		# as a top level key, then that would also be parsed here, so you need to be
		# very careful
		return parse_bestiary_data(data.Monsters)
	
func parse_bestiary_data(monsters):
	var ret: Array[PackedStringArray] = []
	
	for m in monsters:
		# adding a pluralisation option to the monster name
		ret.append(PackedStringArray([m.Name, "", "{str}S".format({"str": m.Name})]))
		ret.append(PackedStringArray([m.Description]))
		ret.append(PackedStringArray([m.Size]))
		
	return ret
	
func _get_recognized_extensions():
	return ["json"]
