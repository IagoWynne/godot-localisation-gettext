#if TOOLS
using Godot;

namespace Plugins
{
    [Tool]
    public partial class ResourceLocalisationPlugin : EditorPlugin
    {
		// creating a new instance of our parser
        ResourceTranslationParser ResourceParser = new ResourceTranslationParser();

        public override void _EnterTree()
        {
			// initialise the plugin
			// here we add our parser
            AddTranslationParserPlugin(ResourceParser);
        }

        public override void _ExitTree()
        {
			// cleaning up the plugin
            if (IsInstanceValid(ResourceParser))
            {
                RemoveTranslationParserPlugin(ResourceParser);
                ResourceParser = null;
            }

            base._ExitTree();
        }
    }
}

#endif
