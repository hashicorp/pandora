package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ templaterForResource = methodsPandoraTemplater{}

type methodsPandoraTemplater struct {
	operation     models.SDKOperation
	operationName string
	constants     map[string]models.SDKConstant
}

func (c methodsPandoraTemplater) template(data GeneratorData) (*string, error) {
	methods, err := c.methods(data)
	if err != nil {
		return nil, fmt.Errorf("building methods: %+v", err)
	}

	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	commonTypesInclude := ""
	if data.commonTypesIncludePath != nil {
		commonTypesInclude = fmt.Sprintf(`"github.com/hashicorp/go-azure-sdk/%s/%s"`, data.sourceType, *data.commonTypesIncludePath)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"net/http"
	"net/url"

	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/odata"
	%[4]s
)

%[2]s

%[3]s
`, data.packageName, *copyrightLines, *methods, commonTypesInclude)
	return &template, nil
}

func (c methodsPandoraTemplater) methods(data GeneratorData) (*string, error) {
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

func (c methodsPandoraTemplater) immediateOperationTemplate(data GeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for immediate operation: %+v", err)
	}
	requestOptionStruct := c.requestOptionStruct()
	requestOptions, err := c.requestOptions()
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	marshalerCode, err := c.marshalerTemplate()
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

	comment := c.operationName
	if c.operation.Description != "" {
		comment += fmt.Sprintf(" - %s", c.operation.Description)
	} else {
		comment += " ..."
	}
	comment = wrapOnWordBoundary(comment, 120, "//")

	templated := fmt.Sprintf(`
%[7]s
%[8]s
%[9]s

%[10]s
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

`, data.serviceClientName, c.operationName, *methodArguments, *requestOptions, *marshalerCode, *unmarshalerCode, *responseStruct, *optionsStruct, requestOptionStruct, comment)
	return &templated, nil
}

func (c methodsPandoraTemplater) longRunningOperationTemplate(data GeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for long running template: %+v", err)
	}
	requestOptionStruct := c.requestOptionStruct()
	requestOptions, err := c.requestOptions()
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	marshalerCode, err := c.marshalerTemplate()
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

	comment := c.operationName
	if c.operation.Description != "" {
		comment += fmt.Sprintf(" - %s", c.operation.Description)
	} else {
		comment += " ..."
	}
	comment = wrapOnWordBoundary(comment, 120, "//")

	templated := fmt.Sprintf(`
%[9]s
%[10]s
%[11]s

%[12]s
func (c %[1]s) %[3]s(ctx context.Context %[4]s) (result %[3]sOperationResponse, err error) {
	opts := %[5]s

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	%[6]s

	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	%[7]s

	result.Poller, err = %[2]s.PollerFromResponse(resp, c.Client)
	if err != nil {
		return
	}

	return
}

// %[3]sThenPoll performs %[3]s then polls until it's completed
func (c %[1]s) %[3]sThenPoll(ctx context.Context %[4]s) error {
	result, err := c.%[3]s(ctx %[8]s)
	if err != nil {
		return fmt.Errorf("performing %[3]s: %%+v", err)
	}

	if err := result.Poller.PollUntilDone(ctx); err != nil {
		return fmt.Errorf("polling after %[3]s: %%+v", err)
	}

	return nil
}
`, data.serviceClientName, data.baseClientPackage, c.operationName, *methodArguments, *requestOptions, *marshalerCode, *unmarshalerCode, argumentsCode, *responseStruct, *optionsStruct, requestOptionStruct, comment)
	return &templated, nil
}

func (c methodsPandoraTemplater) listOperationTemplate(data GeneratorData) (*string, error) {
	methodArguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for list operation: %+v", err)
	}
	requestOptionStruct := c.requestOptionStruct()
	requestOptions, err := c.requestOptions()
	if err != nil {
		return nil, fmt.Errorf("building request config: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
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
	typeName, err := helpers.GolangTypeForSDKObjectDefinition(*c.operation.ResponseObject, nil, data.commonTypesPackageName)
	if err != nil {
		return nil, fmt.Errorf("determining golang type name for response object: %+v", err)
	}
	predicateName := "OperationPredicate"
	if parts := strings.SplitN(*typeName, ".", 2); len(parts) == 2 {
		predicateName = fmt.Sprintf("%s%s", parts[1], predicateName)
	} else {
		predicateName = fmt.Sprintf("%s%s", *typeName, predicateName)
	}

	comment := c.operationName
	if c.operation.Description != "" {
		comment += fmt.Sprintf(" - %s", c.operation.Description)
	} else {
		comment += " ..."
	}
	comment = wrapOnWordBoundary(comment, 120, "//")

	templated := fmt.Sprintf(`
%[6]s
%[7]s
%[8]s

%[9]s
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
`, data.serviceClientName, c.operationName, *methodArguments, *requestOptions, *unmarshalerCode, *responseStruct, *optionsStruct, requestOptionStruct, comment)

	// Only output predicate functions for models and not for base types like string, int etc.
	if c.operation.ResponseObject.Type == models.ReferenceSDKObjectDefinitionType || c.operation.ResponseObject.Type == models.ListSDKObjectDefinitionType {
		templated += fmt.Sprintf(`

// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[4]s) (%[2]sCompleteResult, error) {
	return c.%[2]sCompleteMatchingPredicate(ctx%[6]s, %[8]s{})
}

