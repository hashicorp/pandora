// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"fmt"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
)

type Options struct {
	// ServiceType specifies the type of Data that should be used for this endpoint.
	ServiceType sdkModels.SourceDataType

	// UriPrefix specifies the URI which should be prefixed on any Operation URIs.
	UriPrefix string
}

type Api struct {
	servicesRepository repository.Repository
}

func Router(router chi.Router, options Options, servicesRepository repository.Repository) {
	api := Api{
		servicesRepository: servicesRepository,
	}

	router.Use(optionsContext(options))

	router.Route("/common-types", func(r chi.Router) {
		r.Route("/{commonTypesApiVersion}", func(r chi.Router) {
			r.Use(api.commonTypesApiVersionRouteContext)

			r.Get("/", api.commonTypesForApiVersion)
		})

		r.Get("/", api.commonTypes)
	})

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
		serviceName := chi.URLParam(r, "serviceName")
		if serviceName == "" {
			logging.Debug("Missing Service Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
			return
		}

		service, err := api.servicesRepository.GetService(serviceName)
		if err != nil {
			internalServerError(w, fmt.Errorf("retrieving service %q: %+v", serviceName, err))
			return
		}

		// NOTE: we need to ensure a pointer is passed to the context
		ctx := context.WithValue(r.Context(), "service", service)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func (api Api) commonTypesApiVersionRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		commonTypesApiVersion := chi.URLParam(r, "commonTypesApiVersion")
		if commonTypesApiVersion == "" {
			logging.Debug("Missing Common Types API Version")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
			return
		}

		ctx := r.Context()
		commonTypes, err := api.servicesRepository.GetCommonTypes()
		if err != nil {
			logging.Debug("Missing Common Types API Version")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
			return
		}
		if commonTypes == nil {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		commonTypesForThisApiVersion, ok := (*commonTypes)[commonTypesApiVersion]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		// NOTE: we need to ensure a pointer is passed to the context
		ctx = context.WithValue(ctx, "commonTypesForApiVersion", &commonTypesForThisApiVersion)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func serviceApiVersionRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		serviceApiVersion := chi.URLParam(r, "serviceApiVersion")
		if serviceApiVersion == "" {
			logging.Debug("Missing Service API Version")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
			return
		}

		ctx := r.Context()
		service, ok := ctx.Value("service").(*sdkModels.Service)
		if !ok {
			internalServerError(w, fmt.Errorf("service not found in request"))
			return
		}

		apiVersion, ok := service.APIVersions[serviceApiVersion]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		// NOTE: we need to ensure a pointer is passed to the context
		ctx = context.WithValue(ctx, "serviceApiVersion", &apiVersion)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func apiResourceNameRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		resourceName := chi.URLParam(r, "resourceName")
		if resourceName == "" {
			logging.Debug("Missing Resource Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
			return
		}

		ctx := r.Context()

		apiVersion, ok := ctx.Value("serviceApiVersion").(*sdkModels.APIVersion)
		if !ok {
			internalServerError(w, fmt.Errorf("service api version not found in request"))
			return
		}

		resource, ok := apiVersion.Resources[resourceName]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		// NOTE: we need to ensure a pointer is passed to the context
		ctx = context.WithValue(ctx, "resourceName", &resource)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}
