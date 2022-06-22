using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.HybridRunbookWorker;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkerTypeConstant
{
    [Description("HybridV1")]
    HybridVOne,

    [Description("HybridV2")]
    HybridVTwo,
}
