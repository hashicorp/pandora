using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_11_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Initializing")]
    Initializing,

    [Description("InternallyReady")]
    InternallyReady,

    [Description("Online")]
    Online,

    [Description("Uninitialized")]
    Uninitialized,
}
