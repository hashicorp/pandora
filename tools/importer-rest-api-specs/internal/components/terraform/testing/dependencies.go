// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"
)

type testDependencies struct {
	variables testVariables

	// NOTE: use the Set methods
	needsApplicationInsights      bool
	needsClientConfig             bool
	needsDevCenter                bool
	needsEdgeZone                 bool
	needsKeyVault                 bool
	needsKeyVaultAccessPolicy     bool
	needsKeyVaultKey              bool
	needsKubernetesCluster        bool
	needsKubernetesFleetManager   bool
	needsMachineLearningWorkspace bool
	needsNetworkInterface         bool
	needsPublicIP                 bool
	needsResourceGroup            bool
	needsStorageAccount           bool
	needsSubnet                   bool
	needsUserAssignedIdentity     bool
	needsVirtualNetwork           bool

	// TODO: this obviously isn't going to scale, so we should:
	//
	//   1. In the medium-term, look these up using a struct which
	//      defines it's dependencies so this is manageable.
	//
	//   2. In the longer-term, can we infer the dependencies from
	//      the reference name, for example `virtual_network.test`
	//      and find the matching `basic` test and reference that?
}

func (d *testDependencies) setNeedsApplicationInsights() {
	d.setNeedsResourceGroup()
	d.needsApplicationInsights = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsClientConfig() {
	d.needsClientConfig = true
}

func (d *testDependencies) setNeedsDevCenter() {
	d.setNeedsResourceGroup()
	d.needsDevCenter = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsEdgeZones() {
	d.needsEdgeZone = true

	d.variables.needsPrimaryLocation = true
}

func (d *testDependencies) setNeedsKeyVault() {
	d.setNeedsResourceGroup()
	d.setNeedsClientConfig()
	d.needsKeyVault = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsKeyVaultAccessPolicy() {
	d.setNeedsResourceGroup()
	d.setNeedsClientConfig()
	d.setNeedsKeyVault()
	d.needsKeyVaultAccessPolicy = true
}

func (d *testDependencies) setNeedsKeyVaultKey() {
	d.setNeedsKeyVault()
	d.needsKeyVaultKey = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsKubernetesCluster() {
	d.setNeedsResourceGroup()
	d.needsKubernetesCluster = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsKubernetesFleetManager() {
	d.setNeedsResourceGroup()
	d.needsKubernetesFleetManager = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsMachineLearningWorkspace() {
	d.setNeedsResourceGroup()
	d.setNeedsKeyVault()
	d.setNeedsKeyVaultAccessPolicy()
	d.setNeedsApplicationInsights()
	d.setNeedsStorageAccount()
	d.needsMachineLearningWorkspace = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsNetworkInterface() {
	d.setNeedsSubnet()

	d.needsNetworkInterface = true
}

func (d *testDependencies) setNeedsPublicIP() {
	d.setNeedsVirtualNetwork()
	d.needsPublicIP = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsResourceGroup() {
	d.needsResourceGroup = true

	d.variables.needsRandomInteger = true
	d.variables.needsPrimaryLocation = true
}

func (d *testDependencies) setNeedsStorageAccount() {
	d.setNeedsResourceGroup()
	d.needsStorageAccount = true

	d.variables.needsRandomString = true
}

func (d *testDependencies) setNeedsSubnet() {
	d.setNeedsVirtualNetwork()
	d.needsSubnet = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsUserAssignedIdentity() {
	d.setNeedsResourceGroup()
	d.needsUserAssignedIdentity = true

	d.variables.needsRandomInteger = true
}

func (d *testDependencies) setNeedsVirtualNetwork() {
	d.setNeedsResourceGroup()
	d.needsVirtualNetwork = true

	d.variables.needsPrimaryLocation = true
	d.variables.needsRandomInteger = true
}

type dependencyDefinition struct {
	// Instruction is the dependency func that sets the dependencies needed for the tests
	Instruction func()

	// Reference is the hcl reference to the dependency
	Reference string
}

func DetermineDependencies(field, providerPrefix string, dependencies *testDependencies) (*string, *testDependencies, error) {
	dependencyMapping := map[string]dependencyDefinition{
		"application_insights_id":       {dependencies.setNeedsApplicationInsights, fmt.Sprintf("%s_application_insights.test.id", providerPrefix)},
		"dev_center_id":                 {dependencies.setNeedsDevCenter, fmt.Sprintf("azurerm_dev_center.test.id")},
		"key_vault_id":                  {dependencies.setNeedsKeyVault, fmt.Sprintf("%s_key_vault.test.id", providerPrefix)},
		"key_vault_access_policy_id":    {dependencies.setNeedsKeyVaultAccessPolicy, fmt.Sprintf("%s_key_vault_access_policy.test.id", providerPrefix)},
		"key_vault_key_id":              {dependencies.setNeedsKeyVaultKey, fmt.Sprintf("%s_key_vault_key.test.id", providerPrefix)},
		"kubernetes_cluster_id":         {dependencies.setNeedsKubernetesCluster, fmt.Sprintf("%s_kubernetes_cluster.test.id", providerPrefix)},
		"kubernetes_fleet_id":           {dependencies.setNeedsKubernetesFleetManager, fmt.Sprintf("%s_kubernetes_fleet_manager.test.id", providerPrefix)},
		"machine_learning_workspace_id": {dependencies.setNeedsMachineLearningWorkspace, fmt.Sprintf("%s_machine_learning_workspace.test.id", providerPrefix)},
		"network_interface_id":          {dependencies.setNeedsNetworkInterface, fmt.Sprintf("%s_network_interface.test.id", providerPrefix)},
		"storage_account_id":            {dependencies.setNeedsStorageAccount, fmt.Sprintf("%s_storage_account.test.id", providerPrefix)},
		"subnet_id":                     {dependencies.setNeedsSubnet, fmt.Sprintf("%s_subnet.test.id", providerPrefix)},
		"subscription_id":               {dependencies.setNeedsClientConfig, fmt.Sprintf("data.%s_client_config.test.subscription_id", providerPrefix)},
		// Currently only Chaos Studio Targets has this property which can accept many different resource IDs
		// for now setting this to kubernetes is sufficient, but we will need to consider how to proceed in future
		"target_resource_id":        {dependencies.setNeedsKubernetesCluster, fmt.Sprintf("%s_kubernetes_cluster.test.id", providerPrefix)},
		"tenant_id":                 {dependencies.setNeedsClientConfig, fmt.Sprintf("data.%s_client_config.test.tenant_id", providerPrefix)},
		"user_assigned_identity_id": {dependencies.setNeedsUserAssignedIdentity, fmt.Sprintf("%s_user_assigned_identity.test.id", providerPrefix)},
		"virtual_network_id":        {dependencies.setNeedsVirtualNetwork, fmt.Sprintf("%s_virtual_network.test.id", providerPrefix)},
	}

	if _, ok := dependencyMapping[field]; !ok {
		return nil, nil, fmt.Errorf("internal-error: missing dependency mapping for Resource ID Reference %q", field)
	}

	dependency := dependencyMapping[field]

	dependency.Instruction()

	return &dependency.Reference, dependencies, nil
}
