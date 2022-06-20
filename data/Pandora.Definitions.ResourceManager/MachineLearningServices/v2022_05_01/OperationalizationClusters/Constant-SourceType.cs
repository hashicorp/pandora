using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceTypeConstant
{
    [Description("Dataset")]
    Dataset,

    [Description("Datastore")]
    Datastore,

    [Description("URI")]
    URI,
}
