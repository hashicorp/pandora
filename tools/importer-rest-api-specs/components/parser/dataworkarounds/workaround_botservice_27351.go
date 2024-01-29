// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ workaround = workaroundBotService27351{}

type workaroundBotService27351 struct {
}

func (workaroundBotService27351) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	// This workaround fixes an issue where the BotService Channel URI is defined using two subtly different Resource IDs.
	// Fix: https://github.com/Azure/azure-rest-api-specs/pull/27351
	//
	// The DELETE and GET define the Uri Parameter `channelName` as a String - whereas the PATCH and POST define it as
	// a Constant.
	// The result of this is that whilst we switch out the Resource ID for a Common ID, this inconsistency means we end up
	// with 2 different Resource IDs in the output, the Common ID (`BotServiceChannelId`) using a Constant Segment and another
	// Resource ID (`ChannelId`) using a String segment.
	//
	// As such this workaround fixes this issue by normalizing the resulting output - since these are the same endpoint/should
	// support the same values for this URI Segment.
	serviceMatches := apiDefinition.ServiceName == "BotService"
	apiVersions := map[string]struct{}{
		"2021-05-01-preview": {},
		"2022-06-15-preview": {},
		"2023-09-15-preview": {},
		"2020-06-02":         {},
		"2021-03-01":         {},
		"2022-09-15":         {},
	}
	_, apiVersionMatches := apiVersions[apiDefinition.ApiVersion]
	return serviceMatches && apiVersionMatches
}

func (workaroundBotService27351) Name() string {
	return "BotService / 27351"
}

func (workaroundBotService27351) Process(input models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	output := input

	resource, ok := output.Resources["Channel"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Channel` but didn't get one")
	}
	// ensure we've got the Resource ID we're going to switch over to
	if _, ok := resource.ResourceIds["BotServiceChannelId"]; !ok {
		return nil, fmt.Errorf("expected a Resource ID named `BotServiceChannelId` but didn't get one")
	}

	// ensure we've got the mismatched Resource ID in order to remove it
	if _, ok := resource.ResourceIds["ChannelId"]; !ok {
		return nil, fmt.Errorf("expected a Resource ID named `ChannelId` but didn't get one")
	}
	delete(resource.ResourceIds, "ChannelId")

	for operationName, operation := range resource.Operations {
		if operation.ResourceIdName != nil && *operation.ResourceIdName == "ChannelId" {
			operation.ResourceIdName = pointer.To("BotServiceChannelId")
		}
		resource.Operations[operationName] = operation
	}

	// ensure the Constant `EmailChannelAuthMethod` is updated to be an Integer rather than a Float
	constant, ok := resource.Constants["EmailChannelAuthMethod"]
	if !ok {
		return nil, fmt.Errorf("expected a Constant named `EmailChannelAuthMethod` but didn't get one")
	}
	constant.Type = resourcemanager.IntegerConstant
	resource.Constants["EmailChannelAuthMethod"] = constant

	output.Resources["Channel"] = resource

	return &output, nil
}
