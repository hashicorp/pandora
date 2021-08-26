package parser

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

func normalizeOperationName(operationId string, tag *string) string {
	operationName := operationId
	if tag != nil {
		operationName = strings.TrimPrefix(operationName, *tag)
	}
	operationName = strings.ReplaceAll(operationName, "_", "")
	operationName = strings.TrimPrefix(operationName, "Operations") // sanity checking
	operationName = strings.TrimPrefix(operationName, "s")          // plurals
	operationName = strings.TrimPrefix(operationName, "_")
	operationName = cleanup.NormalizeSegment(operationName, false)
	return operationName
}

func normalizeSegmentName(input string) string {
	output := input
	output = cleanup.NormalizeName(output)

	// todo: something better than this
	if strings.HasSuffix(output, "s") && !strings.HasSuffix(output, "ies") {
		output = strings.TrimSuffix(output, "s")
	}

	output = strings.Title(output)
	return output
}

func normalizeTag(input string) string {
	// NOTE: we could be smarter here, but given this is a handful of cases it's
	// probably prudent to hard-code these for now (and fix the swaggers as we
	// come across them?)
	output := input
	output = strings.ReplaceAll(output, "NetWork", "Network")
	return output
}
