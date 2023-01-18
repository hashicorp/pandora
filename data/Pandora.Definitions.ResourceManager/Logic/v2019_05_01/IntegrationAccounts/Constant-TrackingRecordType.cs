using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrackingRecordTypeConstant
{
    [Description("AS2MDN")]
    ASTwoMDN,

    [Description("AS2Message")]
    ASTwoMessage,

    [Description("Custom")]
    Custom,

    [Description("EdifactFunctionalGroup")]
    EdifactFunctionalGroup,

    [Description("EdifactFunctionalGroupAcknowledgment")]
    EdifactFunctionalGroupAcknowledgment,

    [Description("EdifactInterchange")]
    EdifactInterchange,

    [Description("EdifactInterchangeAcknowledgment")]
    EdifactInterchangeAcknowledgment,

    [Description("EdifactTransactionSet")]
    EdifactTransactionSet,

    [Description("EdifactTransactionSetAcknowledgment")]
    EdifactTransactionSetAcknowledgment,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("X12FunctionalGroup")]
    XOneTwoFunctionalGroup,

    [Description("X12FunctionalGroupAcknowledgment")]
    XOneTwoFunctionalGroupAcknowledgment,

    [Description("X12Interchange")]
    XOneTwoInterchange,

    [Description("X12InterchangeAcknowledgment")]
    XOneTwoInterchangeAcknowledgment,

    [Description("X12TransactionSet")]
    XOneTwoTransactionSet,

    [Description("X12TransactionSetAcknowledgment")]
    XOneTwoTransactionSetAcknowledgment,
}
