using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_05_01.ManagementLocks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LockLevelConstant
{
    [Description("CanNotDelete")]
    CanNotDelete,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("ReadOnly")]
    ReadOnly,
}
