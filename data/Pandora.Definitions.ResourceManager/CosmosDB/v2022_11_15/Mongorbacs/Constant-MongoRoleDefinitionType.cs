using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.Mongorbacs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MongoRoleDefinitionTypeConstant
{
    [Description("BuiltInRole")]
    BuiltInRole,

    [Description("CustomRole")]
    CustomRole,
}
