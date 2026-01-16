// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// changesForField determines the changes between the initial and updated Fields within the specified Model.
func (d differ) changesForField(serviceName, apiVersion, apiResource, modelName, fieldName string, initial, updated map[string]models.SDKField) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, isInOld := initial[fieldName]
	updatedData, isInUpdated := updated[fieldName]
	if isInOld && !isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Field %q has been removed", fieldName))
		output = append(output, changes.FieldRemoved{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
		})
		return &output, nil
	}
	if !isInOld && isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Field %q is new", fieldName))
		output = append(output, changes.FieldAdded{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
		})
		// in the event of a new field, we can skip the other details
		return &output, nil
	}

	// diff the individual properties of note
	if !oldData.Optional && updatedData.Optional {
		output = append(output, changes.FieldIsNowOptional{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
		})
	}
	if !oldData.Required && updatedData.Required {
		output = append(output, changes.FieldIsNowRequired{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
		})
	}
	if oldData.JsonName != updatedData.JsonName {
		output = append(output, changes.FieldJsonNameChanged{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
			OldValue:     oldData.JsonName,
			NewValue:     updatedData.JsonName,
		})
	}

	// for the sake of simplicity when reviewing let's normalise this object to a string
	oldObjectDefinition, err := d.stringifySDKObjectDefinition(oldData.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("stringifying the Old Object Definition: %+v", err)
	}
	newObjectDefinition, err := d.stringifySDKObjectDefinition(updatedData.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("stringifying the Updated Object Definition: %+v", err)
	}
	if *oldObjectDefinition != *newObjectDefinition {
		// To catch unintentional type changes e.g.
		// https://github.com/hashicorp/terraform-provider-azurerm/pull/23129
		output = append(output, changes.FieldObjectDefinitionChanged{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			FieldName:    fieldName,
			OldValue:     *oldObjectDefinition,
			NewValue:     *newObjectDefinition,
		})
	}

	// TODO: DateFormat in the future?

	return &output, nil
}

// changesForFields determines the changes between the initial and updated Fields within the specified Model.
func (d differ) changesForFields(serviceName, apiVersion, apiResource, modelName string, initial, updated map[string]models.SDKField) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	fieldNames := uniqueKeys(initial, updated)
	for _, fieldName := range fieldNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Field %q..", fieldName))
		changesForField, err := d.changesForField(serviceName, apiVersion, apiResource, modelName, fieldName, initial, updated)
		if err != nil {
			return nil, fmt.Errorf("detecting changes in the Field %q: %+v", fieldName, err)
		}
		output = append(output, *changesForField...)
	}
	return &output, nil
}
