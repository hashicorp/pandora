using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceLastPatchInstallationSummarySchema
{

    [HclName("error")]
    [Optional]
    public VirtualMachineResourceApiErrorSchema Error { get; set; }


    [HclName("excluded_patch_count")]
    [Optional]
    public int ExcludedPatchCount { get; set; }


    [HclName("failed_patch_count")]
    [Optional]
    public int FailedPatchCount { get; set; }


    [HclName("installation_activity_id")]
    [Optional]
    public string InstallationActivityId { get; set; }


    [HclName("installed_patch_count")]
    [Optional]
    public int InstalledPatchCount { get; set; }


    [HclName("last_modified_time")]
    [Optional]
    public System.DateTime LastModifiedTime { get; set; }


    [HclName("maintenance_window_exceeded")]
    [Optional]
    public bool MaintenanceWindowExceeded { get; set; }


    [HclName("not_selected_patch_count")]
    [Optional]
    public int NotSelectedPatchCount { get; set; }


    [HclName("pending_patch_count")]
    [Optional]
    public int PendingPatchCount { get; set; }


    [HclName("start_time")]
    [Optional]
    public System.DateTime StartTime { get; set; }


    [HclName("status")]
    [Optional]
    public string Status { get; set; }

}
