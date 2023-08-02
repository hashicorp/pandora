using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OnlineDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerTypeConstant
{
    [Description("InferenceServer")]
    InferenceServer,

    [Description("ModelDataCollector")]
    ModelDataCollector,

    [Description("StorageInitializer")]
    StorageInitializer,
}
