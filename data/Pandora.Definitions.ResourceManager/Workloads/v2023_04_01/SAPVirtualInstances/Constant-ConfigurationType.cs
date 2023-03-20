using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationTypeConstant
{
    [Description("CreateAndMount")]
    CreateAndMount,

    [Description("Mount")]
    Mount,

    [Description("Skip")]
    Skip,
}
