#if TOOLS
using System.Text.Json;
using Godot;
using Godot.Collections;

[Tool]
public partial class JsonTranslationParser : EditorTranslationParserPlugin
{
    public override Array<string[]> _ParseFile(string path)
    {
        var ret = new Array<string[]>();

        var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        var json = file.GetAsText();

        if (DeserializeMonsterData(json, ret))
        {
            return ret;
        }

        return ret;
    }

    private bool DeserializeMonsterData(string json, Array<string[]> ret)
    {
        // I don't really like doing it this way - trying to deserialise into each type we need
        // and moving onto the next type if there's an exception feels like very bad code
        // but since it's just for a tool rather than game code, it will do.
        try
        {
            // Note: this will throw an exception if it doesn't deserialise into the given type
            var data = JsonSerializer.Deserialize<Bestiary>(json);

            foreach (var monster in data.Monsters)
            {
                // adding the plural version for each monster too
                ret.Add([monster.Name, "", $"{monster.Name}S"]);
                ret.Add([monster.Size]);
                ret.Add([monster.Description]);
            }
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public override string[] _GetRecognizedExtensions()
    {
        return ["json"];
    }
}
#endif