using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DataLakeStoreAccountStatusConstant
    {
        [Description("Canceled")]
        Canceled,

        [Description("Creating")]
        Creating,

        [Description("Deleted")]
        Deleted,

        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Patching")]
        Patching,

        [Description("Resuming")]
        Resuming,

        [Description("Running")]
        Running,

        [Description("Succeeded")]
        Succeeded,

        [Description("Suspending")]
        Suspending,

        [Description("Undeleting")]
        Undeleting,
    }
}
