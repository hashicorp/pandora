using Pandora.Definitions.Operations;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules
{
    internal class NamespacesListIPFilterRules : ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override object NestedItemType()
        {
            return new IpFilterRule();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override string? UriSuffix()
        {
            return "/ipfilterrules";
        }
    }
}
