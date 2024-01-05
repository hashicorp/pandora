package differ

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (d differ) changesForResourceIds(serviceName, apiVersion, apiResource string, initial, updated map[string]resourcemanager.ResourceIdDefinition) []changes.Change {
	output := make([]changes.Change, 0)
	resourceIdNames := d.uniqueResourceIdNames(initial, updated)
	for _, resourceIdName := range resourceIdNames {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in Resource ID %q..", resourceIdName))
		changesForResourceId := d.changesForResourceId(serviceName, apiVersion, apiResource, resourceIdName, initial, updated)
		output = append(output, changesForResourceId...)
	}
	return output
}

func (d differ) changesForResourceId(serviceName, apiVersion, apiResource, resourceIdName string, initial, updated map[string]resourcemanager.ResourceIdDefinition) []changes.Change {
	output := make([]changes.Change, 0)

	oldData, isInOld := initial[resourceIdName]
	updatedData, isInUpdated := updated[resourceIdName]

	if isInOld && !isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Resource ID %q was removed", resourceIdName))
		output = append(output, changes.ResourceIdRemoved{
			ServiceName:     serviceName,
			ApiVersion:      apiVersion,
			ResourceName:    apiResource,
			ResourceIdName:  resourceIdName,
			ResourceIdValue: oldData.Id,
		})
		return output
	}
	if !isInOld && isInUpdated {
		log.Logger.Trace(fmt.Sprintf("Resource ID %q was added", resourceIdName))
		staticIdentifiers := d.staticIdentifiersInResourceIdSegments(updatedData.Segments)
		output = append(output, changes.ResourceIdAdded{
			ServiceName:                 serviceName,
			ApiVersion:                  apiVersion,
			ResourceName:                apiResource,
			ResourceIdName:              resourceIdName,
			ResourceIdValue:             updatedData.Id,
			StaticIdentifiersInNewValue: staticIdentifiers,
		})
		return output
	}

	log.Logger.Trace("Determining any changes to the Common Alias..")
	commonAliasChanges := d.changesForResourceIdCommonAlias(serviceName, apiVersion, apiResource, resourceIdName, oldData, updatedData)
	output = append(output, commonAliasChanges...)

	log.Logger.Trace("Determining any changes to the Resource ID Segments..")
	segmentChanges := d.changesForResourceIdSegments(serviceName, apiVersion, apiResource, resourceIdName, oldData, updatedData)
	output = append(output, segmentChanges...)

	return output
}

// changesForResourceIdCommonAlias determines any changes related to the Common Alias for the initial and updated version of this Resource ID.
func (d differ) changesForResourceIdCommonAlias(serviceName, apiVersion, apiResource, resourceIdName string, initial, updated resourcemanager.ResourceIdDefinition) []changes.Change {
	output := make([]changes.Change, 0)

	if initial.CommonAlias != nil && updated.CommonAlias == nil {
		log.Logger.Trace(fmt.Sprintf("The Resource ID %q is no longer a Common ID", resourceIdName))
		output = append(output, changes.ResourceIdCommonIdRemoved{
			ServiceName:     serviceName,
			ApiVersion:      apiVersion,
			ResourceName:    apiResource,
			ResourceIdName:  resourceIdName,
			CommonAliasName: *initial.CommonAlias,
			ResourceIdValue: initial.Id,
		})
	}
	if initial.CommonAlias == nil && updated.CommonAlias != nil {
		log.Logger.Trace(fmt.Sprintf("The Resource ID %q is now a Common ID", resourceIdName))
		output = append(output, changes.ResourceIdCommonIdAdded{
			ServiceName:     serviceName,
			ApiVersion:      apiVersion,
			ResourceName:    apiResource,
			ResourceIdName:  resourceIdName,
			CommonAliasName: *updated.CommonAlias,
			ResourceIdValue: updated.Id,
		})
	}
	if initial.CommonAlias != nil && updated.CommonAlias != nil && *initial.CommonAlias != *updated.CommonAlias {
		log.Logger.Trace(fmt.Sprintf("The Resource ID %q has changed it's Common Alias from %q to %q", resourceIdName, *initial.CommonAlias, *updated.CommonAlias))
		output = append(output, changes.ResourceIdCommonIdChanged{
			ServiceName:        serviceName,
			ApiVersion:         apiVersion,
			ResourceName:       apiResource,
			ResourceIdName:     resourceIdName,
			OldCommonAliasName: *initial.CommonAlias,
			OldValue:           initial.Id,
			NewCommonAliasName: *updated.CommonAlias,
			NewValue:           updated.Id,
		})
	}

	return output
}

