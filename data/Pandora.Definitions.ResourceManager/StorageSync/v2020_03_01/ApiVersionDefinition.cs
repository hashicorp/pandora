using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Actions.Definition(),
        new BackupRestore.Definition(),
        new ChangeDetection.Definition(),
        new CloudEndpointResource.Definition(),
        new OperationStatus.Definition(),
        new PrivateEndpointConnectionResource.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new RegisteredServerResource.Definition(),
        new ServerEndpointResource.Definition(),
        new StorageSyncService.Definition(),
        new StorageSyncServicesResource.Definition(),
        new SyncGroupResource.Definition(),
        new WorkflowResource.Definition(),
    };
}
