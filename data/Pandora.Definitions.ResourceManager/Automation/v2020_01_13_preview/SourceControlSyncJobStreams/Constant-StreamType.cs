using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.SourceControlSyncJobStreams;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StreamTypeConstant
{
    [Description("Error")]
    Error,

    [Description("Output")]
    Output,
}
