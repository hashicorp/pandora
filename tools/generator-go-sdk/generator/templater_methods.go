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

	"github.com/hashicorp/go-azure-helpers/lang/response"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-helpers/polling"
	"github.com/hashicorp/go-azure-sdk/sdk/client"
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
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for immediate operation: %+v", err)
	}
	requestArguments := c.requestArgumentsTemplate()
	requestConfig, err := c.requestConfig(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	unmarshalerCode, err := c.unmarshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building unmarahaler template: %+v", err)
	}
	method := capitalizeFirstLetter(c.operation.Method)

	templated := fmt.Sprintf(`
%[8]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (result %[2]sOperationResponse, err error) {
	req, err := c.Client.New%[3]sRequest(ctx %[5]s)
	if err != nil {
		return
	}

	%[6]s

	var resp *client.Response
	resp, err = req.Execute()
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[7]s

	return
}

`, data.serviceClientName, c.operationName, method, *argumentsMethodCode, requestArguments, *requestConfig, *unmarshalerCode, *responseStruct, *optionsStruct)
	return &templated, nil
}

func (c methodsPandoraTemplater) longRunningOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for long running template: %+v", err)
	}
	requestArguments := c.requestArgumentsTemplate()
	requestConfig, err := c.requestConfig(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	method := capitalizeFirstLetter(c.operation.Method)

	// TODO: check value of provisioningState field after calling PollUntilDone()
	templated := fmt.Sprintf(`
%[8]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (result %[2]sOperationResponse, err error) {
	req, err := c.Client.New%[3]sRequest(ctx %[5]s)
	if err != nil {
		return
	}

	%[6]s

	var resp *client.Response
	resp, err = req.Execute()
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	result.Poller, err = resourcemanager.NewPollerFromResponse(ctx, resp, c.Client)
	if err != nil {
		return
	}

	return
}

// %[2]sThenPoll performs %[2]s then polls until it's completed
func (c %[1]s) %[2]sThenPoll(ctx context.Context %[4]s) error {
	result, err := c.%[2]s(ctx %[7]s)
	if err != nil {
		return fmt.Errorf("performing %[2]s: %%+v", err)
	}

	if err := result.Poller.PollUntilDone(); err != nil {
		return fmt.Errorf("polling after %[2]s: %%+v", err)
	}

	return nil
}
`, data.serviceClientName, c.operationName, method, *argumentsMethodCode, requestArguments, *requestConfig, argumentsCode, *responseStruct, *optionsStruct)
	return &templated, nil
}

func (c methodsPandoraTemplater) listOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for list operation: %+v", err)
	}
	requestArguments := c.requestArgumentsTemplate()
	requestConfig, err := c.requestConfig(data)
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	unmarshalerCode, err := c.unmarshalerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building unmarahaler template: %+v", err)
	}
	typeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
	if err != nil {
		return nil, fmt.Errorf("determining golang type name for response object: %+v", err)
	}
	method := capitalizeFirstLetter(c.operation.Method)

	templated := fmt.Sprintf(`
%[8]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (result %[2]sOperationResponse, err error) {
	req, err := c.Client.New%[3]sRequest(ctx %[5]s)
	if err != nil {
		return
	}

	%[6]s

	var resp *client.Response
	resp, err = req.ExecutePaged()
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[7]s

	return
}
`, data.serviceClientName, c.operationName, method, *argumentsMethodCode, requestArguments, *requestConfig, *unmarshalerCode, *responseStruct, *optionsStruct)

	// Only output predicate functions for models and not for base types like string, int etc.
	if c.operation.ResponseObject.Type == resourcemanager.ReferenceApiObjectDefinitionType || c.operation.ResponseObject.Type == resourcemanager.ListApiObjectDefinitionType {
		templated += fmt.Sprintf(`

// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[4]s) (%[2]sCompleteResult, error) {
	return c.%[2]sCompleteMatchingPredicate(ctx%[6]s, %[7]sOperationPredicate{})
}

// %[2]sCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c %[1]s) %[2]sCompleteMatchingPredicate(ctx context.Context%[4]s, predicate %[7]sOperationPredicate) (resp %[2]sCompleteResult, err error) {
	items := make([]%[7]s, 0)

	result, err := c.%[2]s(ctx%[6]s)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if result.Model != nil {
		for _, v := range *result.Model {
			if predicate.Matches(v) {
				items = append(items, v)
			}
		}
	}

	out := %[2]sCompleteResult{
		Items: items,
	}
	return out, nil
}
`, data.serviceClientName, c.operationName, data.packageName, *argumentsMethodCode, *responseStruct, argumentsCode, *typeName)
	} else {
		templated += fmt.Sprintf(`
// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[3]s) (result %[2]sCompleteResult, err error) {
	items := make([]%[5]s, 0)

	result, err := c.%[2]s(ctx%[4]s)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if result.Model != nil {
		for _, v := range *result.Model {
			items = append(items, v)
		}
	}

	out := %[2]sCompleteResult{
		Items: items,
	}
	return out, nil
}
`, data.serviceClientName, c.operationName, *argumentsMethodCode, argumentsCode, *typeName)
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

func (c methodsPandoraTemplater) requestConfig(data ServiceGeneratorData) (*string, error) {
	expectedStatusCodes := make([]string, 0)
	for _, statusCodeInt := range c.operation.ExpectedStatusCodes {
		statusCode := golangConstantForStatusCode(statusCodeInt)
		expectedStatusCodes = append(expectedStatusCodes, statusCode)
	}
	sort.Strings(expectedStatusCodes)

	out := fmt.Sprintf(`
	req.ValidStatusCodes = []int{%s}
`, strings.Join(expectedStatusCodes, ", "))

	return &out, nil
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
		lro = fmt.Sprintf("Poller *resourcemanager.LongRunningPoller")
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
			headerAssignments = append(headerAssignments, fmt.Sprintf(`
	if o.%[1]s != nil {
		out["%[2]s"] = *o.%[1]s
	}
`, optionName, *option.HeaderName))
		}
		if option.QueryStringName != nil {
			queryStringAssignments = append(queryStringAssignments, fmt.Sprintf(`
	if o.%[1]s != nil {
		out["%[2]s"] = *o.%[1]s
	}
`, optionName, *option.QueryStringName))
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

func (o %[1]s) ToHeaders() *resourcemanager.Headers {
	out := make(resourcemanager.Headers)
%[3]s
	return &out
}

func (o %[1]s) ToOData() *odata.Query {
	out := odata.Query{}
	return &out
}

func (o %[1]s) ToQuery() *resourcemanager.QueryParams {
	out := make(resourcemanager.QueryParams)
%[4]s
	return &out
}
`, optionsStructName, strings.Join(properties, "\n"), strings.Join(headerAssignments, "\n"), strings.Join(queryStringAssignments, "\n"))
	return &out, nil
}
