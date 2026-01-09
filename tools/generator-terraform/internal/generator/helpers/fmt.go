// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"os"
	"os/exec"
)

func WriteToPath(filePath string, fileContents string) {
	_ = os.WriteFile(filePath, []byte(fileContents), 0644)
	RunGoFmt(filePath)
	RunGoImports(filePath)
}

func RunGoFmt(path string) {
	cmd := exec.Command("gofmt", "-w", path)
	_ = cmd.Start()
	_ = cmd.Wait()
}

func RunGoImports(path string) {
	cmd := exec.Command("goimports", "-w", path)
	_ = cmd.Start()
	_ = cmd.Wait()
}
