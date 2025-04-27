#if TOOLS
using Godot;
using Godot.Collections;

[Tool]
public partial class ResourceTranslationParser : EditorTranslationParserPlugin
{
    public override Array<string[]> _ParseFile(string path)
    {
        // load the resource
        var resource = GD.Load(path);

        // check if it's an Item
        if (resource is Item item)
        {
            // if so, parse it as an item
            return ParseItemResource(item);
        }

        return base._ParseFile(path);
    }

    // you will need to parse each resource type separately
    public Array<string[]> ParseItemResource(Item item)
    {
        var ret = new Array<string[]>();

        // add the item name translation key and its plural
        // since I'm English, I've just used a very simple pluralisation
        ret.Add([item.Name, "", $"{item.Name}S"]);

        // add all the trait translation keys
        foreach (var trait in item.Traits)
        {
            ret.Add([trait]);
        }

        return ret;
    }

    // this function tells the editor that we want to be able to parse .tres files
    public override string[] _GetRecognizedExtensions()
    {
        return ["tres"];
    }
}
#endif