// %[2]sCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c %[1]s) %[2]sCompleteMatchingPredicate(ctx context.Context%[4]s, predicate %[8]s) (result %[2]sCompleteResult, err error) {
	items := make([]%[7]s, 0)

	resp, err := c.%[2]s(ctx%[6]s)
	if err != nil {
		result.LatestHttpResponse = resp.HttpResponse
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
		LatestHttpResponse: resp.HttpResponse,
		Items: items,
	}
	return
}
`, data.serviceClientName, c.operationName, data.packageName, *methodArguments, *responseStruct, argumentsCode, *typeName, predicateName)
	} else {
		templated += fmt.Sprintf(`
// %[2]sComplete retrieves all the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context%[3]s) (result %[2]sCompleteResult, err error) {
	items := make([]%[5]s, 0)

	resp, err := c.%[2]s(ctx%[4]s)
	if err != nil {
		result.LatestHttpResponse = resp.HttpResponse
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			items = append(items, v)
		}
	}

	result = %[2]sCompleteResult{
		LatestHttpResponse: resp.HttpResponse,
		Items:		  items,
	}
	return
}
`, data.serviceClientName, c.operationName, *methodArguments, argumentsCode, *typeName)
	}
	return &templated, nil
}

func (c methodsPandoraTemplater) argumentsTemplate() string {
	args := make([]string, 0)
	if c.operation.ResourceIDName != nil {
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

	if c.operation.URISuffix != nil {
		if c.operation.ResourceIDName != nil {
			args = append(args, fmt.Sprintf("fmt.Sprintf(\"%%s%s\", id.ID())", *c.operation.URISuffix))
		} else {
			args = append(args, *c.operation.URISuffix)
		}
	} else {
		if c.operation.ResourceIDName != nil {
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

func (c methodsPandoraTemplater) argumentsTemplateForMethod(data GeneratorData) (*string, error) {
	arguments := make([]string, 0)
	if c.operation.ResourceIDName != nil {
		idName := *c.operation.ResourceIDName
		var id models.ResourceID
		if pointer.From(c.operation.ResourceIDNameIsCommonType) {
			if data.commonTypesPackageName == nil {
				return nil, fmt.Errorf("internal error: Common Type Resource ID %q encountered, but `commonTypesPackageName` was nil", idName)
			}
			var ok bool
			if id, ok = data.commonTypes.ResourceIDs[idName]; !ok {
				return nil, fmt.Errorf("internal error: Common Type Resource ID %q was not found", idName)
			}

			idName = fmt.Sprintf("%s.%s", *data.commonTypesPackageName, idName)
		} else {
			var ok bool
			if id, ok = data.resourceIds[idName]; !ok {
				return nil, fmt.Errorf("internal error: Resource ID %q was not found", idName)
			}
		}
		if id.CommonIDAlias != nil {
			idName = fmt.Sprintf("commonids.%sId", *id.CommonIDAlias)
		}

		arguments = append(arguments, fmt.Sprintf("id %s", idName))
	}
	if c.operation.RequestObject != nil {
		typeName, err := helpers.GolangTypeForSDKObjectDefinition(*c.operation.RequestObject, nil, data.commonTypesPackageName)
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

// define struct used in requestOptions
func (c methodsPandoraTemplater) requestOptionStruct() string {
	var output string

	if c.operation.FieldContainingPaginationDetails != nil {
		jsonTag := fmt.Sprintf("`json:%q`", *c.operation.FieldContainingPaginationDetails)

		output = fmt.Sprintf(`
