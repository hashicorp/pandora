using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DirectoryServiceOptionsConstant
{
    [Description("AADDS")]
    AADDS,

    [Description("AADKERB")]
    AADKERB,

    [Description("AD")]
    AD,

    [Description("None")]
    None,
}
