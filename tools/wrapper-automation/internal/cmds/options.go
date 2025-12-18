// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cmds

import (
	"flag"
	"fmt"
	"os"
	"path/filepath"
)

type options struct {
	// apiDefinitionsDirectory specifies the directory where the API Definitions are located.
	apiDefinitionsDirectory string

	// outputDirectory specifies the output directory where the Go SDK should be generated.
	outputDirectory string
}

func (o options) validate() error {
	if o.apiDefinitionsDirectory == "" {
		return fmt.Errorf("'api-definitions-dir' must be specified")
	}

	abs, err := filepath.Abs(o.apiDefinitionsDirectory)
	if err != nil {
		return fmt.Errorf("determining absolute path to %q: %+v", o.apiDefinitionsDirectory, err)
	}
	o.apiDefinitionsDirectory = abs
	if _, err := os.Stat(o.apiDefinitionsDirectory); err != nil {
		if os.IsNotExist(err) {
			return fmt.Errorf("the API Definitions Directory doesn't exist at %q", o.apiDefinitionsDirectory)
		}

		return fmt.Errorf("validating API Definitions Directory exists at %q: %+v", o.apiDefinitionsDirectory, err)
	}

	return nil
}

func parseCLIArguments(args []string) (*options, error) {
	o := &options{}

	f := flag.NewFlagSet("wrapper-automation", flag.ExitOnError)
	f.StringVar(&o.apiDefinitionsDirectory, "api-definitions-dir", "", "--api-definitions-dir=./api-definitions")
	f.StringVar(&o.outputDirectory, "output-dir", "", "--output-dir=../output")

	if err := f.Parse(args); err != nil {
		return nil, fmt.Errorf("parsing cli arguments: %+v", err)
	}

	if err := o.validate(); err != nil {
		return nil, fmt.Errorf("validating cli arguments: %+v", err)
	}

	return o, nil
}
