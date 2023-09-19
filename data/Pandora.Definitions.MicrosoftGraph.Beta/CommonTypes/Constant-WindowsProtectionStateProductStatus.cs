// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsProtectionStateProductStatusConstant
{
    [Description("NoStatus")]
    @noStatus,

    [Description("ServiceNotRunning")]
    @serviceNotRunning,

    [Description("ServiceStartedWithoutMalwareProtection")]
    @serviceStartedWithoutMalwareProtection,

    [Description("PendingFullScanDueToThreatAction")]
    @pendingFullScanDueToThreatAction,

    [Description("PendingRebootDueToThreatAction")]
    @pendingRebootDueToThreatAction,

    [Description("PendingManualStepsDueToThreatAction")]
    @pendingManualStepsDueToThreatAction,

    [Description("AvSignaturesOutOfDate")]
    @avSignaturesOutOfDate,

    [Description("AsSignaturesOutOfDate")]
    @asSignaturesOutOfDate,

    [Description("NoQuickScanHappenedForSpecifiedPeriod")]
    @noQuickScanHappenedForSpecifiedPeriod,

    [Description("NoFullScanHappenedForSpecifiedPeriod")]
    @noFullScanHappenedForSpecifiedPeriod,

    [Description("SystemInitiatedScanInProgress")]
    @systemInitiatedScanInProgress,

    [Description("SystemInitiatedCleanInProgress")]
    @systemInitiatedCleanInProgress,

    [Description("SamplesPendingSubmission")]
    @samplesPendingSubmission,

    [Description("ProductRunningInEvaluationMode")]
    @productRunningInEvaluationMode,

    [Description("ProductRunningInNonGenuineMode")]
    @productRunningInNonGenuineMode,

    [Description("ProductExpired")]
    @productExpired,

    [Description("OfflineScanRequired")]
    @offlineScanRequired,

    [Description("ServiceShutdownAsPartOfSystemShutdown")]
    @serviceShutdownAsPartOfSystemShutdown,

    [Description("ThreatRemediationFailedCritically")]
    @threatRemediationFailedCritically,

    [Description("ThreatRemediationFailedNonCritically")]
    @threatRemediationFailedNonCritically,

    [Description("NoStatusFlagsSet")]
    @noStatusFlagsSet,

    [Description("PlatformOutOfDate")]
    @platformOutOfDate,

    [Description("PlatformUpdateInProgress")]
    @platformUpdateInProgress,

    [Description("PlatformAboutToBeOutdated")]
    @platformAboutToBeOutdated,

    [Description("SignatureOrPlatformEndOfLifeIsPastOrIsImpending")]
    @signatureOrPlatformEndOfLifeIsPastOrIsImpending,

    [Description("WindowsSModeSignaturesInUseOnNonWin10SInstall")]
    @windowsSModeSignaturesInUseOnNonWin10SInstall,
}
