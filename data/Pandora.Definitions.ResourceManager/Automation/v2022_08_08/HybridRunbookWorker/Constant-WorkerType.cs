using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.HybridRunbookWorker;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkerTypeConstant
{
    [Description("HybridV1")]
    HybridVOne,

    [Description("HybridV2")]
    HybridVTwo,
}
