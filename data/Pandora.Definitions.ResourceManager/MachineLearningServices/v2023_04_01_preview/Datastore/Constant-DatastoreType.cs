using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Datastore;

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

    [Description("Hdfs")]
    Hdfs,

    [Description("OneLake")]
    OneLake,
}
