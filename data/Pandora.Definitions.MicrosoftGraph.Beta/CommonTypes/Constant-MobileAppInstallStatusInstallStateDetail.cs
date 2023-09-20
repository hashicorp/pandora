// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MobileAppInstallStatusInstallStateDetailConstant
{
    [Description("ProcessorArchitectureNotApplicable")]
    @processorArchitectureNotApplicable,

    [Description("MinimumDiskSpaceNotMet")]
    @minimumDiskSpaceNotMet,

    [Description("MinimumOsVersionNotMet")]
    @minimumOsVersionNotMet,

    [Description("MinimumPhysicalMemoryNotMet")]
    @minimumPhysicalMemoryNotMet,

    [Description("MinimumLogicalProcessorCountNotMet")]
    @minimumLogicalProcessorCountNotMet,

    [Description("MinimumCpuSpeedNotMet")]
    @minimumCpuSpeedNotMet,

    [Description("PlatformNotApplicable")]
    @platformNotApplicable,

    [Description("FileSystemRequirementNotMet")]
    @fileSystemRequirementNotMet,

    [Description("RegistryRequirementNotMet")]
    @registryRequirementNotMet,

    [Description("PowerShellScriptRequirementNotMet")]
    @powerShellScriptRequirementNotMet,

    [Description("SupersedingAppsNotApplicable")]
    @supersedingAppsNotApplicable,

    [Description("NoAdditionalDetails")]
    @noAdditionalDetails,

    [Description("DependencyFailedToInstall")]
    @dependencyFailedToInstall,

    [Description("DependencyWithRequirementsNotMet")]
    @dependencyWithRequirementsNotMet,

    [Description("DependencyPendingReboot")]
    @dependencyPendingReboot,

    [Description("DependencyWithAutoInstallDisabled")]
    @dependencyWithAutoInstallDisabled,

    [Description("SupersededAppUninstallFailed")]
    @supersededAppUninstallFailed,

    [Description("SupersededAppUninstallPendingReboot")]
    @supersededAppUninstallPendingReboot,

    [Description("RemovingSupersededApps")]
    @removingSupersededApps,

    [Description("IosAppStoreUpdateFailedToInstall")]
    @iosAppStoreUpdateFailedToInstall,

    [Description("VppAppHasUpdateAvailable")]
    @vppAppHasUpdateAvailable,

    [Description("UserRejectedUpdate")]
    @userRejectedUpdate,

    [Description("UninstallPendingReboot")]
    @uninstallPendingReboot,

    [Description("SupersedingAppsDetected")]
    @supersedingAppsDetected,

    [Description("SupersededAppsDetected")]
    @supersededAppsDetected,

    [Description("SeeInstallErrorCode")]
    @seeInstallErrorCode,

    [Description("AutoInstallDisabled")]
    @autoInstallDisabled,

    [Description("ManagedAppNoLongerPresent")]
    @managedAppNoLongerPresent,

    [Description("UserRejectedInstall")]
    @userRejectedInstall,

    [Description("UserIsNotLoggedIntoAppStore")]
    @userIsNotLoggedIntoAppStore,

    [Description("UntargetedSupersedingAppsDetected")]
    @untargetedSupersedingAppsDetected,

    [Description("AppRemovedBySupersedence")]
    @appRemovedBySupersedence,

    [Description("SeeUninstallErrorCode")]
    @seeUninstallErrorCode,

    [Description("PendingReboot")]
    @pendingReboot,

    [Description("InstallingDependencies")]
    @installingDependencies,

    [Description("ContentDownloaded")]
    @contentDownloaded,
}
