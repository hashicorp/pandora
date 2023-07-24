using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupRestoreOperationTypeConstant
{
    [Description("Clone")]
    Clone,

    [Description("CloudFS")]
    CloudFS,

    [Description("Default")]
    Default,

    [Description("Relocation")]
    Relocation,

    [Description("Snapshot")]
    Snapshot,
}
