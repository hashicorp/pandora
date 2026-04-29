// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"bytes"
	"fmt"
	"sort"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// GenerateOptions defines the configuration for the markdown generation.
type GenerateOptions struct {
	// APIDefinitionsDirectory is the path to the api-definitions directory.
	APIDefinitionsDirectory string

	// SourceDataType specifies the data type to load (e.g. ResourceManager).
	SourceDataType sdkModels.SourceDataType

	// ServiceNamesToLimitTo allows filtering down to specific services.
	ServiceNamesToLimitTo []string

	Logger hclog.Logger
}

// Generate reads the API definitions and returns a map of file path to markdown content.
func Generate(opts GenerateOptions) (map[string][]byte, error) {
	if opts.Logger == nil {
		opts.Logger = hclog.NewNullLogger()
	}

	opts.Logger.Info("Initializing data repository...")
	var limitTo *[]string
	if len(opts.ServiceNamesToLimitTo) > 0 {
		limitTo = &opts.ServiceNamesToLimitTo
	}

	repo, err := repository.NewRepository(opts.APIDefinitionsDirectory, opts.SourceDataType, limitTo, opts.Logger)
	if err != nil {
		return nil, fmt.Errorf("initializing repository: %v", err)
	}

	opts.Logger.Info("Loading all services...")
	servicesMap, err := repo.GetAllServices()
	if err != nil {
		return nil, fmt.Errorf("loading services: %v", err)
	}

	if servicesMap == nil {
		return nil, fmt.Errorf("no services loaded")
	}

	result := make(map[string][]byte)

	for serviceName, service := range *servicesMap {
		for version, apiVersion := range service.APIVersions {
			for resourceName, apiResource := range apiVersion.Resources {
				// We create one file per API Resource
				// Path format: resource-manager/{ServiceName}/{Version}/{ResourceName}.md
				path := fmt.Sprintf("%s/%s/%s/%s.md", string(opts.SourceDataType), serviceName, version, resourceName)
				provider := ""
				if service.ResourceProvider != nil {
					provider = *service.ResourceProvider
				}
				content := generateResourceMarkdown(serviceName, provider, version, resourceName, apiResource)
				result[path] = content
			}
		}
	}

	return result, nil
}

func generateResourceMarkdown(serviceName, provider, version, resourceName string, resource sdkModels.APIResource) []byte {
	var buf bytes.Buffer

	buf.WriteString(fmt.Sprintf("# Resource: %s\n", resourceName))
	buf.WriteString(fmt.Sprintf("**Service**: %s\n", serviceName))
	buf.WriteString(fmt.Sprintf("**Provider**: %s\n", provider))
	buf.WriteString(fmt.Sprintf("**API Version**: %s\n\n", version))

	// Operations
	buf.WriteString("## Operations\n")
	if len(resource.Operations) == 0 {
		buf.WriteString("*No operations defined.*\n\n")
	} else {
		// Sort operations for deterministic output
		opNames := make([]string, 0, len(resource.Operations))
		for k := range resource.Operations {
			opNames = append(opNames, k)
		}
		sort.Strings(opNames)

		for _, opName := range opNames {
			op := resource.Operations[opName]
			buf.WriteString(fmt.Sprintf("*   **%s**: `%s`\n", opName, op.Method))
		}
		buf.WriteString("\n")
	}

	// Models
	buf.WriteString("## Models\n")
	if len(resource.Models) == 0 {
		buf.WriteString("*No models defined.*\n\n")
	} else {
		modelNames := make([]string, 0, len(resource.Models))
		for k := range resource.Models {
			modelNames = append(modelNames, k)
		}
		sort.Strings(modelNames)

		for _, modelName := range modelNames {
			model := resource.Models[modelName]
			buf.WriteString(fmt.Sprintf("### %s\n", modelName))

			if len(model.Fields) == 0 {
				buf.WriteString("*No fields defined.*\n\n")
				continue
			}

			// Keep fields stable
			fieldNames := make([]string, 0, len(model.Fields))
			for k := range model.Fields {
				fieldNames = append(fieldNames, k)
			}
			sort.Strings(fieldNames)

			for _, fieldName := range fieldNames {
				field := model.Fields[fieldName]
				typeStr := string(field.ObjectDefinition.Type)

				// Add reference details if it's a reference type
				if field.ObjectDefinition.Type == sdkModels.ReferenceSDKObjectDefinitionType && field.ObjectDefinition.ReferenceName != nil {
					typeStr = fmt.Sprintf("Reference -> %s", *field.ObjectDefinition.ReferenceName)
				}

				reqStr := "[Optional]"
				if field.Required {
					reqStr = "[Required]"
				}

				modifiers := ""
				if field.Sensitive {
					modifiers += " [Sensitive]"
				}
				if field.ReadOnly {
					modifiers += " [ReadOnly]"
				}
				if field.ContainsDiscriminatedValue {
					modifiers += " [ContainsDiscriminatedTypeValue: true]"
				}

				buf.WriteString(fmt.Sprintf("*   `%s` (%s): %s%s\n", fieldName, typeStr, reqStr, modifiers))
			}
			buf.WriteString("\n")
		}
	}

	return buf.Bytes()
}
