package main

import (
	"fmt"
	"log"
	"os"
	"sort"
	"strings"
	"sync"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func generateApiVersions(input []parsedData, workingDirectory, rootNamespace, swaggerGitSha string, debug bool) error {
	for _, item := range input {
		data := generator.GenerationDataForServiceAndApiVersion(item.ServiceName, item.ApiVersion, workingDirectory, rootNamespace, swaggerGitSha)
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

func generateServiceDefinitions(input []parsedData, workingDirectory, rootNamespace, swaggerGitSha string, debug bool) error {
	// the same service may appear multiple times, so we first need to Distinct them
	serviceNames := distinctServiceNames(input)

	os.MkdirAll(workingDirectory, permissions)

	for _, service := range serviceNames {
		if debug {
			log.Printf("[DEBUG] Processing Service %q..", service)
		}
		data := generator.GenerationDataForService(service, workingDirectory, rootNamespace, swaggerGitSha)
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

func generateEverything(swaggerGitSha string) {
	services, err := parser.FindResourceManagerServices(swaggerDirectory + "/specification")
	if err != nil {
		fmt.Printf("%s", err)
		os.Exit(1)
	}

	var wg sync.WaitGroup
	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			swaggerFiles, err := parser.SwaggerFilesInDirectory(versionPath)
			if err != nil {
				fmt.Println(err.Error())
			}
			swaggerFilesTrimmed := make([]string, 0)
			for _, swaggerFile := range *swaggerFiles {
				swaggerFilesTrimmed = append(swaggerFilesTrimmed, strings.TrimPrefix(swaggerFile, versionPath))
			}

			runInput := RunInput{
				RootNamespace:    RootNamespace,
				ServiceName:      service.Name,
				ApiVersion:       apiVersion,
				OutputDirectory:  outputDirectory,
				SwaggerDirectory: versionPath,
				SwaggerFiles:     swaggerFilesTrimmed,
			}

			wg.Add(1)
			go func(input RunInput, sha string) {
				err := run(input, sha)
				if err != nil {
					log.Printf("error: %+v", err)
				}
				wg.Done()
			}(runInput, swaggerGitSha)
		}
	}
	wg.Wait()
}
