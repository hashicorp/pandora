// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"sort"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func ParseSwaggerFileForTesting(t *testing.T, file string) (*importerModels.AzureApiDefinition, error) {
	// TODO: make this function private
	parsed, err := load("testdata/", file, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	var resourceProvider *string = nil // we're not filtering to just this RP, so it's fine
	resourceIds, err := parsed.ParseResourceIds(resourceProvider)
	if err != nil {
		t.Fatalf("parsing Resource Ids: %+v", err)
	}

	out, err := parsed.parse("Example", "2020-01-01", resourceProvider, *resourceIds)
	if err != nil {
		t.Fatalf("parsing file %q: %+v", file, err)
	}

	return out, nil
}

func validateParsedSwaggerResultMatches(t *testing.T, expected importerModels.AzureApiDefinition, actual *importerModels.AzureApiDefinition) {
	if actual == nil {
		t.Fatal("`actual` was nil")
	}
	if actual.ServiceName != expected.ServiceName {
		t.Fatalf("expected `ServiceName` to be %q but got %q", expected.ServiceName, actual.ServiceName)
	}
	if actual.ApiVersion != expected.ApiVersion {
		t.Fatalf("expected `ApiVersion` to be %q but got %q", expected.ApiVersion, actual.ApiVersion)
	}

	validateMapsMatch(t, expected.Resources, actual.Resources, "API Resource", validateParsedApiResourceMatches)
}

func validateParsedApiResourceMatches(t *testing.T, expected importerModels.AzureApiResource, actual importerModels.AzureApiResource, apiResourceName string) {
	t.Logf("Validating API Resource %q..", apiResourceName)
	// Validate each of the maps matches what we're expecting
	validateMapsMatch(t, expected.Constants, actual.Constants, "Constants", validateParsedConstantsMatch)
	validateMapsMatch(t, expected.Models, actual.Models, "Models", validateParsedModelsMatch)
	validateMapsMatch(t, expected.Operations, actual.Operations, "Operations", validateParsedOperationsMatch)
	validateMapsMatch(t, expected.ResourceIds, actual.ResourceIds, "Resource IDs", validateParsedResourceIDsMatch)
	validateObjectsMatch(t, expected.Terraform, actual.Terraform, "Terraform", validateParsedTerraformDetailsMatch)
}

func validateParsedConstantsMatch(t *testing.T, expected, actual models.SDKConstant, constantName string) {
	if expected.Type != actual.Type {
		t.Fatalf("expected Type to be %q but got %q for Constant %q", string(expected.Type), string(actual.Type), constantName)
	}
	validateMapsMatch(t, expected.Values, actual.Values, "Values", validateStringsMatch)
}

func validateParsedFieldsMatch(t *testing.T, expected importerModels.FieldDetails, actual importerModels.FieldDetails, fieldName string) {
	if expected.JsonName != actual.JsonName {
		t.Fatalf("expected `JsonName` to be %q but got %q for Field %q", expected.JsonName, actual.JsonName, fieldName)
	}
	if expected.ReadOnly != actual.ReadOnly {
		t.Fatalf("expected `ReadOnly` to be %t but got %t for Field %q", expected.ReadOnly, actual.ReadOnly, fieldName)
	}
	if expected.Required != actual.Required {
		t.Fatalf("expected `Required` to be %t but got %t for Field %q", expected.Required, actual.Required, fieldName)
	}
	if expected.Sensitive != actual.Sensitive {
		t.Fatalf("expected `Sensitive` to be %t but got %t for Field %q", expected.Sensitive, actual.Sensitive, fieldName)
	}

	validateParsedObjectDefinitionsMatch(t, expected.ObjectDefinition, actual.ObjectDefinition, fieldName)
}

