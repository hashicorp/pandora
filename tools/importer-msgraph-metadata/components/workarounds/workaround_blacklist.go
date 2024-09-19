// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"slices"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ serviceWorkaround = workaroundBlacklist{}

// workaroundBlacklist drops resources that we do not support. It is not necessary to drop any corresponding
// resource IDs, since unused resource IDs are automatically excluded from being imported.
type workaroundBlacklist struct{}

func (workaroundBlacklist) Name() string {
	return "Blacklist / drop unsupported resources"
}

func (workaroundBlacklist) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	resourceNamesToDrop := make([]string, 0)

	switch serviceName {
	case "groups":
		for resourceName, resource := range resources {
			// Has conflicting paths that cannot be sensibly distinguished from each other, this causes
			// resources to clobber each other. For example:
			//   /groups/{groupId}/sites/{siteId}/termStores/{storeId}/sets/{setId}/terms/{termId}/children/{termId1}/relations/{relationId}
			//   /groups/{groupId}/sites/{siteId}/termStore/sets/{setId}/terms/{termId}/children/{termId1}/relations/{relationId}
			if strings.Contains(resource.Category, "TermStore") {
				resourceNamesToDrop = append(resourceNamesToDrop, resourceName)
			}
		}

	case "me":
		for resourceName, resource := range resources {
			// Has conflicting paths that cannot be sensibly distinguished from each other, this causes
			// resources to clobber each other. For example:
			//   /me/calendar/events/{eventId}/instances/{eventId1}/extensions/{extensionId}
			//   /me/calendars/{calendarId}/events/{eventId}/instances/{eventId1}/extensions/{extensionId}
			if strings.HasPrefix(resource.Category, "Calendar") {
				resourceNamesToDrop = append(resourceNamesToDrop, resourceName)
			}
		}

	case "users":
		for resourceName, resource := range resources {
			// Has conflicting paths that cannot be sensibly distinguished from each other, this causes
			// resources to clobber each other. For example:
			//   /users/{userId}/calendar/events/{eventId}/instances/{eventId1}/extensions/{extensionId}
			//   /users/{userId}/calendars/{calendarId}/events/{eventId}/instances/{eventId1}/extensions/{extensionId}
			if strings.HasPrefix(resource.Category, "Calendar") {
				resourceNamesToDrop = append(resourceNamesToDrop, resourceName)
			}
		}

	}

	// Ensure unique resource names, else we will fail to remove a resource that matches multiple criteria above
	resourceNamesToDrop = slices.Compact(resourceNamesToDrop)

	// Drop unsupported resources
	for _, resourceName := range resourceNamesToDrop {
		delete(resources, resourceName)
	}

	return nil
}
