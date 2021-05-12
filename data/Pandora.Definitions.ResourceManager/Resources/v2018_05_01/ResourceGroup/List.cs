using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    public class List : ListOperation
    {
        public override object NestedItemType()
        {
            return new GetResourceGroup();
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override string? UriSuffix()
        {
            return "/resourceGroups";
        }

        public override object? OptionsObject()
        {
            return new ListOptions();
        }

        public class ListOptions
        {
            [QueryStringName("$top")]
            public int Top { get; set; }
        }
    }

    public class SubscriptionId : ResourceID
    {
        public string ID()
        {
            return "/subscriptions/{subscriptionId}";
        }
    }
}