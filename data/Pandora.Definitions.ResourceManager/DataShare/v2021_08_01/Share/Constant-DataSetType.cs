using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSetTypeConstant
{
    [Description("AdlsGen1File")]
    AdlsGenOneFile,

    [Description("AdlsGen1Folder")]
    AdlsGenOneFolder,

    [Description("AdlsGen2File")]
    AdlsGenTwoFile,

    [Description("AdlsGen2FileSystem")]
    AdlsGenTwoFileSystem,

    [Description("AdlsGen2Folder")]
    AdlsGenTwoFolder,

    [Description("Blob")]
    Blob,

    [Description("BlobFolder")]
    BlobFolder,

    [Description("Container")]
    Container,

    [Description("KustoCluster")]
    KustoCluster,

    [Description("KustoDatabase")]
    KustoDatabase,

    [Description("KustoTable")]
    KustoTable,

    [Description("SqlDBTable")]
    SqlDBTable,

    [Description("SqlDWTable")]
    SqlDWTable,

    [Description("SynapseWorkspaceSqlPoolTable")]
    SynapseWorkspaceSqlPoolTable,
}
