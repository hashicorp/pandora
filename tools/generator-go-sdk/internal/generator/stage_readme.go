// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
	"sort"
)

func (s *ServiceGenerator) readmeFile(data ServiceGeneratorData, logger hclog.Logger) error {
	if len(data.models) == 0 {
		return nil
	}

	sortedOperationNames := make([]string, 0)
	for name := range data.operations {
		sortedOperationNames = append(sortedOperationNames, name)
	}
	sort.Strings(sortedOperationNames)

	t := readmeTemplater{
		sortedOperationNames: sortedOperationNames,
		operations:           data.operations,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "README.md", t, data, logging.Log); err != nil {
		return fmt.Errorf("templating README file: %+v", err)
	}

	return nil
}
