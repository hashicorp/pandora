// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
	"os/exec"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ServiceGenerator struct {
	settings Settings
	logger   hclog.Logger
}

func NewServiceGenerator(settings Settings) ServiceGenerator {
	return ServiceGenerator{
		settings: settings,
	}
}

type ServiceGeneratorInput struct {
	ServiceName     string
	ServiceDetails  models.Service
	VersionName     string
	VersionDetails  models.APIVersion
	ResourceName    string
	ResourceDetails models.APIResource
	OutputDirectory string
	Source          models.SourceDataOrigin
}

func (s *ServiceGenerator) Generate(input ServiceGeneratorInput, logger hclog.Logger) error {
	data := input.generatorData(s.settings)

	if err := cleanAndRecreateWorkingDirectory(data.resourceOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.resourceOutputPath, err)
	}
	if data.useIdAliases {
		if err := ensureWorkingDirectoryExists(data.idsOutputPath); err != nil {
			return fmt.Errorf("ensuring the ids working directory %q exists: %+v", data.idsOutputPath, err)
		}
	}

	stages := map[string]func(data ServiceGeneratorData, logger hclog.Logger) error{
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
		logger.Debug(fmt.Sprintf("Running Stage %q..", name))
		stageLogger := logger.Named(name)
		if err := stage(data, stageLogger); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(data.resourceOutputPath)
	runGoImports(data.resourceOutputPath)

	return nil
}

type VersionInput struct {
	OutputDirectory string
	Resources       map[string]models.APIResource
	ServiceName     string
	Source          models.SourceDataOrigin
	UseNewBaseLayer bool
	VersionName     string
}

func (s *ServiceGenerator) GenerateForVersion(input VersionInput, logger hclog.Logger) error {
	input.ServiceName = strings.ToLower(input.ServiceName)
	input.VersionName = strings.ToLower(input.VersionName)
	versionDirectory := filepath.Join(input.OutputDirectory, input.ServiceName, input.VersionName)

	stages := map[string]func(data VersionInput, versionDirectory string, logger hclog.Logger) error{
		"metaClient": s.metaClient,
	}
	for name, stage := range stages {
		logger.Debug(fmt.Sprintf("Running Stage %q..", name))
		if err := stage(input, versionDirectory, logger); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(versionDirectory)
	runGoImports(versionDirectory)
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
	os.RemoveAll(path)
	// TODO: make these less exciting
	if err := os.MkdirAll(path, 0777); err != nil {
		return fmt.Errorf("creating %q: %+v", path, err)
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
