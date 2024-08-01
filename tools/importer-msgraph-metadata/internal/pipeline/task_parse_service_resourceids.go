// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

func (p pipelineForService) parseResourceIDs() (resourceIds parser.ResourceIds, err error) {
	return parser.ParseResourceIDs(p.spec.Paths, &p.service)
}
