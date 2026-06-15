// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = WorkaroundWeb43978{}

type WorkaroundWeb43978 struct{}

func (WorkaroundWeb43978) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Web"
	apiVersionMatches := apiVersion.APIVersion == "2023-01-01"
	return serviceMatches && apiVersionMatches
}

func (w WorkaroundWeb43978) Name() string {
	return "Web / 43978"
}

func (w WorkaroundWeb43978) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["StaticSites"]
	if !ok {
		return nil, errors.New("expected a `StaticSites` resource but didn't get one")
	}

	model, ok := resource.Models["ResponseMessageEnvelopeRemotePrivateEndpointConnection"]
	if !ok {
		return nil, errors.New("expected an Model named `ResponseMessageEnvelopeRemotePrivateEndpointConnection` but didn't get one")
	}

	propertyField, ok := model.Fields["Properties"]
	if !ok {
		return nil, errors.New("expected an Field named `Properties` but didn't get one")
	}

	if propertyField.ObjectDefinition.ReferenceName == pointer.To("RemotePrivateEndpointConnectionProperties") {
		return nil, fmt.Errorf("%s - expected ResponseObject.ReferenceName for Field named `Properties` to not be RemotePrivateEndpointConnectionProperties, this workaround can be removed", resource.Name)
	}

	propertyField.ObjectDefinition = sdkModels.SDKObjectDefinition{
		ReferenceName: pointer.To("RemotePrivateEndpointConnectionProperties"),
		Type:          sdkModels.ReferenceSDKObjectDefinitionType,
		Nullable:      false,
	}

	model.Fields["Properties"] = propertyField

	return &input, nil
}
