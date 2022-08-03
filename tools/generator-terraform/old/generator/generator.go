package generator

import (
	"fmt"
	"log"
	"path"
	"strings"
)

type Generator struct {
	data  *Data
	debug bool
}

func NewGenerator(data Data, debug bool) *Generator {
	return &Generator{
		data:  &data,
		debug: debug,
	}
}

func (g Generator) Generate() error {
	if g.debug {
		log.Printf("[DEBUG] Processing Data..")
	}
	if err := g.data.process(); err != nil {
		return fmt.Errorf("processing data: %+v", err)
	}
	if g.debug {
		log.Printf("[DEBUG] Ensuring working directory exists..")
	}
	if err := ensureDirectoryExists(g.data.PackageWorkingDirectory); err != nil {
		return fmt.Errorf("ensuring directory exists at %q: %+v", g.data.PackageWorkingDirectory, err)
	}
	if err := removeGeneratedFiles(g.data.PackageWorkingDirectory, g.data.fileNamePrefix); err != nil {
		return fmt.Errorf("removing existing generated files within %q: %+v", g.data.PackageWorkingDirectory, err)
	}

	if g.debug {
		log.Printf("[DEBUG] Running Generation..")
	}

	stages := map[string]stage{
		"dataSourceDefinition": dataSourceDefinitionStage{},
		"dataSourceRead":       dataSourceReadStage{},
		"dataSourceSchema":     dataSourceSchemaStage{},
		"dataSourceTests":      dataSourceTestsStage{},

		"model": modelStage{},

		"resourceDefinition": resourceDefinitionStage{},
		"resourceCreate":     resourceCreateStage{},
		"resourceDelete":     resourceDeleteStage{},
		"resourceRead":       resourceReadStage{},
		"resourceUpdate":     resourceUpdateStage{},
		"resourceSchema":     resourceSchemaStage{},
		"resourceTests":      resourceTestsStage{},

		// TODO: implement this
		// "validationFuncs": validationFuncsStage{},
	}
	for name, stage := range stages {
		if g.debug {
			log.Printf("  [DEBUG] Stage %q..", name)
		}

		if !stage.applicable(g.data) {
			log.Printf("  [DEBUG] .. is not applicable - skipping stage.")
			continue
		}

		filePath := stage.filePath(*g.data)
		filePath = path.Join(g.data.PackageWorkingDirectory, filePath)

		// Generated files are `*_gen.go` - hand maintained are `*.go` - if a hand-maintained file
		// exists then we don't output a generated version
		generatedFileName := fmt.Sprintf("%s.gen.go", strings.TrimSuffix(filePath, ".go"))
		handMaintainedFileName := filePath
		if fileExistsAtPath(handMaintainedFileName) {
			if g.debug {
				log.Printf("  [DEBUG] Hand-maintained file exists at %q - skipping stage.", handMaintainedFileName)
			}
			continue
		}

		fileContent, err := stage.generate(*g.data)
		if err != nil {
			return fmt.Errorf("running generation stage %q for %q: %+v", name, g.data.fileNamePrefix, err)
		}

		if g.debug {
			log.Printf("  [DEBUG] Writing to %q..", generatedFileName)
		}
		if err := writeToFile(generatedFileName, *fileContent); err != nil {
			return fmt.Errorf("outputting generated contents to %q: %+v", generatedFileName, err)
		}

		if g.debug {
			log.Printf("  [DEBUG] Completed Stage %q.", name)
		}
	}

	if g.debug {
		log.Printf("  [DEBUG] Running Go Fmt..")
	}
	runGoFmt(g.data.PackageWorkingDirectory)

	if g.debug {
		log.Printf("  [DEBUG] Running Go Imports..")
	}
	runGoImports(g.data.PackageWorkingDirectory)

	return nil
}
