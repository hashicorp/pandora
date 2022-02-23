using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DirectoryServiceOptionsConstant
{
    [Description("AADDS")]
    AADDS,

    [Description("AD")]
    AD,

    [Description("None")]
    None,
}
