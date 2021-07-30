package main

type RunInput struct {
	RootNamespace    string
	ServiceName      string
	ApiVersion       string
	OutputDirectory  string
	SwaggerDirectory string
	SwaggerFiles     []string
}

func GenerationData() []RunInput {
	return []RunInput{
		// ------------------------------------------------------------------
		// NOTE: These files are in production and should always be generated
		// ------------------------------------------------------------------
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "AnalysisServices",
			ApiVersion:       "2017-08-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/analysisservices/resource-manager/Microsoft.AnalysisServices/stable/2017-08-01",
			SwaggerFiles: []string{
				"analysisservices.json",
			},
		},
		// AppConfiguration
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "AppConfiguration",
			ApiVersion:       "2020-06-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2020-06-01",
			SwaggerFiles: []string{
				"appconfiguration.json",
			},
		},
		// EventHubs (2021-01-01-preview, 2018-01-01-preview and 2017-04-01)
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "EventHub",
			ApiVersion:       "2017-04-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/stable/2017-04-01",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"CheckNameAvailability.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"namespaces.json",
				"networkRuleSets.json",
				"operations.json",
				"sku.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "EventHub",
			ApiVersion:       "2018-01-01-preview",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2018-01-01-preview",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"AvailableClusterRegions-preview.json",
				"CheckNameAvailability.json",
				"Clusters-preview.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"ipfilterrules-preview.json",
				"namespaces-preview.json",
				"networkrulessets-preview.json",
				"operations-preview.json",
				"operations.json",
				"quotaConfiguration-preview.json",
				"sku.json",
				"virtualnetworkrules-preview.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "EventHub",
			ApiVersion:       "2021-01-01-preview",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2021-01-01-preview",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"CheckNameAvailability.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"namespaces-preview.json",
				"networkrulessets-preview.json",
				"operations.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "Maps",
			ApiVersion:       "2021-02-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/maps/resource-manager/Microsoft.Maps/stable/2021-02-01",
			SwaggerFiles: []string{
				"maps-management.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "ManagedIdentity",
			ApiVersion:       "2018-11-30",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2018-11-30",
			SwaggerFiles: []string{
				"ManagedIdentity.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "PowerBIDedicated",
			ApiVersion:       "2021-01-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/powerbidedicated/resource-manager/Microsoft.PowerBIdedicated/stable/2021-01-01",
			SwaggerFiles: []string{
				"autoScaleVCores.json",
				"powerbidedicated.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "Relay",
			ApiVersion:       "2017-04-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/relay/resource-manager/Microsoft.Relay/stable/2017-04-01",
			SwaggerFiles: []string{
				"relay.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "SignalR",
			ApiVersion:       "2020-05-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/signalr/resource-manager/Microsoft.SignalRService/stable/2020-05-01",
			SwaggerFiles: []string{
				"signalr.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "VMware",
			ApiVersion:       "2020-03-20",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/vmware/resource-manager/Microsoft.AVS/stable/2020-03-20",
			SwaggerFiles: []string{
				"vmware.json",
			},
		},

		// ------------------------------------------------------------------
		// NOTE: These are Development Placeholders so can be commented out
		// ------------------------------------------------------------------
		//{
		//	RootNamespace:    "Pandora.Definitions.DataPlane",
		//	OutputDirectory:  outputDirectory,
		//	ServiceName:      "Synapse",
		//	ApiVersion:       "2020-08-01-preview",
		//	SwaggerDirectory: swaggerDirectory + "/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFilePath:  "example-dp-synapse-roleDefinitions.json",
		//},
		//{
		//	RootNamespace:   "Pandora.Definitions.DataPlane",
		//	OutputDirectory: outputDirectory,
		//	ServiceName:     "AppConfiguration",
		//	ApiVersion:      "1.0",
		//	SwaggerFilePath: "example-dp-appconfiguration.json",
		//},

		// Attestation
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Attestation",
		//	ApiVersion:       "2020-10-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/attestation/resource-manager/Microsoft.Attestation/stable/2020-10-01",
		//	SwaggerFiles: []string{
		//		"attestation.json",
		//	},
		//},

		// Batch
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Batch",
		//	ApiVersion:       "2020-03-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/batch/resource-manager/Microsoft.Batch/stable/2020-03-01/",
		//	SwaggerFiles: []string{
		//		"BatchManagement.json",
		//	},
		//},

		// Billing
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Billing",
		//	ApiVersion:       "2018-11-01-preview",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/billing/resource-manager/Microsoft.Billing/preview/2018-11-01-preview/",
		//	SwaggerFiles: []string{
		//		"billing.json",
		//	},
		//},

		// Compute
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Compute",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/compute/resource-manager/Microsoft.Compute/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		"compute.json",
		//		"disk.json",
		//		"runCommands.json",
		//	},
		//},

		// Cosmos
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Cosmosdb",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	// swagger/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15/cosmos-db.json
		//	SwaggerDirectory: swaggerDirectory + "/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15",
		//	SwaggerFiles: []string{
		//		"cosmos-db.json",
		//		"notebook.json",
		//		"privateEndpointConnection.json",
		//		"privateLinkResources.json",
		//	},
		//},

		// Data Protection (PSql)
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "DataProtection",
		//	ApiVersion:       "2021-01-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/dataprotection/resource-manager/Microsoft.DataProtection/stable/2021-01-01",
		//	SwaggerFiles: []string{
		//		"dataprotection.json",
		//	},
		//},

		// Healthcare APIS
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "HealthcareApis",
		//	ApiVersion:       "2021-01-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-01-11",
		//	SwaggerFiles: []string{
		//		"healthcare-apis.json",
		//	},
		//},

		// Logic
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Logic",
		//	ApiVersion:       "2021-01-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/logic/resource-manager/Microsoft.Logic/stable/2019-05-01",
		//	SwaggerFiles: []string{
		//		"logic.json",
		//	},
		//},

		// Network (old)
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Network",
		//	ApiVersion:       "2017-11-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/network/resource-manager/Microsoft.Network/stable/2017-11-01",
		//	SwaggerFiles: []string{
		//		"publicIpAddress.json",
		//	},
		//},

		// Media
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "MediaServices",
		//	ApiVersion:       "2021-05-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/mediaservices/resource-manager/Microsoft.Media/stable/2021-05-01",
		//	SwaggerFiles: []string{
		//		"Accounts.json",
		//	},
		//},

		// Resources
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Resources",
		//	ApiVersion:       "2020-06-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/resources/resource-manager/Microsoft.Resources/stable/2020-06-01",
		//	SwaggerFiles: []string{
		//		"resources.json",
		//	},
		//},

		// Web
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Web",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		// NOTE: stripped out CommonDefinitions.json
		//		"AppServiceEnvironments.json",
		//		"AppServicePlans.json",
		//		"Certificates.json",
		//		"DeletedWebApps.json",
		//		"Diagnostics.json",
		//		"Global.json",
		//		"Provider.json",
		//		"Recommendations.json",
		//		"ResourceHealthMetadata.json",
		//		"ResourceProvider.json",
		//		"StaticSites.json",
		//		"WebApps.json",
		//	},
		//},

		//Network
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Network",
		//	ApiVersion:       "2020-08-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/network/resource-manager/Microsoft.Network/stable/2020-08-01",
		//	SwaggerFiles: []string{
		//		//"applicationGateway.json",
		//		//"applicationSecurityGroup.json",
		//		//"availableDelegations.json",
		//		//"availableServiceAliases.json",
		//		//"azureFirewall.json",
		//		//"azureFirewallFqdnTag.json",
		//		//"azureWebCategory.json",
		//		//"bastionHost.json",
		//		//"checkDnsAvailability.json",
		//		//"cloudServiceNetworkInterface.json",
		//		//"cloudServicePublicIpAddress.json",
		//		//"customIpPrefix.json",
		//		//"ddosCustomPolicy.json",
		//		//"ddosProtectionPlan.json",
		//		//"dscpConfiguration.json",
		//		//"endpointService.json",
		//		//"expressRouteCircuit.json",
		//		//"expressRouteCrossConnection.json",
		//		//"expressRoutePort.json",
		//		//"firewallPolicy.json",
		//		//"ipAllocation.json",
		//		//"ipGroups.json",
		//		//"loadBalancer.json",
		//		//"natGateway.json",
		//		//"network.json",
		//		"networkInterface.json",
		//		//"networkProfile.json",
		//		//"networkSecurityGroup.json",
		//		//"networkVirtualAppliance.json",
		//		//"networkWatcher.json",
		//		//"operation.json",
		//		//"privateEndpoint.json",
		//		//"privateLinkService.json",
		//		//"publicIpAddress.json",
		//		//"publicIpPrefix.json",
		//		//"routeFilter.json",
		//		//"routeTable.json",
		//		//"securityPartnerProvider.json",
		//		//"serviceCommunity.json",
		//		//"serviceEndpointPolicy.json",
		//		//"serviceTags.json",
		//		//"usage.json",
		//		//"virtualNetwork.json",
		//		//"virtualNetworkGateway.json",
		//		//"virtualNetworkTap.json",
		//		//"virtualRouter.json",
		//		//"virtualWan.json",
		//		//"vmssNetworkInterface.json",
		//		//"vmssPublicIpAddress.json",
		//		//"webapplicationfirewall.json",
		//	},
		//},
	}
}
