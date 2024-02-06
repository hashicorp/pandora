// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// changesForModels determines the changes between the initial and updated Models within the specified API Resource.
func (d differ) changesForModels(serviceName, apiVersion, apiResource string, initial, updated map[string]resourcemanager.ModelDetails) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	modelNames := d.uniqueModelNames(initial, updated)
	for _, modelName := range modelNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Model %q..", modelName))
		changesForModel, err := d.changesForModel(serviceName, apiVersion, apiResource, modelName, initial, updated)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to the Model %q: %+v", modelName, err)
		}
		output = append(output, *changesForModel...)
	}
	return &output, nil
}

// changesForModel determines the changes between the initial and updated Models within the specified API Resource.
func (d differ) changesForModel(serviceName, apiVersion, apiResource, modelName string, initial, updated map[string]resourcemanager.ModelDetails) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, isInOld := initial[modelName]
	updatedData, isInUpdated := updated[modelName]
	if isInOld && !isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Model %q has been removed", modelName))
		output = append(output, changes.ModelRemoved{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
		})
		return &output, nil
	}
	if !isInOld && isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Model %q is new", modelName))
		output = append(output, changes.ModelAdded{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
		})
		// in the event of a new model, we can skip the other details
		return &output, nil
	}

	// check for any changes to the discriminated information
	log.Logger.Trace("Checking for changes to the Discriminated Type Information..")
	discriminatorChangesForModel := d.discriminatorChangesForModel(serviceName, apiVersion, apiResource, modelName, oldData, updatedData)
	output = append(output, discriminatorChangesForModel...)

	// then detect any changes to the fields
	log.Logger.Trace("Checking for changes to the Fields..")
	changesToFields, err := d.changesForFields(serviceName, apiVersion, apiResource, modelName, oldData.Fields, updatedData.Fields)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to Fields: %+v", err)
	}
	output = append(output, *changesToFields...)

	return &output, nil
}

func (d differ) discriminatorChangesForModel(serviceName, apiVersion, apiResource, modelName string, initial, updated resourcemanager.ModelDetails) []changes.Change {
	output := make([]changes.Change, 0)

	// Handle this being a Discriminated Implementation
	if initial.ParentTypeName == nil && updated.ParentTypeName != nil {
		// the Model has gone from not having a Parent Type -> having a Parent Type
		// meaning this is now a Discriminated Implementation.
		log.Logger.Trace(fmt.Sprintf("Model %q is now a Discriminated Implementation of %q", modelName, *updated.ParentTypeName))
		output = append(output, changes.ModelDiscriminatedParentTypeAdded{
			ServiceName:        serviceName,
			ApiVersion:         apiVersion,
			ResourceName:       apiResource,
			ModelName:          modelName,
			NewParentModelName: *updated.ParentTypeName,
		})
	}
	if initial.ParentTypeName != nil && updated.ParentTypeName == nil {
		// The model has gone from having a Parent Type -> not having a Parent Type
		// meaning this is no longer a Discriminated Implementation.
		log.Logger.Trace(fmt.Sprintf("Model %q is no longer a Discriminated Implementation of %q", modelName, *initial.ParentTypeName))
		output = append(output, changes.ModelDiscriminatedParentTypeRemoved{
			ServiceName:        serviceName,
			ApiVersion:         apiVersion,
			ResourceName:       apiResource,
			ModelName:          modelName,
			OldParentModelName: *initial.ParentTypeName,
		})
	}
	if initial.ParentTypeName != nil && updated.ParentTypeName != nil && *initial.ParentTypeName != *updated.ParentTypeName {
		// The model has changed its Parent Type - which is going to require additional investigation.
		log.Logger.Trace(fmt.Sprintf("Model %q is is a Discriminated Implementation but changed it's Parent from %q to %q", modelName, *initial.ParentTypeName, *updated.ParentTypeName))
		output = append(output, changes.ModelDiscriminatedParentTypeChanged{
			ServiceName:        serviceName,
			ApiVersion:         apiVersion,
			ResourceName:       apiResource,
			ModelName:          modelName,
			OldParentModelName: *initial.ParentTypeName,
			NewParentModelName: *updated.ParentTypeName,
		})
	}

	// Handle the Field containing the Discriminated Value changing
	if pointer.From(initial.TypeHintIn) != pointer.From(updated.TypeHintIn) {
		// Since TypeHintIn changing is unlikely (but has been seen) but is required along with at least
		// one Discriminated Implementation - we don't need to handle Added/Removed here.
		log.Logger.Trace(fmt.Sprintf("Model %q has a new value for `TypeHintIn` - old %q / new %q", modelName, pointer.From(initial.TypeHintIn), pointer.From(updated.TypeHintIn)))
		output = append(output, changes.ModelDiscriminatedTypeHintInChanged{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			OldValue:     pointer.From(initial.TypeHintIn),
			NewValue:     pointer.From(updated.TypeHintIn),
		})
	}

	// Handle the Discriminated Value changing
	if pointer.From(initial.TypeHintValue) != pointer.From(updated.TypeHintValue) {
		// We're (intentionally) only handling Changed and not Added/Removed here since this is a Required
		// field when `ParentTypeName` is set.
		log.Logger.Trace(fmt.Sprintf("Model %q has a new value for `TypeHintValue` - old %q / new %q", modelName, pointer.From(initial.TypeHintValue), pointer.From(updated.TypeHintValue)))
		output = append(output, changes.ModelDiscriminatedTypeValueChanged{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
			ModelName:    modelName,
			OldValue:     pointer.From(initial.TypeHintValue),
			NewValue:     pointer.From(updated.TypeHintValue),
		})
	}

	return output
}

// uniqueModelNames returns a unique, sorted list of Model Names from the keys of initial and updated.
func (d differ) uniqueModelNames(initial, updated map[string]resourcemanager.ModelDetails) []string {
	uniqueNames := make(map[string]struct{})
	for name := range initial {
		uniqueNames[name] = struct{}{}
	}
	for name := range updated {
		uniqueNames[name] = struct{}{}
	}

	output := make([]string, 0)
	for k := range uniqueNames {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}
