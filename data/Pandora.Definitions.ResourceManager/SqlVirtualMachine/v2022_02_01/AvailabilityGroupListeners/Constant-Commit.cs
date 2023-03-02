using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommitConstant
{
    [Description("Asynchronous_Commit")]
    AsynchronousCommit,

    [Description("Synchronous_Commit")]
    SynchronousCommit,
}
