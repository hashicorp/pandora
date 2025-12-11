// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cleanup

import "strings"

// TODO: this wants moving into the `resourceids` package, but for now

// NormalizeSegment normalizes the segments in the URI, since this data isn't normalized at review time :shrug:
func NormalizeSegment(input string, camelCase bool) string {
	// property names in Models that are normalized in NormalizeCanonicalisation to begin with IP need to be excluded here
	if strings.HasPrefix(input, "IP") {
		return input
	}

	fixed := map[string]string{
		// these are intentionally lower-case keys -> camelCased segments
		"accounts":           "accounts",
		"alertrules":         "alertRules",
		"alertruletemplates": "alertRuleTemplates",
		"apikeys":            "apiKeys",
		"apiversion":         "apiVersion",
		"applicationgatewaywebapplicationfirewallpolicies": "applicationGatewayWebApplicationFirewallPolicies",
		"appsettings":                       "appSettings",
		"armtemplates":                      "armTemplates",
		"artifactsources":                   "artifactSources",
		"artifacttypes":                     "artifactTypes",
		"attacheddatabaseconfigurations":    "attachedDatabaseConfigurations",
		"attachednetworks":                  "attachedNetworks",
		"attestationprovider":               "attestationProviders", // NOTE: this is a Swagger issue we need to fix too
		"authorizationrules":                "authorizationRules",
		"authproviders":                     "authProviders",
		"automationrules":                   "automationRules",
		"autoscalesettings":                 "autoScaleSettings",
		"azureasyncoperations":              "azureAsyncOperations",
		"backupstorageconfig":               "backupStorageConfig",
		"buildpackBindings":                 "buildPackBindings",
		"cdnwebapplicationfirewallpolicies": "cdnWebApplicationFirewallPolicies",
		"certificates":                      "certificates", // handles Certificates
		"channels":                          "channels",
		"clusterpools":                      "clusterPools",
		"clusters":                          "clusters", // handles Clusters
		"compilationjobs":                   "compilationJobs",
		"connectionstrings":                 "connectionStrings",
		"configreferences":                  "configReferences",
		"consumergroups":                    "consumerGroups",
		"contentproducttemplates":           "contentProductTemplates",
		"continuouswebjobs":                 "continuousWebJobs",
		"customimages":                      "customImages",
		"customipprefixes":                  "customIPPrefixes",
		"databases":                         "databases",      // handles Databases
		"datareferences":                    "dataReferences", // handles MachineLearningServices
		"dataconnections":                   "dataConnections",
		"datastores":                        "dataStores",
		"dedicatedsqlminimaltlssettings":    "dedicatedSQLMinimalTLSSettings",
		"default":                           "default", // handles Default
		"deletedservices":                   "deletedServices",
		"devboxdefinitions":                 "devBoxDefinitions",
		"devcenters":                        "devCenters",
		"dicomservices":                     "dicomServices",
		"dnszones":                          "dnsZones",
		"endpoints":                         "endpoints",           // handles Endpoints
		"enrichments":                       "enrichments",         // handles Enrichments
		"exportconfiguration":               "exportConfiguration", // inconsistency in ApplicationInsights (singular, not plural)
		"fhirdestinations":                  "fhirDestinations",
		"fhirservices":                      "fhirServices",
		"fileservers":                       "fileServers",
		"fallbackroute":                     "fallbackRoute",
		"featuresets":                       "featureSets",
		"featurestoreentities":              "featureStoreEntities",
		"fqdnlists":                         "fqdnLists",
		"fqn":                               "fqn", // handles FQN
		"frontdoorwebapplicationfirewallpolicies": "frontDoorWebApplicationFirewallPolicies",
		"functionappsettings":                     "functionAppSettings",
		"globalrulestacks":                        "globalRulestacks", // (@jackofallops) - "Rulestack" is considered one word, but also casing bug in the service. https://github.com/Azure/azure-rest-api-specs/issues/24780#issuecomment-1635234884
		"hostruntime":                             "hostRuntime",      // inconsistency in Web
		"hybridconnection":                        "hybridConnection",
		"hypervsites":                             "hyperVSites",
		"integrationruntimes":                     "integrationRuntimes",
		"iotconnectors":                           "iotConnectors",
		"iothubkeys":                              "iotHubKeys",
		"iothubs":                                 "iotHubs",
		"iotsecuritysolutions":                    "iotSecuritySolutions",
		"ipconfigurations":                        "ipConfigurations",
		"iscsiservers":                            "iscsiServers",
		"linkedservices":                          "linkedServices",
		"listkeys":                                "listKeys",
		"localrulestacks":                         "localRulestacks", // (@jackofallops) - "Rulestack" is considered one word, but also casing bug in the service. https://github.com/Azure/azure-rest-api-specs/issues/24780#issuecomment-1635234884
		"logprofiles":                             "logProfiles",
		"managedclusters":                         "managedClusters",
		"mediaservices":                           "mediaServices",
		"managedclustersnapshots":                 "managedClusterSnapshots",
		"managementassociations":                  "managementAssociations",
		"managementconfigurations":                "managementConfigurations",
		"managedprivateendpoints":                 "managedPrivateEndpoints",
		"mastersites":                             "masterSites",
		"mediaservice":                            "mediaService",
		"migratemysql":                            "migrateMySql",
		"nodecounts":                              "nodeCounts",
		"notificationchannels":                    "notificationChannels",
		"openshiftclusters":                       "openShiftClusters",
		"operationresults":                        "operationResults",
		"p2svpnGateways":                          "p2sVpnGateways",
		"pipelineruns":                            "pipelineRuns",
		"policysets":                              "policySets",
		"portalconfigs":                           "portalConfigs",
		"prefixlists":                             "prefixLists",
		"premieraddons":                           "premierAddons",
		"principalassignments":                    "principalAssignments",
		"publicipaddresses":                       "publicIPAddresses",
		"reservationorders":                       "reservationOrders",
		"resourcegroups":                          "resourceGroups",
		"resourcetyperegistrations":               "resourceTypeRegistrations",
		"role":                                    "role",   // handles Role
		"routes":                                  "routes", // handles Routes
		"rulesengines":                            "rulesEngines",
		"runasaccounts":                           "runAsAccounts",
		"saasresources":                           "saasResources",
		"schemagroups":                            "schemaGroups",
		"scripts":                                 "scripts", // handles Scripts
		"serverfarms":                             "serverFarms",
		"servicefabrics":                          "serviceFabrics",
		"servicerunners":                          "serviceRunners",
		"siteextensions":                          "siteExtensions",
		"smartdetectoralertrules":                 "smartDetectorAlertRules",
		"sourcecontrols":                          "sourceControls",
		"sparkconfigurations":                     "sparkConfigurations",
		"streamingjobs":                           "streamingJobs",
		"supportedbuildpacks":                     "supportedBuildPacks",
		"spring":                                  "spring",
		"subscriptions":                           "subscriptions", // e.g. /Subscriptions -> /subscriptions
		"subvolumes":                              "subVolumes",
		"trafficmanagerprofiles":                  "trafficManagerProfiles",
		"triggeredwebjobs":                        "triggeredWebJobs",
		"vaultstorageconfig":                      "vaultStorageConfig",
		"vcenters":                                "vCenters",
		"virtualendpoints":                        "virtualEndpoints", // exists in Postgresql
		"virtualnetworks":                         "virtualNetworks",
		"virtualmachine":                          "virtualMachine", // exists in MarketplaceOrdering
		"virtualmachines":                         "virtualMachines",
		"vmname":                                  "virtualMachineName",         // inconsistency in Compute
		"vmscalesetname":                          "virtualMachineScaleSetName", // inconsistency in Compute (#1204)
		"vmwaresites":                             "vmwareSites",
		"vmextension":                             "vmExtension",
		"vmimage":                                 "vmImage",
		"volumegroups":                            "volumeGroups",
		"webhooks":                                "webHooks",
		"webjobs":                                 "webJobs",
		"webtests":                                "webTests",
		"workbooktemplates":                       "workbookTemplates",
	}

	for k, v := range fixed {
		if strings.EqualFold(k, input) {
			if camelCase {
				return v
			} else {
				return Title(v)
			}
		}
	}

	return input
}
