using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Module;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ModuleProvisioningStateConstant
{
    [Description("ActivitiesStored")]
    ActivitiesStored,

    [Description("Cancelled")]
    Cancelled,

    [Description("ConnectionTypeImported")]
    ConnectionTypeImported,

    [Description("ContentDownloaded")]
    ContentDownloaded,

    [Description("ContentRetrieved")]
    ContentRetrieved,

    [Description("ContentStored")]
    ContentStored,

    [Description("ContentValidated")]
    ContentValidated,

    [Description("Created")]
    Created,

    [Description("Creating")]
    Creating,

    [Description("Failed")]
    Failed,

    [Description("ModuleDataStored")]
    ModuleDataStored,

    [Description("ModuleImportRunbookComplete")]
    ModuleImportRunbookComplete,

    [Description("RunningImportModuleRunbook")]
    RunningImportModuleRunbook,

    [Description("StartingImportModuleRunbook")]
    StartingImportModuleRunbook,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
