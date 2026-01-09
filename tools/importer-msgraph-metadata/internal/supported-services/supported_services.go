// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package supported_services

import (
	"fmt"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
	"github.com/jedib0t/go-pretty/v6/table"
	"github.com/jedib0t/go-pretty/v6/text"
)

type SupportedServicesInput struct {
	Logger             hclog.Logger
	MetadataDirectory  string
	OpenApiFilePattern string
}

func OutputSupportedServices(input SupportedServicesInput) error {
	for _, apiVersion := range versions.Supported {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, versions.Upstream(apiVersion))

		spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
		if err != nil {
			return err
		}

		serviceTags, err := tags.Parse(spec.Tags)
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
