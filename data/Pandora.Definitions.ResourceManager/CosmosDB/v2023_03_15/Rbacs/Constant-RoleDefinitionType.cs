using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.Rbacs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleDefinitionTypeConstant
{
    [Description("BuiltInRole")]
    BuiltInRole,

    [Description("CustomRole")]
    CustomRole,
}
