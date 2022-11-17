using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AAD.v2022_09_01.DomainServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncScopeConstant
{
    [Description("All")]
    All,

    [Description("CloudOnly")]
    CloudOnly,
}
