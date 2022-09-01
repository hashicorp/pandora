using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SearchServiceStatusConstant
{
    [Description("degraded")]
    Degraded,

    [Description("deleting")]
    Deleting,

    [Description("disabled")]
    Disabled,

    [Description("error")]
    Error,

    [Description("provisioning")]
    Provisioning,

    [Description("running")]
    Running,
}
