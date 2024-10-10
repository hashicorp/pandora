// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundSubscriptions20254{}

// workaroundSubscriptions20254 works around the `SubscriptionCancel` API not exposing the `IgnoreResourceCheck` querystring parameter
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/20254
type workaroundSubscriptions20254 struct {
}

func (w workaroundSubscriptions20254) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Subscription" && apiVersion.APIVersion == "2021-10-01"
}

func (w workaroundSubscriptions20254) Name() string {
	return "Subscription / 20254"
}

func (w workaroundSubscriptions20254) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	output := input

	subscriptionResource, ok := input.Resources["Subscriptions"]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource named `Subscriptions` but didn't get one")
	}
	operation, ok := subscriptionResource.Operations["SubscriptionCancel"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `SubscriptionCancel` but didn't get one")
	}
	operation.Options = map[string]sdkModels.SDKOperationOption{
		// IgnoreResourceCheck allows deleting a Subscription even if it contains nested Resources
		"IgnoreResourceCheck": {
			QueryStringName: pointer.To("IgnoreResourceCheck"),
			ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
				Type: sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
			},
			Required: false,
		},
	}
	subscriptionResource.Operations["SubscriptionCancel"] = operation
	output.Resources["Subscriptions"] = subscriptionResource

	return &output, nil
}
