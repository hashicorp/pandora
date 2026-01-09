// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func OperationOptionMatch(first, second sdkModels.SDKOperationOption) bool {
	if pointer.From(first.HeaderName) != pointer.From(second.HeaderName) {
		logging.Tracef("HeaderName differed - %q vs %q", pointer.From(first.HeaderName), pointer.From(second.HeaderName))
		return false
	}
	if pointer.From(first.QueryStringName) != pointer.From(second.QueryStringName) {
		logging.Tracef("QueryStringName differed - %q vs %q", pointer.From(first.QueryStringName), pointer.From(second.QueryStringName))
		return false
	}
	if !OperationOptionObjectDefinitionMatch(first.ObjectDefinition, second.ObjectDefinition) {
		logging.Tracef("ObjectDefinition differed - %+v vs %+v", first.ObjectDefinition, second.ObjectDefinition)
		return false
	}
	if first.Required != second.Required {
		logging.Tracef("Required differed - %t vs %t", first.Required, second.Required)
		return false
	}

	return true
}
