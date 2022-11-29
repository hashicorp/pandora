package cleanup

import (
	"fmt"
	"strings"
)

func RemoveInvalidCharacters(input string, titleCaseSegments bool) string {
	output := input

	// foreach of these characters, work through and Capitalize the segments as necessary
	// e.g. `Azure-kusto` becomes `AzureKusto`
	charactersToReplace := []string{
		" ",
		"_",
		"-", // note: different to below
		"–", // note: different to above
		"_",
		"[",
		"]",
		"(",
		")",
		"{",
		"}",
		"@",
		"#",
		"+",
		",",
		"/",
		":",
		"$",
		"'",
		".",
	}
	for _, find := range charactersToReplace {
		split := strings.Split(output, find)
		newVal := ""
		for _, word := range split {
			word = strings.ReplaceAll(word, find, "")
			if titleCaseSegments {
				word = strings.Title(word)
			}
			newVal += word
		}
		output = newVal
	}

	return output
}

func NormalizeName(input string) string {
	output := input
	output = wordifyFirstCharacter(output)
	output = NormalizeCanonicalisation(output)
	output = RemoveInvalidCharacters(output, true)
	output = NormalizeSegment(output, false)
	output = strings.Title(output)
	return output
}

func NormalizeSegmentName(input string) string {
	output := input
	output = NormalizeName(output)

	if strings.HasSuffix(output, "Name") {
		output = strings.TrimSuffix(output, "Name")
	}

	output = strings.Title(GetSingular(output))
	return output
}

// NormalizeSegment normalizes the segments in the URI, since this data isn't normalized at review time :shrug:
func NormalizeSegment(input string, camelCase bool) string {
	fixed := map[string]string{
		// these are intentionally lower-case keys -> camelCased segments
		"accounts":           "accounts",
		"alertruletemplates": "alertRuleTemplates",
		"apiversion":         "apiVersion",
		"applicationgatewaywebapplicationfirewallpolicies": "applicationGatewayWebApplicationFirewallPolicies",
		"appsettings":                       "appSettings",
		"armtemplates":                      "armTemplates",
		"artifactsources":                   "artifactSources",
		"artifacttypes":                     "artifactTypes",
		"attacheddatabaseconfigurations":    "attachedDatabaseConfigurations",
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
		"clusters":                          "clusters", // handles Clusters
		"compilationjobs":                   "compilationJobs",
		"connectionstrings":                 "connectionStrings",
		"configreferences":                  "configReferences",
		"consumergroups":                    "consumerGroups",
		"continuouswebjobs":                 "continuousWebJobs",
		"customimages":                      "customImages",
		"databases":                         "databases", // handles Databases
		"dataconnections":                   "dataConnections",
		"datastores":                        "dataStores",
		"dedicatedsqlminimaltlssettings":    "dedicatedSQLMinimalTLSSettings",
		"default":                           "default", // handles Default
		"deletedservices":                   "deletedServices",
		"dicomservices":                     "dicomServices",
		"dnszones":                          "dnsZones",
		"endpoints":                         "endpoints",   // handles Endpoints
		"enrichments":                       "enrichments", // handles Enrichments
		"fhirdestinations":                  "fhirDestinations",
		"fhirservices":                      "fhirServices",
		"fileservers":                       "fileServers",
		"fallbackroute":                     "fallbackRoute",
		"fqn":                               "fqn", // handles FQN
		"frontdoorwebapplicationfirewallpolicies": "frontDoorWebApplicationFirewallPolicies",
		"functionappsettings":                     "functionAppSettings",
		"hybridconnection":                        "hybridConnection",
		"hypervsites":                             "hyperVSites",
		"integrationruntimes":                     "integrationRuntimes",
		"iotconnectors":                           "iotConnectors",
		"iothubkeys":                              "iotHubKeys",
		"iothubs":                                 "iotHubs",
		"iotsecuritysolutions":                    "iotSecuritySolutions",
		"iscsiservers":                            "iscsiServers",
		"linkedservices":                          "linkedServices",
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
		"operationresults":                        "operationResults",
		"pipelineruns":                            "pipelineRuns",
		"policysets":                              "policySets",
		"portalconfigs":                           "portalConfigs",
		"premieraddons":                           "premierAddons",
		"principalassignments":                    "principalAssignments",
		"reservationorders":                       "reservationOrders",
		"resourcegroups":                          "resourceGroups",
		"resourcetyperegistrations":               "resourceTypeRegistrations",
		"role":                                    "role",   // handles Role
		"routes":                                  "routes", // handles Routes
		"rulesengines":                            "rulesEngines",
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
		"virtualnetworks":                         "virtualNetworks",
		"virtualmachines":                         "virtualMachines",
		"vmname":                                  "virtualMachineName",         // inconsistency in Compute
		"vmscalesetname":                          "virtualMachineScaleSetName", // inconsistency in Compute (#1204)
		"vcenters":                                "vCenters",
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
				return strings.Title(v)
			}
		}
	}

	return input
}

