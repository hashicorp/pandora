using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobOutputTypeConstant
{
    [Description("custom_model")]
    CustomModel,

    [Description("mlflow_model")]
    MlflowModel,

    [Description("mltable")]
    Mltable,

    [Description("triton_model")]
    TritonModel,

    [Description("uri_file")]
    UriFile,

    [Description("uri_folder")]
    UriFolder,
}
