#if TOOLS
using Godot;

[Tool]
public partial class JsonLocalisationPlugin : EditorPlugin
{
    // creating a new instance of our parser
    JsonTranslationParser JsonParser = new JsonTranslationParser();

    public override void _EnterTree()
    {
        // initialise the plugin
        // here we add our parser
        AddTranslationParserPlugin(JsonParser);
    }

    public override void _ExitTree()
    {
        // cleaning up the plugin
        if (IsInstanceValid(JsonParser))
        {
            RemoveTranslationParserPlugin(JsonParser);
            JsonParser = null;
        }

        base._ExitTree();
    }
}
#endif
