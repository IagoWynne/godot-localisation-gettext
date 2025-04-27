extends Control

func _ready():
	# loading the items from resources
	var sword = load("res://Inventory/Items/Sword.tres")
	var potion = load("res://Inventory/Items/Potion.tres")
	var warhammer = load("res://Inventory/Items/Warhammer.tres")
	
	# using translation keys when adding the items
	add_item(sword, 1)
	add_item(potion, 3)
	add_item(warhammer, 1)

func add_item(item, quantity):
	var name_label = Label.new()
	# tr_n is the function that translates the given string
	name_label.text = tr_n(item.name, "{str}S".format({"str": item.name}), quantity)

	var item_quantity = Label.new()
	item_quantity.text = str(quantity)
	
	# mapping the traits to their translated version
	var traits = Array(item.traits).map(tr)
	var trait_label = Label.new();
	trait_label.text = ", ".join(traits)
	
	$%ItemsContainer.add_child(name_label)
	$%ItemsContainer.add_child(item_quantity)
	$%ItemsContainer.add_child(trait_label)
