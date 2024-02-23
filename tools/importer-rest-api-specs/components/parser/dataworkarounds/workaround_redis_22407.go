// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type workaroundRedis22407 struct {
}

func (w workaroundRedis22407) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Redis"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-06-01" || apiDefinition.ApiVersion == "2023-04-01" || apiDefinition.ApiVersion == "2023-08-01"
	return serviceMatches && apiVersionMatches
}

func (w workaroundRedis22407) Name() string {
	return "Redis / 22407"
}

func (w workaroundRedis22407) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	if resource, ok := apiDefinition.Resources["Redis"]; ok {
		if model, ok := resource.Models["RedisCommonPropertiesRedisConfiguration"]; ok {

			if _, ok := model.Fields["NotifyKeyspaceEvents"]; !ok {
				model.Fields["NotifyKeyspaceEvents"] = importerModels.FieldDetails{
					Required:    false,
					ReadOnly:    false,
					Sensitive:   false,
					JsonName:    "notify-keyspace-events",
					Description: "The KeySpace Events which should be monitored.",
					ObjectDefinition: &importerModels.ObjectDefinition{
						Type: importerModels.ObjectDefinitionString,
					},
				}
			}
			resource.Models["RedisCommonPropertiesRedisConfiguration"] = model
		}
		apiDefinition.Resources["Redis"] = resource
	}
	return &apiDefinition, nil
}
