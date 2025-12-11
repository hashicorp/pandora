// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"reflect"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

// changesForOperations determines the changes between the initial and updated Operations within the specified API Resource.
func (d differ) changesForOperations(serviceName, apiVersion, apiResource string, initial, updated map[string]models.SDKOperation, initialResourceIds, updatedResourceIds map[string]models.ResourceID) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	operationNames := uniqueKeys(initial, updated)
	for _, operationName := range operationNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Operation %q..", operationName))
		changesForOperation, err := d.changesForOperation(serviceName, apiVersion, apiResource, operationName, initial, updated, initialResourceIds, updatedResourceIds)
		if err != nil {
			return nil, fmt.Errorf("detecting changes for the Operation %q: %+v", operationName, err)
		}
		output = append(output, *changesForOperation...)
	}
	return &output, nil
}

// changesForOperation determines the changes between the initial and updated Operations within the specified API Resource.
func (d differ) changesForOperation(serviceName, apiVersion, apiResource, operationName string, initial, updated map[string]models.SDKOperation, initialResourceIds, updatedResourceIds map[string]models.ResourceID) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, isInOld := initial[operationName]
	updatedData, isInUpdated := updated[operationName]
	oldUri := ""
	if isInOld {
		oldUri = d.uriForOperation(oldData, initialResourceIds)
	}
	updatedUri := ""
	if isInUpdated {
		updatedUri = d.uriForOperation(updatedData, updatedResourceIds)
	}

	if isInOld && !isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Operation %q has been removed", operationName))
		output = append(output, changes.OperationRemoved{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			Uri:           oldUri,
		})
		return &output, nil
	}
	if !isInOld && isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Operation %q is new", operationName))
		output = append(output, changes.OperationAdded{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			Uri:           updatedUri,
		})
		// in the event of a new operation, we can skip the other details
		return &output, nil
	}

	log.Logger.Trace("Detecting changes to the Resource ID for this Operation..")
	resourceIdChanges, err := d.changesForOperationResourceId(serviceName, apiVersion, apiResource, operationName, oldData, updatedData, initialResourceIds, updatedResourceIds)
	if err != nil {
		return nil, fmt.Errorf("determining changes to the Resource ID: %+v", err)
	}
	output = append(output, *resourceIdChanges...)

	// When the Content-Type changes we're sending a semantically different object
	if oldData.ContentType != updatedData.ContentType {
		log.Logger.Trace("Content Type didn't match")
		output = append(output, changes.OperationContentTypeChanged{
			ServiceName:    serviceName,
			ApiVersion:     apiVersion,
			ResourceName:   apiResource,
			OperationName:  operationName,
			OldContentType: oldData.ContentType,
			NewContentType: updatedData.ContentType,
		})
	}

	// When the Field containing Pagination Details changes we're breaking either the existing or
	// updated code paths.
	if pointer.From(oldData.FieldContainingPaginationDetails) != pointer.From(updatedData.FieldContainingPaginationDetails) {
		log.Logger.Trace("Field Containing Pagination Details didn't match")
		output = append(output, changes.OperationPaginationFieldChanged{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			OldValue:      pointer.From(oldData.FieldContainingPaginationDetails),
			NewValue:      pointer.From(updatedData.FieldContainingPaginationDetails),
		})
	}

	// When the HTTP Method changes we're performing a totally different Operation
	if oldData.Method != updatedData.Method {
		log.Logger.Trace("Method didn't match")
		output = append(output, changes.OperationMethodChanged{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			OldValue:      oldData.Method,
			NewValue:      updatedData.Method,
		})
	}

	if !d.expectedStatusCodesMatch(oldData.ExpectedStatusCodes, updatedData.ExpectedStatusCodes) {
		log.Logger.Trace("Expected Status Codes didn't match")
		output = append(output, changes.OperationExpectedStatusCodesChanged{
			ServiceName:            serviceName,
			ApiVersion:             apiVersion,
			ResourceName:           apiResource,
			OperationName:          operationName,
			OldExpectedStatusCodes: oldData.ExpectedStatusCodes,
			NewExpectedStatusCodes: updatedData.ExpectedStatusCodes,
		})
	}

	// Long Running Operations
	if oldData.LongRunning && !updatedData.LongRunning {
		log.Logger.Trace("Operation is no longer a Long Running Operation")
		output = append(output, changes.OperationLongRunningRemoved{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
		})
	}
	if !oldData.LongRunning && updatedData.LongRunning {
		log.Logger.Trace("Operation is now a Long Running Operation")
		output = append(output, changes.OperationLongRunningAdded{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
		})
	}

	// Options
	log.Logger.Trace("Detecting changes to the Options Object..")
	optionsChanges, err := d.changesForOperationOptionsObject(serviceName, apiVersion, apiResource, operationName, oldData, updatedData)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to to the Options Object: %+v", err)
	}
	output = append(output, *optionsChanges...)

	// Request Object
	log.Logger.Trace("Detecting changes to the Request Object..")
	requestObjectChanges, err := d.changesForOperationRequestObject(serviceName, apiVersion, apiResource, operationName, oldData, updatedData)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to the Request Object: %+v", err)
	}
	output = append(output, *requestObjectChanges...)

	// Response Object
	log.Logger.Trace("Detecting changes to the Response Object..")
	responseObjectChanges, err := d.changesForOperationResponseObject(serviceName, apiVersion, apiResource, operationName, oldData, updatedData)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to the Response Object: %+v", err)
	}
	output = append(output, *responseObjectChanges...)

	// Uri Suffix
	log.Logger.Trace("Detecting changes to the Uri Suffix..")
	uriSuffixChanges := d.changesForOperationUriSuffix(serviceName, apiVersion, apiResource, operationName, oldData, updatedData)
	output = append(output, uriSuffixChanges...)

	return &output, nil
}

