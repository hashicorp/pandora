package dataapigeneratoryaml

import (
	"fmt"
	"path"

	"github.com/go-yaml/yaml"
)

func outputRevisionId(workingDirectory, namespace, swaggerGitSha string) error {
	revision := map[string]string{
		"SwaggerRevision": swaggerGitSha,
	}

	data, err := yaml.Marshal(&revision)
	if err != nil {
		return err
	}

	revisionIdFileName := path.Join(workingDirectory, namespace, "SwaggerRevision.yaml")
	if err := writeYamlToFile(revisionIdFileName, data); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
