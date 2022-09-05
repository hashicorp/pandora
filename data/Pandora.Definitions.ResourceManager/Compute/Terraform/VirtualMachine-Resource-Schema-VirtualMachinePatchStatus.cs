using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePatchStatusSchema
{

    [HclName("available_patch_summary")]
    [Optional]
    public List<VirtualMachineResourceAvailablePatchSummarySchema> AvailablePatchSummary { get; set; }


    [HclName("configuration_statuse")]
    [Optional]
    public List<List<VirtualMachineResourceInstanceViewStatusSchema>> ConfigurationStatuse { get; set; }


    [HclName("last_patch_installation_summary")]
    [Optional]
    public List<VirtualMachineResourceLastPatchInstallationSummarySchema> LastPatchInstallationSummary { get; set; }

}