// changesForOperationOptionsObject determines any changes to the Options Object between the initial and updated version of this Operation.
func (d differ) changesForOperationOptionsObject(serviceName, apiVersion, apiResource, operationName string, initial, updated models.SDKOperation) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	if len(initial.Options) == 0 && len(updated.Options) > 0 {
		log.Logger.Trace("The Operation now has options")
		updatedStringified, err := d.stringifyOperationOptions(updated.Options)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Updated Operation Options: %+v", err)
		}
		output = append(output, changes.OperationOptionsAdded{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			NewValue:      *updatedStringified,
		})
	}
	if len(initial.Options) > 0 && len(updated.Options) == 0 {
		log.Logger.Trace("The Operation no longer has options")
		initialStringified, err := d.stringifyOperationOptions(initial.Options)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Initial Operation Options: %+v", err)
		}
		output = append(output, changes.OperationOptionsRemoved{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			OldValue:      *initialStringified,
		})
	}
	if len(initial.Options) > 0 && len(updated.Options) > 0 {
		matches, err := d.optionsMatch(initial.Options, updated.Options)
		if err != nil {
			return nil, fmt.Errorf("determining whether the initial and updated Options Objects match: %+v", err)
		}
		if !*matches {
			log.Logger.Trace("The Options for this Operation have changed")
			initialStringified, err := d.stringifyOperationOptions(initial.Options)
			if err != nil {
				return nil, fmt.Errorf("stringifying the Initial Operation Options: %+v", err)
			}
			updatedStringified, err := d.stringifyOperationOptions(updated.Options)
			if err != nil {
				return nil, fmt.Errorf("stringifying the Updated Operation Options: %+v", err)
			}
			output = append(output, changes.OperationOptionsChanged{
				ServiceName:   serviceName,
				ApiVersion:    apiVersion,
				ResourceName:  apiResource,
				OperationName: operationName,
				OldValue:      *initialStringified,
				NewValue:      *updatedStringified,
			})
		}
	}

	return &output, nil
}

