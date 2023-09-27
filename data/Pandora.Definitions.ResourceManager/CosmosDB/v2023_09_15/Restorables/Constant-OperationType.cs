using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationTypeConstant
{
    [Description("Create")]
    Create,

    [Description("Delete")]
    Delete,

    [Description("Replace")]
    Replace,

    [Description("SystemOperation")]
    SystemOperation,
}
