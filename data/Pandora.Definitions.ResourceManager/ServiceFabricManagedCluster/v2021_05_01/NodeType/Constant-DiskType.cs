using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DiskTypeConstant
    {
        [Description("Premium_LRS")]
        PremiumLRS,

        [Description("Standard_LRS")]
        StandardLRS,

        [Description("StandardSSD_LRS")]
        StandardSSDLRS,
    }
}
