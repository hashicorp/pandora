using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatastoreTypeConstant
{
    [Description("AzureBlob")]
    AzureBlob,

    [Description("AzureDataLakeGen1")]
    AzureDataLakeGenOne,

    [Description("AzureDataLakeGen2")]
    AzureDataLakeGenTwo,

    [Description("AzureFile")]
    AzureFile,
}
