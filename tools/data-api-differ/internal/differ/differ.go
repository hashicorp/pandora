// Copyright (c) HashiCorp, Inc.
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

	// TODO: support additional Data Sources when we're using the updated SDK
	log.Logger.Trace("Detecting changes to the Resource Manager Services..")
	resourceManagerChanges, err := diff.changesForServices(initial.Services, updated.Services, includeNestedChangesWhenNew)
	if err != nil {
		return nil, fmt.Errorf("determining changes for the Resource Manager Services: %+v", err)
	}
	output = append(output, *resourceManagerChanges...)

	return &Result{
		Changes: output,
	}, nil
}
