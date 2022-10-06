using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.Terraform;

public class UserAssignedIdentityResourceSchema
{

    [Computed]
    [Documentation("The ID of the app associated with the Identity.")]
    [HclName("client_id")]
    public string ClientId { get; set; }


    [Documentation("The Azure Region where the User Assigned Identity should exist.")]
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
    [Documentation("The ID of the Service Principal object associated with the created Identity.")]
    [HclName("principal_id")]
    public string PrincipalId { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this User Assigned Identity should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the User Assigned Identity.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [Documentation("The ID of the Tenant which the Identity belongs to.")]
    [HclName("tenant_id")]
    public string TenantId { get; set; }

}
