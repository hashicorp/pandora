using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01.Grouping
{
    public class ExampleResourceId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/blah";
    }
}