type %[2]sCustomPager struct {
	NextLink *odata.Link %[1]s
}

func (p *%[2]sCustomPager) NextPageLink() *odata.Link {
	defer func() {
		p.NextLink = nil
	}()

	return p.NextLink
}
`, jsonTag, c.operationName)
	}

	return output
}

func (c methodsPandoraTemplater) requestOptions() (*string, error) {
	method := capitalizeFirstLetter(c.operation.Method)
	expectedStatusCodes := make([]string, 0)
	for _, statusCodeInt := range c.operation.ExpectedStatusCodes {
		statusCode := golangConstantForStatusCode(statusCodeInt)
		expectedStatusCodes = append(expectedStatusCodes, statusCode)
	}
	sort.Strings(expectedStatusCodes)

	var path string
	if c.operation.URISuffix != nil {
		if c.operation.ResourceIDName != nil {
			path = fmt.Sprintf(`fmt.Sprintf("%%s%s", id.ID())`, *c.operation.URISuffix)
		} else {
			path = fmt.Sprintf("%q", *c.operation.URISuffix)
		}
	} else {
		if c.operation.ResourceIDName != nil {
			path = "id.ID()"
		}
	}

	items := []string{
		fmt.Sprintf("ContentType: %q", c.operation.ContentType),
		fmt.Sprintf(`ExpectedStatusCodes: []int{
			%s,
}`, strings.Join(expectedStatusCodes, ",\n\t\t\t")),
		fmt.Sprintf("HttpMethod: http.Method%s", method),
		fmt.Sprintf("Path: %s", path),
	}
	if len(c.operation.Options) > 0 {
		items = append(items, "OptionsObject: options")
	}
	if c.operation.FieldContainingPaginationDetails != nil {
		items = append(items, fmt.Sprintf("Pager: &%sCustomPager{}", c.operationName))
	}
	sort.Strings(items)

	out := fmt.Sprintf(`client.RequestOptions{
		%s,
	}
`, strings.Join(items, ",\n\t\t"))
	return &out, nil
}

func (c methodsPandoraTemplater) marshalerTemplate() (*string, error) {
	var output string

	if c.operation.RequestObject != nil {
		output = fmt.Sprintf(`
	if err = req.Marshal(input); err != nil {
		return
	}
