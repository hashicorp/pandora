using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BlobContainers.Definition(),
        new BlobInventoryPolicies.Definition(),
        new BlobService.Definition(),
        new DeletedAccounts.Definition(),
        new EncryptionScopes.Definition(),
        new FileService.Definition(),
        new FileShares.Definition(),
        new ManagementPolicies.Definition(),
        new ObjectReplicationPolicies.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new QueueService.Definition(),
        new QueueServiceProperties.Definition(),
        new Skus.Definition(),
        new StorageAccounts.Definition(),
        new TableService.Definition(),
        new TableServiceProperties.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
