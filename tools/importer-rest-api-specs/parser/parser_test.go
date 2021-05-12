package parser

import (
	"context"
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"path/filepath"
	"sort"
	"strings"
	"testing"
	"time"
)

func TestParser(t *testing.T) {
	swaggerDirectory := "/Users/tharvey/code/src/github.com/Azure/azure-rest-api-specs/specification"
	services, err := findResourceManagerServices(swaggerDirectory)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				t.Parallel()

				// safety
				_, done := context.WithTimeout(context.TODO(), 90*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					t.Fatal(err)
				}
			})
		}
	}
}

func TestValidateAllSwaggersContainTypes(t *testing.T) {
	swaggerDirectory := "/Users/tharvey/code/src/github.com/Azure/azure-rest-api-specs/specification"
	services, err := findResourceManagerServices(swaggerDirectory)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				t.Parallel()

				// safety
				_, done := context.WithTimeout(context.TODO(), 90*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if strings.HasSuffix(err.Error(), "is missing a type") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

func TestValidateFindOAIGenParserBug(t *testing.T) {
	swaggerDirectory := "/Users/tharvey/code/src/github.com/Azure/azure-rest-api-specs/specification"
	services, err := findResourceManagerServices(swaggerDirectory)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				// safety
				_, done := context.WithTimeout(context.TODO(), 30*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if strings.Contains(err.Error(), "OAIGen") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

func TestValidateFindUnknownBugs(t *testing.T) {
	swaggerDirectory := "/Users/tharvey/code/src/github.com/Azure/azure-rest-api-specs/specification"
	services, err := findResourceManagerServices(swaggerDirectory)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				// safety
				_, done := context.WithTimeout(context.TODO(), 30*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if !strings.Contains(err.Error(), "OAIGen") &&
						!strings.HasSuffix(err.Error(), "is missing a type") &&
						!strings.HasSuffix(err.Error(), "duplicate operation ID") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

type resourceManagerService struct {
	Name            string
	ApiVersionPaths map[string]string
}

func findResourceManagerServices(directory string) (*[]resourceManagerService, error) {
	services := make(map[string]map[string]string, 0)
	err := filepath.Walk(directory,
		func(fullPath string, info os.FileInfo, err error) error {
			if err != nil {
				return err
			}
			if !info.IsDir() {
				return nil
			}

			// appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0
			// vmware/resource-manager/Microsoft.AVS/{preview|stable}/{version}
			relativePath := strings.TrimPrefix(fullPath, directory)
			relativePath = strings.TrimPrefix(relativePath, "/")
			trimmed := strings.TrimPrefix(relativePath, directory)
			segments := strings.Split(trimmed, "/")
			if len(segments) != 5 {
				return nil
			}

			serviceName := segments[0]
			serviceType := segments[1]
			resourceProvider := segments[2]
			serviceReleaseState := segments[3]
			apiVersion := segments[4]
			log.Printf("Service %q / Type %q / RP %q / Status %q / Version %q", serviceName, serviceType, resourceProvider, serviceReleaseState, apiVersion)
			log.Printf("Path %q", fullPath)

			existingPaths, ok := services[serviceName]
			if !ok {
				existingPaths = make(map[string]string, 0)
			}
			existingPaths[apiVersion] = fullPath
			services[serviceName] = existingPaths
			return nil
		})
	if err != nil {
		return nil, err
	}

	serviceNames := make([]string, 0)
	for serviceName := range services {
		serviceNames = append(serviceNames, serviceName)
	}
	sort.Strings(serviceNames)
	out := make([]resourceManagerService, 0)
	for _, serviceName := range serviceNames {
		paths := services[serviceName]
		out = append(out, resourceManagerService{
			Name:            serviceName,
			ApiVersionPaths: paths,
		})
	}
	return &out, nil
}

func swaggerFilesInDirectory(directory string) (*[]string, error) {
	swaggerFiles := make([]string, 0)
	dirContents, err := ioutil.ReadDir(directory)
	if err != nil {
		return nil, err
	}

	for _, file := range dirContents {
		if file.IsDir() {
			continue
		}

		extension := filepath.Ext(file.Name())
		if strings.EqualFold(extension, ".json") {
			filePath := filepath.Join(directory, file.Name())
			swaggerFiles = append(swaggerFiles, filePath)
		}
	}

	return &swaggerFiles, nil
}

func validateDirectory(serviceName, apiVersion, versionDirectory string) error {
	swaggerFiles, err := swaggerFilesInDirectory(versionDirectory)
	if err != nil {
		return fmt.Errorf("parsing swagger files in %q: %+v", versionDirectory, err)
	}

	for _, file := range *swaggerFiles {
		log.Printf("[DEBUG]    - File %q..", file)

		fileName := strings.TrimPrefix(file, versionDirectory)
		parsedFile, err := Load(versionDirectory, fileName, true)
		if err != nil {
			return err
		}

		_, err = parsedFile.Parse(serviceName, apiVersion)
		if err != nil {
			return err
		}

		// TODO; something more useful with the result
	}

	return nil
}
