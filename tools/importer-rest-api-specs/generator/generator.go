package generator

import (
	"fmt"
	"log"
	"os"
	"path"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type PandoraDefinitionGenerator struct {
	rootNamespace string
	serviceName   string
	apiVersion    string
	debugLog      bool
}

func NewPandoraDefinitionGenerator(rootNamespace, serviceName, apiVersion string, debug bool) PandoraDefinitionGenerator {
	return PandoraDefinitionGenerator{
		rootNamespace: rootNamespace,
		serviceName:   serviceName,
		apiVersion:    apiVersion,
		debugLog:      debug,
	}
}

func (g PandoraDefinitionGenerator) Generate(resourceName string, resource models.AzureApiResource, workingDirectory string) error {
	namespace := g.namespace(resourceName)
	if g.debugLog {
		log.Printf("[DEBUG] Generating %q..", namespace)
	}

	// TODO: we should duplicate the types depending on the operation
	// This would allow us to have a "CreateThing", "UpdateThing" and "GetThing" where "Thing"
	// defines a single model in the Swagger. These could then output the specifics for each field, for example
	// the GetThing model would be the only one with the ReadOnly fields output
	// We'd also need to parse the mutability data out of the fields, which we're not doing today - but exists in
	// the Swagger and is parsed out just unused

	if g.debugLog {
		log.Printf("[DEBUG] Generating Constants..")
	}
	for constantName, vals := range resource.Constants {
		if g.debugLog {
			log.Printf("Generating Constant %q (in %s)", constantName, namespace)
		}
		code := g.codeForConstant(namespace, constantName, vals)
		fileName := path.Join(workingDirectory, fmt.Sprintf("Constant-%s.cs", constantName))
		if err := g.writeToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", constantName, err)
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Models..")
	}
	for modelName, vals := range resource.Models {
		if g.debugLog {
			log.Printf("Generating Model %q (in %s)", modelName, namespace)
		}
		code, err := g.codeForModel(namespace, modelName, vals)
		if err != nil {
			return fmt.Errorf("generating code for model %q in %q: %+v", modelName, namespace, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Model-%s.cs", modelName))
		if *code != "" {
			if err := g.writeToFile(fileName, *code); err != nil {
				return fmt.Errorf("generating code for %q: %+v", modelName, err)
			}
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Operations..")
	}
	for operationName, operation := range resource.Operations {
		if g.debugLog {
			log.Printf("Generating Operation %q (in %s)", operationName, namespace)
		}
		code := g.codeForOperation(namespace, operationName, operation)
		fileName := path.Join(workingDirectory, fmt.Sprintf("Operation-%s.cs", operationName))
		if err := g.writeToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", operationName, err)
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Resource IDs..")
	}
	for name, id := range resource.ResourceIds {
		if g.debugLog {
			log.Printf("Generating Resource ID %q (in %s)", name, namespace)
		}
		code := g.codeForResourceID(namespace, name, id)
		fileName := path.Join(workingDirectory, fmt.Sprintf("ResourceId-%s.cs", name))
		if err := g.writeToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", name, err)
		}
	}

	// TODO: also generate the Resource Definition, API Version Definition and Service Definition?

	return nil
}

func (g PandoraDefinitionGenerator) RecommendedWorkingDirectory(rootDirectory, resourceName string) string {
	apiVersion := g.normalizeApiVersion()
	return path.Join(rootDirectory, g.rootNamespace, g.serviceName, apiVersion, resourceName)
}

func (g PandoraDefinitionGenerator) normalizeApiVersion() string {
	normalized := strings.ReplaceAll(g.apiVersion, "-", "_") // e.g. 2020-01-01-preview -> 2020_01_01_preview
	normalized = strings.ReplaceAll(normalized, ".", "_")    // e.g. 1.0 -> 1_0
	return fmt.Sprintf("v%s", normalized)
}

func (g PandoraDefinitionGenerator) codeForConstant(namespace, constantName string, details models.ConstantDetails) string {
	code := make([]string, 0)

	sortedKeys := make([]string, 0)
	for key := range details.Values {
		sortedKeys = append(sortedKeys, key)
	}
	sort.Strings(sortedKeys)

	for _, key := range sortedKeys {
		value := details.Values[key]
		normalizedKey := g.normalizeConstantKey(key)
		code = append(code, fmt.Sprintf("\t\t[Description(%q)]\n\t\t%s,", value, normalizedKey))
	}

	return fmt.Sprintf(`using System.ComponentModel;

namespace %[1]s
{
	internal enum %[2]s
	{
%[3]s
	}
}
`, namespace, constantName, strings.Join(code, "\n\n"))
}

func (g PandoraDefinitionGenerator) codeForModel(namespace string, modelName string, model models.ModelDetails) (*string, error) {
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q in namespace %q has no fields", modelName, namespace)
	}

	code := make([]string, 0)

	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]
		fieldCode, err := g.codeForField("\t\t", fieldName, field)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}
		code = append(code, *fieldCode)
	}

	out := fmt.Sprintf(`using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace %[1]s
{
	internal class %[2]s
	{
%[3]s
	}
}
`, namespace, modelName, strings.Join(code, "\n\n"))
	return &out, nil
}