// changesForOperationRequestObject determines any changes to the Request Object in both the initial and updated versions of this Operation.
func (d differ) changesForOperationRequestObject(serviceName, apiVersion, apiResource, operationName string, initial, updated models.SDKOperation) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	if initial.RequestObject != nil && updated.RequestObject == nil {
		log.Logger.Trace("The updated Operation no longer has a Request Object")
		oldStringified, err := d.stringifySDKObjectDefinition(*initial.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Old Object Definition: %+v", err)
		}
		output = append(output, changes.OperationRequestObjectRemoved{
			ServiceName:      serviceName,
			ApiVersion:       apiVersion,
			ResourceName:     apiResource,
			OperationName:    operationName,
			OldRequestObject: *oldStringified,
		})
	}
	if initial.RequestObject == nil && updated.RequestObject != nil {
		log.Logger.Trace("The updated Operation now has a Request Object")
		updatedStringified, err := d.stringifySDKObjectDefinition(*updated.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Updated Object Definition: %+v", err)
		}
		output = append(output, changes.OperationRequestObjectAdded{
			ServiceName:      serviceName,
			ApiVersion:       apiVersion,
			ResourceName:     apiResource,
			OperationName:    operationName,
			NewRequestObject: *updatedStringified,
		})
	}
	if initial.RequestObject != nil && updated.RequestObject != nil {
		oldStringified, err := d.stringifySDKObjectDefinition(*initial.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Old Object Definition: %+v", err)
		}
		updatedStringified, err := d.stringifySDKObjectDefinition(*updated.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Updated Object Definition: %+v", err)
		}
		if *oldStringified != *updatedStringified {
			log.Logger.Trace("The updated Operation has a different Request Object")
			output = append(output, changes.OperationRequestObjectChanged{
				ServiceName:      serviceName,
				ApiVersion:       apiVersion,
				ResourceName:     apiResource,
				OperationName:    operationName,
				OldRequestObject: *oldStringified,
				NewRequestObject: *updatedStringified,
			})
		}
	}

	return &output, nil
}

// changesForOperationResourceId determines any changes to the Resource Id used in both the initial and updated versions of this Operation.
func (d differ) changesForOperationResourceId(serviceName, apiVersion, apiResource, operationName string, initial, updated models.SDKOperation, initialResourceIds, updatedResourceIds map[string]models.ResourceID) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	if initial.ResourceIDName != nil && updated.ResourceIDName == nil {
		log.Logger.Trace(fmt.Sprintf("The Operation no longer requires a Resource ID %q", *initial.ResourceIDName))
		output = append(output, changes.OperationResourceIdRemoved{
			ServiceName:       serviceName,
			ApiVersion:        apiVersion,
			ResourceName:      apiResource,
			OperationName:     operationName,
			OldResourceIdName: *initial.ResourceIDName,
		})
	}
	if initial.ResourceIDName == nil && updated.ResourceIDName != nil {
		log.Logger.Trace(fmt.Sprintf("The Operation now requires a Resource ID %q", *updated.ResourceIDName))
		output = append(output, changes.OperationResourceIdAdded{
			ServiceName:       serviceName,
			ApiVersion:        apiVersion,
			ResourceName:      apiResource,
			OperationName:     operationName,
			NewResourceIdName: *updated.ResourceIDName,
		})
	}
	if initial.ResourceIDName != nil && updated.ResourceIDName != nil {
		oldId, ok := initialResourceIds[*initial.ResourceIDName]
		if !ok {
			return nil, fmt.Errorf("Unable to find the original Resource ID %q", *initial.ResourceIDName)
		}
		updatedId, ok := updatedResourceIds[*updated.ResourceIDName]
		if !ok {
			return nil, fmt.Errorf("Unable to find the updated Resource ID %q", *updated.ResourceIDName)
		}

		// Determine if the Resource ID itself has changed - or whether it's been renamed
		if *initial.ResourceIDName != *updated.ResourceIDName {
			log.Logger.Trace("The Operation uses a different Resource ID Name")
			output = append(output, changes.OperationResourceIdRenamed{
				ServiceName:       serviceName,
				ApiVersion:        apiVersion,
				ResourceName:      apiResource,
				OperationName:     operationName,
				NewResourceIdName: *updated.ResourceIDName,
				OldResourceIdName: *initial.ResourceIDName,
			})
		}

		if oldId.ExampleValue != updatedId.ExampleValue {
			log.Logger.Trace("The Operation now targets a different Resource ID")
			output = append(output, changes.OperationResourceIdChanged{
				ServiceName:       serviceName,
				ApiVersion:        apiVersion,
				ResourceName:      apiResource,
				OperationName:     operationName,
				OldResourceIdName: *initial.ResourceIDName,
				OldValue:          oldId.ExampleValue,
				NewResourceIdName: *updated.ResourceIDName,
				NewValue:          updatedId.ExampleValue,
			})
		}
	}

	return &output, nil
}

