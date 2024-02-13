// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

// Diff returns information about the changes between `initialPath` and `updatedPath`.
func Diff(dataApiBinaryPath, initialPath, updatedPath string, includeNestedChangesWhenNew bool) (*Result, error) {
	log.Logger.Trace(fmt.Sprintf("Parsing the Initial Data Set from %q..", initialPath))
	initialData, err := dataapi.ParseDataFromPath(dataApiBinaryPath, initialPath)
	if err != nil {
		return nil, fmt.Errorf("parsing data from %q: %+v", initialPath, err)
	}

	log.Logger.Trace(fmt.Sprintf("Parsing the Updated Data Set from %q..", updatedPath))
	updatedData, err := dataapi.ParseDataFromPath(dataApiBinaryPath, updatedPath)
	if err != nil {
		return nil, fmt.Errorf("parsing data from %q: %+v", updatedPath, err)
	}

	log.Logger.Trace("Performing the diff..")
	return performDiff(*initialData, *updatedData, includeNestedChangesWhenNew)
}
