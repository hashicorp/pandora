// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"regexp"
	"strings"
)

// DeDuplicateName reduces duplication in long form constant/model names. Since we typically prefix these to provide
// some namespacing, this can lead to excessive duplication which we try to cut down on here.
// Rules:
// 1. Immediately duplicated words should be removed, e.g. "GroupGroupMember"
// 2. Chains of successive words that match should be removed, e.g. "GroupMemberGroupMemberRef"
// 3. Single duplicate words that are not adjacent should not be removed, e.g. "GroupMemberGroupOwner"
// 4. Duplicate chains of words that reach the end of the string should not be removed, e.g. "SynchronizationSecretKeySynchronizationSecret"
// 5. Words should be compared in their singular form, but retained in their existing form, whether singular or plural
func DeDuplicateName(name string) string {
	nameSpaced := regexp.MustCompile("([A-Z])").ReplaceAllString(name, " $1")
	nameParts := strings.Split(strings.TrimSpace(nameSpaced), " ")

	singularParts := make([]string, len(nameParts))
	for i, s := range nameParts {
		singularParts[i] = Singularize(s)
	}

	newParts := make([]string, 0)
	var buffer []string
	var matchStart, offset int

	for i := 0; i < len(nameParts); i++ {
		if i > 0 {
			// preceding word is identical, omit this word
			if strings.EqualFold(singularParts[i], singularParts[i-1]) {
				offset++
				continue
			}

			if matchStart < 0 {
				// look for a matching word to begin a chain
				for matchStart = offset; matchStart < i; matchStart++ {
					if strings.EqualFold(singularParts[i], singularParts[matchStart]) {
						buffer = append(buffer, nameParts[i])
						break
					}
				}
				if len(buffer) > 0 {
					continue
				}
			} else if matchStart+len(buffer) < i && strings.EqualFold(singularParts[i], singularParts[matchStart+len(buffer)]) {
				// continue matching if a chain was started
				buffer = append(buffer, nameParts[i])
				continue
			} else if len(buffer) == 1 {
				// if a chain was only a single word, that doesn't count
				newParts = append(newParts, buffer[0])
			}
		}

		buffer = make([]string, 0)
		matchStart = -1
		newParts = append(newParts, nameParts[i])
	}

	// retain the final segment if it was specified and trimmed
	if len(buffer) > 0 {
		newParts = append(newParts, buffer...)
	}

	return strings.Join(newParts, "")
}