func validateParsedModelsMatch(t *testing.T, expected importerModels.ModelDetails, actual importerModels.ModelDetails, modelName string) {
	t.Logf("Validating Model %q...", modelName)
	if pointer.From(expected.ParentTypeName) != pointer.From(actual.ParentTypeName) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `ParentTypeName` to be %q but got %q for Model %q", pointer.From(expected.ParentTypeName), pointer.From(actual.ParentTypeName), modelName)
	}
	if pointer.From(expected.TypeHintIn) != pointer.From(actual.TypeHintIn) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `TypeHintIn` to be %q but got %q for Model %q", pointer.From(expected.TypeHintIn), pointer.From(actual.TypeHintIn), modelName)
	}
	if pointer.From(expected.TypeHintValue) != pointer.From(actual.TypeHintValue) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `TypeHintValue` to be %q but got %q for Model %q", pointer.From(expected.TypeHintValue), pointer.From(actual.TypeHintValue), modelName)
	}
	if expected.Description != actual.Description {
		t.Fatalf("expected `Description` to be %q but got %q for Model %q", expected.Description, actual.Description, modelName)
	}
	validateMapsMatch(t, expected.Fields, actual.Fields, "Fields", validateParsedFieldsMatch)
}

func validateParsedObjectDefinitionsMatch(t *testing.T, expected, actual models.SDKObjectDefinition, fieldName string) {
	if expected.Type != actual.Type {
		t.Fatalf("expected `Type` to be %q but got %q for Field %q", string(expected.Type), string(actual.Type), fieldName)
	}
	if pointer.From(expected.ReferenceName) != pointer.From(actual.ReferenceName) {
		t.Fatalf("expected `ReferenceName` to be %q but got %q for Field %q", pointer.From(expected.ReferenceName), pointer.From(actual.ReferenceName), fieldName)
	}
	//// TODO: re-enable Min/Max/Unique
	//if pointer.From(expected.Maximum) != pointer.From(actual.Maximum) {
	//	t.Fatalf("expected `Maximum` to be %d but got %d for Field %q", pointer.From(expected.Maximum), pointer.From(actual.Maximum), fieldName)
	//}
	//if pointer.From(expected.Minimum) != pointer.From(actual.Minimum) {
	//	t.Fatalf("expected `Minimum` to be %d but got %d for Field %q", pointer.From(expected.Minimum), pointer.From(actual.Minimum), fieldName)
	//}
	//if pointer.From(expected.UniqueItems) != pointer.From(actual.UniqueItems) {
	//	t.Fatalf("expected `UniqueItems` to be %t but got %t for Field %q", pointer.From(expected.UniqueItems), pointer.From(actual.UniqueItems), fieldName)
	//}

	validateObjectsMatch(t, expected.NestedItem, actual.NestedItem, "NestedItem", validateParsedObjectDefinitionsMatch)
}

func validateParsedOperationsMatch(t *testing.T, expected, actual importerModels.OperationDetails, operationName string) {
	t.Logf("Validating Operation %q..", operationName)
	if expected.ContentType != actual.ContentType {
		t.Fatalf("expected `ContentType` to be %q but got %q for Operation %q", expected.ContentType, actual.ContentType, operationName)
	}
	validateSlicesMatch(t, expected.ExpectedStatusCodes, actual.ExpectedStatusCodes, "ExpectedStatusCodes", validateIntegersMatch)
	if pointer.From(expected.FieldContainingPaginationDetails) != pointer.From(actual.FieldContainingPaginationDetails) {
		t.Fatalf("expected `FieldContainingPaginationDetails` to be %q but got %q for Operation %q", pointer.From(expected.FieldContainingPaginationDetails), pointer.From(actual.FieldContainingPaginationDetails), operationName)
	}
	if expected.IsListOperation != actual.IsListOperation {
		t.Fatalf("expected `IsListOperation` to be %t but got %t for Operation %q", expected.IsListOperation, actual.IsListOperation, operationName)
	}
	if expected.LongRunning != actual.LongRunning {
		t.Fatalf("expected `LongRunning` to be %t but got %t for Operation %q", expected.LongRunning, actual.LongRunning, operationName)
	}
	if expected.Method != actual.Method {
		t.Fatalf("expected `Method` to be %q but got %q for Operation %q", expected.Method, actual.Method, operationName)
	}
	validateMapsMatch(t, expected.Options, actual.Options, "Options", validateParsedOptionsMatch)
	if pointer.From(expected.ResourceIdName) != pointer.From(actual.ResourceIdName) {
		t.Fatalf("expected `ResourceIdName` to be %q but got %q for Operation %q", pointer.From(expected.ResourceIdName), pointer.From(actual.ResourceIdName), operationName)
	}
	validateObjectsMatch(t, expected.RequestObject, actual.RequestObject, "RequestObject", validateParsedObjectDefinitionsMatch)
	validateObjectsMatch(t, expected.ResponseObject, actual.ResponseObject, "ResponseObject", validateParsedObjectDefinitionsMatch)
	if pointer.From(expected.UriSuffix) != pointer.From(actual.UriSuffix) {
		t.Fatalf("expected `UriSuffix` to be %q but got %q for Operation %q", pointer.From(expected.UriSuffix), pointer.From(actual.UriSuffix), operationName)
	}
}