func NormalizeReservedKeywords(input string) string {
	keywords := []string{
		"const",
		"continue",
		"case",
		"default",
		"import",
		"interface",
		"package",
		"range",
		"select",
		"type",
		"var",
	}

	for _, v := range keywords {
		if strings.EqualFold(input, v) {
			return input + "Name"
		}
	}

	return input
}

func NormalizeResourceName(input string) string {
	output := input
	output = NormalizeName(output)
	output = NormalizeServiceName(output)
	return output
}

func NormalizeResourceProviderName(input string) string {
	replacements := map[string]string{
		"microsoft.aad":                            "Microsoft.AAD",
		"microsoft.aadiam":                         "Microsoft.AADIAM",
		"microsoft.avs":                            "Microsoft.AVS",
		"microsoft.addons":                         "Microsoft.Addons",
		"microsoft.agfoodplatform":                 "Microsoft.AgFoodPlatform",
		"microsoft.alertsmanagement":               "Microsoft.AlertsManagement",
		"microsoft.analysisservices":               "Microsoft.AnalysisServices",
		"microsoft.apimanagement":                  "Microsoft.ApiManagement",
		"microsoft.appconfiguration":               "Microsoft.AppConfiguration",
		"microsoft.appplatform":                    "Microsoft.AppPlatform",
		"microsoft.automanage":                     "Microsoft.AutoManage",
		"microsoft.autonomousdevelopmentplatform":  "Microsoft.AutonomousDevelopmentPlatform",
		"microsoft.azureactivedirectory":           "Microsoft.AzureActiveDirectory",
		"microsoft.azurearcdata":                   "Microsoft.AzureArcData",
		"microsoft.azuredata":                      "Microsoft.AzureData",
		"microsoft.azurestack":                     "Microsoft.AzureStack",
		"microsoft.azurestackhci":                  "Microsoft.AzureStackHCI",
		"microsoft.baremetalinfrastructure":        "Microsoft.BareMetalInfrastructure",
		"microsoft.botservice":                     "Microsoft.BotService",
		"microsoft.cdn":                            "Microsoft.CDN",
		"microsoft.cognitiveservices":              "Microsoft.CognitiveServices",
		"microsoft.confidentialledger":             "Microsoft.ConfidentialLedger",
		"microsoft.connectedvmwarevsphere":         "Microsoft.ConnectedVMwarevSphere",
		"microsoft.containerinstance":              "Microsoft.ContainerInstance",
		"microsoft.containerregistry":              "Microsoft.ContainerRegistry",
		"microsoft.containerservice":               "Microsoft.ContainerService",
		"microsoft.customproviders":                "Microsoft.CustomProviders",
		"microsoft.customerinsights":               "Microsoft.CustomerInsights",
		"microsoft.customerlockbox":                "Microsoft.CustomerLockbox",
		"microsoft.dbforpostgresql":                "Microsoft.DBforPostgreSQL",
		"microsoft.dbformariadb":                   "Microsoft.DBforMariaDB",
		"microsoft.dbformysql":                     "Microsoft.DBforMySQL",
		"microsoft.databox":                        "Microsoft.DataBox",
		"microsoft.databoxedge":                    "Microsoft.DataBoxEdge",
		"microsoft.datacatalog":                    "Microsoft.DataCatalog",
		"microsoft.datafactory":                    "Microsoft.DataFactory",
		"microsoft.datalakeanalytics":              "Microsoft.DataLakeAnalytics",
		"microsoft.datalakestore":                  "Microsoft.DataLakeStore",
		"microsoft.datamigration":                  "Microsoft.DataMigration",
		"microsoft.dataprotection":                 "Microsoft.DataProtection",
		"microsoft.datashare":                      "Microsoft.DataShare",
		"microsoft.databricks":                     "Microsoft.Databricks",
		"microsoft.datadog":                        "Microsoft.Datadog",
		"microsoft.delegatednetwork":               "Microsoft.DelegatedNetwork",
		"microsoft.deploymentmanager":              "Microsoft.DeploymentManager",
		"microsoft.desktopvirtualization":          "Microsoft.DesktopVirtualization",
		"microsoft.devops":                         "Microsoft.DevOps",
		"microsoft.devtestlab":                     "Microsoft.DevTestLab",
		"microsoft.deviceupdate":                   "Microsoft.DeviceUpdate",
		"microsoft.digitaltwins":                   "Microsoft.DigitalTwins",
		"microsoft.documentdb":                     "Microsoft.DocumentDB",
		"microsoft.dynamics365fraudprotection":     "Microsoft.Dynamics365FraudProtection",
		"microsoft.edgeorder":                      "Microsoft.EdgeOrder",
		"microsoft.edgeorderpartner":               "Microsoft.EdgeOrderPartner",
		"microsoft.engagementfabric":               "Microsoft.EngagementFabric",
		"microsoft.enterpriseknowledgegraph":       "Microsoft.EnterpriseKnowledgeGraph",
		"microsoft.eventgrid":                      "Microsoft.EventGrid",
		"microsoft.eventhub":                       "Microsoft.EventHub",
		"microsoft.extendedlocation":               "Microsoft.ExtendedLocation",
		"microsoft.fluidrelay":                     "Microsoft.FluidRelay",
		"microsoft.hdinsight":                      "Microsoft.HDInsight",
		"microsoft.hanaonazure":                    "Microsoft.HanaOnAzure",
		"microsoft.hardwaresecuritymodules":        "Microsoft.HardwareSecurityModules",
		"microsoft.healthbot":                      "Microsoft.HealthBot",
		"microsoft.healthcareapis":                 "Microsoft.HealthcareApis",
		"microsoft.hybridcompute":                  "Microsoft.HybridCompute",
		"microsoft.hybriddata":                     "Microsoft.HybridData",
		"microsoft.hybridnetwork":                  "Microsoft.HybridNetwork",
		"microsoft.importexport":                   "Microsoft.ImportExport",
		"microsoft.iotcentral":                     "Microsoft.IoTCentral",
		"microsoft.iotsecurity":                    "Microsoft.IoTSecurity",
		"microsoft.keyvault":                       "Microsoft.KeyVault",
		"microsoft.kubernetesconfiguration":        "Microsoft.KubernetesConfiguration",
		"microsoft.labservices":                    "Microsoft.LabServices",
		"microsoft.logz":                           "Microsoft.Logz",
		"microsoft.m365securityandcompliance":      "Microsoft.M365SecurityAndCompliance",
		"microsoft.machinelearning":                "Microsoft.MachineLearning",
		"microsoft.machinelearningcompute":         "Microsoft.MachineLearningCompute",
		"microsoft.machinelearningexperimentation": "Microsoft.MachineLearningExperimentation",
		"microsoft.machinelearningservices":        "Microsoft.MachineLearningServices",
		"microsoft.managedidentity":                "Microsoft.ManagedIdentity",
		"microsoft.managednetwork":                 "Microsoft.ManagedNetwork",
		"microsoft.marketplacenotifications":       "Microsoft.MarketplaceNotifications",
		"microsoft.marketplaceordering":            "Microsoft.MarketplaceOrdering",
		"microsoft.mixedreality":                   "Microsoft.MixedReality",
		"microsoft.netapp":                         "Microsoft.NetApp",
		"microsoft.notificationhubs":               "Microsoft.NotificationHubs",
		"microsoft.offazure":                       "Microsoft.OffAzure",
		"microsoft.operationalinsights":            "Microsoft.OperationalInsights",
		"microsoft.operationsmanagement":           "Microsoft.OperationsManagement",
		"microsoft.policyinsights":                 "Microsoft.PolicyInsights",
		"microsoft.powerbi":                        "Microsoft.PowerBI",
		"microsoft.powerbidedicated":               "Microsoft.PowerBIDedicated",
		"microsoft.providerhub":                    "Microsoft.ProviderHub",
		"microsoft.recoveryservices":               "Microsoft.RecoveryServices",
		"microsoft.redhatopenshift":                "Microsoft.RedHatOpenShift",
		"microsoft.saas":                           "Microsoft.SaaS",
		"microsoft.securityandcompliance":          "Microsoft.SecurityAndCompliance",
		"microsoft.securityinsights":               "Microsoft.SecurityInsights",
		"microsoft.serialconsole":                  "Microsoft.SerialConsole",
		"microsoft.servicebus":                     "Microsoft.ServiceBus",
		"microsoft.servicefabric":                  "Microsoft.ServiceFabric",
		"microsoft.signalrservice":                 "Microsoft.SignalRService",
		"microsoft.sql":                            "Microsoft.Sql",
		"microsoft.sqlvirtualmachine":              "Microsoft.SqlVirtualMachine",
		"microsoft.storsimple":                     "Microsoft.StorSimple",
		"microsoft.storagecache":                   "Microsoft.StorageCache",
		"microsoft.storagepool":                    "Microsoft.StoragePool",
		"microsoft.storagesync":                    "Microsoft.StorageSync",
		"microsoft.testbase":                       "Microsoft.TestBase",
		"microsoft.timeseriesinsights":             "Microsoft.TimeSeriesInsights",
		"microsoft.vmwarecloudsimple":              "Microsoft.VMwareCloudSimple",
		"microsoft.virtualmachineimages":           "Microsoft.VirtualMachineImages",
		"microsoft.visualstudio":                   "Microsoft.VisualStudio",
		"microsoft.windowsesu":                     "Microsoft.WindowsESU",
		"microsoft.windowsiot":                     "Microsoft.WindowsIoT",
		"microsoft.workloadmonitor":                "Microsoft.WorkloadMonitor",
	}
	if v, ok := replacements[strings.ToLower(input)]; ok {
		return v
	}

	// ResourceProviders are in the form `Microsoft.Compute` (or `microsoft.compute`)
	// the only transformation we should make is to change the lowered -> Title Case
	segments := strings.Split(input, ".")
	output := make([]string, 0)

	for _, segment := range segments {
		segment = strings.Title(segment)
		output = append(output, segment)
	}

	return strings.Join(output, ".")
}

