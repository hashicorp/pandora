package generator

import (
	"fmt"
	"os"
	"os/exec"
	"path"
	"path/filepath"
)

func ensureDirectoryExists(directory string) error {
	return os.MkdirAll(directory, 0755)
}

func fileExistsAtPath(filePath string) bool {
	exists, err := os.Stat(filePath)
	if err != nil {
		return false
	}

	return exists.Size() > 0
}

func removeGeneratedFiles(directory string, fileNamePrefix string) error {
	match := fmt.Sprintf("%s*.gen.go", fileNamePrefix)
	files, err := filepath.Glob(path.Join(directory, match))
	if err != nil {
		return fmt.Errorf("finding files matching %q: %+v", match, err)
	}

	for _, file := range files {
		os.Remove(file)
	}
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

func writeToFile(fileName, fileContents string) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.WriteString(fileContents)
	file.Close()

	return nil
}
