using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LedgerRoleNameConstant
{
    [Description("Administrator")]
    Administrator,

    [Description("Contributor")]
    Contributor,

    [Description("Reader")]
    Reader,
}
