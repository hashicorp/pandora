package dataapigeneratorjson

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"os"
	"path"
)

func (s Generator) workingDirectoryForResource(resource string) string {
	dir := s.workingDirectoryForApiVersion
	return path.Join(dir, resource)
}

func recreateDirectory(directory string, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Deleting any existing directory at %q..", directory))
	if err := os.RemoveAll(directory); err != nil {
		return fmt.Errorf("removing any existing directory at %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("(Re)Creating the directory at %q..", directory))
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("Created Directory at %q", directory))
	return nil
}

func ensureDirectoryExists(directory string, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Ensuring the directory exists at %q..", directory))
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		if os.IsExist(err) {
			logger.Trace(fmt.Sprintf("Directory already exists at %q", directory))
			return nil
		}
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("Created Directory at %q", directory))
	return nil
}

func writeJsonToFile(fileName string, fileContents []byte) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.Write(fileContents)
	file.Close()
	return nil
}
