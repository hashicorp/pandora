package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templaterForResource = methodsPandoraTemplater{}

type methodsPandoraTemplater struct {
	operation     resourcemanager.ApiOperation
	operationName string
	constants     map[string]resourcemanager.ConstantDetails
}

func (c methodsPandoraTemplater) template(data ServiceGeneratorData) (*string, error) {
	methods, err := c.methods(data)
	if err != nil {
		return nil, fmt.Errorf("building methods: %+v", err)
	}

	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"net/http"
	"net/url"

	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/odata"
)

%[2]s

%[3]s
`, data.packageName, *copyrightLines, *methods)
	return &template, nil
}

func (c methodsPandoraTemplater) methods(data ServiceGeneratorData) (*string, error) {
	switch strings.ToUpper(c.operation.Method) {
	case "DELETE":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for DELETE Operations")
		}

		return c.immediateOperationTemplate(data)

	case "GET":
		if c.operation.LongRunning {
			return nil, fmt.Errorf("`GET` operations cannot be long-running")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return c.listOperationTemplate(data)
		}

		return c.immediateOperationTemplate(data)

	case "HEAD":
		if c.operation.LongRunning {
			return nil, fmt.Errorf("`HEAD` operations cannot be long running")
		}
		if c.operation.RequestObject != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have request objects")
		}
		if c.operation.ResponseObject != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have response objects")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for HEAD Operations")
		}

		return c.immediateOperationTemplate(data)

	case "PATCH":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for PATCH Operations")
		}

		return c.immediateOperationTemplate(data)

	case "POST":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return c.listOperationTemplate(data)
		}

		return c.immediateOperationTemplate(data)

	case "PUT":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for PUT Operations")
		}

		return c.immediateOperationTemplate(data)
	}

	return nil, fmt.Errorf("unsupported HTTP Method %q", c.operation.Method)
}

func (c methodsPandoraTemplater) immediateOperationTemplate(data ServiceGeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for immediate operation: %+v", err)
	}
	requestOptions, err := c.requestOptions(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	marshalerCode, err := c.marshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building marshaler template: %+v", err)
	}
	unmarshalerCode, err := c.unmarshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building unmarshaler template: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}

	templated := fmt.Sprintf(`
%[7]s
%[8]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[3]s) (result %[2]sOperationResponse, err error) {
	opts := %[4]s

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	%[5]s

	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[6]s

	return
}

`, data.serviceClientName, c.operationName, *methodArguments, *requestOptions, *marshalerCode, *unmarshalerCode, *responseStruct, *optionsStruct)
	return &templated, nil
}

func (c methodsPandoraTemplater) longRunningOperationTemplate(data ServiceGeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for long running template: %+v", err)
	}
	requestOptions, err := c.requestOptions(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	marshalerCode, err := c.marshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building marshaler template: %+v", err)
	}
	unmarshalerCode, err := c.unmarshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building unmarshaler template: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}

	templated := fmt.Sprintf(`
%[8]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[3]s) (result %[2]sOperationResponse, err error) {
	opts := %[4]s

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	%[5]s

	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[6]s

	result.Poller, err = resourcemanager.PollerFromResponse(resp, c.Client)
	if err != nil {
		return
	}

	return
}

// %[2]sThenPoll performs %[2]s then polls until it's completed
func (c %[1]s) %[2]sThenPoll(ctx context.Context %[3]s) error {
	result, err := c.%[2]s(ctx %[7]s)
	if err != nil {
		return fmt.Errorf("performing %[2]s: %%+v", err)
	}

	if err := result.Poller.PollUntilDone(ctx); err != nil {
		return fmt.Errorf("polling after %[2]s: %%+v", err)
	}

	return nil
}
`, data.serviceClientName, c.operationName, *methodArguments, *requestOptions, *marshalerCode, *unmarshalerCode, argumentsCode, *responseStruct, *optionsStruct)
	return &templated, nil
}

func (c methodsPandoraTemplater) listOperationTemplate(data ServiceGeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for list operation: %+v", err)
	}
	requestOptions, err := c.requestOptions(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	unmarshalerCode, err := c.unmarshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building unmarahaler template: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	typeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
	if err != nil {
		return nil, fmt.Errorf("determining golang type name for response object: %+v", err)
	}

	templated := fmt.Sprintf(`
%[6]s
%[7]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[3]s) (result %[2]sOperationResponse, err error) {
	opts := %[4]s

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.ExecutePaged(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[5]s

	return
}
`, data.serviceClientName, c.operationName, *methodArguments, *requestOptions, *unmarshalerCode, *responseStruct, *optionsStruct)

	// Only output predicate functions for models and not for base types like string, int etc.
	if c.operation.ResponseObject.Type == resourcemanager.ReferenceApiObjectDefinitionType || c.operation.ResponseObject.Type == resourcemanager.ListApiObjectDefinitionType {
		templated += fmt.Sprintf(`

// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[4]s) (%[2]sCompleteResult, error) {
	return c.%[2]sCompleteMatchingPredicate(ctx%[6]s, %[7]sOperationPredicate{})
}

