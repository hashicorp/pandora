using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("EP2_128_GPU1_Mx1_W")]
    EPTwoOneTwoEightGPUOneMxOneW,

    [Description("EP2_128_1T4_Mx1_W")]
    EPTwoOneTwoEightOneTFourMxOneW,

    [Description("EP2_64_Mx1_W")]
    EPTwoSixFourMxOneW,

    [Description("EP2_64_1VPU_W")]
    EPTwoSixFourOneVPUW,

    [Description("EP2_256_GPU2_Mx1")]
    EPTwoTwoFiveSixGPUTwoMxOne,

    [Description("EP2_256_2T4_W")]
    EPTwoTwoFiveSixTwoTFourW,

    [Description("Edge")]
    Edge,

    [Description("EdgeMR_Mini")]
    EdgeMRMini,

    [Description("EdgeMR_TCP")]
    EdgeMRTCP,

    [Description("EdgeP_Base")]
    EdgePBase,

    [Description("EdgeP_High")]
    EdgePHigh,

    [Description("EdgePR_Base")]
    EdgePRBase,

    [Description("EdgePR_Base_UPS")]
    EdgePRBaseUPS,

    [Description("GPU")]
    GPU,

    [Description("Gateway")]
    Gateway,

    [Description("Management")]
    Management,

    [Description("RCA_Large")]
    RCALarge,

    [Description("RCA_Small")]
    RCASmall,

    [Description("RDC")]
    RDC,

    [Description("TCA_Large")]
    TCALarge,

    [Description("TCA_Small")]
    TCASmall,

    [Description("TDC")]
    TDC,

    [Description("TEA_4Node_Heater")]
    TEAFourNodeHeater,

    [Description("TEA_4Node_UPS_Heater")]
    TEAFourNodeUPSHeater,

    [Description("TEA_1Node")]
    TEAOneNode,

    [Description("TEA_1Node_Heater")]
    TEAOneNodeHeater,

    [Description("TEA_1Node_UPS")]
    TEAOneNodeUPS,

    [Description("TEA_1Node_UPS_Heater")]
    TEAOneNodeUPSHeater,

    [Description("TMA")]
    TMA,
}
