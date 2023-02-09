using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.DataSet;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSetKindConstant
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

    [Description("SqlDBTable")]
    SqlDBTable,

    [Description("SqlDWTable")]
    SqlDWTable,
}
