using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.SourceControlSyncJobStreams;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StreamTypeConstant
{
    [Description("Error")]
    Error,

    [Description("Output")]
    Output,
}