// %[2]sCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c %[1]s) %[2]sCompleteMatchingPredicate(ctx context.Context%[4]s, predicate %[7]sOperationPredicate) (result %[2]sCompleteResult, err error) {
	items := make([]%[7]s, 0)

	resp, err := c.%[2]s(ctx%[6]s)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			if predicate.Matches(v) {
				items = append(items, v)
			}
		}
	}

	result = %[2]sCompleteResult{
		Items: items,
	}
	return
}
`, data.serviceClientName, c.operationName, data.packageName, *methodArguments, *responseStruct, argumentsCode, *typeName)
	} else {
		templated += fmt.Sprintf(`
// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[3]s) (result %[2]sCompleteResult, err error) {
	items := make([]%[5]s, 0)

	resp, err := c.%[2]s(ctx%[4]s)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			items = append(items, v)
		}
	}

	result = %[2]sCompleteResult{
		Items: items,
	}
	return
}
`, data.serviceClientName, c.operationName, *methodArguments, argumentsCode, *typeName)
	}
	return &templated, nil
}

func (c methodsPandoraTemplater) argumentsTemplate() string {
	args := make([]string, 0)
	if c.operation.ResourceIdName != nil {
		args = append(args, "id")
	}
	if c.operation.RequestObject != nil {
		args = append(args, "input")
	}
	if len(c.operation.Options) > 0 {
		args = append(args, "options")
	}
	if len(args) == 0 {
		return ""
	}

	return fmt.Sprintf(", %s", strings.Join(args, ", "))
}

func (c methodsPandoraTemplater) requestArgumentsTemplate() string {
	args := make([]string, 0)

	if c.operation.UriSuffix != nil {
		if c.operation.ResourceIdName != nil {
			args = append(args, fmt.Sprintf("fmt.Sprintf(\"%%s%s\", id.ID())", *c.operation.UriSuffix))
		} else {
			args = append(args, *c.operation.UriSuffix)
		}
	} else {
		if c.operation.ResourceIdName != nil {
			args = append(args, "id.ID()")
		}
	}

	args = append(args, "defaultApiVersion")

	if len(c.operation.Options) > 0 {
		args = append(args, "options")
	} else {
		args = append(args, "nil")
	}

	switch strings.ToUpper(c.operation.Method) {
	case "PATCH", "PUT", "POST":
		if c.operation.RequestObject != nil {
			args = append(args, "input")
		} else {
			args = append(args, "nil")
		}
	}

	if len(args) == 0 {
		return ""
	}

	return fmt.Sprintf(", %s", strings.Join(args, ", "))
}

func (c methodsPandoraTemplater) argumentsTemplateForMethod(data ServiceGeneratorData) (*string, error) {
	arguments := make([]string, 0)
	if c.operation.ResourceIdName != nil {
		idName := *c.operation.ResourceIdName
		id, ok := data.resourceIds[idName]
		if !ok {
			return nil, fmt.Errorf("internal error: Resource ID %q was not found", idName)
		}
		if id.CommonAlias != nil {
			idName = fmt.Sprintf("commonids.%sId", *id.CommonAlias)
		}

		arguments = append(arguments, fmt.Sprintf("id %s", idName))
	}
	if c.operation.RequestObject != nil {
		typeName, err := golangTypeNameForObjectDefinition(*c.operation.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("determining type name for request object: %+v", err)
		}
		arguments = append(arguments, fmt.Sprintf("input %s", *typeName))
	}
	if len(c.operation.Options) > 0 {
		arguments = append(arguments, fmt.Sprintf("options %sOperationOptions", c.operationName))
	}

	out := fmt.Sprintf(", %s", strings.Join(arguments, ", "))
	if len(arguments) == 0 {
		out = ""
	}
	return &out, nil
}

func (c methodsPandoraTemplater) requestOptions(data ServiceGeneratorData) (*string, error) {
	method := capitalizeFirstLetter(c.operation.Method)
	expectedStatusCodes := make([]string, 0)
	for _, statusCodeInt := range c.operation.ExpectedStatusCodes {
		statusCode := golangConstantForStatusCode(statusCodeInt)
		expectedStatusCodes = append(expectedStatusCodes, statusCode)
	}
	sort.Strings(expectedStatusCodes)

	var path string
	if c.operation.UriSuffix != nil {
		if c.operation.ResourceIdName != nil {
			path = fmt.Sprintf(`fmt.Sprintf("%%s%s", id.ID())`, *c.operation.UriSuffix)
		} else {
			path = fmt.Sprintf("%q", *c.operation.UriSuffix)
		}
	} else {
		if c.operation.ResourceIdName != nil {
			path = "id.ID()"
		}
	}
	options := ""
	if len(c.operation.Options) > 0 {
		options = "OptionsObject: options,"
	}

	out := fmt.Sprintf(`client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			%[1]s,
		},
		HttpMethod: http.Method%[2]s,
		Path: %[3]s,
		%[4]s
	}
