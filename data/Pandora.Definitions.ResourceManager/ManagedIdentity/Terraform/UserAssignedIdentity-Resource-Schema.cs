using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.Terraform;

public class UserAssignedIdentityResourceSchema
{

    [Computed]
    [Documentation("The id of the app associated with the identity. This is a random generated UUID by MSI.")]
    [HclName("client_id")]
    public string ClientId { get; set; }


    [Documentation("The Azure Region where the resource should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this User Assigned Identity.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Computed]
    [Documentation("The id of the service principal object associated with the created identity.")]
    [HclName("principal_id")]
    public string PrincipalId { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this User Assigned Identity should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Resource.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [Documentation("The id of the tenant which the identity belongs to.")]
    [HclName("tenant_id")]
    public string TenantId { get; set; }

}
