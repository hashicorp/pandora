// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCOnPremisesConnectionHealthCheckErrorTypeConstant
{
    [Description("DnsCheckFqdnNotFound")]
    @dnsCheckFqdnNotFound,

    [Description("DnsCheckNameWithInvalidCharacter")]
    @dnsCheckNameWithInvalidCharacter,

    [Description("DnsCheckUnknownError")]
    @dnsCheckUnknownError,

    [Description("AdJoinCheckFqdnNotFound")]
    @adJoinCheckFqdnNotFound,

    [Description("AdJoinCheckIncorrectCredentials")]
    @adJoinCheckIncorrectCredentials,

    [Description("AdJoinCheckOrganizationalUnitNotFound")]
    @adJoinCheckOrganizationalUnitNotFound,

    [Description("AdJoinCheckOrganizationalUnitIncorrectFormat")]
    @adJoinCheckOrganizationalUnitIncorrectFormat,

    [Description("AdJoinCheckComputerObjectAlreadyExists")]
    @adJoinCheckComputerObjectAlreadyExists,

    [Description("AdJoinCheckAccessDenied")]
    @adJoinCheckAccessDenied,

    [Description("AdJoinCheckCredentialsExpired")]
    @adJoinCheckCredentialsExpired,

    [Description("AdJoinCheckAccountLockedOrDisabled")]
    @adJoinCheckAccountLockedOrDisabled,

    [Description("AdJoinCheckAccountQuotaExceeded")]
    @adJoinCheckAccountQuotaExceeded,

    [Description("AdJoinCheckServerNotOperational")]
    @adJoinCheckServerNotOperational,

    [Description("AdJoinCheckUnknownError")]
    @adJoinCheckUnknownError,

    [Description("EndpointConnectivityCheckCloudPCUrlNotAllowListed")]
    @endpointConnectivityCheckCloudPcUrlNotAllowListed,

    [Description("EndpointConnectivityCheckWVDUrlNotAllowListed")]
    @endpointConnectivityCheckWVDUrlNotAllowListed,

    [Description("EndpointConnectivityCheckIntuneUrlNotAllowListed")]
    @endpointConnectivityCheckIntuneUrlNotAllowListed,

    [Description("EndpointConnectivityCheckAzureADUrlNotAllowListed")]
    @endpointConnectivityCheckAzureADUrlNotAllowListed,

    [Description("EndpointConnectivityCheckLocaleUrlNotAllowListed")]
    @endpointConnectivityCheckLocaleUrlNotAllowListed,

    [Description("EndpointConnectivityCheckUnknownError")]
    @endpointConnectivityCheckUnknownError,

    [Description("AzureAdDeviceSyncCheckDeviceNotFound")]
    @azureAdDeviceSyncCheckDeviceNotFound,

    [Description("AzureAdDeviceSyncCheckLongSyncCircle")]
    @azureAdDeviceSyncCheckLongSyncCircle,

    [Description("AzureAdDeviceSyncCheckConnectDisabled")]
    @azureAdDeviceSyncCheckConnectDisabled,

    [Description("AzureAdDeviceSyncCheckDurationExceeded")]
    @azureAdDeviceSyncCheckDurationExceeded,

    [Description("AzureAdDeviceSyncCheckScpNotConfigured")]
    @azureAdDeviceSyncCheckScpNotConfigured,

    [Description("AzureAdDeviceSyncCheckTransientServiceError")]
    @azureAdDeviceSyncCheckTransientServiceError,

    [Description("AzureAdDeviceSyncCheckUnknownError")]
    @azureAdDeviceSyncCheckUnknownError,

    [Description("ResourceAvailabilityCheckNoSubnetIP")]
    @resourceAvailabilityCheckNoSubnetIP,

    [Description("ResourceAvailabilityCheckSubscriptionDisabled")]
    @resourceAvailabilityCheckSubscriptionDisabled,

    [Description("ResourceAvailabilityCheckAzurePolicyViolation")]
    @resourceAvailabilityCheckAzurePolicyViolation,

    [Description("ResourceAvailabilityCheckSubscriptionNotFound")]
    @resourceAvailabilityCheckSubscriptionNotFound,

    [Description("ResourceAvailabilityCheckSubscriptionTransferred")]
    @resourceAvailabilityCheckSubscriptionTransferred,

    [Description("ResourceAvailabilityCheckGeneralSubscriptionError")]
    @resourceAvailabilityCheckGeneralSubscriptionError,

    [Description("ResourceAvailabilityCheckUnsupportedVNetRegion")]
    @resourceAvailabilityCheckUnsupportedVNetRegion,

    [Description("ResourceAvailabilityCheckResourceGroupInvalid")]
    @resourceAvailabilityCheckResourceGroupInvalid,

    [Description("ResourceAvailabilityCheckVNetInvalid")]
    @resourceAvailabilityCheckVNetInvalid,

    [Description("ResourceAvailabilityCheckSubnetInvalid")]
    @resourceAvailabilityCheckSubnetInvalid,

    [Description("ResourceAvailabilityCheckResourceGroupBeingDeleted")]
    @resourceAvailabilityCheckResourceGroupBeingDeleted,

    [Description("ResourceAvailabilityCheckVNetBeingMoved")]
    @resourceAvailabilityCheckVNetBeingMoved,

    [Description("ResourceAvailabilityCheckSubnetDelegationFailed")]
    @resourceAvailabilityCheckSubnetDelegationFailed,

    [Description("ResourceAvailabilityCheckSubnetWithExternalResources")]
    @resourceAvailabilityCheckSubnetWithExternalResources,

    [Description("ResourceAvailabilityCheckResourceGroupLockedForReadonly")]
    @resourceAvailabilityCheckResourceGroupLockedForReadonly,

    [Description("ResourceAvailabilityCheckResourceGroupLockedForDelete")]
    @resourceAvailabilityCheckResourceGroupLockedForDelete,

    [Description("ResourceAvailabilityCheckNoIntuneReaderRoleError")]
    @resourceAvailabilityCheckNoIntuneReaderRoleError,

    [Description("ResourceAvailabilityCheckIntuneDefaultWindowsRestrictionViolation")]
    @resourceAvailabilityCheckIntuneDefaultWindowsRestrictionViolation,

    [Description("ResourceAvailabilityCheckIntuneCustomWindowsRestrictionViolation")]
    @resourceAvailabilityCheckIntuneCustomWindowsRestrictionViolation,

    [Description("ResourceAvailabilityCheckTransientServiceError")]
    @resourceAvailabilityCheckTransientServiceError,

    [Description("ResourceAvailabilityCheckUnknownError")]
    @resourceAvailabilityCheckUnknownError,

    [Description("PermissionCheckNoSubscriptionReaderRole")]
    @permissionCheckNoSubscriptionReaderRole,

    [Description("PermissionCheckNoResourceGroupOwnerRole")]
    @permissionCheckNoResourceGroupOwnerRole,

    [Description("PermissionCheckNoVNetContributorRole")]
    @permissionCheckNoVNetContributorRole,

    [Description("PermissionCheckNoResourceGroupNetworkContributorRole")]
    @permissionCheckNoResourceGroupNetworkContributorRole,

    [Description("PermissionCheckNoWindows365NetworkUserRole")]
    @permissionCheckNoWindows365NetworkUserRole,

    [Description("PermissionCheckNoWindows365NetworkInterfaceContributorRole")]
    @permissionCheckNoWindows365NetworkInterfaceContributorRole,

    [Description("PermissionCheckTransientServiceError")]
    @permissionCheckTransientServiceError,

    [Description("PermissionCheckUnknownError")]
    @permissionCheckUnknownError,

    [Description("UdpConnectivityCheckStunUrlNotAllowListed")]
    @udpConnectivityCheckStunUrlNotAllowListed,

    [Description("UdpConnectivityCheckTurnUrlNotAllowListed")]
    @udpConnectivityCheckTurnUrlNotAllowListed,

    [Description("UdpConnectivityCheckUrlsNotAllowListed")]
    @udpConnectivityCheckUrlsNotAllowListed,

    [Description("UdpConnectivityCheckUnknownError")]
    @udpConnectivityCheckUnknownError,

    [Description("InternalServerErrorDeploymentCanceled")]
    @internalServerErrorDeploymentCanceled,

    [Description("InternalServerErrorAllocateResourceFailed")]
    @internalServerErrorAllocateResourceFailed,

    [Description("InternalServerErrorVMDeploymentTimeout")]
    @internalServerErrorVMDeploymentTimeout,

    [Description("InternalServerErrorUnableToRunDscScript")]
    @internalServerErrorUnableToRunDscScript,

    [Description("SsoCheckKerberosConfigurationError")]
    @ssoCheckKerberosConfigurationError,

    [Description("InternalServerUnknownError")]
    @internalServerUnknownError,
}
