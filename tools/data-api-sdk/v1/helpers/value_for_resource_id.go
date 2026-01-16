// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: tests covering this

// DisplayValueForResourceID returns the templated value for this Resource ID
func DisplayValueForResourceID(input models.ResourceID) string {
	components := make([]string, 0)
	for _, segment := range input.Segments {
		if segment.FixedValue != nil {
			components = append(components, *segment.FixedValue)
			continue
		}

		components = append(components, fmt.Sprintf("{%s}", segment.Name))
	}

	return fmt.Sprintf("/%s", strings.Join(components, "/"))
}
