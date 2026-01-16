// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testhelpers

import (
	"fmt"
	"sort"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func ValidateParsedSwaggerResultMatches(t *testing.T, expected sdkModels.APIVersion, actual *sdkModels.APIVersion) {
	if actual == nil {
		t.Fatal("`actual` was nil")
	}
	if actual.APIVersion != expected.APIVersion {
		t.Fatalf("expected `APIVersion` to be %q but got %q", expected.APIVersion, actual.APIVersion)
	}

	validateMapsMatch(t, expected.Resources, actual.Resources, "API Resource", validateParsedApiResourceMatches)
}

func validateParsedApiResourceMatches(t *testing.T, expected, actual sdkModels.APIResource, apiResourceName string) {
	t.Logf("Validating API Resource %q..", apiResourceName)
	// Validate each of the maps matches what we're expecting
	validateMapsMatch(t, expected.Constants, actual.Constants, "Constants", validateParsedConstantsMatch)
	validateMapsMatch(t, expected.Models, actual.Models, "Models", validateParsedSDKModelsMatch)
	validateMapsMatch(t, expected.Operations, actual.Operations, "Operations", validateParsedOperationsMatch)
	validateMapsMatch(t, expected.ResourceIDs, actual.ResourceIDs, "Resource IDs", validateParsedResourceIDsMatch)
}

func validateParsedConstantsMatch(t *testing.T, expected, actual sdkModels.SDKConstant, constantName string) {
	if expected.Type != actual.Type {
		t.Fatalf("expected Type to be %q but got %q for Constant %q", string(expected.Type), string(actual.Type), constantName)
	}
	validateMapsMatch(t, expected.Values, actual.Values, "Values", validateStringsMatch)
}

func validateParsedSDKFieldsMatch(t *testing.T, expected, actual sdkModels.SDKField, fieldName string) {
	if expected.JsonName != actual.JsonName {
		t.Fatalf("expected `JsonName` to be %q but got %q for Field %q", expected.JsonName, actual.JsonName, fieldName)
	}
	// TODO: @tombuildsstuff: reenable readonly support
	//if expected.ReadOnly != actual.ReadOnly {
	//	t.Fatalf("expected `ReadOnly` to be %t but got %t for Field %q", expected.ReadOnly, actual.ReadOnly, fieldName)
	//}
	if expected.Required != actual.Required {
		t.Fatalf("expected `Required` to be %t but got %t for Field %q", expected.Required, actual.Required, fieldName)
	}
	if expected.Sensitive != actual.Sensitive {
		t.Fatalf("expected `Sensitive` to be %t but got %t for Field %q", expected.Sensitive, actual.Sensitive, fieldName)
	}

	validateParsedObjectDefinitionsMatch(t, expected.ObjectDefinition, actual.ObjectDefinition, fieldName)
}

func validateParsedSDKModelsMatch(t *testing.T, expected, actual sdkModels.SDKModel, modelName string) {
	t.Logf("Validating Model %q...", modelName)
	if pointer.From(expected.ParentTypeName) != pointer.From(actual.ParentTypeName) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `ParentTypeName` to be %q but got %q for Model %q", pointer.From(expected.ParentTypeName), pointer.From(actual.ParentTypeName), modelName)
	}
	if pointer.From(expected.FieldNameContainingDiscriminatedValue) != pointer.From(actual.FieldNameContainingDiscriminatedValue) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `FieldNameContainingDiscriminatedValue` to be %q but got %q for Model %q", pointer.From(expected.FieldNameContainingDiscriminatedValue), pointer.From(actual.FieldNameContainingDiscriminatedValue), modelName)
	}
	if pointer.From(expected.DiscriminatedValue) != pointer.From(actual.DiscriminatedValue) {
		// NOTE: this should be nil when unset, otherwise a value
		t.Fatalf("expected `DiscriminatedValue` to be %q but got %q for Model %q", pointer.From(expected.DiscriminatedValue), pointer.From(actual.DiscriminatedValue), modelName)
	}
	// TODO: thread description through once https://github.com/hashicorp/pandora/issues/3325 is completed
	//if expected.Description != actual.Description {
	//	t.Fatalf("expected `Description` to be %q but got %q for Model %q", expected.Description, actual.Description, modelName)
	//}
	validateMapsMatch(t, expected.Fields, actual.Fields, "Fields", validateParsedSDKFieldsMatch)
}

