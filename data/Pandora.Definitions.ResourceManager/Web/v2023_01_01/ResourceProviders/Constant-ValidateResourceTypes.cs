using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidateResourceTypesConstant
{
    [Description("Microsoft.Web/hostingEnvironments")]
    MicrosoftPointWebHostingEnvironments,

    [Description("ServerFarm")]
    ServerFarm,

    [Description("Site")]
    Site,
}
