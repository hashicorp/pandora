package generator

import (
	"fmt"
	"log"
	"os"
	"os/exec"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/sdk/services"
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
	ServiceName     string
	ServiceDetails  services.ResourceManagerService
	VersionName     string
	VersionDetails  services.ServiceVersion
	ResourceName    string
	ResourceDetails services.Resource
	OutputDirectory string
	Source          resourcemanager.ApiDefinitionsSource
}

func (s *ServiceGenerator) Generate(input ServiceGeneratorInput) error {
	data := input.generatorData()

	if err := cleanAndRecreateWorkingDirectory(data.resourceOutputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", data.resourceOutputPath, err)
	}
	if data.useIdAliases {
		if err := ensureWorkingDirectoryExists(data.idsOutputPath); err != nil {
			return fmt.Errorf("ensuring the ids working directory %q exists: %+v", data.idsOutputPath, err)
		}
	}

	stages := map[string]func(data ServiceGeneratorData) error{
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
		log.Printf("[DEBUG] Running Stage %q..", name)
		if err := stage(data); err != nil {
			return fmt.Errorf("generating %s: %+v", name, err)
		}
	}

	runGoFmt(data.resourceOutputPath)
	runGoImports(data.resourceOutputPath)

	return nil
}

type VersionInput struct {
	OutputDirectory string
	Resources       map[string]services.Resource
	ServiceName     string
	Source          resourcemanager.ApiDefinitionsSource
	VersionName     string
}

func (s *ServiceGenerator) GenerateForVersion(data VersionInput) error {
	data.ServiceName = strings.ToLower(data.ServiceName)
	data.VersionName = strings.ToLower(data.VersionName)
	versionDirectory := filepath.Join(data.OutputDirectory, data.ServiceName, data.VersionName)

	stages := map[string]func(data VersionInput, versionDirectory string) error{
		"metaClient": s.metaClient,
	}
	for name, stage := range stages {
		log.Printf("[DEBUG] Running Stage %q..", name)
		if err := stage(data, versionDirectory); err != nil {
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
