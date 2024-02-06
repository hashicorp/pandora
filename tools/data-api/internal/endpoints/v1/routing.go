// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"fmt"
	"log"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

type Options struct {
	// ServiceType specifies the type of Data that should be used for this endpoint.
	ServiceType repositories.ServiceType

	// UriPrefix specifies the URI which should be prefixed on any Operation URIs.
	UriPrefix string

	// UsesCommonTypes specifies whether this endpoint supports Common Types or not.
	UsesCommonTypes bool
}

type Api struct {
	servicesRepository repositories.ServicesRepository
}

func Router(router chi.Router, options Options, servicesRepository repositories.ServicesRepository) {
	api := Api{
		servicesRepository: servicesRepository,
	}

	router.Use(optionsContext(options))

	router.Get("/commonTypes", api.commonTypes)

	router.Route("/services", func(r chi.Router) {
		r.Route("/{serviceName}", func(r chi.Router) {
			r.Use(api.serviceRouteContext)

			r.Get("/", api.serviceDetails)

			r.Route("/{serviceApiVersion}", func(r chi.Router) {
				r.Use(serviceApiVersionRouteContext)
				r.Get("/", api.detailsForApiVersion)

				r.Route("/{resourceName}", func(r chi.Router) {
					r.Use(apiResourceNameRouteContext)

					r.Get("/operations", api.operationsForApiResource)
					r.Get("/schema", api.schemaForApiResource)
				})
			})

			r.Get("/terraform", api.terraform)
		})
		r.NotFound(func(w http.ResponseWriter, r *http.Request) {
			w.WriteHeader(http.StatusNotFound)
		})
		r.Get("/", api.services)
	})
}

func optionsContext(options Options) func(http.Handler) http.Handler {
	return func(next http.Handler) http.Handler {
		return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
			ctx := context.WithValue(r.Context(), "options", options)
			next.ServeHTTP(w, r.WithContext(ctx))
		})
	}
}

func (api Api) serviceRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		opts, ok := r.Context().Value("options").(Options)
		if !ok {
			w.WriteHeader(http.StatusInternalServerError)
			return
		}

		serviceName := chi.URLParam(r, "serviceName")
		if serviceName == "" {
			log.Printf("[DEBUG] Missing Service Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		service, err := api.servicesRepository.GetByName(serviceName, opts.ServiceType)
		if err != nil {
			internalServerError(w, fmt.Errorf("retrieving service %q: %+v", serviceName, err))
			return
		}

		ctx := context.WithValue(r.Context(), "service", service)

		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func serviceApiVersionRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		serviceApiVersion := chi.URLParam(r, "serviceApiVersion")
		if serviceApiVersion == "" {
			log.Printf("[DEBUG] Missing Service API Version")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		ctx := r.Context()
		service, ok := ctx.Value("service").(*repositories.ServiceDetails)
		if !ok {
			internalServerError(w, fmt.Errorf("service not found in request"))
			return
		}

		apiVersion, ok := service.ApiVersions[serviceApiVersion]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		ctx = context.WithValue(ctx, "serviceApiVersion", apiVersion)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func apiResourceNameRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		resourceName := chi.URLParam(r, "resourceName")
		if resourceName == "" {
			log.Printf("[DEBUG] Missing Resource Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		ctx := r.Context()

		apiVersion, ok := ctx.Value("serviceApiVersion").(*repositories.ServiceApiVersionDetails)
		if !ok {
			internalServerError(w, fmt.Errorf("service api version not found in request"))
			return
		}

		resource, ok := apiVersion.Resources[resourceName]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		ctx = context.WithValue(ctx, "resourceName", resource)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}
