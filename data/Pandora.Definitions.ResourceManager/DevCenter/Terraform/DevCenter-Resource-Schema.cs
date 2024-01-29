// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterResourceSchema
{

    [Computed]
    [Documentation("The URI of the Dev Center.")]
    [HclName("dev_center_uri")]
    public string DevCenterUri { get; set; }


    [Documentation("Specifies the Managed Identity which should be assigned to this Dev Center.")]
    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAndUserAssignedIdentity Identity { get; set; }


    [Documentation("The Azure Region where the Dev Center should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this Dev Center.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this Dev Center should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Dev Center.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
