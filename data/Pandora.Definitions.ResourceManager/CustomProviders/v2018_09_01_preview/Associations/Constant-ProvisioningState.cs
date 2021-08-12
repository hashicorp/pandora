using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.Associations
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProvisioningStateConstant
    {
        [Description("Accepted")]
        Accepted,

        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Running")]
        Running,

        [Description("Succeeded")]
        Succeeded,
    }
}
