using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.PUT;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProjectProvisioningStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Succeeded")]
    Succeeded,
}