`)
	}

	return &output, nil
}

func (c methodsPandoraTemplater) unmarshalerTemplate(data GeneratorData) (*string, error) {
	var output string

	if c.operation.LongRunning {
		// Long Running operations shouldn't be attempted to be unmarshalled until the LRO is completed
		// in the event this needs to be unmarshalled early - the Response Object being exposed means that
		// we can opt to do this by calling `Unmarshal` by hand on a case-by-case basis.
		return pointer.To(""), nil
	}

	if c.operation.ResponseObject == nil {
		return &output, nil
	}

	golangTypeName, err := helpers.GolangTypeForSDKObjectDefinition(*c.operation.ResponseObject, nil, data.commonTypesPackageName)
	if err != nil {
		return nil, fmt.Errorf("determing golang type name for response object: %+v", err)
	}
	typeName := *golangTypeName

	discriminatedTypeParentName := ""

	var model *models.SDKModel
	modelPackage := ""
	modelName := typeName
	if s := strings.SplitN(modelName, ".", 2); len(s) == 2 {
		modelPackage = s[0]
		modelName = s[1]
	}
	if m, ok := data.models[modelName]; ok {
		model = &m
	} else if m, ok = data.commonTypes.Models[modelName]; ok {
		model = &m
	}

	if model != nil {
		// it's either a parent model
		if model.FieldNameContainingDiscriminatedValue != nil {
			discriminatedTypeParentName = modelName
		}
		// or an implementation referencing a parent
		if model.ParentTypeName != nil {
			discriminatedTypeParentName = *model.ParentTypeName
		}

		if model.DiscriminatedValue != nil {
			// in this instance this would be a discriminated implementation present in the response object
			// as such we should use that directly, rather than calling the parents unmarshal function
			discriminatedTypeParentName = ""
		}
	}

	if c.operation.FieldContainingPaginationDetails != nil {
		unmarshaler := fmt.Sprintf("Unmarshal%sImplementation", modelName)
		if modelPackage != "" {
			unmarshaler = fmt.Sprintf("%s.Unmarshal%sImplementation", modelPackage, modelName)
		}

		output = fmt.Sprintf(`
	var values struct {
		Values *[]%[1]s %[2]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	result.Model = values.Values
`, typeName, "`json:\"value\"`")

		if discriminatedTypeParentName != "" {
			output = fmt.Sprintf(`
	var values struct {
		Values *[]json.RawMessage %[3]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	temp := make([]%[1]s, 0)
	if values.Values != nil {
		for i, v := range *values.Values {
			val, err := %[2]s(v)
			if err != nil {
				err = fmt.Errorf("unmarshalling item %%d for %[1]s (%%q): %%+v", i, v, err)
				return result, err
			}
			temp = append(temp, val)
		}
	}
	result.Model = &temp
`, typeName, unmarshaler, "`json:\"value\"`")
		}

		return &output, nil
	}

	// when this is a Discriminated Type (either the Parent or the Implementation, call the `unmarshal` func
	// for the relevant Parent
	if discriminatedTypeParentName != "" {
		unmarshaler := fmt.Sprintf("Unmarshal%sImplementation", discriminatedTypeParentName)
		if modelPackage != "" {
			unmarshaler = fmt.Sprintf("%s.Unmarshal%sImplementation", modelPackage, discriminatedTypeParentName)
		}

		output = fmt.Sprintf(`
	var respObj json.RawMessage
	if err = resp.Unmarshal(&respObj); err != nil {
		return
	}
	model, err := %s(respObj)
	if err != nil {
		return
	}
	result.Model = &model
`, unmarshaler)
	} else {
		responseModelType, err := helpers.GolangTypeForSDKObjectDefinition(*c.operation.ResponseObject, nil, data.commonTypesPackageName)
		if err != nil {
			return nil, fmt.Errorf("determing golang type name for response object: %+v", err)
		}
		if responseModelType != nil {
			if c.operation.FieldContainingPaginationDetails != nil {
				output = fmt.Sprintf(`
	var model []%s`, *responseModelType)
			} else {
				output = fmt.Sprintf(`
	var model %s`, *responseModelType)
			}
			output = fmt.Sprintf(`%s
	result.Model = &model`, output)
		}
		output = fmt.Sprintf(`%s

	if err = resp.Unmarshal(result.Model); err != nil {
		return
	}
`, output)
	}

	return &output, nil
}

func (c methodsPandoraTemplater) responseStructTemplate(data GeneratorData) (*string, error) {
	model := ""
	typeName := ""
	if c.operation.ResponseObject != nil {
		golangTypeName, err := helpers.GolangTypeForSDKObjectDefinition(*c.operation.ResponseObject, nil, data.commonTypesPackageName)
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
	LatestHttpResponse *http.Response
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

func (c methodsPandoraTemplater) optionsStruct(data GeneratorData) (*string, error) {
	if len(c.operation.Options) == 0 {
		out := ""
		return &out, nil
	}

	optionsStructName := fmt.Sprintf("%sOperationOptions", c.operationName)
	if _, hasExisting := data.models[optionsStructName]; hasExisting {
		return nil, fmt.Errorf("existing model %q conflicts with options model for %q", optionsStructName, c.operationName)
	}

	properties := make([]string, 0)
	odataAssignments := make([]string, 0)
	queryStringAssignments := make([]string, 0)
	headerAssignments := make([]string, 0)

	for optionName, option := range c.operation.Options {
		optionType, err := helpers.GolangTypeForSDKOperationOptionObjectDefinition(option.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining golang type name for option %q's ObjectDefinition: %+v", optionName, err)
		}
		properties = append(properties, fmt.Sprintf("%s *%s", optionName, *optionType))
		if option.ODataFieldName != nil {
			value := fmt.Sprintf("*o.%s", *option.ODataFieldName)
			if option.ObjectDefinition.Type == models.IntegerSDKOperationOptionObjectDefinitionType {
				value = fmt.Sprintf("int(%s)", value)
			}
			odataAssignments = append(odataAssignments, fmt.Sprintf(`if o.%[1]s != nil {
	out.%[2]s = %[3]s
}`, optionName, *option.ODataFieldName, value))
		}
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
	sort.Strings(odataAssignments)
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
%[4]s
	return &out
}

func (o %[1]s) ToQuery() *client.QueryParams {
	out := client.QueryParams{}
%[5]s
	return &out
}
`, optionsStructName, strings.Join(properties, "\n"), strings.Join(headerAssignments, "\n"), strings.Join(odataAssignments, "\n"), strings.Join(queryStringAssignments, "\n"))
	return &out, nil
}
