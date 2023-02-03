package dataworkarounds

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type workaroundRedis22407 struct {
}

func (w workaroundRedis22407) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Redis"
	apiVersionMatches := apiDefinition.ApiVersion == "2021-06-01" || apiDefinition.ApiVersion == "2022-05-01" || apiDefinition.ApiVersion == "2022-06-01"
	return serviceMatches && apiVersionMatches
}

func (w workaroundRedis22407) Name() string {
	return "Redis / 22407"
}

func (w workaroundRedis22407) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	if resource, ok := apiDefinition.Resources["Redis"]; ok {
		if model, ok := resource.Models["RedisCommonPropertiesRedisConfiguration"]; ok {

			if _, ok := model.Fields["NotifyKeyspaceEvents"]; !ok {
				model.Fields["NotifyKeyspaceEvents"] = models.FieldDetails{
					Required:    false,
					ReadOnly:    false,
					Sensitive:   false,
					JsonName:    "notify-keyspace-events",
					Description: "The KeySpace Events which should be monitored.",
					ObjectDefinition: &models.ObjectDefinition{
						Type: models.ObjectDefinitionString,
					},
				}
			}
			resource.Models["RedisCommonPropertiesRedisConfiguration"] = model
		}
		apiDefinition.Resources["Redis"] = resource
	}
	return &apiDefinition, nil
}
