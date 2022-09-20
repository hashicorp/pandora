using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceLastPatchInstallationSummarySchema
{

    [Computed]
    [HclName("error")]
    public VirtualMachineResourceApiErrorSchema Error { get; set; }


    [Computed]
    [HclName("excluded_patch_count")]
    public int ExcludedPatchCount { get; set; }


    [Computed]
    [HclName("failed_patch_count")]
    public int FailedPatchCount { get; set; }


    [Computed]
    [HclName("installation_activity_id")]
    public string InstallationActivityId { get; set; }


    [Computed]
    [HclName("installed_patch_count")]
    public int InstalledPatchCount { get; set; }


    [Computed]
    [HclName("last_modified_time")]
    public System.DateTime LastModifiedTime { get; set; }


    [Computed]
    [HclName("maintenance_window_exceeded")]
    public bool MaintenanceWindowExceeded { get; set; }


    [Computed]
    [HclName("not_selected_patch_count")]
    public int NotSelectedPatchCount { get; set; }


    [Computed]
    [HclName("pending_patch_count")]
    public int PendingPatchCount { get; set; }


    [Computed]
    [HclName("start_time")]
    public System.DateTime StartTime { get; set; }


    [Computed]
    [HclName("status")]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PatchOperationStatusConstant))]
    public string Status { get; set; }

}