func NormalizeServiceName(input string) string {
	fixed := map[string]string{
		// NOTE: these are intentionally lower-cased
		"adhybridhealthservice":          "ADHybridHealthService",
		"adp":                            "ADP",
		"alertsmanagement":               "AlertsManagement",
		"analysisservices":               "AnalysisServices",
		"appconfiguration":               "AppConfiguration",
		"applicationinsights":            "ApplicationInsights",
		"appplatform":                    "AppPlatform",
		"automanage":                     "AutoManage",
		"azureactivedirectory":           "AzureActiveDirectory",
		"azurearcdata":                   "AzureArcData",
		"azuredata":                      "AzureData",
		"azurekusto":                     "AzureKusto",
		"azurestack":                     "AzureStack",
		"azurestackhci":                  "AzureStackHCI",
		"baremetalinfrastructure":        "BareMetalInfrastructure",
		"botservice":                     "BotService",
		"changeanalysis":                 "ChangeAnalysis",
		"cognitiveservices":              "CognitiveServices",
		"confidentialledger":             "ConfidentialLedger",
		"containerinstance":              "ContainerInstance",
		"containerregistry":              "ContainerRegistry",
		"containerservice":               "ContainerService",
		"cosmosdb":                       "CosmosDB",
		"costmanagement":                 "CostManagement",
		"customerinsights":               "CustomerInsights",
		"customerlockbox":                "CustomerLockbox",
		"customproviders":                "CustomProviders",
		"databox":                        "DataBox",
		"databoxedge":                    "DataBoxEdge",
		"databricks":                     "Databricks",
		"datacatalog":                    "DataCatalog",
		"datafactory":                    "DataFactory",
		"datalakeanalytics":              "DataLakeAnalytics",
		"datalakestore":                  "DataLakeStore",
		"datamigration":                  "DataMigration",
		"dataprotection":                 "DataProtection",
		"datashare":                      "DataShare",
		"deploymentmanager":              "DeploymentManager",
		"desktopvirtualization":          "DesktopVirtualization",
		"deviceprovisioningservices":     "DeviceProvisioningServices",
		"deviceupdate":                   "DeviceUpdate",
		"devops":                         "DevOps",
		"devtestlabs":                    "DevTestLabs",
		"dfp":                            "DynamicsFraudProtection",
		"digitaltwins":                   "DigitalTwins",
		"dnc":                            "Dnc", // TODO: determine proper naming for this
		"domainservices":                 "DomainServices",
		"dynamicstelemetry":              "DynamicsTelemetry",
		"edgeorder":                      "EdgeOrder",
		"edgeorderpartner":               "EdgeOrderPartner",
		"engagementfabric":               "EngagementFabric",
		"eventgrid":                      "EventGrid",
		"eventhub":                       "EventHub",
		"extendedlocation":               "ExtendedLocation",
		"fluidrelay":                     "FluidRelay",
		"frontdoor":                      "FrontDoor",
		"guestconfiguration":             "GuestConfiguration",
		"hanaonazure":                    "HanaOnAzure",
		"hardwaresecuritymodules":        "HardwareSecurityModules",
		"hdinsight":                      "HDInsight",
		"healthbot":                      "HealthBot",
		"healthcareapis":                 "HealthcareApis",
		"hybridcompute":                  "HybridCompute",
		"hybriddatamanager":              "HybridDataManager",
		"hybridkubernetes":               "HybridKubernetes",
		"hybridnetwork":                  "HybridNetwork",
		"imagebuilder":                   "ImageBuilder",
		"iotcentral":                     "IoTCentral",
		"iothub":                         "IotHub",
		"iotsecurity":                    "IoTSecurity",
		"iotspaces":                      "IoTSpaces",
		"keyvault":                       "KeyVault",
		"kubernetesconfiguration":        "KubernetesConfiguration",
		"labservices":                    "LabServices",
		"machinelearning":                "MachineLearning",
		"machinelearningcompute":         "MachineLearningCompute",
		"machinelearningexperimentation": "MachineLearningExperimentation",
		"machinelearningservices":        "MachineLearningServices",
		"managednetwork":                 "ManagedNetwork",
		"managedservices":                "ManagedServices",
		"managementgroups":               "ManagementGroups",
		"managementpartner":              "ManagementPartner",
		"mariadb":                        "MariaDB",
		"marketplaceordering":            "MarketplaceOrdering",
		"mediaservices":                  "MediaServices",
		"migrateprojects":                "MigrateProjects",
		"mixedreality":                   "MixedReality",
		"msi":                            "ManagedIdentity",
		"mysql":                          "MySql",
		"netapp":                         "NetApp",
		"notificationhubs":               "NotificationHubs",
		"operationalinsights":            "OperationalInsights",
		"operationsmanagement":           "OperationsManagement",
		"policyinsights":                 "PolicyInsights",
		"postgresql":                     "PostgreSql",
		"postgresqlhsc":                  "PostgreSqlHSC",
		"powerbidedicated":               "PowerBIDedicated",
		"powerbiembedded":                "PowerBIEmbedded",
		"powerbiprivatelinks":            "PowerBIPrivateLinks",
		"powerplatform":                  "PowerPlatform",
		"privatedns":                     "PrivateDNS",
		"providerhub":                    "ProviderHub",
		"recoveryservices":               "RecoveryServices",
		"recoveryservicesbackup":         "RecoveryServicesBackup",
		"recoveryservicessiterecovery":   "RecoveryServicesSiteRecovery",
		"redhatopenshift":                "RedHatOpenShift",
		"redisenterprise":                "RedisEnterprise",
		"resourcegraph":                  "ResourceGraph",
		"resourcehealth":                 "ResourceHealth",
		"resourcemover":                  "ResourceMover",
		"saas":                           "SaaS",
		"securityinsights":               "SecurityInsights",
		"signalr":                        "SignalR",
		"serialconsole":                  "SerialConsole",
		"servicebus":                     "ServiceBus",
		"servicefabric":                  "ServiceFabric",
		"servicefabricmanagedclusters":   "ServiceFabricManagedClusters",
		"servicemap":                     "ServiceMap",
		"softwareplan":                   "SoftwarePlan",
		"sqlvirtualmachine":              "SqlVirtualMachine",
		"storagecache":                   "StorageCache",
		"storageimportexport":            "StorageImportExport",
		"storagepool":                    "StoragePool",
		"storagesync":                    "StorageSync",
		"storsimple8000series":           "StorSimple8000Series",
		"streamanalytics":                "StreamAnalytics",
		"testbase":                       "TestBase",
		"timeseriesinsights":             "TimeSeriesInsights",
		"trafficmanager":                 "TrafficManager",
		"videoanalyzer":                  "VideoAnalyzer",
		"visualstudio":                   "VisualStudio",
		"vmware":                         "VMware",
		"vmwarecloudsimple":              "VMwareCloudSimple",
		"webpubsub":                      "WebPubSub",
		"windowsesu":                     "WindowsESU",
		"windowsiot":                     "WindowsIoT",
		"workloadmonitor":                "WorkloadMonitor",
	}

	if v, ok := fixed[strings.ToLower(input)]; ok {
		return strings.Title(v)
	}

	return input
}

