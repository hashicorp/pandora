package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"
)

type operationUri struct {
	segments []string
}

func newOperationUri(input string) operationUri {
	segments := strings.Split(strings.TrimPrefix(input, "/"), "/")
	for i, v := range segments {
		segment := cleanup.NormalizeSegment(v, true)
		if v != segment {
			segments[i] = segment
		}
	}
	return operationUri{
		segments: segments,
	}
}

func (u operationUri) normalizedUri() string {
	return fmt.Sprintf("/%s", strings.Join(u.segments, "/"))
}

func (u operationUri) isArmResourceId() bool {
	if len(u.segments)%2 != 0 {
		return false
	}

	for _, segment := range u.segments {
		if segment == "resourceGroups" {
			return true
		}
	}

	return false
}

func (u operationUri) findTopLevelArmResourceId() *string {
	for i := len(u.segments) - 1; i > 0; i-- {
		segment := u.segments[i]
		if segmentIsUserSpecifiable(segment) {
			val := fmt.Sprintf("/%s", strings.Join(u.segments[0:i+1], "/"))
			return &val
		}
	}

	return nil
}

func (u operationUri) userSpecifiableSegmentName() *string {
	for i := len(u.segments) - 1; i > 0; i-- {
		segment := u.segments[i]
		if segmentIsUserSpecifiable(segment) {
			// if it's the first segment (e.g. `{thing}/something`) we'll have to take that
			if i == 0 {
				segment = strings.TrimPrefix(segment, "{")
				segment = strings.TrimSuffix(segment, "}")
				return &segment
			}

			// else we want the item before it e.g. /.../virtualMachines/{name}
			parentSegment := u.segments[i-1]
			if segmentIsUserSpecifiable(parentSegment) {
				// it's possible that this can be `../{thing}/{thing}`
				continue
			}
			return &parentSegment
		}
	}

	return nil
}

func (u operationUri) userSpecifiableSegments() (*[]string, error) {
	//if !u.isArmResourceId() {
	//	return nil, fmt.Errorf("non-arm uri's are unimplemented")
	//}

	segments := make([]string, 0)

	for _, segment := range u.segments {
		if !segmentIsUserSpecifiable(segment) {
			segments = append(segments, segment)
		}
	}

	return &segments, nil
}

func (u operationUri) suffix() *string {
	// an ARM ID should be Key-Value Pairs, however there's 'suffixes' to this e.g. {id}/restart
	if len(u.segments)%2 != 0 {
		val := u.segments[len(u.segments)-1]
		return &val
	}

	return nil
}

func (u operationUri) isTopLevelArmResource() bool {
	lastSegment := u.segments[len(u.segments)-1]
	return segmentIsUserSpecifiable(lastSegment)
}

func (u operationUri) shouldBeIgnored() bool {
	uri := u.normalizedUri()

	// we're not concerned with exposing the "operations" API's at this time - e.g.
	// /providers/Microsoft.EnterpriseKnowledgeGraph/services
	if strings.HasPrefix(strings.ToLower(uri), "/providers/") {
		return true
	}
	// or /subscriptions/{subscriptionId}/providers/Microsoft.EnterpriseKnowledgeGraph/services
	if v := strings.TrimPrefix(strings.ToLower(uri), "/subscriptions/{subscriptionid}"); strings.HasPrefix(v, "/providers/") {
		return true
	}
	// LRO's shouldn't be directly exposed, ignore bad data
	if strings.Contains(strings.ToLower(uri), "/operationresults/{operationid}") {
		return true
	}

	return false
}

func segmentIsUserSpecifiable(input string) bool {
	return strings.HasPrefix(input, "{") && strings.HasSuffix(input, "}")
}

func fragmentNameFromReference(input spec.Ref) *string {
	fragmentName := input.String()
	if fragmentName != "" {
		fragments := strings.Split(fragmentName, "/") // format #/definitions/ConfigurationStoreListResult
		referenceName := fragments[len(fragments)-1]
		return &referenceName
	}

	return nil
}

func normalizeModelName(input string) string {
	out := input
	out = cleanup.NormalizeSegment(out, false)
	out = strings.Title(out)
	return out
}

func normalizeOperationName(operationId string, tag *string) string {
	operationName := operationId
	if tag != nil {
		operationName = strings.TrimPrefix(operationName, *tag)
	}
	operationName = strings.TrimPrefix(operationName, "Operations") // sanity checking
	operationName = strings.TrimPrefix(operationName, "s")          // plurals
	operationName = strings.TrimPrefix(operationName, "_")
	operationName = cleanup.NormalizeSegment(operationName, false)
	return operationName
}

func operationMatchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if thisTag == *tag {
			return true
		}
	}

	return false
}
