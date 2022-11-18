using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComputeTypeConstant
{
    [Description("AKS")]
    AKS,

    [Description("AmlCompute")]
    AmlCompute,

    [Description("ComputeInstance")]
    ComputeInstance,

    [Description("DataFactory")]
    DataFactory,

    [Description("DataLakeAnalytics")]
    DataLakeAnalytics,

    [Description("Databricks")]
    Databricks,

    [Description("HDInsight")]
    HDInsight,

    [Description("Kubernetes")]
    Kubernetes,

    [Description("SynapseSpark")]
    SynapseSpark,

    [Description("VirtualMachine")]
    VirtualMachine,
}
