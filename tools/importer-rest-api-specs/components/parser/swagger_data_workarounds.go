package parser

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func patchSwaggerData(input []models.AzureApiDefinition, logger hclog.Logger) (*[]models.AzureApiDefinition, error) {
	output := make([]models.AzureApiDefinition, 0)

	// NOTE: each override in this file is temporary until the associated upstream Swagger PR is merged.

	for _, item := range input {
		// This works around the Patch Model having no type for the Tags field (which is parsed as an Object instead)
		// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/20961
		if item.ServiceName == "LoadTestService" && (item.ApiVersion == "2021-12-01-preview" || item.ApiVersion == "2022-04-15-preview" || item.ApiVersion == "2022-12-01") {
			logger.Trace(fmt.Sprintf("Processing Overrides for Service %q / API Version %q..", item.ServiceName, item.ApiVersion))
			resource, ok := item.Resources["LoadTests"]
			if !ok {
				return nil, fmt.Errorf("couldn't find API Resource LoadTests")
			}
			model, ok := resource.Models["LoadTestResourcePatchRequestBody"]
			if !ok {
				return nil, fmt.Errorf("couldn't find Model LoadTestResourcePatchRequestBody")
			}
			field, ok := model.Fields["Tags"]
			if !ok {
				return nil, fmt.Errorf("couldn't find field Tags within model LoadTestResourcePatchRequestBody")
			}
			tagsType := models.CustomFieldTypeTags
			field.CustomFieldType = &tagsType
			field.ObjectDefinition = nil

			model.Fields["Tags"] = field
			resource.Models["LoadTestResourcePatchRequestBody"] = model
			item.Resources["LoadTests"] = resource
		}

		// Works around the `DnsPrefix` field being required but being marked as Optional
		// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21394
		if item.ServiceName == "ContainerService" && item.ApiVersion == "2022-09-02-preview" {
			logger.Trace(fmt.Sprintf("Processing Overrides for Service %q / API Version %q..", item.ServiceName, item.ApiVersion))
			resource, ok := item.Resources["Fleets"]
			if !ok {
				return nil, fmt.Errorf("couldn't find API Resource Fleets")
			}
			model, ok := resource.Models["FleetHubProfile"]
			if !ok {
				return nil, fmt.Errorf("couldn't find Model FleetHubProfile")
			}
			field, ok := model.Fields["DnsPrefix"]
			if !ok {
				return nil, fmt.Errorf("couldn't find field DnsPrefix within model FleetHubProfile")
			}
			field.Required = true

			model.Fields["DnsPrefix"] = field
			resource.Models["FleetHubProfile"] = model
			item.Resources["Fleets"] = resource
		}

		// Works around the Update operation having the incorrect Swagger Tag (StreamingEndpoint
		// rather than StreamingEndpoints).
		// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21581
		if item.ServiceName == "Media" && item.ApiVersion == "2020-05-01" {
			singular, singularExists := item.Resources["StreamingEndpoint"]
			plural, pluralExists := item.Resources["StreamingEndpoints"]
			if singularExists && pluralExists {
				updateOperation, ok := singular.Operations["Update"]
				if ok {
					// NOTE: we should be moving the Model too, but as it's the same as for Create this should be fine
					plural.Operations["Update"] = updateOperation
					item.Resources["StreamingEndpoints"] = plural
					delete(item.Resources, "StreamingEndpoint")
				}
			}
		}

		// Works around https://github.com/Azure/azure-rest-api-specs/pull/21667 which is where the Swagger segments
		// are inconsistent, both named as `replicatedProtectedItemName` and `replicationProtectedItemName`
		if item.ServiceName == "RecoveryServicesSiteRecovery" && (item.ApiVersion == "2022-05-01" || item.ApiVersion == "2022-10-01") {
			resourcesToPatch := []string{
				"RecoveryPoints",
				"ReplicationProtectedItems",
				"TargetComputeSizes",
			}
			for _, resourceName := range resourcesToPatch {
				if resource, ok := item.Resources[resourceName]; ok {
					if rid, ok := resource.ResourceIds["ReplicationProtectedItem"]; ok {
						expectedResourceId := models.ParsedResourceId{
							Segments: []resourcemanager.ResourceIdSegment{
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticSubscriptions",
									FixedValue: pointer.To("subscriptions"),
								},
								{
									Type: resourcemanager.SubscriptionIdSegment,
									Name: "subscriptionId",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticResourceGroups",
									FixedValue: pointer.To("resourceGroups"),
								},
								{
									Type: resourcemanager.ResourceGroupSegment,
									Name: "resourceGroupName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticProviders",
									FixedValue: pointer.To("providers"),
								},
								{
									Type:       resourcemanager.ResourceProviderSegment,
									Name:       "staticMicrosoftRecoveryServices",
									FixedValue: pointer.To("Microsoft.RecoveryServices"),
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticVaults",
									FixedValue: pointer.To("vaults"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "resourceName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationFabrics",
									FixedValue: pointer.To("replicationFabrics"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "fabricName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationProtectionContainers",
									FixedValue: pointer.To("replicationProtectionContainers"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "protectionContainerName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationProtectedItems",
									FixedValue: pointer.To("replicationProtectedItems"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "replicatedProtectedItemName",
								},
							},
							Constants: map[string]resourcemanager.ConstantDetails{},
						}
						correctedResourceId := models.ParsedResourceId{
							Segments: []resourcemanager.ResourceIdSegment{
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticSubscriptions",
									FixedValue: pointer.To("subscriptions"),
								},
								{
									Type: resourcemanager.SubscriptionIdSegment,
									Name: "subscriptionId",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticResourceGroups",
									FixedValue: pointer.To("resourceGroups"),
								},
								{
									Type: resourcemanager.ResourceGroupSegment,
									Name: "resourceGroupName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticProviders",
									FixedValue: pointer.To("providers"),
								},
								{
									Type:       resourcemanager.ResourceProviderSegment,
									Name:       "staticMicrosoftRecoveryServices",
									FixedValue: pointer.To("Microsoft.RecoveryServices"),
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticVaults",
									FixedValue: pointer.To("vaults"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "resourceName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationFabrics",
									FixedValue: pointer.To("replicationFabrics"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "fabricName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationProtectionContainers",
									FixedValue: pointer.To("replicationProtectionContainers"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "protectionContainerName",
								},
								{
									Type:       resourcemanager.StaticSegment,
									Name:       "staticReplicationProtectedItems",
									FixedValue: pointer.To("replicationProtectedItems"),
								},
								{
									Type: resourcemanager.UserSpecifiedSegment,
									Name: "replicationProtectedItemName",
								},
							},
							Constants: map[string]resourcemanager.ConstantDetails{},
						}
						if rid.Matches(expectedResourceId) {
							rid.Segments = correctedResourceId.Segments
						}
						resource.ResourceIds["ReplicationProtectedItem"] = rid
					}
					item.Resources[resourceName] = resource
				}
			}
		}

		output = append(output, item)
	}

	return &output, nil
}
