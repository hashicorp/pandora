package generator

import (
	"fmt"
	"sort"
	"strings"
)

func (s *ServiceGenerator) idAliases(data ServiceGeneratorData) error {
	if !data.useIdAliases {
		return nil
	}

	return s.writeToPath(data.outputPath, "ids.go", idAliasesTemplater{}, data)
}

var _ templater = idAliasesTemplater{}

type idAliasesTemplater struct {
}

func (t idAliasesTemplater) template(data ServiceGeneratorData) (*string, error) {
	keys := make([]string, 0)
	for k := range data.resourceIds {
		nameWithoutSuffix := strings.TrimSuffix(k, "Id") // we suffix 'Id' and 'ID' in places
		keys = append(keys, nameWithoutSuffix)
	}
	sort.Strings(keys)

	aliases := make([]string, 0)
	for _, key := range keys {
		aliases = append(aliases, fmt.Sprintf(`type %[1]sId = ids.%[1]sId
func Parse%[1]sID = ids.Parse%[1]sID
func Parse%[1]sIDInsensitively = ids.Parse%[1]sIDInsensitively
`, key))
	}

	output := fmt.Sprintf(`package %[1]s

import "github.com/hashicorp/pandora/sdk/services/%[2]s/%[3]s/ids"

%[4]s
`, data.packageName, data.servicePackageName, data.apiVersion, strings.Join(aliases, "\n\n"))
	return &output, nil
}
