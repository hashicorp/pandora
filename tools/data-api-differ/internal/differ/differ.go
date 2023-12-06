package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

type differ struct {
}

func performDiff(initial dataapi.Data, updated dataapi.Data) (*Result, error) {
	diff := differ{}
	output := make([]changes.Change, 0)

	// TODO: support additional Data Sources when we're using the updated SDK
	log.Logger.Trace("Detecting changes to the Resource Manager Services..")
	resourceManagerChanges, err := diff.changesForServices(initial.ResourceManagerServices, updated.ResourceManagerServices)
	if err != nil {
		return nil, fmt.Errorf("determining changes for the Resource Manager Services: %+v", err)
	}
	output = append(output, *resourceManagerChanges...)

	return &Result{
		Changes: output,
	}, nil
}
