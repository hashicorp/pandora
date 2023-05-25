using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ServerKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerKeyTypeConstant
{
    [Description("AzureKeyVault")]
    AzureKeyVault,

    [Description("ServiceManaged")]
    ServiceManaged,
}
