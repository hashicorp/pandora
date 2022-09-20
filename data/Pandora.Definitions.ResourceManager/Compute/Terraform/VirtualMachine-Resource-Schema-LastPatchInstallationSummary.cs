using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceLastPatchInstallationSummarySchema
{

    [HclName("error")]
    public VirtualMachineResourceApiErrorSchema Error { get; set; }


    [HclName("excluded_patch_count")]
    public int ExcludedPatchCount { get; set; }


    [HclName("failed_patch_count")]
    public int FailedPatchCount { get; set; }


    [HclName("installation_activity_id")]
    public string InstallationActivityId { get; set; }


    [HclName("installed_patch_count")]
    public int InstalledPatchCount { get; set; }


    [HclName("last_modified_time")]
    public System.DateTime LastModifiedTime { get; set; }


    [HclName("maintenance_window_exceeded")]
    public bool MaintenanceWindowExceeded { get; set; }


    [HclName("not_selected_patch_count")]
    public int NotSelectedPatchCount { get; set; }


    [HclName("pending_patch_count")]
    public int PendingPatchCount { get; set; }


    [HclName("start_time")]
    public System.DateTime StartTime { get; set; }


    [HclName("status")]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PatchOperationStatusConstant))]
    public string Status { get; set; }

}
