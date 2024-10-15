// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func OperationOptionObjectDefinitionMatch(first, second sdkModels.SDKOperationOptionObjectDefinition) bool {
	if first.Type != second.Type {
		logging.Tracef("Type differed - %q vs %q", string(first.Type), string(second.Type))
		return false
	}
	if !strings.EqualFold(pointer.From(first.ReferenceName), pointer.From(second.ReferenceName)) {
		logging.Tracef("ReferenceName differed - %q vs %q", pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
		return false
	}
	if first.NestedItem != nil && second.NestedItem != nil {
		if !OperationOptionObjectDefinitionMatch(*first.NestedItem, *second.NestedItem) {
			logging.Tracef("NestedItem differed: %+v vs %+v", *first.NestedItem, *second.NestedItem)
			return false
		}
	}
	if first.NestedItem != nil && second.NestedItem == nil {
		logging.Tracef("NestedItem differed - First was %+v - Second was nil", *first.NestedItem)
		return false
	}
	if first.NestedItem == nil && second.NestedItem != nil {
		logging.Tracef("NestedItem differed - First was nil - Second was %+v", *second.NestedItem)
		return false
	}

	return true
}
