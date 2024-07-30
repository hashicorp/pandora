// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
	"os/exec"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
)

type ServiceGenerator struct {
	settings Settings
}

func NewServiceGenerator(settings Settings) ServiceGenerator {
	return ServiceGenerator{
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

func (s *ServiceGenerator) Generate(input ServiceGeneratorInput) error {
	data := input.generatorData(s.settings)

	if err := cleanAndRecreateWorkingDirectory(data.resourceOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.resourceOutputPath, err)
	}
	if data.useIdAliases {
		if err := ensureWorkingDirectoryExists(data.idsOutputPath); err != nil {
			return fmt.Errorf("ensuring the ids working directory %q exists: %+v", data.idsOutputPath, err)
		}
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

func (s *ServiceGenerator) GenerateForVersion(input VersionGeneratorInput) error {
	data := input.generatorData(s.settings)

	if err := cleanAndRecreateWorkingDirectory(data.commonTypesOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.commonTypesOutputPath, err)
	}

	stages := map[string]func(data VersionGeneratorData) error{
		"commonTypes": s.commonTypes,
		"metaClient":  s.metaClient,
	}
	for name, stage := range stages {
		logging.Debugf("Running Stage %q..", name)
		if err := stage(data); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(data.commonTypesOutputPath)
	runGoFmt(data.versionOutputPath)

	runGoImports(data.commonTypesOutputPath)
	runGoImports(data.versionOutputPath)

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
	// first, ensure the directory exists
	if err := os.MkdirAll(path, 0777); err != nil {
		return fmt.Errorf("creating %q: %+v", path, err)
	}

	// determine contents of output directory
	pathsToDelete, err := filepath.Glob(filepath.Join(path, "*"))
	if err != nil {
		return fmt.Errorf("globbing files to delete: %+v", err)
	}

	// delete any contained files and directories
	for _, pathToDelete := range pathsToDelete {
		if err = os.RemoveAll(pathToDelete); err != nil {
			return fmt.Errorf("deleting %q: %w", pathToDelete, err)
		}
	}

	return nil
}

func ensureWorkingDirectoryExists(path string) error {
	// TODO: make these less exciting
	if err := os.MkdirAll(path, 0777); err != nil {
		if !os.IsExist(err) {
			return fmt.Errorf("creating %q: %+v", path, err)
		}
	}

	return nil
}
