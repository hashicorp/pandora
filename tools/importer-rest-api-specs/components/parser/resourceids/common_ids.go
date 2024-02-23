// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type commonIdMatcher interface {
	// id returns the Resource ID for this Common ID
	id() models.ResourceID
}

var commonIdTypes = []commonIdMatcher{
	commonIdManagementGroupMatcher{},
	commonIdResourceGroupMatcher{},
	commonIdSubscriptionMatcher{},
	commonIdScopeMatcher{},
	commonIdUserAssignedIdentity{},

	// Network ids
	// "Core"
	commonIdNetworkInterface{},
	commonIdPublicIPAddress{},
	commonIdSubnet{},
	commonIdVirtualNetwork{},
	commonIdVPNConnection{},

	// Kusto
	commonIdKustoCluster{},
	commonIdKustoDatabase{},

	// RP Specific
	commonIdCloudServicesIPConfiguration{},
	commonIdCloudServicesPublicIPAddress{},
	commonIdExpressRouteCircuitPeering{},
	commonIdNetworkInterfaceIPConfiguration{},
	commonIdP2sVPNGateway{},
	commonIdVirtualHubBGPConnection{},
	commonIdVirtualHubIPConfiguration{},
	commonIdVirtualMachineScaleSetIPConfiguration{},
	commonIdVirtualMachineScaleSetNetworkInterface{},
	commonIdVirtualMachineScaleSetPublicIPAddress{},
	commonIdVirtualRouterPeering{},
	commonIdVirtualWANP2SVPNGateway{},

	// https://github.com/hashicorp/pandora/pull/1962#issuecomment-1375005199
	commonIdHyperVSiteJob{},
	commonIdHyperVSiteMachine{},
	commonIdHyperVSiteRunAsAccount{},
	commonIdVMwareSiteJob{},
	commonIdVMwareSiteMachine{},
	commonIdVMwareSiteRunAsAccount{},

	// Misc data fixes
	commonIdAutomationCompilationJob{}, // (@stephybun) CompilationJobId segment is defined in three different ways `jobId`, `compilationJobId` and `compilationJobName`
	commonIdProvisioningService{},      // (@jackofallops): Inconsistent user specified fields in the swagger - `provisioningServices/{resourceName}` vs `provisioningServices/{provisioningServiceName}`

	// Bot Service
	commonIdBotService{},
	commonIdBotServiceChannel{},

	// Chaos
	commonIdChaosStudioCapability{},
	commonIdChaosStudioTarget{},

	// Compute
	commonIdAvailabilitySet{},
	commonIdDedicatedHost{},
	commonIdDedicatedHostGroup{},
	commonIdDiskEncryptionSet{},
	commonIdManagedDisk{},

	// HDInsight
	commonIdHDInsightCluster{},

	// Key Vault
	commonIdKeyVault{},
	commonIdKeyVaultKey{},
	commonIdKeyVaultKeyVersion{},
	commonIdKeyVaultPrivateEndpointConnection{},

	// Kubernetes
	commonIdKubernetesFleet{},

	// SQL
	commonIdSqlDatabase{},
	commonIdSqlElasticPool{},
	commonIdSqlManagedInstance{},
	commonIdSqlManagedInstanceDatabase{},
	commonIdSqlServer{},

	// Spring Cloud
	commonIdSpringCloudService{},

	// Storage
	commonIdStorageAccount{},
	commonIdStorageContainer{},

	// Web / App Service
	commonIdAppService{},
	commonIdAppServiceEnvironment{},
	commonIdAppServicePlan{},

	// Parent IDs
	commonIdKubernetesCluster{},

	// Shared Image Gallery
	commonIdSharedImageGallery{},
}

func switchOutCommonResourceIDsAsNeeded(input []models.ResourceID) []models.ResourceID {
	output := make([]models.ResourceID, 0)

	for _, value := range input {
		for _, commonId := range commonIdTypes {
			if ResourceIdsMatch(commonId.id(), value) {
				value = commonId.id()
				break
			}
		}

		output = append(output, value)
	}

	return output
}
