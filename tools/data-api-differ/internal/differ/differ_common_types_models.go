// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (d differ) changesForCommonTypesModels(apiVersion string, initial, updated map[string]models.SDKModel) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	modelNames := uniqueKeys(initial, updated)
	for _, modelName := range modelNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in CommonTypes Model %q..", modelName))
		changesForModel, err := d.changesForCommonTypesModel(apiVersion, modelName, initial, updated)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to the CommonTypes Model %q: %+v", modelName, err)
		}
		output = append(output, *changesForModel...)
	}
	return &output, nil
}

// changesForCommonTypesModel determines the changes between the initial and updated CommonTypes Model.
func (d differ) changesForCommonTypesModel(apiVersion, modelName string, initial, updated map[string]models.SDKModel) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, isInOld := initial[modelName]
	updatedData, isInUpdated := updated[modelName]
	if isInOld && !isInUpdated {
		log.Logger.Trace(fmt.Sprintf("CommonTypes Model %q has been removed", modelName))
		output = append(output, changes.CommonTypesModelRemoved{
			ApiVersion: apiVersion,
			ModelName:  modelName,
		})
		return &output, nil
	}
	if !isInOld && isInUpdated {
		log.Logger.Trace(fmt.Sprintf("CommonTypes Model %q is new", modelName))
		output = append(output, changes.CommonTypesModelAdded{
			ApiVersion: apiVersion,
			ModelName:  modelName,
		})
		// in the event of a new model, we can skip the other details
		return &output, nil
	}

	// @tombuildsstuff: I've opted to reuse the existing diffing logic, since these are the same models
	// and I don't think it's worth having a new type specifically for each change for CommonModels until
	// that changes - so this is fine for now.

	// check for any changes to the discriminated information
	log.Logger.Trace("Checking for changes to the Discriminated Type Information..")
	discriminatorChangesForModel := d.discriminatorChangesForModel(commonTypesServiceName, apiVersion, commonTypesServiceName, modelName, oldData, updatedData)
	output = append(output, discriminatorChangesForModel...)

	// then detect any changes to the fields
	log.Logger.Trace("Checking for changes to the Fields..")
	changesToFields, err := d.changesForFields(commonTypesServiceName, apiVersion, commonTypesServiceName, modelName, oldData.Fields, updatedData.Fields)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to Fields: %+v", err)
	}
	output = append(output, *changesToFields...)

	return &output, nil
}
