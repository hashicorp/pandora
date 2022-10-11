using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview.AccessConnector;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
