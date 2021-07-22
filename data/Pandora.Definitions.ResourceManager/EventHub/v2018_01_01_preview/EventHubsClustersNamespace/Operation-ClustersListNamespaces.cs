using Pandora.Definitions.Operations;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace
{
    internal class ClustersListNamespaces : ListOperation
    {
        public override object NestedItemType()
        {
            return new EHNamespaceIdContainer();
        }

        public override ResourceID? ResourceId()
        {
            return new ClusterId();
        }

        public override string? UriSuffix()
        {
            return "/namespaces";
        }
    }
}
