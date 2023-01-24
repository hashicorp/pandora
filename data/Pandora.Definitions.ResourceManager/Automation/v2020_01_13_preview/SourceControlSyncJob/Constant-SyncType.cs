using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.SourceControlSyncJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncTypeConstant
{
    [Description("FullSync")]
    FullSync,

    [Description("PartialSync")]
    PartialSync,
}
