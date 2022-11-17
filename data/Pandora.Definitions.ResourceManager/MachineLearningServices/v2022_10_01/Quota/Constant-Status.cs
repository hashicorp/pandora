using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Quota;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Failure")]
    Failure,

    [Description("InvalidQuotaBelowClusterMinimum")]
    InvalidQuotaBelowClusterMinimum,

    [Description("InvalidQuotaExceedsSubscriptionLimit")]
    InvalidQuotaExceedsSubscriptionLimit,

    [Description("InvalidVMFamilyName")]
    InvalidVMFamilyName,

    [Description("OperationNotEnabledForRegion")]
    OperationNotEnabledForRegion,

    [Description("OperationNotSupportedForSku")]
    OperationNotSupportedForSku,

    [Description("Success")]
    Success,

    [Description("Undefined")]
    Undefined,
}
