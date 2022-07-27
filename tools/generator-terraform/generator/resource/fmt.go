package resource

import (
	"os"
	"os/exec"
)

func writeToPath(filePath string, fileContents string) {
	os.WriteFile(filePath, []byte(fileContents), 0644)
	runGoFmt(filePath)
	runGoImports(filePath)
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
