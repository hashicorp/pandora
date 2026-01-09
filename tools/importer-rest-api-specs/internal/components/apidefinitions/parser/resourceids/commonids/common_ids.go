// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

var CommonIDTypes = []commonIdMatcher{
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
	//commonIdP2sVPNGateway{},
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
	commonIdSharedImageGallery{},

	// HDInsight
	commonIdHDInsightCluster{},

	// Key Vault
	commonIdKeyVault{},
	commonIdKeyVaultKey{},
	commonIdKeyVaultKeyVersion{},
	commonIdKeyVaultPrivateEndpointConnection{},

	// Kubernetes
	commonIdKubernetesCluster{},
	//commonIdKubernetesFleet{},

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
}