func validateParsedOptionsMatch(t *testing.T, expected, actual models.SDKOperationOption, optionName string) {
	if pointer.From(expected.HeaderName) != pointer.From(actual.HeaderName) {
		t.Errorf("expected `HeaderName` to be %q but got %q for Option %q", pointer.From(expected.HeaderName), pointer.From(actual.HeaderName), optionName)
	}
	if pointer.From(expected.QueryStringName) != pointer.From(actual.QueryStringName) {
		t.Errorf("expected `QueryStringName` to be %q but got %q for Option %q", pointer.From(expected.QueryStringName), pointer.From(actual.QueryStringName), optionName)
	}
	if expected.Required != actual.Required {
		t.Errorf("expected `Required` to be %t but got %t for Option %q", expected.Required, actual.Required, optionName)
	}
	validateParsedOptionsObjectDefinitionsMatch(t, expected.ObjectDefinition, actual.ObjectDefinition, "OptionObjectDefinition")
}

func validateParsedOptionsObjectDefinitionsMatch(t *testing.T, expected, actual models.SDKOperationOptionObjectDefinition, fieldName string) {
	if expected.Type != actual.Type {
		t.Fatalf("expected `Type` to be %q but got %q for Field %q", string(expected.Type), string(actual.Type), fieldName)
	}
	if pointer.From(expected.ReferenceName) != pointer.From(actual.ReferenceName) {
		t.Fatalf("expected `ReferenceName` to be %q but got %q for Field %q", pointer.From(expected.ReferenceName), pointer.From(actual.ReferenceName), fieldName)
	}

	validateObjectsMatch(t, expected.NestedItem, actual.NestedItem, "NestedItem", validateParsedOptionsObjectDefinitionsMatch)
}

func validateParsedResourceIDsMatch(t *testing.T, expected, actual models.ResourceID, resourceIdName string) {
	if pointer.From(expected.CommonIDAlias) != pointer.From(actual.CommonIDAlias) {
		t.Errorf("expected `CommonIDAlias` to be %q but got %q for Resource ID %q", pointer.From(expected.CommonIDAlias), pointer.From(actual.CommonIDAlias), resourceIdName)
	}
	validateSlicesMatch(t, expected.ConstantNames, actual.ConstantNames, "ConstantNames", validateStringsMatch)
	validateSlicesMatch(t, expected.Segments, actual.Segments, "Segments", validateParsedResourceIDSegmentsMatch)
}