func validateParsedObjectDefinitionsMatch(t *testing.T, expected, actual sdkModels.SDKObjectDefinition, fieldName string) {
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

func validateParsedOperationsMatch(t *testing.T, expected, actual sdkModels.SDKOperation, operationName string) {
	t.Logf("Validating Operation %q..", operationName)
	if expected.ContentType != actual.ContentType {
		t.Fatalf("expected `ContentType` to be %q but got %q for Operation %q", expected.ContentType, actual.ContentType, operationName)
	}
	validateSlicesMatch(t, expected.ExpectedStatusCodes, actual.ExpectedStatusCodes, "ExpectedStatusCodes", validateIntegersMatch)
	if pointer.From(expected.FieldContainingPaginationDetails) != pointer.From(actual.FieldContainingPaginationDetails) {
		t.Fatalf("expected `FieldContainingPaginationDetails` to be %q but got %q for Operation %q", pointer.From(expected.FieldContainingPaginationDetails), pointer.From(actual.FieldContainingPaginationDetails), operationName)
	}
	if expected.LongRunning != actual.LongRunning {
		t.Fatalf("expected `LongRunning` to be %t but got %t for Operation %q", expected.LongRunning, actual.LongRunning, operationName)
	}
	if expected.Method != actual.Method {
		t.Fatalf("expected `Method` to be %q but got %q for Operation %q", expected.Method, actual.Method, operationName)
	}
	validateMapsMatch(t, expected.Options, actual.Options, "Options", validateParsedOptionsMatch)
	if pointer.From(expected.ResourceIDName) != pointer.From(actual.ResourceIDName) {
		t.Fatalf("expected `ResourceIDName` to be %q but got %q for Operation %q", pointer.From(expected.ResourceIDName), pointer.From(actual.ResourceIDName), operationName)
	}
	validateObjectsMatch(t, expected.RequestObject, actual.RequestObject, "RequestObject", validateParsedObjectDefinitionsMatch)
	validateObjectsMatch(t, expected.ResponseObject, actual.ResponseObject, "ResponseObject", validateParsedObjectDefinitionsMatch)
	if pointer.From(expected.URISuffix) != pointer.From(actual.URISuffix) {
		t.Fatalf("expected `URISuffix` to be %q but got %q for Operation %q", pointer.From(expected.URISuffix), pointer.From(actual.URISuffix), operationName)
	}
}

func validateParsedOptionsMatch(t *testing.T, expected, actual sdkModels.SDKOperationOption, optionName string) {
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

func validateParsedOptionsObjectDefinitionsMatch(t *testing.T, expected, actual sdkModels.SDKOperationOptionObjectDefinition, fieldName string) {
	if expected.Type != actual.Type {
		t.Fatalf("expected `Type` to be %q but got %q for Field %q", string(expected.Type), string(actual.Type), fieldName)
	}
	if pointer.From(expected.ReferenceName) != pointer.From(actual.ReferenceName) {
		t.Fatalf("expected `ReferenceName` to be %q but got %q for Field %q", pointer.From(expected.ReferenceName), pointer.From(actual.ReferenceName), fieldName)
	}

	validateObjectsMatch(t, expected.NestedItem, actual.NestedItem, "NestedItem", validateParsedOptionsObjectDefinitionsMatch)
}

func validateParsedResourceIDsMatch(t *testing.T, expected, actual sdkModels.ResourceID, resourceIdName string) {
	if pointer.From(expected.CommonIDAlias) != pointer.From(actual.CommonIDAlias) {
		t.Errorf("expected `CommonIDAlias` to be %q but got %q for Resource ID %q", pointer.From(expected.CommonIDAlias), pointer.From(actual.CommonIDAlias), resourceIdName)
	}
	validateSlicesMatch(t, expected.ConstantNames, actual.ConstantNames, "ConstantNames", validateStringsMatch)
	validateSlicesMatch(t, expected.Segments, actual.Segments, "Segments", validateParsedResourceIDSegmentsMatch)
}

func validateParsedResourceIDSegmentsMatch(t *testing.T, expected, actual sdkModels.ResourceIDSegment, segmentName string) {
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
