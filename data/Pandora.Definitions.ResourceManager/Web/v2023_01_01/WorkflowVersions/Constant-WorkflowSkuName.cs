using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WorkflowVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowSkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Premium")]
    Premium,

    [Description("Shared")]
    Shared,

    [Description("Standard")]
    Standard,
}
