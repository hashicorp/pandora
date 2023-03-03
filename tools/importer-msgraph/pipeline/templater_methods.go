package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"strconv"
	"strings"
)

func templateMethods(files *Tree, packageName string, endpoints []*Endpoint, logger hclog.Logger) error {
	clientName := strings.Title(packageName)
	clientMethods := make(map[string]string)

	// First build all the methods
	for _, endpoint := range endpoints {
		// Skip functions and casts for now
		if lastSegment := endpoint.Id.segments[len(endpoint.Id.segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction {
			logger.Debug("Skipping suspected function/cast endpoint", "endpoint", endpoint.Id.ID())
			continue
		}

		for _, operation := range endpoint.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "endpoint", endpoint.Id.ID(), "method", operation.Method)
				continue
			}

			// Build string arguments from user-specified URI segments
			args := make([]string, 0)
			argNames := make([]string, 0)
			for _, segment := range endpoint.Id.segments {
				if segment.Type == SegmentUserValue {
					argName := cleanNameCamel(segment.Value)
					argNames = append(argNames, argName)
					args = append(args, fmt.Sprintf("%s string", argName))
				}
			}

			operationType := operation.Type.Name(endpoint.Id)

			// Name the method according to the final URI segment, or deriving it from the tag
			var clientMethodNameTarget string
			if lastLabel := endpoint.Id.LastLabel(); lastLabel != nil {
				if operation.Type == OperationTypeList {
					clientMethodNameTarget = pluralize(cleanName(lastLabel.Value))
				} else {
					clientMethodNameTarget = singularize(cleanName(lastLabel.Value))
				}
			}

			if clientMethodNameTarget == "" {
				if len(operation.Tags) > 1 {
					return fmt.Errorf("found %d tags for operation %s/%s: %s", len(operation.Tags), endpoint.Id.ID(), operationType, operation.Tags)
				} else if len(operation.Tags) == 1 {
					t := strings.Split(operation.Tags[0], ".")
					if len(t) != 2 {
						return fmt.Errorf("invalid tag for operation %s/%s: %s", endpoint.Id.ID(), operationType, operation.Tags[0])
					}
					clientMethodNameTarget = cleanName(t[1])
				}
			}

			// TODO: this shouldn't happen, but probably log/handle this
			if clientMethodNameTarget == "" {
				logger.Debug("Skipping operation with empty method name", "endpoint", endpoint.Id.ID(), "method", operation.Method)
				continue
			}

			// Pluralize for list operations
			if operation.Type == OperationTypeList {
				clientMethodNameTarget = pluralize(clientMethodNameTarget)
			}

			// Determine request model
			var requestModelVar string
			if operation.Type == OperationTypeCreate || operation.Type == OperationTypeUpdate || operation.Type == OperationTypeCreateUpdate {
				if operation.RequestModel != nil {
					requestModelVar = cleanNameCamel(*operation.RequestModel)
					args = append(args, fmt.Sprintf("%s models.%s", requestModelVar, *operation.RequestModel))
				} else if lastSegment := endpoint.Id.segments[len(endpoint.Id.segments)-1]; lastSegment.Value == "$ref" {
					requestModelVar = "directoryObject"
					args = append(args, fmt.Sprintf("%s models.DirectoryObject", requestModelVar))
				}
			}

			// Determine response model and return values
			var responseModel, sigRet string
			if operation.Type != OperationTypeDelete {
				responseModel = findModel(operation.Responses)
				sigRet = "error"
				if responseModel == "" {
					if lastSegment := endpoint.Id.segments[len(endpoint.Id.segments)-1]; lastSegment.Value == "$ref" {
						responseModel = "DirectoryObject"
					}
				}
				if responseModel != "" {
					if operation.Type == OperationTypeList {
						sigRet = fmt.Sprintf("(*[]models.%s, error)", responseModel)
					} else {
						sigRet = fmt.Sprintf("(*models.%s, error)", responseModel)
					}
				}
			}

			// Template the method code
			var methodCode string
			switch operation.Type {
			case OperationTypeList:
				if responseModel == "" {
					logger.Debug("Skipping operation with empty response model", "endpoint", endpoint.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateListMethod(endpoint, &operation, argNames, responseModel)
			case OperationTypeRead:
				if responseModel == "" {
					logger.Debug("Skipping operation with empty response model", "endpoint", endpoint.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateReadMethod(endpoint, &operation, argNames, responseModel)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				if requestModelVar == "" {
					logger.Debug("Skipping operation with empty request model var", "endpoint", endpoint.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateCreateUpdateMethod(endpoint, &operation, argNames, requestModelVar, responseModel)
			case OperationTypeDelete:
				methodCode = templateDeleteMethod(endpoint, &operation, argNames)
			}

			// Construct the method arguments
			argString := "ctx context.Context"
			if appendArgs := strings.Join(args, ", "); len(appendArgs) > 0 {
				argString = fmt.Sprintf("%s, %s", argString, appendArgs)
			}
			argString = fmt.Sprintf("%s, %s", argString, "opts Options")

			// Name the method
			clientMethodName := fmt.Sprintf("%s%s", operationType, clientMethodNameTarget)
			clientMethodFile := fmt.Sprintf("%s_%s", strings.ToLower(clientMethodNameTarget), strings.ToLower(operationType))

			// Build it
			clientMethods[clientMethodFile] = fmt.Sprintf(`func (c *%[1]sClient) %[2]s(%[3]s) %[4]s{
				// %[5]s %[6]s

				%[7]s
			}`, clientName, clientMethodName, argString, sigRet, operation.Method, endpoint.Id.ID(), strings.TrimSpace(methodCode))
		}
	}

	// Then output them as separate source files
	methodNames := sortedKeys(clientMethods)
	for _, method := range methodNames {
		if err := files.addFile(fmt.Sprintf("%s/method_%s.go", packageName, method), templateFile(packageName, []string{clientMethods[method]})); err != nil {
			return err
		}
	}

	return nil
}

func templateListMethod(endpoint *Endpoint, operation *Operation, args []string, model string) string {
	statuses := make([]string, 0)
	for _, response := range operation.Responses {
		if response.Status >= 200 && response.Status < 400 {
			statuses = append(statuses, strconv.Itoa(response.Status))
		}
	}

	var path string
	if len(args) > 0 {
		path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	} else {
		path = fmt.Sprintf("%q", endpoint.Id.ID())
	}

	return fmt.Sprintf(`
	reqOpts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			%[3]s,
		},
		HttpMethod:    %[1]q,
		OptionsObject: opts,
		Path:          %[2]s,
	}

	req, err := c.Client.NewRequest(ctx, reqOpts)
	if err != nil {
		return nil, fmt.Errorf("building new request: %%+v", err)
	}

	resp, err := req.ExecutePaged(ctx)
	if err != nil {
		return nil, fmt.Errorf("executing request: %%+v", err)
	}

	model := struct {
		Values []models.%[4]s `+"`"+`json:"values"`+"`"+`
	}{}
	if err = resp.Unmarshal(&model); err != nil {
		return nil, fmt.Errorf("unmarshaling response: %%+v", err)
	}

	return &model.Values, nil
`, operation.Method, path, strings.Join(statuses, ",\n\t"), model)
}

func templateReadMethod(endpoint *Endpoint, operation *Operation, args []string, model string) string {
	statuses := make([]string, 0)
	for _, response := range operation.Responses {
		if response.Status >= 200 && response.Status < 400 {
			statuses = append(statuses, strconv.Itoa(response.Status))
		}
	}

	var path string
	if len(args) > 0 {
		path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	} else {
		path = fmt.Sprintf("%q", endpoint.Id.ID())
	}

	return fmt.Sprintf(`
	reqOpts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			%[3]s,
		},
		HttpMethod:    %[1]q,
		OptionsObject: opts,
		Path:          %[2]s,
	}

	req, err := c.Client.NewRequest(ctx, reqOpts)
	if err != nil {
		return nil, fmt.Errorf("building new request: %%+v", err)
	}

	resp, err := req.Execute(ctx)
	if err != nil {
		return nil, fmt.Errorf("executing request: %%+v", err)
	}

	model := models.%[4]s{}
	if err = resp.Unmarshal(&model); err != nil {
		return nil, fmt.Errorf("unmarshaling response: %%+v", err)
	}

	return &model, nil
`, operation.Method, path, strings.Join(statuses, ",\n\t"), model)
}

func templateCreateUpdateMethod(endpoint *Endpoint, operation *Operation, args []string, requestModel string, responseModel string) string {
	statuses := make([]string, 0)
	for _, response := range operation.Responses {
		if response.Status >= 200 && response.Status < 400 {
			statuses = append(statuses, strconv.Itoa(response.Status))
		}
	}

	var path string
	if len(args) > 0 {
		path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	} else {
		path = fmt.Sprintf("%q", endpoint.Id.ID())
	}

	returnVal := func(ret string) string {
		if responseModel == "" {
			return fmt.Sprintf("return %s", ret)
		}
		return fmt.Sprintf("return nil, %s", ret)
	}

	returns := map[string]string{
		"req":       `fmt.Errorf("building new request: %+v", err)`,
		"marshal":   `fmt.Errorf("marshaling payload: %+v", err)`,
		"resp":      `fmt.Errorf("executing request: %+v", err)`,
		"unmarshal": `fmt.Errorf("unmarshaling response: %+v", err)`,
	}

	var resp string
	if responseModel == "" {
		resp = fmt.Sprintf(`
		if _, err = req.Execute(ctx); err != nil {
			%[1]s
		}

		return nil`, returnVal(returns["resp"]))
	} else {
		resp = fmt.Sprintf(`
		resp, err := req.Execute(ctx)
		if err != nil {
			%[2]s
		}

		model := models.%[1]s{}
		if err = resp.Unmarshal(&model); err != nil {
			%[3]s
		}

		return &model, nil`, responseModel, returnVal(returns["resp"]), returnVal(returns["unmarshal"]))
	}

	return fmt.Sprintf(`
	reqOpts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			%[3]s,
		},
		HttpMethod:    %[1]q,
		OptionsObject: opts,
		Path:          %[2]s,
	}

	req, err := c.Client.NewRequest(ctx, reqOpts)
	if err != nil {
		%[6]s
	}

	if err = req.Marshal(%[4]s); err != nil {
		%[7]s
	}

	%[5]s
`, operation.Method, path, strings.Join(statuses, ",\n\t"), requestModel, resp, returnVal(returns["req"]), returnVal(returns["resp"]), returnVal(returns["unmarshal"]), returnVal(returns["marshal"]))
}

func templateDeleteMethod(endpoint *Endpoint, operation *Operation, args []string) string {
	statuses := make([]string, 0)
	for _, response := range operation.Responses {
		if response.Status >= 200 && response.Status < 400 {
			statuses = append(statuses, strconv.Itoa(response.Status))
		}
	}

	var path string
	if len(args) > 0 {
		path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	} else {
		path = fmt.Sprintf("%q", endpoint.Id.ID())
	}

	return fmt.Sprintf(`
	reqOpts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			%[3]s,
		},
		HttpMethod:    %[1]q,
		OptionsObject: opts,
		Path:          %[2]s,
	}

	req, err := c.Client.NewRequest(ctx, reqOpts)
	if err != nil {
		return fmt.Errorf("building new request: %%+v", err)
	}

	if _, err = req.Execute(ctx); err != nil {
		return fmt.Errorf("executing request: %%+v", err)
	}

	return nil
`, operation.Method, path, strings.Join(statuses, ",\n\t"))
}
