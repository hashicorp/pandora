// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os/exec"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
)

type Generator struct {
	settings Settings
}

func NewGenerator(settings Settings) Generator {
	return Generator{
		settings: settings,
	}
}

type ServiceGeneratorInput struct {
	CommonTypes     models.CommonTypes
	OutputDirectory string
	ResourceDetails models.APIResource
	ResourceName    string
	ServiceDetails  models.Service
	ServiceName     string
	Source          models.SourceDataOrigin
	Type            models.SourceDataType
	VersionDetails  models.APIVersion
	VersionName     string
}

func (s *Generator) Generate(input ServiceGeneratorInput) error {
	data := input.generatorData(s.settings)

	if err := CleanAndRecreateWorkingDirectory(data.resourceOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.resourceOutputPath, err)
	}

	stages := map[string]func(data GeneratorData) error{
		"clients":    s.clients,
		"constants":  s.constants,
		"ids":        s.ids,
		"methods":    s.methods,
		"models":     s.models,
		"readmeFile": s.readmeFile,
		"predicates": s.predicates,
		"version":    s.version,
	}
	// ensure that the generator steps are consistent. Primarily this matters to ensure that the ID stage is executed
	// before the readme stage as ID date is mutated there to accommodate Azure Data Plane URL style IDs.
	consistentOrder := []string{
		"clients",
		"constants",
		"ids",
		"methods",
		"models",
		"readmeFile",
		"predicates",
		"version",
	}
	for _, stage := range consistentOrder {
		logging.Debugf("Running Stage %q..", stage)
		if err := stages[stage](data); err != nil {
			return fmt.Errorf("generating %s: %+v", stage, err)
		}
	}

	runGoImports(data.resourceOutputPath)

	return nil
}

type VersionGeneratorInput struct {
	CommonTypes     models.CommonTypes
	OutputDirectory string
	Resources       map[string]models.APIResource
	ServiceName     string
	Source          models.SourceDataOrigin
	Type            models.SourceDataType
	UseNewBaseLayer bool
	VersionName     string
}

func (s *Generator) GenerateForVersion(input VersionGeneratorInput) error {
	data := input.generatorData(s.settings)

	stages := map[string]func(data VersionGeneratorData) error{
		"metaClient": s.metaClient,
	}
	for name, stage := range stages {
		logging.Debugf("Running Stage %q..", name)
		if err := stage(data); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoImports(data.versionOutputPath)

	return nil
}

func (s *Generator) GenerateCommonTypes(input VersionGeneratorInput) error {
	data := input.generatorData(s.settings)

	if err := CleanAndRecreateWorkingDirectory(data.commonTypesOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.commonTypesOutputPath, err)
	}

	stages := map[string]func(data VersionGeneratorData) error{
		"commonTypes": s.commonTypes,
	}
	for name, stage := range stages {
		logging.Debugf("Running Stage %q..", name)
		if err := stage(data); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoImports(data.commonTypesOutputPath)

	return nil
}

func runGoImports(path string) {
	logging.Debugf("Running goimports -w %s..", path)
	p, err := exec.LookPath("goimports")
	if err != nil {
		logging.Errorf("goimports not found in path!")
	}
	cmd := exec.Command(p, "-w", path)
	o, err := cmd.CombinedOutput()
	if err != nil {
		logging.Errorf("failed to execute goimports: %s", err.Error())
	} else {
		logging.Debug(string(o))
	}
}
