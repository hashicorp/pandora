using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

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
