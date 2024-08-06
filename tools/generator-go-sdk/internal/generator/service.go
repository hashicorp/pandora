// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
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

	if err := cleanAndRecreateWorkingDirectory(data.resourceOutputPath); err != nil {
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
	for name, stage := range stages {
		logging.Debugf("Running Stage %q..", name)
		if err := stage(data); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(data.resourceOutputPath)
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

	runGoFmt(data.versionOutputPath)
	runGoImports(data.versionOutputPath)

	return nil
}

func (s *Generator) GenerateCommonTypes(input VersionGeneratorInput) error {
	data := input.generatorData(s.settings)

	if err := cleanAndRecreateWorkingDirectory(data.commonTypesOutputPath); err != nil {
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

	runGoFmt(data.commonTypesOutputPath)
	runGoImports(data.commonTypesOutputPath)

	return nil
}

func runGoFmt(path string) {
	cmd := exec.Command("gofmt", "-w", path)
	_ = cmd.Start()
	_ = cmd.Wait()
}

func runGoImports(path string) {
	cmd := exec.Command("goimports", "-w", path)
	_ = cmd.Start()
	_ = cmd.Wait()
}

func cleanAndRecreateWorkingDirectory(path string) error {
	// rm -r 💥
	if err := os.RemoveAll(path); err != nil {
		return fmt.Errorf("deleting %q: %+v", path, err)
	}

	return ensureWorkingDirectoryExists(path)
}

func ensureWorkingDirectoryExists(path string) error {
	if err := os.MkdirAll(path, 0777); err != nil {
		if !os.IsExist(err) {
			return fmt.Errorf("creating %q: %+v", path, err)
		}
	}

	return nil
}
