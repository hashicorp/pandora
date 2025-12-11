// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// changesForConstants determines the changes between the different Constants within the provided API Resource.
func (d differ) changesForConstants(serviceName, apiVersion, apiResource string, initial, updated map[string]models.SDKConstant) []changes.Change {
	output := make([]changes.Change, 0)
	constantNames := uniqueKeys(initial, updated)
	for _, constantName := range constantNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Constant %q..", constantName))
		changesForConstant := d.changesForConstant(serviceName, apiVersion, apiResource, constantName, initial, updated)
		output = append(output, changesForConstant...)
	}
	return output
}

// changesForConstant determines the changes between two different versions of the same Constant.
func (d differ) changesForConstant(serviceName, apiVersion, apiResource, constantName string, initial, updated map[string]models.SDKConstant) []changes.Change {
	output := make([]changes.Change, 0)

	oldData, inOldData := initial[constantName]
	updatedData, inUpdatedData := updated[constantName]
	if inOldData && !inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Constant %q not present in the updated data", constantName))
		output = append(output, changes.ConstantRemoved{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			ConstantName:  constantName,
			ConstantType:  string(oldData.Type),
			KeysAndValues: oldData.Values,
		})
		// no point continuing to diff if it's gone
		return output
	}
	if !inOldData && inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Constant %q is new", constantName))
		output = append(output, changes.ConstantAdded{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			ConstantName:  constantName,
			ConstantType:  string(updatedData.Type),
			KeysAndValues: updatedData.Values,
		})
		// no point returning since `ConstantAdded` contains the details
		return output
	}

	if inOldData && inUpdatedData {
		// the Type changing would be problematic - so we should surface that
		if oldData.Type != updatedData.Type {
			output = append(output, changes.ConstantTypeChanged{
				ServiceName:  serviceName,
				ApiVersion:   apiVersion,
				ResourceName: apiResource,
				ConstantName: constantName,
				OldType:      string(oldData.Type),
				NewType:      string(updatedData.Type),
			})
		}
	}

	keys := uniqueKeys(oldData.Values, updatedData.Values)
	for _, key := range keys {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Constant Key %q..", key))
		oldValue, oldContainsKey := oldData.Values[key]
		updatedValue, updatedContainsKey := updatedData.Values[key]

		if oldContainsKey && !updatedContainsKey {
			log.Logger.Trace("Key %q / Value %q has been removed", key, oldValue)
			output = append(output, changes.ConstantKeyValueRemoved{
				ServiceName:   serviceName,
				ApiVersion:    apiVersion,
				ResourceName:  apiResource,
				ConstantName:  constantName,
				ConstantKey:   key,
				ConstantValue: oldValue,
			})
			continue
		}
		if !oldContainsKey && updatedContainsKey {
			log.Logger.Trace("Key %q / Value %q has been added", key, updatedValue)
			output = append(output, changes.ConstantKeyValueAdded{
				ServiceName:   serviceName,
				ApiVersion:    apiVersion,
				ResourceName:  apiResource,
				ConstantName:  constantName,
				ConstantKey:   key,
				ConstantValue: updatedValue,
			})
			continue
		}

		// NOTE: if the casing of the Value changes this would be a breaking change too
		if oldValue != updatedValue {
			log.Logger.Trace("Key %q has changed value from %q to %q", key, oldValue, updatedValue)
			output = append(output, changes.ConstantKeyValueChanged{
				ServiceName:      serviceName,
				ApiVersion:       apiVersion,
				ResourceName:     apiResource,
				ConstantName:     constantName,
				ConstantKey:      key,
				OldConstantValue: oldValue,
				NewConstantValue: updatedValue,
			})
			continue
		}
	}

	return output
}
