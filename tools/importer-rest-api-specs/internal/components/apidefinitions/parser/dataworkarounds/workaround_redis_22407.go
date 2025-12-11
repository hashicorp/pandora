// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type workaroundRedis22407 struct {
}

func (w workaroundRedis22407) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Redis"
	apiVersionMatches := apiVersion.APIVersion == "2022-06-01" || apiVersion.APIVersion == "2023-04-01" || apiVersion.APIVersion == "2023-08-01"
	return serviceMatches && apiVersionMatches
}

func (w workaroundRedis22407) Name() string {
	return "Redis / 22407"
}

func (w workaroundRedis22407) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	if resource, ok := input.Resources["Redis"]; ok {
		if model, ok := resource.Models["RedisCommonPropertiesRedisConfiguration"]; ok {

			if _, ok := model.Fields["NotifyKeyspaceEvents"]; !ok {
				model.Fields["NotifyKeyspaceEvents"] = sdkModels.SDKField{
					Required:    false,
					ReadOnly:    false,
					Sensitive:   false,
					JsonName:    "notify-keyspace-events",
					Description: "The KeySpace Events which should be monitored.",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				}
			}
			resource.Models["RedisCommonPropertiesRedisConfiguration"] = model
		}
		input.Resources["Redis"] = resource
	}
	return &input, nil
}
