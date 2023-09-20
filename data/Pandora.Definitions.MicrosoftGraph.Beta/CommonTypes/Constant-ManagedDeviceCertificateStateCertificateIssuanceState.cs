// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceCertificateStateCertificateIssuanceStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("ChallengeIssued")]
    @challengeIssued,

    [Description("ChallengeIssueFailed")]
    @challengeIssueFailed,

    [Description("RequestCreationFailed")]
    @requestCreationFailed,

    [Description("RequestSubmitFailed")]
    @requestSubmitFailed,

    [Description("ChallengeValidationSucceeded")]
    @challengeValidationSucceeded,

    [Description("ChallengeValidationFailed")]
    @challengeValidationFailed,

    [Description("IssueFailed")]
    @issueFailed,

    [Description("IssuePending")]
    @issuePending,

    [Description("Issued")]
    @issued,

    [Description("ResponseProcessingFailed")]
    @responseProcessingFailed,

    [Description("ResponsePending")]
    @responsePending,

    [Description("EnrollmentSucceeded")]
    @enrollmentSucceeded,

    [Description("EnrollmentNotNeeded")]
    @enrollmentNotNeeded,

    [Description("Revoked")]
    @revoked,

    [Description("RemovedFromCollection")]
    @removedFromCollection,

    [Description("RenewVerified")]
    @renewVerified,

    [Description("InstallFailed")]
    @installFailed,

    [Description("Installed")]
    @installed,

    [Description("DeleteFailed")]
    @deleteFailed,

    [Description("Deleted")]
    @deleted,

    [Description("RenewalRequested")]
    @renewalRequested,

    [Description("Requested")]
    @requested,
}
