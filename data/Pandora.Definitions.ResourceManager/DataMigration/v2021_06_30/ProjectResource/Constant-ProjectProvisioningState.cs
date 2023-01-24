using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.ProjectResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProjectProvisioningStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Succeeded")]
    Succeeded,
}
