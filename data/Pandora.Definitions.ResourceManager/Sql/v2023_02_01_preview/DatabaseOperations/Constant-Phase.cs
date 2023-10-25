using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PhaseConstant
{
    [Description("Catchup")]
    Catchup,

    [Description("Copying")]
    Copying,

    [Description("CutoverInProgress")]
    CutoverInProgress,

    [Description("WaitingForCutover")]
    WaitingForCutover,
}
