// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"os"
	"os/exec"
)

// TODO: refactor/de-dupe this

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
