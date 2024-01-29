// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesClusterTrustedAccessRoleBindingResourceSchema
{

    [Documentation("Specifies the Kubernetes Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist.")]
    [ForceNew]
    [HclName("kubernetes_cluster_id")]
    [Required]
    public string KubernetesClusterId { get; set; }


    [Documentation("Specifies the name of this Kubernetes Cluster Trusted Access Role Binding.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("A list of roles to bind, each item is a resource type qualified role name.")]
    [HclName("roles")]
    [Required]
    public List<string> Roles { get; set; }


    [Documentation("The ARM resource ID of source resource that trusted access is configured for.")]
    [ForceNew]
    [HclName("source_resource_id")]
    [Required]
    public string SourceResourceId { get; set; }

}
