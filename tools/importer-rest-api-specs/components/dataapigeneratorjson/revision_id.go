package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"
)

func OutputMetaData(workingDirectory, swaggerGitSha string) error {
	revision := map[string]string{
		"SwaggerRevision": swaggerGitSha,
	}

	data, err := json.MarshalIndent(&revision, "", `	`)
	if err != nil {
		return err
	}

	revisionIdFileName := path.Join(workingDirectory, "SwaggerRevision.json") // TODO: rename to metadata.json
	if err := writeJsonToFile(revisionIdFileName, data); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
