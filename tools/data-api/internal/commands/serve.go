// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"fmt"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/go-chi/chi/v5/middleware"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ServeCommand{}

type ServeCommand struct {
	args Arguments
}

func NewServeCommand(args Arguments) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ServeCommand{
			args: args,
		}, nil
	}
}

func (ServeCommand) Help() string {
	return "Launches the Server"
}

func (c ServeCommand) Run(_ []string) int {
	logging.Debugf("Launching Server on port %d", c.args.Port)
	r := chi.NewRouter()
	r.Use(middleware.Logger)
	r.Route("/", endpoints.Router(c.args.DataDirectory, c.args.ServiceNames))
	logging.Infof("Data API launched at http://localhost:%d", c.args.Port)
	http.ListenAndServe(fmt.Sprintf(":%d", c.args.Port), r)
	return 0
}

func (ServeCommand) Synopsis() string {
	return "Launches the Server"
}
