using Godot;

// this if is very important, otherwise the plugin can't parse the resource type
#if TOOLS
[Tool]
#endif
[GlobalClass]
public partial class Item : Resource
{
    [Export]
    public string Name { get; set; }

    [Export]
    public string[] Traits { get; set; }
}
