using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SourceControlSyncJobStreams;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StreamTypeConstant
{
    [Description("Error")]
    Error,

    [Description("Output")]
    Output,
}
