package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"
)

func outputRevisionId(workingDirectory, swaggerGitSha string) error {
	revision := map[string]string{
		"SwaggerRevision": swaggerGitSha,
	}

	data, err := json.MarshalIndent(&revision, "", " ")
	if err != nil {
		return err
	}

	revisionIdFileName := path.Join(workingDirectory, "SwaggerRevision.json")
	if err := writeJsonToFile(revisionIdFileName, data); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
