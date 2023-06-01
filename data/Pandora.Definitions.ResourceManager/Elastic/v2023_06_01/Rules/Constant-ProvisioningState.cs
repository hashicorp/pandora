using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.Rules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
