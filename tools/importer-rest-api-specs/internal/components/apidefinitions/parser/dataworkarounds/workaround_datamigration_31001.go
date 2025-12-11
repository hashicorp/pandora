// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundDataMigration31001{}

// workaroundDataMigration31001 sets the correct casing for `MongoDbConnectionInfo` as the discriminated value. Since the
// swagger doesn't have this defined, the casing of this would switch back and forth on subsequent runs due to the way that we
// load/parse/flatten the swagger files.
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/31001
type workaroundDataMigration31001 struct {
}

func (workaroundDataMigration31001) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DataMigration" && apiVersion.APIVersion == "2021-06-30"
}

func (workaroundDataMigration31001) Name() string {
	return "DataMigration / 31001"
}

func (workaroundDataMigration31001) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resources := []string{
		"CustomOperation",
		"GET",
		"PATCH",
		"POST",
		"ProjectResource",
		"PUT",
		"ServiceResource",
		"ServiceTaskResource",
		"StandardOperation",
		"TaskResource",
	}

	for _, resource := range resources {
		r, ok := input.Resources[resource]
		if !ok {
			return nil, fmt.Errorf("expected a Resource named `%s` but didn't get one", resource)
		}

		model, ok := r.Models["MongoDbConnectionInfo"]
		if !ok {
			return nil, fmt.Errorf("expected a Model named `MongoDbConnectionInfo` but didn't get one")
		}

		model.DiscriminatedValue = pointer.To("MongoDbConnectionInfo")

		r.Models["MongoDbConnectionInfo"] = model
		input.Resources[resource] = r
	}

	return &input, nil
}
