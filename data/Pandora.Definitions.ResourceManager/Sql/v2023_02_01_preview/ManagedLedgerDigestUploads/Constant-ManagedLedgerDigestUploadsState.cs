using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedLedgerDigestUploads;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedLedgerDigestUploadsStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
