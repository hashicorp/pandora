// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"fmt"
	"log"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/go-chi/chi/v5/middleware"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ServeCommand{}

type ServeCommand struct {
}

func NewServeCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ServeCommand{}, nil
	}
}

func (ServeCommand) Help() string {
	return "Launches the Server"
}

func (c ServeCommand) Run(inputArgs []string) int {
	args := Arguments{
		// defaults
		DataDirectory: "../../api-definitions/",
		Port:          8080,
		ServiceNames:  nil,
	}
	if err := args.Parse(inputArgs); err != nil {
		log.Fatal(err.Error())
	}

	logging.Debugf("Launching Server on port %d", args.Port)
	r := chi.NewRouter()
	r.Use(middleware.Logger)
	r.Route("/", endpoints.Router(args.DataDirectory, args.ServiceNames))
	logging.Infof("Data API launched at http://localhost:%d", args.Port)
	http.ListenAndServe(fmt.Sprintf(":%d", args.Port), r)
	return 0
}

func (ServeCommand) Synopsis() string {
	return "Launches the Server"
}
