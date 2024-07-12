// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"testing"
)

const (
	outputDirectoryJson   = "../../../api-definitions/"
	swaggerDirectory      = "../../../submodules/rest-api-specs"
	resourceManagerConfig = "../../../config/resource-manager.hcl"
)

func TestConfigContainsValidServiceNames(t *testing.T) {
	t.Fatalf("TODO")
	//resources := definitions.Config{
	//	Services: map[string]definitions.ServiceDefinition{},
	//}
	//input := discovery.FindServiceInput{
	//	SwaggerDirectory: swaggerDirectory,
	//	ConfigFilePath:   resourceManagerConfig,
	//	OutputDirectory:  outputDirectoryJson,
	//	Logger:           hclog.New(hclog.DefaultOptions),
	//}
	//generationData, err := discovery.FindServices(input, resources)
	//if err != nil {
	//	t.Fatalf("building generation data: %+v", err)
	//}
	//
	//nameRegex, err := regexp.Compile("^[A-Z]{1}[A-Za-z0-9_]{1,}$")
	//if err != nil {
	//	t.Fatalf("compiling regex: %+v", err)
	//}
	//
	//for _, data := range *generationData {
	//	t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
	//		generationData := data
	//
	//		if !nameRegex.MatchString(generationData.ServiceName) {
	//			t.Fatalf("name wasn't valid for %q - must contain only alphanumeric characters and underscores", generationData.ServiceName)
	//		}
	//	})
	//}
}

func TestExistingDataCanBeGenerated(t *testing.T) {
	t.Fatalf("TODO")

	//// works around the OAIGen bug
	//os.Setenv("OAIGEN_DEDUPE", "false")
	//
	//resources := definitions.Config{
	//	Services: map[string]definitions.ServiceDefinition{},
	//}
	//input := discovery.FindServiceInput{
	//	SwaggerDirectory: swaggerDirectory,
	//	ConfigFilePath:   resourceManagerConfig,
	//	OutputDirectory:  outputDirectoryJson,
	//	Logger:           hclog.New(hclog.DefaultOptions),
	//}
	//generationData, err := discovery.FindServices(input, resources)
	//if err != nil {
	//	t.Fatalf("building generation data: %+v", err)
	//}
	//
	//for _, data := range *generationData {
	//	t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
	//		generationData := data
	//
	//		task := pipelineTask{}
	//		if _, err := task.parseDataForApiVersion(generationData); err != nil {
	//			t.Fatalf("error: %+v", err)
	//		}
	//	})
	//}
}
