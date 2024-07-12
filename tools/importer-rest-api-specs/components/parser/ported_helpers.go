// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

func fragmentNameFromReference(input spec.Ref) *string {
	fragmentName := input.String()
	return fragmentNameFromString(fragmentName)
}

func fragmentNameFromString(fragmentName string) *string {
	if fragmentName != "" {
		fragments := strings.Split(fragmentName, "/") // format #/definitions/ConfigurationStoreListResult
		referenceName := fragments[len(fragments)-1]
		return &referenceName
	}

	return nil
}

func inlinedModelName(parentModelName, fieldName string) string {
	// intentionally split out for consistency
	val := fmt.Sprintf("%s%s", strings.Title(parentModelName), strings.Title(fieldName))
	return cleanup.NormalizeName(val)
}

func operationMatchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if strings.EqualFold(thisTag, *tag) {
			return true
		}
	}

	return false
}

func referencesAreTheSame(first []string, second []string) bool {
	if len(first) != len(second) {
		return false
	}

	// first load the existing keys
	keys := make(map[string]struct{}, 0)
	for _, key := range first {
		keys[key] = struct{}{}
	}

	// then check the remaining ones
	for _, key := range second {
		if _, exists := keys[key]; !exists {
			return false
		}
	}

	return true
}

func isFieldRequired(name string, required map[string]struct{}) bool {
	for k := range required {
		// assume data inconsistencies
		if strings.EqualFold(k, name) {
			return true
		}
	}

	return false
}