// changesForOperationResponseObject determines any changes to the Response Object in both the initial and updated versions of this Operation.
func (d differ) changesForOperationResponseObject(serviceName, apiVersion, apiResource, operationName string, initial, updated models.SDKOperation) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	if initial.ResponseObject != nil && updated.ResponseObject == nil {
		log.Logger.Trace("The updated Operation no longer has a Response Object")
		oldStringified, err := d.stringifySDKObjectDefinition(*initial.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Old Object Definition: %+v", err)
		}
		output = append(output, changes.OperationResponseObjectRemoved{
			ServiceName:       serviceName,
			ApiVersion:        apiVersion,
			ResourceName:      apiResource,
			OperationName:     operationName,
			OldResponseObject: *oldStringified,
		})
	}
	if initial.ResponseObject == nil && updated.ResponseObject != nil {
		log.Logger.Trace("The updated Operation now has a Response Object")
		updatedStringified, err := d.stringifySDKObjectDefinition(*updated.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Updated Object Definition: %+v", err)
		}
		output = append(output, changes.OperationResponseObjectAdded{
			ServiceName:       serviceName,
			ApiVersion:        apiVersion,
			ResourceName:      apiResource,
			OperationName:     operationName,
			NewResponseObject: *updatedStringified,
		})
	}
	if initial.ResponseObject != nil && updated.ResponseObject != nil {
		oldStringified, err := d.stringifySDKObjectDefinition(*initial.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Old Object Definition: %+v", err)
		}
		updatedStringified, err := d.stringifySDKObjectDefinition(*updated.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Updated Object Definition: %+v", err)
		}
		if *oldStringified != *updatedStringified {
			log.Logger.Trace("The updated Operation has a different Response Object")
			output = append(output, changes.OperationResponseObjectChanged{
				ServiceName:       serviceName,
				ApiVersion:        apiVersion,
				ResourceName:      apiResource,
				OperationName:     operationName,
				OldResponseObject: *oldStringified,
				NewResponseObject: *updatedStringified,
			})
		}
	}

	return &output, nil
}

// changesForOperationUriSuffix determines any changes to the Uri Suffix between the initial and updated versions of this Operation.
func (d differ) changesForOperationUriSuffix(serviceName, apiVersion, apiResource, operationName string, initial, updated models.SDKOperation) []changes.Change {
	output := make([]changes.Change, 0)

	if initial.URISuffix != nil && updated.URISuffix == nil {
		log.Logger.Trace("The existing Uri Suffix has been removed")
		output = append(output, changes.OperationUriSuffixRemoved{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			OldValue:      *initial.URISuffix,
		})
		return output
	}

	if initial.URISuffix == nil && updated.URISuffix != nil {
		log.Logger.Trace("A new Uri Suffix has been added")
		output = append(output, changes.OperationUriSuffixAdded{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			NewValue:      *updated.URISuffix,
		})
		return output
	}

	if initial.URISuffix != nil && updated.URISuffix != nil && *initial.URISuffix != *updated.URISuffix {
		log.Logger.Trace("The Uri Suffix has changed")
		output = append(output, changes.OperationUriSuffixChanged{
			ServiceName:   serviceName,
			ApiVersion:    apiVersion,
			ResourceName:  apiResource,
			OperationName: operationName,
			OldValue:      *initial.URISuffix,
			NewValue:      *updated.URISuffix,
		})
	}

	return output
}

