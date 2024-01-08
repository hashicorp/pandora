using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.Restores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetDiskNetworkAccessOptionConstant
{
    [Description("EnablePrivateAccessForAllDisks")]
    EnablePrivateAccessForAllDisks,

    [Description("EnablePublicAccessForAllDisks")]
    EnablePublicAccessForAllDisks,

    [Description("SameAsOnSourceDisks")]
    SameAsOnSourceDisks,
}
