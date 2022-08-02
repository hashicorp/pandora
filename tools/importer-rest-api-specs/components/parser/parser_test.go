package parser

import (
	"context"
	"fmt"
	"log"
	"os"
	"strings"
	"testing"
	"time"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
)

const swaggerDirectory = "../../../swagger/specification"
const runAllEnvVar = "ALL"

func TestAllSwaggersUsingParser(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	services, err := discovery.FindResourceManagerServices(swaggerDirectory, hclog.New(hclog.DefaultOptions))
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

func TestAllSwaggersValidateAllContainTypes(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	services, err := discovery.FindResourceManagerServices(swaggerDirectory, hclog.New(hclog.DefaultOptions))
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

func TestAllSwaggersValidateFindOAIGenParserBug(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	services, err := discovery.FindResourceManagerServices(swaggerDirectory, hclog.New(hclog.DefaultOptions))
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

func TestAllSwaggersValidateFindUnknownBugs(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	services, err := discovery.FindResourceManagerServices(swaggerDirectory, hclog.New(hclog.DefaultOptions))
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

func validateDirectory(serviceName, apiVersion, versionDirectory string) error {
	swaggerFiles, err := discovery.SwaggerFilesInDirectory(versionDirectory)
	if err != nil {
		return fmt.Errorf("parsing swagger files in %q: %+v", versionDirectory, err)
	}

	fileNames := make([]string, 0)
	for _, file := range *swaggerFiles {
		fileName := strings.TrimPrefix(file, versionDirectory)
		fileNames = append(fileNames, fileName)
	}

	if _, err := LoadAndParseFiles(versionDirectory, *swaggerFiles, serviceName, apiVersion, hclog.New(hclog.DefaultOptions)); err != nil {
		return err
	}

	return nil
}
