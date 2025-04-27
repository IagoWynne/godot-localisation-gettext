using System.Linq;
using Godot;

public partial class Inventory : Control
{
    private GridContainer ItemsContainer;

    public override void _Ready()
    {
        ItemsContainer = GetNode<GridContainer>("%ItemsContainer");

        // loading the items from their resource files
        var sword = GD.Load<Item>("res://Inventory/Items/Sword.tres");
        var potion = GD.Load<Item>("res://Inventory/Items/Potion.tres");
        var warhammer = GD.Load<Item>("res://Inventory/Items/Warhammer.tres");

        // adding the items to the grid
        AddItemToGrid(sword, 1);
        AddItemToGrid(potion, 3);
        AddItemToGrid(warhammer, 1);
    }

    private void AddItemToGrid(Item item, int quantity)
    {
        // the TrN function is a shortcut to TranslationServer.Translate
        ItemsContainer.AddChild(new Label { Text = TrN(item.Name, $"{item.Name}S", quantity) });
        ItemsContainer.AddChild(new Label { Text = quantity.ToString() });

        // mapping the traits to their translated version and joining them into a single string
        ItemsContainer.AddChild(new Label { Text = string.Join(", ", item.Traits.Select(trait => Tr(trait))) });
    }
}
