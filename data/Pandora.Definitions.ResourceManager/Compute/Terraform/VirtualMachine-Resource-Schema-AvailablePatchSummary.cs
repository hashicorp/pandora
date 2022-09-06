using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceAvailablePatchSummarySchema
{

    [HclName("assessment_activity_id")]
    [Optional]
    public string AssessmentActivityId { get; set; }


    [HclName("critical_and_security_patch_count")]
    [Optional]
    public int CriticalAndSecurityPatchCount { get; set; }


    [HclName("error")]
    [Optional]
    public VirtualMachineResourceApiErrorSchema Error { get; set; }


    [HclName("last_modified_time")]
    [Optional]
    public System.DateTime LastModifiedTime { get; set; }


    [HclName("other_patch_count")]
    [Optional]
    public int OtherPatchCount { get; set; }


    [HclName("reboot_pending")]
    [Optional]
    public bool RebootPending { get; set; }


    [HclName("start_time")]
    [Optional]
    public System.DateTime StartTime { get; set; }


    [HclName("status")]
    [Optional]
    public string Status { get; set; }

}