// changesForResourceIdSegments determines any changes related to the Segments for the initial and updated version of this Resource ID.
func (d differ) changesForResourceIdSegments(serviceName, apiVersion, apiResource, resourceIdName string, initial, updated resourcemanager.ResourceIdDefinition) []changes.Change {
	output := make([]changes.Change, 0)

	// Stringify the Resource ID Segments so these are consistent for diffing and output
	oldStringified := d.stringifyResourceIdSegments(initial.Segments)
	updatedStringified := d.stringifyResourceIdSegments(updated.Segments)

	if len(initial.Segments) != len(updated.Segments) {
		log.Logger.Trace(fmt.Sprintf("The Resource ID has a different set of segments (old %d segments / new %d segments)", len(initial.Segments), len(updated.Segments)))

		staticIdentifiersInSegments := d.staticIdentifiersInResourceIdSegments(updated.Segments)

		output = append(output, changes.ResourceIdSegmentsChangedLength{
			ServiceName:                 serviceName,
			ApiVersion:                  apiVersion,
			ResourceName:                apiResource,
			ResourceIdName:              resourceIdName,
			OldValue:                    oldStringified,
			NewValue:                    updatedStringified,
			StaticIdentifiersInNewValue: staticIdentifiersInSegments,
		})
		return output
	}

	// at this point we should be able to assume these are the same size, so:
	for i, oldValue := range oldStringified {
		updatedValue := updatedStringified[i]
		if oldValue != updatedValue {
			log.Logger.Trace(fmt.Sprintf("Resource ID Segment Index %d differs", i))
			staticIdentifiers := d.staticIdentifiersInResourceIdSegments([]resourcemanager.ResourceIdSegment{
				updated.Segments[i], // only the changed Resource ID Segment
			})
			var staticIdentifier *string
			if len(staticIdentifiers) > 0 {
				staticIdentifier = pointer.To(staticIdentifiers[0])
			}

			output = append(output, changes.ResourceIdSegmentChangedValue{
				ServiceName:                serviceName,
				ApiVersion:                 apiVersion,
				ResourceName:               apiResource,
				ResourceIdName:             resourceIdName,
				SegmentIndex:               i,
				OldValue:                   oldValue,
				NewValue:                   updatedValue,
				StaticIdentifierInNewValue: staticIdentifier,
			})
		}
	}
	return output
}

// stringifyResourceIdSegments builds up a stringified version of the Resource ID segments for human understanding of the diff
func (d differ) stringifyResourceIdSegments(input []resourcemanager.ResourceIdSegment) []string {
	output := make([]string, 0)

	for _, item := range input {
		// We could JSON marshal these, but this is _probably_ clearer having this in text rather than JSON?
		components := []string{
			fmt.Sprintf("Name %q", item.Name),
			fmt.Sprintf("Type %q", string(item.Type)),
		}
		if item.ConstantReference != nil {
			components = append(components, fmt.Sprintf("ConstantReference %q", *item.ConstantReference))
		}
		if item.FixedValue != nil {
			components = append(components, fmt.Sprintf("FixedValue %q", *item.FixedValue))
		}
		components = append(components, fmt.Sprintf("ExampleValue %q", item.ExampleValue))
		output = append(output, strings.Join(components, " / "))
	}

	return output
}

// staticIdentifiersInResourceIdSegments retrieves a unique, sorted list of the static identifiers within the Resource ID Segments
// This comes from both Static Segments, Resource Provider Segments,
func (d differ) staticIdentifiersInResourceIdSegments(input []resourcemanager.ResourceIdSegment) []string {
	segments := make(map[string]struct{})

	// first pull out a unique list of fixed values from the different segment types
	for _, item := range input {
		if item.FixedValue != nil {
			segments[*item.FixedValue] = struct{}{}
		}
	}

	// then sort it
	output := make([]string, 0)
	for k := range segments {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}

// uniqueResourceIdNames returns a unique, sorted list of Resource ID Names from the keys of initial and updated.
func (d differ) uniqueResourceIdNames(initial, updated map[string]resourcemanager.ResourceIdDefinition) []string {
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