`, strings.Join(expectedStatusCodes, ",\n\t\t\t"), method, path, options)

	return &out, nil
}

func (c methodsPandoraTemplater) marshalerTemplate(data ServiceGeneratorData) (*string, error) {
	var output string

	if c.operation.RequestObject != nil {
		output = fmt.Sprintf(`
	err = req.Marshal(input)
	if err != nil {
		return
	}
`)
	}

	return &output, nil
}

func (c methodsPandoraTemplater) unmarshalerTemplate(data ServiceGeneratorData) (*string, error) {
	var output string
	if c.operation.ResponseObject != nil {
		golangTypeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("determing golang type name for response object: %+v", err)
		}
		typeName := *golangTypeName
		if c.operation.FieldContainingPaginationDetails != nil {
			output = fmt.Sprintf(`
	var values struct {
		Values *[]%[1]s %[2]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	result.Model = values.Values
`, typeName, "`json:\"values\"`")
		} else {
			output = fmt.Sprintf(`
	if err = resp.Unmarshal(&result.Model); err != nil {
		return
	}
`)
		}
	}

	return &output, nil
}

func (c methodsPandoraTemplater) responseStructTemplate(data ServiceGeneratorData) (*string, error) {
	model := ""
	typeName := ""
	if c.operation.ResponseObject != nil {
		golangTypeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("determing golang type name for response object: %+v", err)
		}
		typeName = *golangTypeName

		if c.operation.FieldContainingPaginationDetails != nil {
			model = fmt.Sprintf("Model *[]%s", typeName)
		} else {
			model = fmt.Sprintf("Model *%s", typeName)
		}
	}

	lro := ""
	if c.operation.LongRunning {
		lro = fmt.Sprintf("Poller pollers.Poller")
	}

	responseStructName := fmt.Sprintf("%[1]sOperationResponse", c.operationName)
	if _, hasExistingModel := data.models[responseStructName]; hasExistingModel {
		return nil, fmt.Errorf("existing model %q conflicts with the operation response model for %q", responseStructName, c.operationName)
	}

	paginationCode := ""
	if c.operation.FieldContainingPaginationDetails != nil {
		// whilst these looks like they could crash it's guaranteed above
		paginationCode = fmt.Sprintf(`
type %[2]sCompleteResult struct {
	Items []%[1]s
}
`, typeName, c.operationName)
	}

	output := fmt.Sprintf(`
type %[1]s struct {
	%[3]s
	HttpResponse *http.Response
	OData *odata.OData
	%[2]s
}

%[4]s
`, responseStructName, model, lro, paginationCode)
	return &output, nil
}

func (c methodsPandoraTemplater) optionsStruct(data ServiceGeneratorData) (*string, error) {
	if len(c.operation.Options) == 0 {
		out := ""
		return &out, nil
	}

	optionsStructName := fmt.Sprintf("%sOperationOptions", c.operationName)
	if _, hasExisting := data.models[optionsStructName]; hasExisting {
		return nil, fmt.Errorf("existing model %q conflicts with options model for %q", optionsStructName, c.operationName)
	}

	properties := make([]string, 0)
	queryStringAssignments := make([]string, 0)
	headerAssignments := make([]string, 0)

	for optionName, option := range c.operation.Options {
		optionType, err := golangTypeNameForObjectDefinition(option.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining golang type name for option %q's ObjectDefinition: %+v", optionName, err)
		}
		properties = append(properties, fmt.Sprintf("%s *%s", optionName, *optionType))
		if option.HeaderName != nil {
			headerAssignments = append(headerAssignments, fmt.Sprintf(`if o.%[1]s != nil {
	out.Append("%[2]s", fmt.Sprintf("%%v", *o.%[1]s))
}`, optionName, *option.HeaderName))
		}
		if option.QueryStringName != nil {
			queryStringAssignments = append(queryStringAssignments, fmt.Sprintf(`if o.%[1]s != nil {
	out.Append("%[2]s", fmt.Sprintf("%%v", *o.%[1]s))
}`, optionName, *option.QueryStringName))
		}
	}

	sort.Strings(properties)
	sort.Strings(headerAssignments)
	sort.Strings(queryStringAssignments)

	out := fmt.Sprintf(`
type %[1]s struct {
%[2]s
}

func Default%[1]s() %[1]s {
	return %[1]s{}
}

func (o %[1]s) ToHeaders() *client.Headers {
	out := client.Headers{}
%[3]s
	return &out
}

func (o %[1]s) ToOData() *odata.Query {
	out := odata.Query{}
	return &out
}

func (o %[1]s) ToQuery() *client.QueryParams {
	out := client.QueryParams{}
%[4]s
	return &out
}
`, optionsStructName, strings.Join(properties, "\n"), strings.Join(headerAssignments, "\n"), strings.Join(queryStringAssignments, "\n"))
	return &out, nil
}
