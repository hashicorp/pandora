// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

const commonTypesServiceName = "common-types"

// changesForCommonTypes determines the changes between the initial and updated set of Common Types.
func (d differ) changesForCommonTypes(initial, updated map[string]models.CommonTypes, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	// first pull out a unique list of APIVersions for the Common Types
	log.Logger.Info("Identifying a unique list of APIVersions for Common Types..")
	apiVersions := uniqueKeys(initial, updated)
	for _, apiVersion := range apiVersions {
		log.Logger.Info(fmt.Sprintf("Detecting changes to the Common Types in API Version %q..", apiVersion))
		changesForCommonType, err := d.changesForCommonTypesInAPIVersion(apiVersion, initial, updated, includeNestedChangesWhenNew)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to the Common Types in API Version %q: %+v", apiVersion, err)
		}
		output = append(output, *changesForCommonType...)
	}
	return &output, nil
}

func (d differ) changesForCommonTypesInAPIVersion(apiVersion string, initial, updated map[string]models.CommonTypes, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	oldData, inOldData := initial[apiVersion]
	updatedData, inUpdatedData := updated[apiVersion]
	output := make([]changes.Change, 0)
	if inOldData && !inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Common Types no longer contains data for API Version %q", apiVersion))
		output = append(output, changes.CommonTypesApiVersionRemoved{
			ApiVersion: apiVersion,
		})
		// no point continuing to diff if it's gone
		return &output, nil
	}
	if !inOldData && inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Common Types contains a new set of data for API Version %q", apiVersion))
		output = append(output, changes.CommonTypesApiVersionAdded{
			ApiVersion: apiVersion,
		})
		// intentionally not returning here
	}
	if !includeNestedChangesWhenNew {
		return &output, nil
	}

	log.Logger.Debug("Determining the changes for the CommonTypes Constants..")
	changesToConstants := d.changesForCommonTypesConstants(apiVersion, oldData.Constants, updatedData.Constants)
	output = append(output, changesToConstants...)

	log.Logger.Debug("Determining the changes for the CommonTypes Models..")
	changesToModels, err := d.changesForCommonTypesModels(apiVersion, oldData.Models, updatedData.Models)
	if err != nil {
		return nil, fmt.Errorf("determining the changes for the CommonTypes Models: %+v", err)
	}
	output = append(output, *changesToModels...)

	return &output, nil
}
