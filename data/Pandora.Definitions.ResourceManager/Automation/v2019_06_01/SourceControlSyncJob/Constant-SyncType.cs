using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SourceControlSyncJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncTypeConstant
{
    [Description("FullSync")]
    FullSync,

    [Description("PartialSync")]
    PartialSync,
}
