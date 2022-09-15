using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceMaintenanceRedeployStatusSchema
{

    [HclName("customer_initiated_maintenance_allowed")]
    [Optional]
    public bool CustomerInitiatedMaintenanceAllowed { get; set; }


    [HclName("last_operation_message")]
    [Optional]
    public string LastOperationMessage { get; set; }


    [HclName("last_operation_result_code")]
    [Optional]
    public string LastOperationResultCode { get; set; }


    [HclName("maintenance_window_end_time")]
    [Optional]
    public System.DateTime MaintenanceWindowEndTime { get; set; }


    [HclName("maintenance_window_start_time")]
    [Optional]
    public System.DateTime MaintenanceWindowStartTime { get; set; }


    [HclName("pre_maintenance_window_end_time")]
    [Optional]
    public System.DateTime PreMaintenanceWindowEndTime { get; set; }


    [HclName("pre_maintenance_window_start_time")]
    [Optional]
    public System.DateTime PreMaintenanceWindowStartTime { get; set; }

}