func (g PandoraDefinitionGenerator) codeForField(indentation, fieldName string, field models.FieldDefinition) (*string, error) {
	fieldType, err := dotNetTypeNameForComplexType(field)
	if err != nil {
		return nil, err
	}

	lines := make([]string, 0)

	if field.Type == models.DateTime {
		// TODO: support for custom date formats
		lines = append(lines, fmt.Sprintf("%[1]s[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]", indentation))
	}

	lines = append(lines, fmt.Sprintf("%[1]s[JsonPropertyName(%[2]q)]", indentation, field.JsonName))

	if field.Required {
		lines = append(lines, fmt.Sprintf("%[1]s[Required]", indentation))
	} else {
		typeName := fmt.Sprintf("%s?", *fieldType)
		fieldType = &typeName
	}

	lines = append(lines, fmt.Sprintf("%[1]spublic %[2]s %[3]s { get; set; }", indentation, *fieldType, strings.Title(fieldName)))
	out := strings.Join(lines, "\n")
	return &out, nil
}

func (g PandoraDefinitionGenerator) codeForOperation(namespace string, operationName string, operation models.OperationDetails) string {
	code := make([]string, 0)

	if g.usesNonDefaultStatusCodes(operation) {
		statusCodes := make([]string, 0)
		for _, sc := range operation.ExpectedStatusCodes {
			statusCodes = append(statusCodes, fmt.Sprintf("\t\t\t\t%s,", g.dotnetNameForStatusCode(sc)))
		}
		code = append(code, fmt.Sprintf(`		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
%s
			};
		}`, strings.Join(statusCodes, "\n")))
	}

	if operation.FieldContainingPaginationDetails != nil {
		code = append(code, fmt.Sprintf(`		public override string? FieldContainingPaginationDetails()
		{
			return %[1]q;
		}`, *operation.FieldContainingPaginationDetails))
	}

	// TODO: other fields, status codes if they're non-default
	if operation.LongRunning {
		code = append(code, `		public override bool LongRunning()
		{
			return true;
		}`)
	}

	if operation.RequestObjectName != nil {
		code = append(code, fmt.Sprintf(`		public override object? RequestObject()
		{
			return new %[1]s();
		}`, *operation.RequestObjectName))
	} else if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
		// Post and Put operations should have one but it's possible they don't
		code = append(code, fmt.Sprintf(`		public override object? RequestObject()
		{
			return null;
		}`))
	}

	if operation.ResourceIdName != nil {
		code = append(code, fmt.Sprintf(`		public override ResourceID? ResourceId()
		{
			return new %[1]s();
		}`, *operation.ResourceIdName))
	}

	if operation.ResponseObjectName != nil {
		code = append(code, fmt.Sprintf(`		public override object? ResponseObject()
		{
			return new %[1]s();
		}`, *operation.ResponseObjectName))
	}

	optionsCode := make([]string, 0)
	if len(operation.Options) > 0 {
		code = append(code, fmt.Sprintf(`		public override object? OptionsObject()
		{
			return new %[1]qOptions();
		}`, operationName))

		optionsCode = append(optionsCode, fmt.Sprintf("\n\tinternal class %sOptions", operationName))
		for optionName, optionDetails := range operation.Options {
			optionsCode = append(optionsCode, "\t{")
			if optionDetails.QueryStringName != "" {
				optionsCode = append(optionsCode, fmt.Sprintf("\t\t[QueryStringName(%q)]", optionDetails.QueryStringName))
			}
			if !optionDetails.Required {
				optionsCode = append(optionsCode, "\t\t[Optional]")
			}
			optionsCode = append(optionsCode, fmt.Sprintf("\t\tpublic %s %s { get; set; }", optionDetails.FieldType, optionName))
			optionsCode = append(optionsCode, "\t") // spacer
		}
		optionsCode = append(optionsCode, "\t}")
	}

	if operation.UriSuffix != nil {
		code = append(code, fmt.Sprintf(`		public override string? UriSuffix()
		{
			return %[1]q;
		}`, *operation.UriSuffix))
	}

	operationType := strings.Title(strings.ToLower(operation.Method))
	return fmt.Sprintf(`using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class %[2]s : %[3]sOperation
	{
%[4]s
	}%[5]s
}
`, namespace, operationName, operationType, strings.Join(code, "\n\n"), strings.Join(optionsCode, "\n"))
}

