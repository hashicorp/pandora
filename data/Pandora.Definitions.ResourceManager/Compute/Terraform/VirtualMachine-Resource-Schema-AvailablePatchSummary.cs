using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceAvailablePatchSummarySchema
{

    [Computed]
    [HclName("assessment_activity_id")]
    public string AssessmentActivityId { get; set; }


    [Computed]
    [HclName("critical_and_security_patch_count")]
    public int CriticalAndSecurityPatchCount { get; set; }


    [Computed]
    [HclName("error")]
    public VirtualMachineResourceApiErrorSchema Error { get; set; }


    [Computed]
    [HclName("last_modified_time")]
    public System.DateTime LastModifiedTime { get; set; }


    [Computed]
    [HclName("other_patch_count")]
    public int OtherPatchCount { get; set; }


    [Computed]
    [HclName("reboot_pending")]
    public bool RebootPending { get; set; }


    [Computed]
    [HclName("start_time")]
    public System.DateTime StartTime { get; set; }


    [Computed]
    [HclName("status")]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PatchOperationStatusConstant))]
    public string Status { get; set; }

}
