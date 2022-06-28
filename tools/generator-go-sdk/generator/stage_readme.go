package generator

import (
	"fmt"
	"sort"
)

func (s *ServiceGenerator) readmeFile(data ServiceGeneratorData) error {
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
	if err := s.writeToPath(data.outputPath, "README.md", t, data); err != nil {
		return fmt.Errorf("templating README file: %+v", err)
	}

	return nil
}
