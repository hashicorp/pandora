package main

type RunInput struct {
	RootNamespace    string
	ServiceName      string
	ApiVersion       string
	OutputDirectory  string
	SwaggerDirectory string
	SwaggerFiles     []string
}

type ResourceManagerInput struct {
	ServiceName      string
	ApiVersion       string
	SwaggerDirectory string
	SwaggerFiles     []string
}

func (rmi ResourceManagerInput) ToRunInput() RunInput {
	return RunInput{
		RootNamespace:    "Pandora.Definitions.ResourceManager",
		ServiceName:      rmi.ServiceName,
		ApiVersion:       rmi.ApiVersion,
		OutputDirectory:  outputDirectory,
		SwaggerDirectory: rmi.SwaggerDirectory,
		SwaggerFiles:     rmi.SwaggerFiles,
	}
}

func GenerationData() []RunInput {
	return []RunInput{
		// ------------------------------------------------------------------
		// NOTE: These files are in production and should always be generated
		// ------------------------------------------------------------------
		ResourceManagerInput{
			ServiceName:      "AnalysisServices",
			ApiVersion:       "2017-08-01",
			SwaggerDirectory: swaggerDirectory + "/specification/analysisservices/resource-manager/Microsoft.AnalysisServices/stable/2017-08-01",
			SwaggerFiles: []string{
				"analysisservices.json",
			},
		}.ToRunInput(),
		// AppConfiguration
		ResourceManagerInput{
			ServiceName:      "AppConfiguration",
			ApiVersion:       "2020-06-01",
			SwaggerDirectory: swaggerDirectory + "/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2020-06-01",
			SwaggerFiles: []string{
				"appconfiguration.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "Attestation",
			ApiVersion:       "2020-10-01",
			SwaggerDirectory: swaggerDirectory + "/specification/attestation/resource-manager/Microsoft.Attestation/stable/2020-10-01",
			SwaggerFiles: []string{
				"attestation.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "EventHub",
			ApiVersion:       "2017-04-01",
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
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "EventHub",
			ApiVersion:       "2018-01-01-preview",
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
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "EventHub",
			ApiVersion:       "2021-01-01-preview",
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
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "Maps",
			ApiVersion:       "2021-02-01",
			SwaggerDirectory: swaggerDirectory + "/specification/maps/resource-manager/Microsoft.Maps/stable/2021-02-01",
			SwaggerFiles: []string{
				"maps-management.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "ManagedIdentity",
			ApiVersion:       "2018-11-30",
			SwaggerDirectory: swaggerDirectory + "/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2018-11-30",
			SwaggerFiles: []string{
				"ManagedIdentity.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "PowerBIDedicated",
			ApiVersion:       "2021-01-01",
			SwaggerDirectory: swaggerDirectory + "/specification/powerbidedicated/resource-manager/Microsoft.PowerBIdedicated/stable/2021-01-01",
			SwaggerFiles: []string{
				"autoScaleVCores.json",
				"powerbidedicated.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "Relay",
			ApiVersion:       "2017-04-01",
			SwaggerDirectory: swaggerDirectory + "/specification/relay/resource-manager/Microsoft.Relay/stable/2017-04-01",
			SwaggerFiles: []string{
				"relay.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "SignalR",
			ApiVersion:       "2020-05-01",
			SwaggerDirectory: swaggerDirectory + "/specification/signalr/resource-manager/Microsoft.SignalRService/stable/2020-05-01",
			SwaggerFiles: []string{
				"signalr.json",
			},
		}.ToRunInput(),
		ResourceManagerInput{
			ServiceName:      "VMware",
			ApiVersion:       "2020-03-20",
			SwaggerDirectory: swaggerDirectory + "/specification/vmware/resource-manager/Microsoft.AVS/stable/2020-03-20",
			SwaggerFiles: []string{
				"vmware.json",
			},
		}.ToRunInput(),

		// ------------------------------------------------------------------
		// NOTE: These are Development Placeholders so can be commented out
		// ------------------------------------------------------------------
		// TODO: Data Plane input
		//{
		//	RootNamespace:    "Pandora.Definitions.DataPlane",
		//	OutputDirectory:  outputDirectory,
		//	ServiceName:      "Synapse",
		//	ApiVersion:       "2020-08-01-preview",
		//	SwaggerDirectory: swaggerDirectory + "/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFilePath:  "example-dp-synapse-roleDefinitions.json",
		//}
		//{
		//	RootNamespace:   "Pandora.Definitions.DataPlane",
		//	OutputDirectory: outputDirectory,
		//	ServiceName:     "AppConfiguration",
		//	ApiVersion:      "1.0",
		//	SwaggerFilePath: "example-dp-appconfiguration.json",
		//}

		// Batch
		// ResourceManagerInput{
		//	ServiceName:      "Batch",
		//	ApiVersion:       "2020-03-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/batch/resource-manager/Microsoft.Batch/stable/2020-03-01/",
		//	SwaggerFiles: []string{
		//		"BatchManagement.json",
		//	},
		//}.ToRunInput(),

		// Billing
		// ResourceManagerInput{
		//	ServiceName:      "Billing",
		//	ApiVersion:       "2018-11-01-preview",
		//	SwaggerDirectory: swaggerDirectory + "/specification/billing/resource-manager/Microsoft.Billing/preview/2018-11-01-preview/",
		//	SwaggerFiles: []string{
		//		"billing.json",
		//	},
		//}.ToRunInput(),

		// Compute
		// ResourceManagerInput{
		//	ServiceName:      "Compute",
		//	ApiVersion:       "2020-12-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/compute/resource-manager/Microsoft.Compute/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		"compute.json",
		//		"disk.json",
		//		"runCommands.json",
		//	},
		//}.ToRunInput(),

		// Cosmos
		// ResourceManagerInput{
		//	ServiceName:      "Cosmosdb",
		//	ApiVersion:       "2020-12-01",
		//	// swagger/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15/cosmos-db.json
		//	SwaggerDirectory: swaggerDirectory + "/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15",
		//	SwaggerFiles: []string{
		//		"cosmos-db.json",
		//		"notebook.json",
		//		"privateEndpointConnection.json",
		//		"privateLinkResources.json",
		//	},
		//}.ToRunInput(),

		//ResourceManagerInput{
		//	// Blocked on https://github.com/hashicorp/pandora/issues/204
		//	ServiceName:      "CustomProviders",
		//	ApiVersion:       "2018-09-01-preview",
		//	SwaggerDirectory: swaggerDirectory + "/specification/customproviders/resource-manager/Microsoft.CustomProviders/preview/2018-09-01-preview",
		//	SwaggerFiles: []string{
		//		"customproviders.json",
		//	},
		//}.ToRunInput(),

		// Data Protection (PSql)
		// ResourceManagerInput{
		//	ServiceName:      "DataProtection",
		//	ApiVersion:       "2021-01-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/dataprotection/resource-manager/Microsoft.DataProtection/stable/2021-01-01",
		//	SwaggerFiles: []string{
		//		"dataprotection.json",
		//	},
		//}.ToRunInput(),
		//
		// DataBoxEdge - blocked on #73
		// ResourceManagerInput{
		//         ServiceName:      "DataBoxEdge",
		//         ApiVersion:       "2020-12-01",
		//         SwaggerDirectory: swaggerDirectory + "/specification/databoxedge/resource-manager/Microsoft.DataBoxEdge/stable/2020-12-01",
		//         SwaggerFiles: []string{
		//                 "databoxedge.json",
		//         },
		// }.ToRunInput(),
		//
		// Healthcare APIS
		// ResourceManagerInput{
		//	ServiceName:      "HealthcareApis",
		//	ApiVersion:       "2021-01-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-01-11",
		//	SwaggerFiles: []string{
		//		"healthcare-apis.json",
		//	},
		//}.ToRunInput(),

		// Logic
		// ResourceManagerInput{
		//	ServiceName:      "Logic",
		//	ApiVersion:       "2021-01-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/logic/resource-manager/Microsoft.Logic/stable/2019-05-01",
		//	SwaggerFiles: []string{
		//		"logic.json",
		//	},
		//}.ToRunInput(),

		// Network (old)
		// ResourceManagerInput{
		//	ServiceName:      "Network",
		//	ApiVersion:       "2017-11-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/network/resource-manager/Microsoft.Network/stable/2017-11-01",
		//	SwaggerFiles: []string{
		//		"publicIpAddress.json",
		//	},
		//}.ToRunInput(),

		// Media
		// ResourceManagerInput{
		//	ServiceName:      "MediaServices",
		//	ApiVersion:       "2021-05-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/mediaservices/resource-manager/Microsoft.Media/stable/2021-05-01",
		//	SwaggerFiles: []string{
		//		"Accounts.json",
		//	},
		//}.ToRunInput(),

		// Resources
		// ResourceManagerInput{
		//	ServiceName:      "Resources",
		//	ApiVersion:       "2020-06-01",
		//	SwaggerDirectory: swaggerDirectory + "/specification/resources/resource-manager/Microsoft.Resources/stable/2020-06-01",
		//	SwaggerFiles: []string{
		//		"resources.json",
		//	},
		//}.ToRunInput(),

		// Web
		// ResourceManagerInput{
		//	ServiceName:      "Web",
		//	ApiVersion:       "2020-12-01",
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
		//}.ToRunInput(),

		//Network
		// ResourceManagerInput{
		//	ServiceName:      "Network",
		//	ApiVersion:       "2020-08-01",
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
		//}.ToRunInput(),
	}
}
