using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.FeaturesetVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MaterializationStoreTypeConstant
{
    [Description("None")]
    None,

    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("OnlineAndOffline")]
    OnlineAndOffline,
}
