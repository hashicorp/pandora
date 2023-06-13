using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstanceKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerKeyTypeConstant
{
    [Description("AzureKeyVault")]
    AzureKeyVault,

    [Description("ServiceManaged")]
    ServiceManaged,
}