// expectedStatusCodesMatch determines whether the two sets of Expected Status Codes are the same.
func (d differ) expectedStatusCodesMatch(initial, updated []int) bool {
	if len(initial) != len(updated) {
		return false
	}

	sort.Ints(initial)
	sort.Ints(updated)
	return reflect.DeepEqual(initial, updated)
}

// optionsMatch determines whether the two sets of Options are the same.
func (d differ) optionsMatch(initial, updated map[string]models.SDKOperationOption) (*bool, error) {
	// since we're stringifying the options for output, we can reuse this here
	initialStringified, err := d.stringifyOperationOptions(initial)
	if err != nil {
		return nil, fmt.Errorf("stringifying the Initial Operation Options: %+v", err)
	}
	updatedStringified, err := d.stringifyOperationOptions(updated)
	if err != nil {
		return nil, fmt.Errorf("stringifying the Updated Operation Options: %+v", err)
	}
	uniqKeys := uniqueKeys(*initialStringified, *updatedStringified)
	for _, key := range uniqKeys {
		initialVal, isInInitial := (*initialStringified)[key]
		if !isInInitial {
			return pointer.To(false), nil
		}

		updatedVal, isInUpdated := (*updatedStringified)[key]
		if !isInUpdated {
			return pointer.To(false), nil
		}

		if initialVal != updatedVal {
			return pointer.To(false), nil
		}
	}

	return pointer.To(true), nil
}

// stringifyOperationOptions returns a stringified version of the Options object
// which is used to provide a human-readable output.
func (d differ) stringifyOperationOptions(input map[string]models.SDKOperationOption) (*map[string]string, error) {
	output := make(map[string]string)

	for key, value := range input {
		log.Logger.Trace(fmt.Sprintf("Processing Option %q", key))
		stringifiedObjectDefinition, err := d.stringifySDKOperationOptionObjectDefinition(value.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("stringifying the Object Definition for Option %q: %+v", key, err)
		}

		components := make([]string, 0)

		// Why not `json.Encode` this? because it's worth normalizing the ObjectDefinition so its
		// consistent with the Object Definition against Field
		components = append(components, fmt.Sprintf("ObjectDefinition %q", *stringifiedObjectDefinition))
		components = append(components, fmt.Sprintf("Required %t", value.Required))
		if value.HeaderName != nil {
			components = append(components, fmt.Sprintf("HeaderName %q", *value.HeaderName))
		}
		if value.QueryStringName != nil {
			components = append(components, fmt.Sprintf("QueryStringName %q", *value.QueryStringName))
		}

		output[key] = strings.Join(components, " / ")
	}

	return &output, nil
}

// uriForOperation returns the formatted URI for this operation, comprising either the Resource ID, the Resource ID and the Uri Suffix
// or just the Uri Suffix.
func (d differ) uriForOperation(input models.SDKOperation, resourceIds map[string]models.ResourceID) string {
	components := make([]string, 0)
	if input.ResourceIDName != nil {
		id, ok := resourceIds[*input.ResourceIDName]
		if !ok {
			// TODO: thread through errors/raise this, but for now:
			components = append(components, "{MISSING RESOURCE ID}")
		} else {
			components = append(components, id.ExampleValue)
		}
	}

	if input.URISuffix != nil {
		components = append(components, *input.URISuffix)
	}

	// We could use a strings.Join(components, "/") here but since we need to check if both the Resource ID and URISuffix
	// value have start with a "/" we might as well do this here?
	out := ""
	for _, val := range components {
		component := val
		if strings.HasPrefix(component, "/") {
			component = strings.TrimPrefix(component, "/")
		}
		out += fmt.Sprintf("/%s", component)
	}

	return out
}
