using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.AzureADAdministrators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdministratorTypeConstant
{
    [Description("ActiveDirectory")]
    ActiveDirectory,
}
