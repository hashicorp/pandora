package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundMongoCluster38810{}

type workaroundMongoCluster38810 struct{}

func (workaroundMongoCluster38810) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "MongoCluster" && apiVersion.APIVersion == "2025-09-01"
}

func (workaroundMongoCluster38810) Name() string {
	return "MongoCluster / 38810"
}

func (workaroundMongoCluster38810) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["MongoClusters"]
	if !ok {
		return nil, errors.New("expected a resource named `MongoClusters` but didn't get one")
	}

	model, ok := resource.Models["MongoCluster"]
	if !ok {
		return nil, errors.New("couldn't find model `MongoCluster`")
	}

	identityField, ok := model.Fields["Identity"]
	if !ok {
		return nil, errors.New("couldn't find the field `Identity`")
	}

	identityField.ObjectDefinition.Type = sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType
	identityField.ObjectDefinition.ReferenceName = nil

	model.Fields["Identity"] = identityField
	resource.Models["MongoCluster"] = model
	input.Resources["MongoClusters"] = resource

	return &input, nil
}
