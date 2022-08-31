using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AvailableServiceTiers.Definition(),
        new Clusters.Definition(),
        new DataExport.Definition(),
        new DataSources.Definition(),
        new DeletedWorkspaces.Definition(),
        new IntelligencePacks.Definition(),
        new LinkedServices.Definition(),
        new LinkedStorageAccounts.Definition(),
        new SavedSearches.Definition(),
        new StorageInsights.Definition(),
        new Tables.Definition(),
        new Workspaces.Definition(),
    };
}
