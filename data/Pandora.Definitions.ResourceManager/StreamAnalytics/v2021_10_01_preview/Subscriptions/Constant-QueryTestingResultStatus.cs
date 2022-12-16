using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryTestingResultStatusConstant
{
    [Description("CompilerError")]
    CompilerError,

    [Description("RuntimeError")]
    RuntimeError,

    [Description("Started")]
    Started,

    [Description("Success")]
    Success,

    [Description("Timeout")]
    Timeout,

    [Description("UnknownError")]
    UnknownError,
}