func validateParsedResourceIDSegmentsMatch(t *testing.T, expected, actual models.ResourceIDSegment, segmentName string) {
	if pointer.From(expected.ConstantReference) != pointer.From(actual.ConstantReference) {
		t.Errorf("expected `ConstantReference` to be %q but got %q for %s", pointer.From(expected.ConstantReference), pointer.From(actual.ConstantReference), segmentName)
	}
	// TODO: enable once the SDK migration is completed
	//if expected.ExampleValue != actual.ExampleValue {
	//	t.Errorf("expected `ExampleValue` to be %q but got %q for %s", expected.ExampleValue, actual.ExampleValue, segmentName)
	//}
	if pointer.From(expected.FixedValue) != pointer.From(actual.FixedValue) {
		t.Errorf("expected `FixedValue` to be %q but got %q for %s", pointer.From(expected.FixedValue), pointer.From(actual.FixedValue), segmentName)
	}
	if expected.Name != actual.Name {
		t.Errorf("expected `Name` to be %q but got %q for %s", expected.Name, actual.Name, segmentName)
	}
	if string(expected.Type) != string(actual.Type) {
		t.Errorf("expected `Type` to be %q but got %q for %s", string(expected.Type), string(actual.Type), segmentName)
	}
}

func validateParsedTerraformDetailsMatch(t *testing.T, expected, actual resourcemanager.TerraformDetails, _ string) {
	if len(expected.DataSources) > 0 || len(actual.DataSources) > 0 {
		t.Fatalf("unimplemented: data source comparisons")
	}
	if len(expected.Resources) > 0 || len(actual.Resources) > 0 {
		// At this time we don't implement Terraform Resource comparisons since we're not expecting
		// these to be present as a result of the Swagger Parser (these are the next stage).
		t.Fatalf("unimplemented: Terraform Resource comparisons")
	}
}

func validateIntegersMatch(t *testing.T, expected, actual int, key string) {
	if expected != actual {
		t.Fatalf("expected %q to be %d but got %d", key, expected, actual)
	}
}

func validateStringsMatch(t *testing.T, expected, actual string, key string) {
	if expected != actual {
		t.Fatalf("expected %q to be %q but got %q", key, expected, actual)
	}
}

// Generic helper functions below this point

func validateObjectsMatch[T any](t *testing.T, expected, actual *T, name string, innerAssert func(t *testing.T, expected T, actual T, key string)) {
	if expected != nil && actual == nil {
		t.Fatalf("expected %q to be %q but got nil for %q", name, expected, name)
	}
	if expected == nil && actual != nil {
		t.Fatalf("expected %q to be nil but got %q for %q", name, actual, name)
	}
	if expected != nil && actual != nil {
		innerAssert(t, *expected, *actual, name)
	}
}

func validateMapsMatch[T any](t *testing.T, expected, actual map[string]T, name string, innerAssert func(t *testing.T, expected T, actual T, key string)) {
	if len(actual) != len(expected) {
		t.Fatalf("expected there to be %d %q but got %d", len(expected), name, len(actual))
	}
	resourceKeys := uniqueKeys[T](actual, expected)
	for _, resourceKey := range resourceKeys {
		expectedItem, ok := expected[resourceKey]
		if !ok {
			t.Fatalf("found an unexpected `%s` called %q", name, resourceKey)
		}
		actualItem, ok := actual[resourceKey]
		if !ok {
			t.Fatalf("expected a `%s` called %q but got nil", name, resourceKey)
		}

		innerAssert(t, expectedItem, actualItem, resourceKey)
	}
}

func validateSlicesMatch[T any](t *testing.T, expected, actual []T, name string, innerAssert func(t *testing.T, expected T, actual T, key string)) {
	if len(actual) != len(expected) {
		t.Fatalf("expected there to be %d %q but got %d", len(expected), name, len(actual))
	}
	for i := range expected {
		expectedItem := expected[i]
		actualItem := actual[i]

		innerAssert(t, expectedItem, actualItem, fmt.Sprintf("%s item %d", name, i))
	}
}

func uniqueKeys[T any](first, second map[string]T) []string {
	keys := make(map[string]struct{})
	for key := range first {
		keys[key] = struct{}{}
	}
	for key := range second {
		keys[key] = struct{}{}
	}

	out := make([]string, 0)
	for k := range keys {
		out = append(out, k)
	}
	sort.Strings(out)
	return out
}
