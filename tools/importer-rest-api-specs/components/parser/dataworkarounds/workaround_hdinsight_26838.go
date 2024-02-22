// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ workaround = workaroundHDInsight26838{}

// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/26838
type workaroundHDInsight26838 struct{}

func (workaroundHDInsight26838) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	// The field `kind` is a constant within the API but isn't documented as such - whilst
	// we've previously been using this as a String - since we need to recase the value as
	// the API returns this inconsistently - and there's a fixed list of possible values
	// PR https://github.com/Azure/azure-rest-api-specs/pull/26838 updates the field within
	// the API Definition to be an Enum - so that we can transform this into a Constant.
	//
	// NOTE: the fix for this currently spans multiple API Versions
	supportedApiVersions := map[string]struct{}{
		"2018-06-01-preview": {},
		"2021-06-01":         {},
		"2023-04-15-preview": {},
		"2023-08-15-preview": {},
	}

	serviceMatches := apiDefinition.ServiceName == "HDInsight"
	_, apiVersionMatches := supportedApiVersions[apiDefinition.ApiVersion]
	return serviceMatches && apiVersionMatches
}

func (workaroundHDInsight26838) Name() string {
	return "HDInsight / 26838"
}

func (workaroundHDInsight26838) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["Clusters"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Clusters`")
	}

	model, ok := resource.Models["ClusterDefinition"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `ClusterDefinition`")
	}
	field, ok := model.Fields["Kind"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `Kind`")
	}
	field.ObjectDefinition = &importerModels.ObjectDefinition{
		Type:          importerModels.ObjectDefinitionReference,
		ReferenceName: pointer.To("ClusterKind"),
	}
	model.Fields["Kind"] = field
	resource.Models["ClusterDefinition"] = model

	// then add the backing constant
	if v, ok := resource.Constants["ClusterKind"]; ok {
		return nil, fmt.Errorf("an existing Constant exists with the name `ClusterKind`: %+v", v)
	}
	resource.Constants["ClusterKind"] = resourcemanager.ConstantDetails{
		Type: resourcemanager.StringConstant,
		Values: map[string]string{
			"Hadoop":          "HADOOP",
			"HBase":           "HBASE",
			"Kafka":           "KAFKA",
			"InteractiveHive": "INTERACTIVEHIVE",
			"Spark":           "SPARK",
		},
	}

	apiDefinition.Resources["Clusters"] = resource
	return &apiDefinition, nil
}
