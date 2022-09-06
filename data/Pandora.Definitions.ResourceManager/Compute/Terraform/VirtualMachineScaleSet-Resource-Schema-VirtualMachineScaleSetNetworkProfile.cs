using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkProfileSchema
{

    [HclName("health_probe_id")]
    [Optional]
    public VirtualMachineScaleSetResourceApiEntityReferenceSchema HealthProbeId { get; set; }


    [HclName("network_api_version")]
    [Optional]
    public string NetworkApiVersion { get; set; }


    [HclName("network_interface_configuration")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkConfigurationSchema> NetworkInterfaceConfiguration { get; set; }

}
