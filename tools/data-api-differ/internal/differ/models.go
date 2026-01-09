// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import "github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"

type Result struct {
	// Changes is a slice of the Changes present between the two paths
	Changes []changes.Change
}

func (r Result) ContainsBreakingChanges() bool {
	for _, change := range r.Changes {
		if change.IsBreaking() {
			return true
		}
	}

	return false
}

func (r Result) ContainsNonBreakingChanges() bool {
	for _, change := range r.Changes {
		if !change.IsBreaking() {
			return true
		}
	}

	return false
}
