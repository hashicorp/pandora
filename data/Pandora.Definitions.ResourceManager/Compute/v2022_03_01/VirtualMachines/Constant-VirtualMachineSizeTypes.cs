using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineSizeTypesConstant
{
    [Description("Basic_A4")]
    BasicAFour,

    [Description("Basic_A1")]
    BasicAOne,

    [Description("Basic_A3")]
    BasicAThree,

    [Description("Basic_A2")]
    BasicATwo,

    [Description("Basic_A0")]
    BasicAZero,

    [Description("Standard_A8")]
    StandardAEight,

    [Description("Standard_A8_v2")]
    StandardAEightVTwo,

    [Description("Standard_A8m_v2")]
    StandardAEightmVTwo,

    [Description("Standard_A5")]
    StandardAFive,

    [Description("Standard_A4")]
    StandardAFour,

    [Description("Standard_A4_v2")]
    StandardAFourVTwo,

    [Description("Standard_A4m_v2")]
    StandardAFourmVTwo,

    [Description("Standard_A9")]
    StandardANine,

    [Description("Standard_A1")]
    StandardAOne,

    [Description("Standard_A11")]
    StandardAOneOne,

    [Description("Standard_A1_v2")]
    StandardAOneVTwo,

    [Description("Standard_A10")]
    StandardAOneZero,

    [Description("Standard_A7")]
    StandardASeven,

    [Description("Standard_A6")]
    StandardASix,

    [Description("Standard_A3")]
    StandardAThree,

    [Description("Standard_A2")]
    StandardATwo,

    [Description("Standard_A2_v2")]
    StandardATwoVTwo,

    [Description("Standard_A2m_v2")]
    StandardATwomVTwo,

    [Description("Standard_A0")]
    StandardAZero,

    [Description("Standard_B8ms")]
    StandardBEightms,

    [Description("Standard_B4ms")]
    StandardBFourms,

    [Description("Standard_B1ms")]
    StandardBOnems,

    [Description("Standard_B1s")]
    StandardBOnes,

    [Description("Standard_B2ms")]
    StandardBTwoms,

    [Description("Standard_B2s")]
    StandardBTwos,

    [Description("Standard_D8_v3")]
    StandardDEightVThree,

    [Description("Standard_D8s_v3")]
    StandardDEightsVThree,

    [Description("Standard_D5_v2")]
    StandardDFiveVTwo,

    [Description("Standard_D4")]
    StandardDFour,

    [Description("Standard_D4_v3")]
    StandardDFourVThree,

    [Description("Standard_D4_v2")]
    StandardDFourVTwo,

    [Description("Standard_D4s_v3")]
    StandardDFoursVThree,

    [Description("Standard_D1")]
    StandardDOne,

    [Description("Standard_D15_v2")]
    StandardDOneFiveVTwo,

    [Description("Standard_D14")]
    StandardDOneFour,

    [Description("Standard_D14_v2")]
    StandardDOneFourVTwo,

    [Description("Standard_D11")]
    StandardDOneOne,

    [Description("Standard_D11_v2")]
    StandardDOneOneVTwo,

    [Description("Standard_D16_v3")]
    StandardDOneSixVThree,

    [Description("Standard_D16s_v3")]
    StandardDOneSixsVThree,

    [Description("Standard_D13")]
    StandardDOneThree,

    [Description("Standard_D13_v2")]
    StandardDOneThreeVTwo,

    [Description("Standard_D12")]
    StandardDOneTwo,

    [Description("Standard_D12_v2")]
    StandardDOneTwoVTwo,

    [Description("Standard_D1_v2")]
    StandardDOneVTwo,

    [Description("Standard_DS5_v2")]
    StandardDSFiveVTwo,

    [Description("Standard_DS4")]
    StandardDSFour,

    [Description("Standard_DS4_v2")]
    StandardDSFourVTwo,

    [Description("Standard_DS1")]
    StandardDSOne,

    [Description("Standard_DS15_v2")]
    StandardDSOneFiveVTwo,

    [Description("Standard_DS14")]
    StandardDSOneFour,

    [Description("Standard_DS14-8_v2")]
    StandardDSOneFourNegativeEightVTwo,

    [Description("Standard_DS14-4_v2")]
    StandardDSOneFourNegativeFourVTwo,

    [Description("Standard_DS14_v2")]
    StandardDSOneFourVTwo,

    [Description("Standard_DS11")]
    StandardDSOneOne,

    [Description("Standard_DS11_v2")]
    StandardDSOneOneVTwo,

    [Description("Standard_DS13")]
    StandardDSOneThree,

    [Description("Standard_DS13-4_v2")]
    StandardDSOneThreeNegativeFourVTwo,

    [Description("Standard_DS13-2_v2")]
    StandardDSOneThreeNegativeTwoVTwo,

    [Description("Standard_DS13_v2")]
    StandardDSOneThreeVTwo,

    [Description("Standard_DS12")]
    StandardDSOneTwo,

    [Description("Standard_DS12_v2")]
    StandardDSOneTwoVTwo,

    [Description("Standard_DS1_v2")]
    StandardDSOneVTwo,

    [Description("Standard_DS3")]
    StandardDSThree,

    [Description("Standard_DS3_v2")]
    StandardDSThreeVTwo,

    [Description("Standard_DS2")]
    StandardDSTwo,

    [Description("Standard_DS2_v2")]
    StandardDSTwoVTwo,

    [Description("Standard_D64_v3")]
    StandardDSixFourVThree,

    [Description("Standard_D64s_v3")]
    StandardDSixFoursVThree,

    [Description("Standard_D3")]
    StandardDThree,

    [Description("Standard_D32_v3")]
    StandardDThreeTwoVThree,

    [Description("Standard_D32s_v3")]
    StandardDThreeTwosVThree,

    [Description("Standard_D3_v2")]
    StandardDThreeVTwo,

    [Description("Standard_D2")]
    StandardDTwo,

    [Description("Standard_D2_v3")]
    StandardDTwoVThree,

    [Description("Standard_D2_v2")]
    StandardDTwoVTwo,

    [Description("Standard_D2s_v3")]
    StandardDTwosVThree,

    [Description("Standard_E8_v3")]
    StandardEEightVThree,

    [Description("Standard_E8s_v3")]
    StandardEEightsVThree,

    [Description("Standard_E4_v3")]
    StandardEFourVThree,

    [Description("Standard_E4s_v3")]
    StandardEFoursVThree,

    [Description("Standard_E16_v3")]
    StandardEOneSixVThree,

    [Description("Standard_E16s_v3")]
    StandardEOneSixsVThree,

    [Description("Standard_E64-16s_v3")]
    StandardESixFourNegativeOneSixsVThree,

    [Description("Standard_E64-32s_v3")]
    StandardESixFourNegativeThreeTwosVThree,

    [Description("Standard_E64_v3")]
    StandardESixFourVThree,

    [Description("Standard_E64s_v3")]
    StandardESixFoursVThree,

    [Description("Standard_E32-8s_v3")]
    StandardEThreeTwoNegativeEightsVThree,

    [Description("Standard_E32-16_v3")]
    StandardEThreeTwoNegativeOneSixVThree,

    [Description("Standard_E32_v3")]
    StandardEThreeTwoVThree,

    [Description("Standard_E32s_v3")]
    StandardEThreeTwosVThree,

    [Description("Standard_E2_v3")]
    StandardETwoVThree,

    [Description("Standard_E2s_v3")]
    StandardETwosVThree,

    [Description("Standard_F8")]
    StandardFEight,

    [Description("Standard_F8s")]
    StandardFEights,

    [Description("Standard_F8s_v2")]
    StandardFEightsVTwo,

    [Description("Standard_F4")]
    StandardFFour,

    [Description("Standard_F4s")]
    StandardFFours,

    [Description("Standard_F4s_v2")]
    StandardFFoursVTwo,

    [Description("Standard_F1")]
    StandardFOne,

    [Description("Standard_F16")]
    StandardFOneSix,

    [Description("Standard_F16s")]
    StandardFOneSixs,

    [Description("Standard_F16s_v2")]
    StandardFOneSixsVTwo,

    [Description("Standard_F1s")]
    StandardFOnes,

    [Description("Standard_F72s_v2")]
    StandardFSevenTwosVTwo,

    [Description("Standard_F64s_v2")]
    StandardFSixFoursVTwo,

    [Description("Standard_F32s_v2")]
    StandardFThreeTwosVTwo,

    [Description("Standard_F2")]
    StandardFTwo,

    [Description("Standard_F2s")]
    StandardFTwos,

    [Description("Standard_F2s_v2")]
    StandardFTwosVTwo,

    [Description("Standard_G5")]
    StandardGFive,

    [Description("Standard_G4")]
    StandardGFour,

    [Description("Standard_G1")]
    StandardGOne,

    [Description("Standard_GS5")]
    StandardGSFive,

    [Description("Standard_GS5-8")]
    StandardGSFiveNegativeEight,

    [Description("Standard_GS5-16")]
    StandardGSFiveNegativeOneSix,

    [Description("Standard_GS4")]
    StandardGSFour,

    [Description("Standard_GS4-8")]
    StandardGSFourNegativeEight,

    [Description("Standard_GS4-4")]
    StandardGSFourNegativeFour,

    [Description("Standard_GS1")]
    StandardGSOne,

    [Description("Standard_GS3")]
    StandardGSThree,

    [Description("Standard_GS2")]
    StandardGSTwo,

    [Description("Standard_G3")]
    StandardGThree,

    [Description("Standard_G2")]
    StandardGTwo,

    [Description("Standard_H8")]
    StandardHEight,

    [Description("Standard_H8m")]
    StandardHEightm,

    [Description("Standard_H16")]
    StandardHOneSix,

    [Description("Standard_H16m")]
    StandardHOneSixm,

    [Description("Standard_H16mr")]
    StandardHOneSixmr,

    [Description("Standard_H16r")]
    StandardHOneSixr,

    [Description("Standard_L8s")]
    StandardLEights,

    [Description("Standard_L4s")]
    StandardLFours,

    [Description("Standard_L16s")]
    StandardLOneSixs,

    [Description("Standard_L32s")]
    StandardLThreeTwos,

    [Description("Standard_M128-64ms")]
    StandardMOneTwoEightNegativeSixFourms,

    [Description("Standard_M128-32ms")]
    StandardMOneTwoEightNegativeThreeTwoms,

    [Description("Standard_M128ms")]
    StandardMOneTwoEightms,

    [Description("Standard_M128s")]
    StandardMOneTwoEights,

    [Description("Standard_M64-16ms")]
    StandardMSixFourNegativeOneSixms,

    [Description("Standard_M64-32ms")]
    StandardMSixFourNegativeThreeTwoms,

    [Description("Standard_M64ms")]
    StandardMSixFourms,

    [Description("Standard_M64s")]
    StandardMSixFours,

    [Description("Standard_NC12")]
    StandardNCOneTwo,

    [Description("Standard_NC12s_v3")]
    StandardNCOneTwosVThree,

    [Description("Standard_NC12s_v2")]
    StandardNCOneTwosVTwo,

    [Description("Standard_NC6")]
    StandardNCSix,

    [Description("Standard_NC6s_v3")]
    StandardNCSixsVThree,

    [Description("Standard_NC6s_v2")]
    StandardNCSixsVTwo,

    [Description("Standard_NC24")]
    StandardNCTwoFour,

    [Description("Standard_NC24r")]
    StandardNCTwoFourr,

    [Description("Standard_NC24rs_v3")]
    StandardNCTwoFourrsVThree,

    [Description("Standard_NC24rs_v2")]
    StandardNCTwoFourrsVTwo,

    [Description("Standard_NC24s_v3")]
    StandardNCTwoFoursVThree,

    [Description("Standard_NC24s_v2")]
    StandardNCTwoFoursVTwo,

    [Description("Standard_ND12s")]
    StandardNDOneTwos,

    [Description("Standard_ND6s")]
    StandardNDSixs,

    [Description("Standard_ND24rs")]
    StandardNDTwoFourrs,

    [Description("Standard_ND24s")]
    StandardNDTwoFours,

    [Description("Standard_NV12")]
    StandardNVOneTwo,

    [Description("Standard_NV6")]
    StandardNVSix,

    [Description("Standard_NV24")]
    StandardNVTwoFour,
}
