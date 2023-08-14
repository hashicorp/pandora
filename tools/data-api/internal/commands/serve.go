package commands

import (
	"fmt"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/go-chi/chi/v5/middleware"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ServeCommand{}

type ServeCommand struct {
	Log hclog.Logger
}

func (ServeCommand) Help() string {
	return "Launches the Server"
}

func (c ServeCommand) Run(args []string) int {
	port := 8080
	// TODO: dynamic ports from args/env

	c.Log.Debug(fmt.Sprintf("Launching Server on port %d", port))
	r := chi.NewRouter()
	r.Use(middleware.Logger)
	r.Route("/", endpoints.Router)
	http.ListenAndServe(fmt.Sprintf(":%d", port), r)
	return 0
}

func (ServeCommand) Synopsis() string {
	return "Launches the Server"
}
