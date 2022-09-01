using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.ApplicationGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGroupPolicyTypeConstant
{
    [Description("ThrottlingPolicy")]
    ThrottlingPolicy,
}
