using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesFleetManagerResourceFleetHubProfileSchema
{

    [HclName("dns_prefix")]
    [Required]
    public string DnsPrefix { get; set; }


    [Computed]
    [HclName("fqdn")]
    public string Fqdn { get; set; }


    [Computed]
    [HclName("kubernetes_version")]
    public string KubernetesVersion { get; set; }

}