func wordifyFirstCharacter(input string) string {
	// TODO: @tombuildsstuff: track down the models with no-name bug
	if len(input) == 0 {
		return input
	}
	vals := map[string]string{
		"0": "Zero",
		"1": "One",
		"2": "Two",
		"3": "Three",
		"4": "Four",
		"5": "Five",
		"6": "Six",
		"7": "Seven",
		"8": "Eight",
		"9": "Nine",
	}
	firstChar := string(input[0])
	if replacement, ok := vals[firstChar]; ok {
		output := strings.TrimPrefix(input, firstChar)
		output = fmt.Sprintf("%s%s", replacement, output)
		return output
	}
	return input
}

func NormalizeCanonicalisation(input string) string {
	output := input

	// Some IP references have 'ip' as a prefix
	if strings.HasPrefix(output, "ip") {
		output = strings.Replace(output, "ip", "IP", 1)
	}

	if strings.HasPrefix(output, "https") {
		output = strings.Replace(output, "https", "HTTPS", 1)
	}

	if strings.HasPrefix(output, "http") {
		output = strings.Replace(output, "http", "HTTP", 1)
	}

	if strings.Contains(output, "github") {
		output = strings.Replace(output, "github", "gitHub", 1)
	}

	if strings.EqualFold(output, "Publicipaddress") {
		// This is an explicit force for broken data in `Network`
		output = "PublicIPAddress"
	}

	if strings.EqualFold(output, "PublicIPAddresses") {
		// This is an explicit force for broken data in `Network`
		output = "PublicIPAddresses"
	}

	if strings.EqualFold(output, "IPconfiguration") {
		// This is an explicit force for broken data in `Network`
		output = "IPConfiguration"
	}

	if strings.EqualFold(output, "NetworkInterfaceIPConfiguration") {
		// This is an explicit force for broken data in `Network`
		output = "NetworkInterfaceIPConfiguration"
	}

	if strings.EqualFold(output, "virtualwan") {
		// This is an explicit force for broken data in `Network`
		output = "VirtualWAN"
	}

	// intentionally case-sensitive
	output = strings.ReplaceAll(output, "Ip", "IP")

	output = strings.ReplaceAll(output, "Https", "HTTPS")
	output = strings.ReplaceAll(output, "Http", "HTTP")

	return output
}

func PluraliseName(input string) string {
	return GetPlural(strings.TrimPrefix(input, "/"))
}
