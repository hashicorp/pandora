using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DiagnosticSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessLevelConstant
{
    [Description("FullAccess")]
    FullAccess,

    [Description("None")]
    None,

    [Description("ReadOnly")]
    ReadOnly,

    [Description("ReadWrite")]
    ReadWrite,
}
