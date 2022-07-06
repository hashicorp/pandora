using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureSkuNameConstant
{
    [Description("Dev(No SLA)_Standard_D11_v2")]
    DevNoSLAStandardDOneOneVTwo,

    [Description("Dev(No SLA)_Standard_E2a_v4")]
    DevNoSLAStandardETwoaVFour,

    [Description("Standard_D14_v2")]
    StandardDOneFourVTwo,

    [Description("Standard_D11_v2")]
    StandardDOneOneVTwo,

    [Description("Standard_D13_v2")]
    StandardDOneThreeVTwo,

    [Description("Standard_D12_v2")]
    StandardDOneTwoVTwo,

    [Description("Standard_DS14_v2+4TB_PS")]
    StandardDSOneFourVTwoPositiveFourTBPS,

    [Description("Standard_DS14_v2+3TB_PS")]
    StandardDSOneFourVTwoPositiveThreeTBPS,

    [Description("Standard_DS13_v2+1TB_PS")]
    StandardDSOneThreeVTwoPositiveOneTBPS,

    [Description("Standard_DS13_v2+2TB_PS")]
    StandardDSOneThreeVTwoPositiveTwoTBPS,

    [Description("Standard_E80ids_v4")]
    StandardEEightZeroidsVFour,

    [Description("Standard_E8a_v4")]
    StandardEEightaVFour,

    [Description("Standard_E8as_v4+1TB_PS")]
    StandardEEightasVFourPositiveOneTBPS,

    [Description("Standard_E8as_v4+2TB_PS")]
    StandardEEightasVFourPositiveTwoTBPS,

    [Description("Standard_E4a_v4")]
    StandardEFouraVFour,

    [Description("Standard_E16a_v4")]
    StandardEOneSixaVFour,

    [Description("Standard_E16as_v4+4TB_PS")]
    StandardEOneSixasVFourPositiveFourTBPS,

    [Description("Standard_E16as_v4+3TB_PS")]
    StandardEOneSixasVFourPositiveThreeTBPS,

    [Description("Standard_E64i_v3")]
    StandardESixFouriVThree,

    [Description("Standard_E2a_v4")]
    StandardETwoaVFour,

    [Description("Standard_L8s")]
    StandardLEights,

    [Description("Standard_L8s_v2")]
    StandardLEightsVTwo,

    [Description("Standard_L4s")]
    StandardLFours,

    [Description("Standard_L16s")]
    StandardLOneSixs,

    [Description("Standard_L16s_v2")]
    StandardLOneSixsVTwo,
}
