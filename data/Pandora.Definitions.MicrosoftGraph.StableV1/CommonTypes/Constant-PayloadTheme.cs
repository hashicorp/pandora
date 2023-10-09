// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PayloadThemeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Other")]
    @other,

    [Description("AccountActivation")]
    @accountActivation,

    [Description("AccountVerification")]
    @accountVerification,

    [Description("Billing")]
    @billing,

    [Description("CleanUpMail")]
    @cleanUpMail,

    [Description("Controversial")]
    @controversial,

    [Description("DocumentReceived")]
    @documentReceived,

    [Description("Expense")]
    @expense,

    [Description("Fax")]
    @fax,

    [Description("FinanceReport")]
    @financeReport,

    [Description("IncomingMessages")]
    @incomingMessages,

    [Description("Invoice")]
    @invoice,

    [Description("ItemReceived")]
    @itemReceived,

    [Description("LoginAlert")]
    @loginAlert,

    [Description("MailReceived")]
    @mailReceived,

    [Description("Password")]
    @password,

    [Description("Payment")]
    @payment,

    [Description("Payroll")]
    @payroll,

    [Description("PersonalizedOffer")]
    @personalizedOffer,

    [Description("Quarantine")]
    @quarantine,

    [Description("RemoteWork")]
    @remoteWork,

    [Description("ReviewMessage")]
    @reviewMessage,

    [Description("SecurityUpdate")]
    @securityUpdate,

    [Description("ServiceSuspended")]
    @serviceSuspended,

    [Description("SignatureRequired")]
    @signatureRequired,

    [Description("UpgradeMailboxStorage")]
    @upgradeMailboxStorage,

    [Description("VerifyMailbox")]
    @verifyMailbox,

    [Description("Voicemail")]
    @voicemail,

    [Description("Advertisement")]
    @advertisement,

    [Description("EmployeeEngagement")]
    @employeeEngagement,
}
