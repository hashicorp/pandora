using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.V2WorkspaceConnectionResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionCategoryConstant
{
    [Description("AzureDataLakeGen2")]
    AzureDataLakeGenTwo,

    [Description("AzureMySqlDb")]
    AzureMySqlDb,

    [Description("AzurePostgresDb")]
    AzurePostgresDb,

    [Description("AzureSqlDb")]
    AzureSqlDb,

    [Description("AzureSynapseAnalytics")]
    AzureSynapseAnalytics,

    [Description("ContainerRegistry")]
    ContainerRegistry,

    [Description("FeatureStore")]
    FeatureStore,

    [Description("Git")]
    Git,

    [Description("PythonFeed")]
    PythonFeed,

    [Description("Redis")]
    Redis,

    [Description("S3")]
    SThree,

    [Description("Snowflake")]
    Snowflake,
}
