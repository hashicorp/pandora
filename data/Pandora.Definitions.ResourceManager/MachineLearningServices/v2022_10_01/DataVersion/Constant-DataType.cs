using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.DataVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataTypeConstant
{
    [Description("mltable")]
    Mltable,

    [Description("uri_file")]
    UriFile,

    [Description("uri_folder")]
    UriFolder,
}
