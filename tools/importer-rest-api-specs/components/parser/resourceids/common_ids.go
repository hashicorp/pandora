package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type commonIdMatcher interface {
	// id returns the Resource ID for this Common ID
	id() models.ParsedResourceId
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

	// RP Specific
	commonIdCloudServicesIPConfiguration{},
	commonIdCloudServicesPublicIPAddress{},
	commonIdExpressRouteCircuitPeering{},
	commonIdNetworkInterfaceIPConfiguration{},
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

func switchOutCommonResourceIDsAsNeeded(input []models.ParsedResourceId) []models.ParsedResourceId {
	output := make([]models.ParsedResourceId, 0)

	for _, value := range input {
		for _, commonId := range commonIdTypes {
			if commonId.id().Matches(value) {
				value = commonId.id()
				break
			}
		}

		output = append(output, value)
	}

	return output
}
