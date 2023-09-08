package generator

import (
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type CommonTypesGenerator struct{}

func NewCommonTypesGenerator() CommonTypesGenerator {
	return CommonTypesGenerator{}
}

type SDKInput struct {
	CommonPackageName         string
	CommonPackageRelativePath string
	CommonTypes               *services.ResourceManagerCommonTypes
	OutputSubDirectoryName    string
	OutputDirectoryPath       string
	Source                    resourcemanager.ApiDefinitionsSource
	VersionName               string
}

func (s *CommonTypesGenerator) GenerateForSDK(input SDKInput) error {
	input.VersionName = strings.ToLower(input.VersionName)
	commonTypesDirectory := filepath.Join(input.OutputDirectoryPath, input.CommonPackageRelativePath)

	if err := cleanAndRecreateWorkingDirectory(commonTypesDirectory); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", commonTypesDirectory, err)
	}

	stages := map[string]func(SDKInput, string) error{
		"constants":  s.constants,
		"models":     s.models,
		"predicates": s.predicates,
	}
	for name, stage := range stages {
		log.Printf("[DEBUG] Running Stage %q..", name)
		if err := stage(input, commonTypesDirectory); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(commonTypesDirectory)
	runGoImports(commonTypesDirectory)
	return nil
}

func (s *CommonTypesGenerator) constants(input SDKInput, outputDirectory string) error {
	data := ServiceGeneratorData{
		apiVersion:  input.VersionName,
		constants:   input.CommonTypes.Constants,
		models:      input.CommonTypes.Models,
		packageName: input.CommonPackageName,
		source:      input.Source,
	}

	for constantName, constant := range input.CommonTypes.Constants {
		fileName := fmt.Sprintf("constant_%s.go", strings.ToLower(constantName))
		gen := constantTemplater{
			name:    constantName,
			details: constant,
		}
		if err := s.writeToPath(outputDirectory, fileName, gen, data); err != nil {
			return fmt.Errorf("templating constant for %q: %+v", constantName, err)
		}
	}

	return nil
}

func (s *CommonTypesGenerator) models(input SDKInput, outputDirectory string) error {
	data := ServiceGeneratorData{
		apiVersion:  input.VersionName,
		constants:   input.CommonTypes.Constants,
		models:      input.CommonTypes.Models,
		packageName: input.CommonPackageName,
		source:      input.Source,
	}

	for modelName, model := range input.CommonTypes.Models {
		fileName := fmt.Sprintf("model_%s.go", strings.ToLower(modelName))
		gen := modelTemplater{
			name:  modelName,
			model: model,
		}
		if err := s.writeToPath(outputDirectory, fileName, gen, data); err != nil {
			return fmt.Errorf("templating model for %q: %+v", modelName, err)
		}
	}

	return nil
}

func (s *CommonTypesGenerator) predicates(input SDKInput, outputDirectory string) error {
	data := ServiceGeneratorData{
		apiVersion:  input.VersionName,
		constants:   input.CommonTypes.Constants,
		models:      input.CommonTypes.Models,
		packageName: input.CommonPackageName,
		source:      input.Source,
	}

	for modelName := range input.CommonTypes.Models {
		fileName := fmt.Sprintf("predicates_%s.go", strings.ToLower(modelName))
		gen := predicatesTemplater{
			sortedModelNames: []string{modelName},
			models:           input.CommonTypes.Models,
		}
		if err := s.writeToPath(outputDirectory, fileName, gen, data); err != nil {
			return fmt.Errorf("templating model predicates for %q: %+v", modelName, err)
		}
	}

	return nil
}

func (s *CommonTypesGenerator) writeToPath(directory, filePath string, templater templaterForResource, data ServiceGeneratorData) error {
	fileContents, err := templater.template(data)
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)
	file, err := os.Create(fullFilePath)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	_, _ = file.WriteString(*fileContents)
	return nil
}
