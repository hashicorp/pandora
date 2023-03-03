package pipeline

import (
	"os"
	"os/exec"
)

func writeFile(dest, content string) error {
	if err := os.WriteFile(dest, []byte(content), 0644); err != nil {
		return err
	}
	if err := exec.Command("gofmt", "-w", dest).Run(); err != nil {
		return err
	}
	if err := exec.Command("goimports", "-w", dest).Run(); err != nil {
		return err
	}
	return nil
}
