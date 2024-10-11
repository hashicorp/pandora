// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
)

func (s *Generator) readmeFile(data GeneratorData) error {
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
	if err := s.writeToPathForResource(data.resourceOutputPath, "README.md", t, data); err != nil {
		return fmt.Errorf("templating README file: %+v", err)
	}

	return nil
}
