using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineExtensionPropertiesSchema
{

    [HclName("auto_upgrade_minor_version")]
    [Optional]
    public bool AutoUpgradeMinorVersion { get; set; }


    [HclName("automatic_upgrade_enabled")]
    [Optional]
    public bool AutomaticUpgradeEnabled { get; set; }


    [HclName("force_update_tag")]
    [Optional]
    public string ForceUpdateTag { get; set; }


    [HclName("instance_view")]
    [Optional]
    public VirtualMachineResourceVirtualMachineExtensionInstanceViewSchema InstanceView { get; set; }


    [HclName("provisioning_state")]
    [Optional]
    public string ProvisioningState { get; set; }


    [HclName("publisher")]
    [Optional]
    public string Publisher { get; set; }


    [HclName("suppress_failures")]
    [Optional]
    public bool SuppressFailures { get; set; }


    [HclName("type")]
    [Optional]
    public string Type { get; set; }


    [HclName("type_handler_version")]
    [Optional]
    public string TypeHandlerVersion { get; set; }

}
