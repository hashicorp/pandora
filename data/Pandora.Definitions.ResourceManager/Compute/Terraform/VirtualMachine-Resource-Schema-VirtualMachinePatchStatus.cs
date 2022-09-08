using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePatchStatusSchema
{

    [HclName("available_patch_summary")]
    [Optional]
    public VirtualMachineResourceAvailablePatchSummarySchema AvailablePatchSummary { get; set; }


    [HclName("configuration_statuse")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> ConfigurationStatuse { get; set; }


    [HclName("last_patch_installation_summary")]
    [Optional]
    public VirtualMachineResourceLastPatchInstallationSummarySchema LastPatchInstallationSummary { get; set; }

}
