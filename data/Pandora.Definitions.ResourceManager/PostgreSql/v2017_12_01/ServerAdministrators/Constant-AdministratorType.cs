using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.ServerAdministrators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdministratorTypeConstant
{
    [Description("ActiveDirectory")]
    ActiveDirectory,
}
