using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Mongorbacs;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum MongoRoleDefinitionTypeConstant
{
    [Description("1")]
    One,

    [Description("0")]
    Zero,
}
