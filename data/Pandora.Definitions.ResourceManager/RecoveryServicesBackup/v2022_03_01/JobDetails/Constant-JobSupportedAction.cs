using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.JobDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobSupportedActionConstant
{
    [Description("Cancellable")]
    Cancellable,

    [Description("Invalid")]
    Invalid,

    [Description("Retriable")]
    Retriable,
}
