package pipeline

import (
	"fmt"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/jedib0t/go-pretty/v6/table"
	"github.com/jedib0t/go-pretty/v6/text"
	"os"
	"path/filepath"
	"sort"
	"strings"
)

func OutputSupportedServices(input RunInput) error {
	for _, apiVersion := range input.SupportedVersions {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, apiVersion)

		spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
		if err != nil {
			return err
		}

		serviceTags, err := parseTags(spec.Tags)
		if err != nil {
			return err
		}

		serviceTagNames := make([]string, 0, len(serviceTags))
		for serviceTag := range serviceTags {
			serviceTagNames = append(serviceTagNames, serviceTag)
		}
		sort.Strings(serviceTagNames)

		t := table.NewWriter()
		t.SetOutputMirror(os.Stdout)
		t.SetTitle("Version: %s", apiVersion)
		t.AppendHeader(table.Row{"Service Tag", "Resource Tags"})

		for _, serviceTag := range serviceTagNames {
			resourceTags := strings.Join(serviceTags[serviceTag], ", ")
			t.AppendRow(table.Row{serviceTag, text.WrapSoft(resourceTags, 100)})
		}

		t.SetStyle(table.StyleColoredMagentaWhiteOnBlack)
		t.Render()
		fmt.Println()
	}

	return nil
}
