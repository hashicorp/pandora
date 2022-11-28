package dataworkarounds

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ workaround = workaroundRecoveryServicesSiteRecovery21667{}

type workaroundRecoveryServicesSiteRecovery21667 struct {
}

func (workaroundRecoveryServicesSiteRecovery21667) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "RecoveryServicesSiteRecovery"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-05-01" || apiDefinition.ApiVersion == "2022-10-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundRecoveryServicesSiteRecovery21667) Name() string {
	return "RecoveryServicesSiteRecovery / 21667"
}

func (w workaroundRecoveryServicesSiteRecovery21667) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resourcesToPatch := []string{
		"RecoveryPoints",
		"ReplicationProtectedItems",
		"TargetComputeSizes",
	}
	for _, resourceName := range resourcesToPatch {
		if resource, ok := apiDefinition.Resources[resourceName]; ok {
			if rid, ok := resource.ResourceIds["ReplicationProtectedItem"]; ok {
				if rid.Matches(w.expectedResourceId()) {
					rid.Segments = w.correctedResourceId().Segments
				}
				resource.ResourceIds["ReplicationProtectedItem"] = rid
			}
			apiDefinition.Resources[resourceName] = resource
		}
	}
	return &apiDefinition, nil
}

func (w workaroundRecoveryServicesSiteRecovery21667) expectedResourceId() models.ParsedResourceId {
	return models.ParsedResourceId{
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
}

func (w workaroundRecoveryServicesSiteRecovery21667) correctedResourceId() models.ParsedResourceId {
	return models.ParsedResourceId{
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
}
