// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func ObjectDefinitionsMatch(first, second *sdkModels.SDKObjectDefinition) (bool, error) {
	if first == nil && second == nil {
		logging.Tracef("Both ObjectDefinitions were nil - so the same")
		return true, nil
	}
	if first != nil && second == nil {
		logging.Tracef("First was %+v - Second was nil", *first)
		return false, fmt.Errorf("First was %+v - Second was nil", *first)
	}
	if first == nil && second != nil {
		logging.Tracef("First was nil - Second was %+v", *second)
		return false, fmt.Errorf("First was nil - Second was %+v", *second)
	}

	if first.Type != second.Type {
		logging.Tracef("Type differed - %q vs %q", string(first.Type), string(second.Type))
		return false, fmt.Errorf("Type differed - %q vs %q", string(first.Type), string(second.Type))
	}
	if !strings.EqualFold(pointer.From(first.ReferenceName), pointer.From(second.ReferenceName)) {
		logging.Tracef("ReferenceName differed - %q vs %q", pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
		return false, fmt.Errorf("ReferenceName differed - %q vs %q", pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
	}
	if first.ReferenceNameIsCommonType != second.ReferenceNameIsCommonType {
		firstValue := "nil"
		secondValue := "nil"
		if first.ReferenceNameIsCommonType != nil {
			firstValue = fmt.Sprintf("%t", *first.ReferenceNameIsCommonType)
		}
		if second.ReferenceNameIsCommonType != nil {
			secondValue = fmt.Sprintf("%t", *second.ReferenceNameIsCommonType)
		}
		logging.Tracef("ReferenceNameIsCommonType differed - %s vs %s", firstValue, secondValue)
		return false, fmt.Errorf("ReferenceNameIsCommonType differed - %s vs %s", firstValue, secondValue)
	}
	if first.NestedItem != nil && second.NestedItem != nil {
		if ok, err := ObjectDefinitionsMatch(first.NestedItem, second.NestedItem); !ok {
			logging.Tracef("NestedItem differed: %+v vs %+v", *first.NestedItem, *second.NestedItem)
			return false, fmt.Errorf("NestedItem differed: %+v", err)
		}
	}
	if first.NestedItem != nil && second.NestedItem == nil {
		logging.Tracef("NestedItem differed - First was %+v - Second was nil", *first.NestedItem)
		return false, fmt.Errorf("NestedItem differed - First was %+v - Second was nil", *first.NestedItem)
	}
	if first.NestedItem == nil && second.NestedItem != nil {
		logging.Tracef("NestedItem differed - First was nil - Second was %+v", *second.NestedItem)
		return false, fmt.Errorf("NestedItem differed - First was nil - Second was %+v", *second.NestedItem)
	}

	return true, nil
}
