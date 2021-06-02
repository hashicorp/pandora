package main

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"log"
	"os"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
)

func generateApiVersions(input []parsedData, workingDirectory, rootNamespace string, debug bool) error {
	for _, item := range input {
		data := generator.GenerationDataForServiceAndApiVersion(item.ServiceName, item.ApiVersion, workingDirectory, rootNamespace)
		generator := generator.NewPackageDefinitionGenerator(data, debug)

		os.MkdirAll(data.WorkingDirectoryForApiVersion, permissions)
		if err := generator.GenerateVersionDefinitionAndRecreateDirectory(item.Resources, data.WorkingDirectoryForApiVersion, permissions); err != nil {
			return fmt.Errorf("generating Version Definition for Namespace %q: %+v", data.NamespaceForApiVersion, err)
		}

		for resourceName, resource := range item.Resources {
			if debug {
				log.Printf("Generating Resource at %q", resourceName)
			}
			outputDirectory := data.WorkingDirectoryForResource(resourceName)
			os.MkdirAll(outputDirectory, permissions)
			namespace := data.NamespaceForResource(resourceName)
			if err := generator.GenerateResources(resourceName, namespace, resource, outputDirectory); err != nil {
				return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
			}
		}
	}

	return nil
}

func generateServiceDefinitions(input []parsedData, workingDirectory, rootNamespace string, debug bool) error {
	// the same service may appear multiple times, so we first need to Distinct them
	serviceNames := distinctServiceNames(input)

	os.MkdirAll(workingDirectory, permissions)

	for _, service := range serviceNames {
		if debug {
			log.Printf("[DEBUG] Processing Service %q..", service)
		}
		data := generator.GenerationDataForService(service, workingDirectory, rootNamespace)
		os.MkdirAll(data.WorkingDirectoryForService, permissions)

		// clean up any files or directories which which aren't on the exclude list
		excludeList := []string{
			"ServiceDefinition-GenerationSetting.cs",
			// whilst this is a directory that should be excluded, it's just the name not with a prefix
			"Terraform",
		}
		files, err := findFilesInDirectory(data.WorkingDirectoryForService, excludeList, debug)
		if err != nil {
			return fmt.Errorf("finding files in directory %q: %+v", data.WorkingDirectoryForService, err)
		}

		for _, name := range *files {
			if debug {
				log.Printf("[DEBUG] Removing Path %q..", name)
			}
			os.RemoveAll(name)
		}

		// finally let's output the new Service Definition
		generator := generator.NewPackageDefinitionGenerator(data, debug)
		if err := generator.GenerateServiceDefinition(); err != nil {
			return fmt.Errorf("generating Service Definition for Namespace %q: %+v", data.NamespaceForService, err)
		}
	}

	return nil
}

func findFilesInDirectory(directory string, excludeList []string, debug bool) (*[]string, error) {
	dir, err := os.Open(directory)
	if err != nil {
		if os.IsNotExist(err) {
			if debug {
				log.Printf("[DEBUG] Creating Directory %q..", directory)
			}

		} else {
			return nil, fmt.Errorf("opening directory %q: %+v", directory, err)
		}
	}
	defer dir.Close()

	files := make([]string, 0)
	f, err := dir.ReadDir(0)
	if err != nil {
		return nil, fmt.Errorf("finding files in %q: %+v", directory, err)
	}
	for i := range f {
		file := f[i]
		fileName := file.Name()

		skip := false
		for _, e := range excludeList {
			if strings.EqualFold(e, fileName) {
				skip = true
				break
			}
		}
		if skip {
			continue
		}
		files = append(files, fileName)
	}

	return &files, nil
}

func distinctServiceNames(input []parsedData) []string {
	distinctServiceNames := make(map[string]struct{})
	apiVersionsForServices := make(map[string][]string)
	for _, v := range input {
		distinctServiceNames[v.ServiceName] = struct{}{}
		versions, ok := apiVersionsForServices[v.ServiceName]
		if !ok {
			versions = make([]string, 0)
		}
		versions = append(versions, v.ApiVersion)
		apiVersionsForServices[v.ServiceName] = versions
	}

	names := make([]string, 0)
	for k := range distinctServiceNames {
		names = append(names, k)
	}
	sort.Strings(names)

	return names
}

func generateEverything() {
	services, err := parser.FindResourceManagerServices(swaggerDirectory + "/specification")
	if err != nil {
		fmt.Printf("%s", err)
		os.Exit(1)
	}
	loadFailures := make([]string, 0)
	genFailures := make([]string, 0)
	parseFailures := make([]string, 0)
	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			swaggerFiles, err := parser.SwaggerFilesInDirectory(versionPath)
			if err != nil {
				fmt.Println(err.Error())
			}

			for _, f := range *swaggerFiles {
				fileName := strings.TrimPrefix(f, versionPath)
				fmt.Println(fmt.Sprintf("[DEBUG] loading %s%s (API Version: %s)", service.Name, fileName, apiVersion))
				parsed, erl := parser.Load(versionPath, fileName, false)
				if erl != nil {
					loadAttempt := 0
					MaxLoadFails := 5
					for loadAttempt < MaxLoadFails {
						parsed, erl = parser.Load(versionPath, fileName, false)
						if erl != nil {
							fmt.Println(fmt.Sprintf("failed loading %q (%s), attempt %d, error was: %s", fileName, service.Name, loadAttempt+1, erl.Error()))
							loadAttempt++
						}
					}
					if loadAttempt >= MaxLoadFails {
						loadFailures = append(loadFailures, fmt.Sprintf("failed loading %q (%s) after %d attempts, giving up: %s", fileName, service.Name, loadAttempt, erl))
						continue
					} else {
						fmt.Println(fmt.Sprintf("succeeded loading %q (%s) on attempt %d", fileName, service.Name, loadAttempt))
					}

				}
				fmt.Println(fmt.Sprintf("[DEBUG] parsing %s%s (API Version: %s)", service.Name, fileName, apiVersion))
				def, erp := parsed.Parse(service.Name, apiVersion)
				if erp != nil {
					fmt.Println(erp.Error())
					parseFailures = append(parseFailures, fmt.Sprintf("failed parsing %s: %s", service.Name, erp))
					break
				}

				data := generator.GenerationDataForServiceAndApiVersion(service.Name, apiVersion, outputDirectory, RootNamespace)
				generator := generator.NewPackageDefinitionGenerator(data, false)
				for resourceName, resource := range def.Resources {
					apiOutputDirectory := data.WorkingDirectoryForResource(resourceName)
					os.MkdirAll(apiOutputDirectory, permissions)
					fmt.Println(fmt.Sprintf("[DEBUG] Generating resource %s in service %s (API version: %s)", resourceName, def.ServiceName, def.ApiVersion))
					namespace := data.NamespaceForResource(resourceName)
					if err := generator.GenerateResources(resourceName, namespace, resource, apiOutputDirectory); err != nil {
						fmt.Printf("generating %s: %+v", resourceName, err)
						genFailures = append(genFailures, fmt.Sprintf("%s in %s", resourceName, apiOutputDirectory))
					}
				}
			}
		}
	}
	if len(loadFailures) > 0 {
		for _, l := range loadFailures {
			fmt.Println(fmt.Sprintf("Failed to load: %s", l))
		}
	}
	if len(parseFailures) > 0 {
		for _, p := range parseFailures {
			fmt.Println(fmt.Sprintf("Failed to parse: %s", p))
		}
	}
	if len(genFailures) > 0 {
		for _, g := range genFailures {
			fmt.Println(fmt.Sprintf("Failed to generate: %s", g))
		}
	}
}