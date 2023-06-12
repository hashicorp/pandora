using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.Pool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InterNodeCommunicationStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
