using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LedgerDigestUploads;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LedgerDigestUploadsStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
