// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"fmt"
	"reflect"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
)

// renderChangeToMarkdown renders a summary of this change in Markdown
func renderChangeToMarkdown(input changes.Change) (*string, error) {
	switch input.(type) {
	// CommonTypes
	case changes.CommonTypesApiVersionAdded:
		{
			v := input.(changes.CommonTypesApiVersionAdded)
			line := fmt.Sprintf("**New CommonTypes API Version:** `%s`.", v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesApiVersionRemoved:
		{
			v := input.(changes.CommonTypesApiVersionRemoved)
			line := fmt.Sprintf("**Removed CommonTypes API Version:** `%s`.", v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantAdded:
		{
			v := input.(changes.CommonTypesConstantAdded)
			keysAndValues := strings.Join(sortConstantKeysAndValues(v.KeysAndValues), ", ")
			line := fmt.Sprintf("**New CommonTypes Constant:** `%s` (Type `%s`) in `%s`. Possible Values: %s.", v.ConstantName, v.ConstantType, v.ApiVersion, keysAndValues)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantKeyValueAdded:
		{
			v := input.(changes.CommonTypesConstantKeyValueAdded)
			line := fmt.Sprintf("**New Key/Value for CommonTypes Constant:** `%s` - Key `%s` / Value `%s` in `%s`.", v.ConstantName, v.ConstantKey, v.ConstantValue, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantKeyValueChanged:
		{
			v := input.(changes.CommonTypesConstantKeyValueChanged)
			line := fmt.Sprintf("**Updated Value for CommonTypes Constant Key:** Constant `%s` Key `%s` - Old Value `%s` / New Value `%s` in `%s`.", v.ConstantName, v.ConstantKey, v.OldConstantValue, v.NewConstantValue, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantKeyValueRemoved:
		{
			v := input.(changes.CommonTypesConstantKeyValueRemoved)
			line := fmt.Sprintf("**Removed Key/Value for CommonTypes Constant:** `%s` - Key `%s` / Value `%s` in `%s`.", v.ConstantName, v.ConstantKey, v.ConstantValue, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantRemoved:
		{
			// intentionally not outputting the old values for now, but they're on the object if this is useful
			v := input.(changes.CommonTypesConstantRemoved)
			line := fmt.Sprintf("**Removed CommonTypes Constant:** `%s` (Type `%s`) in `%s`.", v.ConstantName, v.ConstantType, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesConstantTypeChanged:
		{
			v := input.(changes.CommonTypesConstantTypeChanged)
			line := fmt.Sprintf("**Updated Type for CommonTypes Constant:** `%s` - Old Type `%s` / New Type `%s` in `%s`.", v.ConstantName, v.OldType, v.NewType, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesModelAdded:
		{
			v := input.(changes.CommonTypesModelAdded)
			line := fmt.Sprintf("**CommonTypes Model Added:** `%s` in `%s`.", v.ModelName, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.CommonTypesModelRemoved:
		{
			v := input.(changes.CommonTypesModelRemoved)
			line := fmt.Sprintf("**CommonTypes Model Removed:** `%s` in `%s`.", v.ModelName, v.ApiVersion)
			return trimSpaceAround(line)
		}

	// Services
	case changes.ServiceAdded:
		{
			v := input.(changes.ServiceAdded)
			line := fmt.Sprintf("**New Service:** `%s`.", v.ServiceName)
			return trimSpaceAround(line)
		}
	case changes.ServiceRemoved:
		{
			v := input.(changes.ServiceRemoved)
			line := fmt.Sprintf("**Removed Service:** `%s`.", v.ServiceName)
			return trimSpaceAround(line)
		}

		// API Versions
	case changes.ApiVersionAdded:
		{
			v := input.(changes.ApiVersionAdded)
			line := fmt.Sprintf("**New API Version:** `%s` in `%s`.", v.ApiVersion, v.ServiceName)
			return trimSpaceAround(line)
		}
	case changes.ApiVersionRemoved:
		{
			v := input.(changes.ApiVersionRemoved)
			line := fmt.Sprintf("**Removed API Version:** `%s` in `%s`.", v.ApiVersion, v.ServiceName)
			return trimSpaceAround(line)
		}

		// API Resources
	case changes.ApiResourceAdded:
		{
			v := input.(changes.ApiResourceAdded)
			line := fmt.Sprintf("**New API Resource:** `%s` in `%s@%s`.", v.ResourceName, v.ServiceName, v.ApiVersion)
			return trimSpaceAround(line)
		}
	case changes.ApiResourceRemoved:
		{
			v := input.(changes.ApiResourceRemoved)
			line := fmt.Sprintf("**Removed API Resource:** `%s` in `%s@%s`.", v.ResourceName, v.ServiceName, v.ApiVersion)
			return trimSpaceAround(line)
		}

	// Constants
	case changes.ConstantAdded:
		{
			v := input.(changes.ConstantAdded)
			keysAndValues := strings.Join(sortConstantKeysAndValues(v.KeysAndValues), ", ")
			line := fmt.Sprintf("**New Constant:** `%s` (Type `%s`) in `%s@%s/%s`. Possible Values: %s.", v.ConstantName, v.ConstantType, v.ServiceName, v.ApiVersion, v.ResourceName, keysAndValues)
			return trimSpaceAround(line)
		}
	case changes.ConstantKeyValueAdded:
		{
			v := input.(changes.ConstantKeyValueAdded)
			line := fmt.Sprintf("**New Key/Value for Constant:** `%s` - Key `%s` / Value `%s` in `%s@%s/%s`.", v.ConstantName, v.ConstantKey, v.ConstantValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ConstantKeyValueChanged:
		{
			v := input.(changes.ConstantKeyValueChanged)
			line := fmt.Sprintf("**Updated Value for Constant Key:** Constant `%s` Key `%s` - Old Value `%s` / New Value `%s` in `%s@%s/%s`.", v.ConstantName, v.ConstantKey, v.OldConstantValue, v.NewConstantValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ConstantKeyValueRemoved:
		{
			v := input.(changes.ConstantKeyValueRemoved)
			line := fmt.Sprintf("**Removed Key/Value for Constant:** `%s` - Key `%s` / Value `%s` in `%s@%s/%s`.", v.ConstantName, v.ConstantKey, v.ConstantValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ConstantRemoved:
		{
			// intentionally not outputting the old values for now, but they're on the object if this is useful
			v := input.(changes.ConstantRemoved)
			line := fmt.Sprintf("**Removed Constant:** `%s` (Type `%s`) in `%s@%s/%s`.", v.ConstantName, v.ConstantType, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ConstantTypeChanged:
		{
			v := input.(changes.ConstantTypeChanged)
			line := fmt.Sprintf("**Updated Type for Constant:** `%s` - Old Type `%s` / New Type `%s` in `%s@%s/%s`.", v.ConstantName, v.OldType, v.NewType, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}

	// Fields
	case changes.FieldAdded:
		{
			v := input.(changes.FieldAdded)
			line := fmt.Sprintf("**Field Added:** `%s` to Model `%s` in `%s@%s/%s`.", v.FieldName, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.FieldIsNowOptional:
		{
			v := input.(changes.FieldIsNowOptional)
			line := fmt.Sprintf("**Field Now Optional:** `%s` in Model `%s` in `%s@%s/%s`.", v.FieldName, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.FieldIsNowRequired:
		{
			v := input.(changes.FieldIsNowRequired)
			line := fmt.Sprintf("**Field Now Required:** `%s` in Model `%s` in `%s@%s/%s`.", v.FieldName, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.FieldJsonNameChanged:
		{
			v := input.(changes.FieldJsonNameChanged)
			line := fmt.Sprintf("**Field JsonName Changed:** `%s` (was `%s` now `%s`) in Model `%s` in `%s@%s/%s`.", v.FieldName, v.OldValue, v.NewValue, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.FieldObjectDefinitionChanged:
		{
			v := input.(changes.FieldObjectDefinitionChanged)
			line := fmt.Sprintf("**Field Object Definition Changed:** `%s` (was `%s` now `%s`) in Model `%s` in `%s@%s/%s`.", v.FieldName, v.OldValue, v.NewValue, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.FieldRemoved:
		{
			v := input.(changes.FieldRemoved)
			line := fmt.Sprintf("**Field Removed:** `%s` from Model `%s` in `%s@%s/%s`.", v.FieldName, v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}

		// Models

	// Models
	case changes.ModelAdded:
		{
			v := input.(changes.ModelAdded)
			line := fmt.Sprintf("**Model Added:** `%s` in `%s@%s/%s`.", v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelDiscriminatedParentTypeAdded:
		{
			v := input.(changes.ModelDiscriminatedParentTypeAdded)
			line := fmt.Sprintf("**Parent Type was Added to Model:** `%s` (now `%s`) in `%s@%s/%s`.", v.ModelName, v.NewParentModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelDiscriminatedParentTypeChanged:
		{
			v := input.(changes.ModelDiscriminatedParentTypeChanged)
			line := fmt.Sprintf("**Parent Type was Changed for Model:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.ModelName, v.OldParentModelName, v.NewParentModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelDiscriminatedParentTypeRemoved:
		{
			v := input.(changes.ModelDiscriminatedParentTypeRemoved)
			line := fmt.Sprintf("**Parent Type was Removed for Model:** `%s` (was `%s`) in `%s@%s/%s`.", v.ModelName, v.OldParentModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelDiscriminatedTypeHintInChanged:
		{
			v := input.(changes.ModelDiscriminatedTypeHintInChanged)
			line := fmt.Sprintf("**Model has an updated value for Discriminated TypeHintIn:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.ModelName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelDiscriminatedTypeValueChanged:
		{
			v := input.(changes.ModelDiscriminatedTypeValueChanged)
			line := fmt.Sprintf("**Model has an updated value for Discriminated Type Value:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.ModelName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ModelRemoved:
		{
			v := input.(changes.ModelRemoved)
			line := fmt.Sprintf("**Model Removed:** `%s` in `%s@%s/%s`.", v.ModelName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}

	// Operations
	case changes.OperationAdded:
		{
			v := input.(changes.OperationAdded)
			line := fmt.Sprintf("**Operation Added:** `%s` (URI `%s`) in `%s@%s/%s`.", v.OperationName, v.Uri, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationContentTypeChanged:
		{
			v := input.(changes.OperationContentTypeChanged)
			line := fmt.Sprintf("**Operation Content Type Changed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldContentType, v.NewContentType, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationExpectedStatusCodesChanged:
		{
			v := input.(changes.OperationExpectedStatusCodesChanged)
			line := fmt.Sprintf("**Operation Expected Status Codes Changed:** `%s` (was `%+v` now `%+v`) in `%s@%s/%s`.", v.OperationName, v.OldExpectedStatusCodes, v.NewExpectedStatusCodes, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationLongRunningAdded:
		{
			v := input.(changes.OperationLongRunningAdded)
			line := fmt.Sprintf("**Operation Is Now Long Running:** `%s` in `%s@%s/%s`.", v.OperationName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationLongRunningRemoved:
		{
			v := input.(changes.OperationLongRunningRemoved)
			line := fmt.Sprintf("**Operation Is No Longer Long Running:** `%s` in `%s@%s/%s`.", v.OperationName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationMethodChanged:
		{
			v := input.(changes.OperationMethodChanged)
			line := fmt.Sprintf("**Operation uses a different HTTP Method:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationOptionsAdded:
		{
			v := input.(changes.OperationOptionsAdded)
			line := fmt.Sprintf("**Operation Option Added:** `%s` now supports `%s` in `%s@%s/%s`.", v.OperationName, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationOptionsChanged:
		{
			v := input.(changes.OperationOptionsChanged)
			line := fmt.Sprintf("**Operation Option Changed:** `%s` - `%s` is now `%s` in `%s@%s/%s`.", v.OperationName, v.NewValue, v.OldValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationOptionsRemoved:
		{
			v := input.(changes.OperationOptionsRemoved)
			line := fmt.Sprintf("**Operation Option Removed:** `%s` no longer `%s` in `%s@%s/%s`.", v.OperationName, v.OldValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationPaginationFieldChanged:
		{
			v := input.(changes.OperationPaginationFieldChanged)
			line := fmt.Sprintf("**Operation uses a new Field for Pagination:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationRemoved:
		{
			v := input.(changes.OperationRemoved)
			line := fmt.Sprintf("**Operation Removed:** `%s` (URI `%s`) in `%s@%s/%s`.", v.OperationName, v.Uri, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationRequestObjectAdded:
		{
			v := input.(changes.OperationRequestObjectAdded)
			line := fmt.Sprintf("**Operation Request Object Added:** `%s` (Type `%s`) in `%s@%s/%s`.", v.OperationName, v.NewRequestObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationRequestObjectChanged:
		{
			v := input.(changes.OperationRequestObjectChanged)
			line := fmt.Sprintf("**Operation Request Object Changed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldRequestObject, v.NewRequestObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationRequestObjectRemoved:
		{
			v := input.(changes.OperationRequestObjectRemoved)
			line := fmt.Sprintf("**Operation Request Object Removed:** `%s` (Type `%s`) in `%s@%s/%s`.", v.OperationName, v.OldRequestObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResourceIdAdded:
		{
			v := input.(changes.OperationResourceIdAdded)
			line := fmt.Sprintf("**Operation Resource ID Added:** `%s` (now `%s`) in `%s@%s/%s`.", v.OperationName, v.NewResourceIdName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResourceIdChanged:
		{
			v := input.(changes.OperationResourceIdChanged)
			line := fmt.Sprintf("**Operation Resource ID Changed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldResourceIdName, v.NewResourceIdName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResourceIdRemoved:
		{
			v := input.(changes.OperationResourceIdRemoved)
			line := fmt.Sprintf("**Operation Resource ID Removed:** `%s` (was `%s`) in `%s@%s/%s`.", v.OperationName, v.OldResourceIdName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResourceIdRenamed:
		{
			v := input.(changes.OperationResourceIdRenamed)
			line := fmt.Sprintf("**Operation Resource ID was Renamed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldResourceIdName, v.NewResourceIdName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResponseObjectAdded:
		{
			v := input.(changes.OperationResponseObjectAdded)
			line := fmt.Sprintf("**Operation Response Object Added:** `%s` (Type `%s`) in `%s@%s/%s`.", v.OperationName, v.NewResponseObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResponseObjectChanged:
		{
			v := input.(changes.OperationResponseObjectChanged)
			line := fmt.Sprintf("**Operation Response Object Changed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldResponseObject, v.NewResponseObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationResponseObjectRemoved:
		{
			v := input.(changes.OperationResponseObjectRemoved)
			line := fmt.Sprintf("**Operation Response Object Removed:** `%s` (Type `%s`) in `%s@%s/%s`.", v.OperationName, v.OldResponseObject, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationUriSuffixAdded:
		{
			v := input.(changes.OperationUriSuffixAdded)
			line := fmt.Sprintf("**Operation URISuffix Added:** `%s` (now `%s`) in `%s@%s/%s`.", v.OperationName, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationUriSuffixChanged:
		{
			v := input.(changes.OperationUriSuffixChanged)
			line := fmt.Sprintf("**Operation URISuffix Changed:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.OperationUriSuffixRemoved:
		{
			v := input.(changes.OperationUriSuffixRemoved)
			line := fmt.Sprintf("**Operation URISuffix Removed:** `%s` (now `%s`) in `%s@%s/%s`.", v.OperationName, v.OldValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}

	// Resource IDs
	case changes.ResourceIdAdded:
		{
			v := input.(changes.ResourceIdAdded)
			line := fmt.Sprintf("**New Resource ID:** `%s` (ID `%s`) in `%s@%s/%s`.", v.ResourceIdName, v.ResourceIdValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdCommonIdAdded:
		{
			v := input.(changes.ResourceIdCommonIdAdded)
			line := fmt.Sprintf("**Resource ID is now a Common ID:** `%s` (Alias `%s` / ID `%s`) in `%s@%s/%s`.", v.ResourceIdName, v.CommonAliasName, v.ResourceIdValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdCommonIdChanged:
		{
			v := input.(changes.ResourceIdCommonIdChanged)
			line := fmt.Sprintf("**Resource ID has changed it's Common ID:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.ResourceIdName, v.OldCommonAliasName, v.NewCommonAliasName, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdCommonIdRemoved:
		{
			v := input.(changes.ResourceIdCommonIdRemoved)
			line := fmt.Sprintf("**Resource ID is no longer a Common ID:** `%s` (Alias `%s` / ID `%s`) in `%s@%s/%s`.", v.ResourceIdName, v.CommonAliasName, v.ResourceIdValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdRemoved:
		{
			v := input.(changes.ResourceIdRemoved)
			line := fmt.Sprintf("**Removed Resource ID:** `%s` (ID `%s`) in `%s@%s/%s`.", v.ResourceIdName, v.ResourceIdValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdSegmentChangedValue:
		{
			v := input.(changes.ResourceIdSegmentChangedValue)
			line := fmt.Sprintf("**Resource ID Segment (Index %d) Changed Value:** `%s` (was `%s` now `%s`) in `%s@%s/%s`.", v.SegmentIndex, v.ResourceIdName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	case changes.ResourceIdSegmentsChangedLength:
		{
			v := input.(changes.ResourceIdSegmentsChangedLength)
			line := fmt.Sprintf("**Resource ID Segments Changed:** `%s` (was `%+v` now `%+v`) in `%s@%s/%s`.", v.ResourceIdName, v.OldValue, v.NewValue, v.ServiceName, v.ApiVersion, v.ResourceName)
			return trimSpaceAround(line)
		}
	}

	return nil, fmt.Errorf("internal-error: unimplemented change type %q", reflect.TypeOf(input).Name())
}

func sortConstantKeysAndValues(input map[string]string) []string {
	output := make([]string, 0)
	for k, v := range input {
		item := fmt.Sprintf("`%s: %s`", k, v)
		output = append(output, item)
	}
	sort.Strings(output)
	return output
}

func trimSpaceAround(input string) (*string, error) {
	output := input
	output = strings.TrimSpace(output)
	return pointer.To(output), nil
}