func (g PandoraDefinitionGenerator) codeForResourceID(namespace string, resourceIdName string, resourceIdValue string) string {
	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class %[2]s : ResourceID
	{
		public string ID() => "%[3]s";
	}
}
`, namespace, resourceIdName, resourceIdValue)
}

func (g PandoraDefinitionGenerator) namespace(resourceName string) string {
	normalizedApiVersion := g.normalizeApiVersion()
	return fmt.Sprintf("%s.%s.%s.%s", g.rootNamespace, strings.Title(g.serviceName), normalizedApiVersion, strings.Title(resourceName))
}

func (g PandoraDefinitionGenerator) writeToFile(fileName, fileContents string) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.WriteString(fileContents)
	file.Close()
	return nil
}

func (g PandoraDefinitionGenerator) usesNonDefaultStatusCodes(operation models.OperationDetails) bool {
	defaultStatusCodes := map[string][]int{
		"get":    {200},
		"post":   {200, 201},
		"put":    {200, 201},
		"delete": {200, 201},
		"patch":  {200, 201},
	}
	expected, ok := defaultStatusCodes[strings.ToLower(operation.Method)]
	if !ok {
		// potentially an unsupported use-case but fine for now
		return true
	}

	if len(expected) != len(operation.ExpectedStatusCodes) {
		return true
	}

	sort.Ints(expected)
	sort.Ints(operation.ExpectedStatusCodes)
	for i, ev := range expected {
		av := operation.ExpectedStatusCodes[i]
		if ev != av {
			return true
		}
	}

	return false
}

func (g PandoraDefinitionGenerator) dotnetNameForStatusCode(input int) string {
	switch input {
	case 200:
		return "HttpStatusCode.OK"
	case 201:
		return "HttpStatusCode.Created"
	case 202:
		return "HttpStatusCode.Accepted"
	case 204:
		return "HttpStatusCode.NoContent"
	case 301:
		return "HttpStatusCode.Moved"
	case 302:
		return "HttpStatusCode.Found"

	default:
		return fmt.Sprintf("TODO: support %d", input)
	}
}

func (g PandoraDefinitionGenerator) normalizeConstantKey(input string) string {
	output := input
	output = strings.ReplaceAll(output, ",", "")
	output = strings.ReplaceAll(output, " ", "")
	return output
}

func dotNetTypeNameForComplexType(field models.FieldDefinition) (*string, error) {
	var nilableType = func(input string) (*string, error) {
		return &input, nil
	}

	switch field.Type {
	case models.Boolean, models.DateTime, models.Integer, models.String:
		return dotNetTypeNameForSimpleType(field.Type)

	case models.Dictionary:
		{
			if field.ConstantReference != nil {
				return nilableType(fmt.Sprintf("Dictionary<string, %s>", *field.ConstantReference))
			}
			if field.ModelReference != nil {
				return nilableType(fmt.Sprintf("Dictionary<string, %s>", *field.ModelReference))
			}

			// TODO: we could have keys of other types, but this is likely fine for now
			return nil, fmt.Errorf("the Dictionary has no Nested Element Type")
		}

	case models.List:
		{
			if field.ConstantReference != nil {
				return nilableType(fmt.Sprintf("List<%s>", *field.ConstantReference))
			}
			if field.ModelReference != nil {
				return nilableType(fmt.Sprintf("List<%s>", *field.ModelReference))
			}
			if field.ListElementType != nil {
				nestedType := ""
				if *field.ListElementType == models.Object {
					// not ideal, but it'll do for now since there's no definition for this
					nestedType = "object"
				} else {
					nestedTypeName, err := dotNetTypeNameForSimpleType(*field.ListElementType)
					if err != nil {
						return nil, fmt.Errorf("determining Type for nested Element %q: %+v", string(*field.ListElementType), err)
					}
					nestedType = *nestedTypeName
				}

				return nilableType(fmt.Sprintf("List<%s>", nestedType))
			}

			return nil, fmt.Errorf("the List has no Nested Element Type")
		}

	case models.Object:
		if field.ConstantReference != nil {
			return nilableType(*field.ConstantReference)
		}
		if field.ModelReference != nil {
			return nilableType(*field.ModelReference)
		}

		// for example JSON fields
		return nilableType("object")

	// Custom Types exist for these
	case models.Location:
		return nilableType("Location")
	case models.Tags:
		return nilableType("Tags")
	}

	return nil, fmt.Errorf(fmt.Sprintf("TODO: unsupported type %q", string(field.Type)))
}

func dotNetTypeNameForSimpleType(input models.FieldDefinitionType) (*string, error) {
	var nilableType = func(input string) (*string, error) {
		return &input, nil
	}

	switch input {
	case models.Boolean:
		return nilableType("bool")

	case models.DateTime:
		return nilableType("DateTime")

	case models.Float:
		return nilableType("float")

	case models.Integer:
		return nilableType("int")

	case models.String:
		return nilableType("string")
	}

	return nil, fmt.Errorf("type %q is not a simple type", string(input))
}
