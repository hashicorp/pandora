using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.HybridRunbookWorker;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkerTypeConstant
{
    [Description("HybridV1")]
    HybridVOne,

    [Description("HybridV2")]
    HybridVTwo,
}
