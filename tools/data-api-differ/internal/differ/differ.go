// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

type differ struct {
}

func performDiff(initial, updated v1.LoadAllDataResult, includeNestedChangesWhenNew bool) (*Result, error) {
	diff := differ{}
	output := make([]changes.Change, 0)

	log.Logger.Trace("Detecting changes to Common Types..")
	commonTypesChanges, err := diff.changesForCommonTypes(initial.CommonTypes, updated.CommonTypes, includeNestedChangesWhenNew)
	if err != nil {
		return nil, fmt.Errorf("determining changes for the Common Types: %+v", err)
	}
	output = append(output, *commonTypesChanges...)

	log.Logger.Trace("Detecting changes to the Services..")
	serviceChanges, err := diff.changesForServices(initial.Services, updated.Services, includeNestedChangesWhenNew)
	if err != nil {
		return nil, fmt.Errorf("determining changes for the Services: %+v", err)
	}
	output = append(output, *serviceChanges...)

	return &Result{
		Changes: output,
	}, nil
}
