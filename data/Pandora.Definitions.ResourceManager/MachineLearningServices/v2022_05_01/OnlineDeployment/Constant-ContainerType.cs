using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerTypeConstant
{
    [Description("InferenceServer")]
    InferenceServer,

    [Description("StorageInitializer")]
    StorageInitializer,
}
