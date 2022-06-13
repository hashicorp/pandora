using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2022_05_13.ConfidentialLedger;

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
