using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AccountFilters.Definition(),
        new Accounts.Definition(),
        new AssetsAndAssetFilters.Definition(),
        new ContentKeyPolicies.Definition(),
        new Encodings.Definition(),
        new LiveEvents.Definition(),
        new LiveOutputs.Definition(),
        new StreamingEndpoints.Definition(),
        new StreamingPoliciesAndStreamingLocators.Definition(),
    };
}
