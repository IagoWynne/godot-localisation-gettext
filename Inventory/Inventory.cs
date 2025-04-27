using Godot;

public partial class Inventory : Control
{
    private GridContainer ItemsContainer;


        // loading the items from their resource files
        // var sword = GD.Load<Item>("res://Inventory/Items/Sword.tres");
        // var potion = GD.Load<Item>("res://Inventory/Items/Potion.tres");

    public override void _Ready()
    {
        ItemsContainer = GetNode<GridContainer>("%ItemsContainer");


        // using translation names to the add to grid function
        AddItemToGrid(TrN("ITEM_SWORD", "ITEM_SWORDS", 1), 1);
        AddItemToGrid(TrN("ITEM_POTION", "ITEM_POTIONS", 3), 3);
    }

    private void AddItemToGrid(string name, int quantity)
    {
        // the Tr function is a shortcut to TranslationServer.Translate
        ItemsContainer.AddChild(new Label { Text = name });
        ItemsContainer.AddChild(new Label { Text = quantity.ToString() });
    }
}
