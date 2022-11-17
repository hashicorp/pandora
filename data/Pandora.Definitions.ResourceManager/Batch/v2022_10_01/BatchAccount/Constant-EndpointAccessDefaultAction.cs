using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.BatchAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointAccessDefaultActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
