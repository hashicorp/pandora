// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"context"
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

// Diff returns information about the changes between `initialPath` and `updatedPath`.
func Diff(ctx context.Context, dataApiBinaryPath, initialPath, updatedPath string, sourceDataType models.SourceDataType, includeNestedChangesWhenNew bool) (*Result, error) {
	log.Logger.Trace(fmt.Sprintf("Parsing the Initial Data Set from %q..", initialPath))
	initialData, err := dataapi.ParseDataFromPath(ctx, dataApiBinaryPath, initialPath, sourceDataType)
	if err != nil {
		return nil, fmt.Errorf("parsing data from %q: %+v", initialPath, err)
	}

	log.Logger.Trace(fmt.Sprintf("Parsing the Updated Data Set from %q..", updatedPath))
	updatedData, err := dataapi.ParseDataFromPath(ctx, dataApiBinaryPath, updatedPath, sourceDataType)
	if err != nil {
		return nil, fmt.Errorf("parsing data from %q: %+v", updatedPath, err)
	}

	log.Logger.Trace("Performing the diff..")
	return performDiff(*initialData, *updatedData, includeNestedChangesWhenNew)
}
