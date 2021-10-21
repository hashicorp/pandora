using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-05-01-preview";
        public string Name => "VideoAnalyzer";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AccessPoliciesCreateOrUpdateOperation(),
            new AccessPoliciesDeleteOperation(),
            new AccessPoliciesGetOperation(),
            new AccessPoliciesListOperation(),
            new AccessPoliciesUpdateOperation(),
            new EdgeModulesCreateOrUpdateOperation(),
            new EdgeModulesDeleteOperation(),
            new EdgeModulesGetOperation(),
            new EdgeModulesListOperation(),
            new EdgeModulesListProvisioningTokenOperation(),
            new LocationsCheckNameAvailabilityOperation(),
            new VideoAnalyzersCreateOrUpdateOperation(),
            new VideoAnalyzersDeleteOperation(),
            new VideoAnalyzersGetOperation(),
            new VideoAnalyzersListOperation(),
            new VideoAnalyzersListBySubscriptionOperation(),
            new VideoAnalyzersSyncStorageKeysOperation(),
            new VideoAnalyzersUpdateOperation(),
            new VideosCreateOrUpdateOperation(),
            new VideosDeleteOperation(),
            new VideosGetOperation(),
            new VideosListOperation(),
            new VideosListStreamingTokenOperation(),
            new VideosUpdateOperation(),
        };
    }
}
