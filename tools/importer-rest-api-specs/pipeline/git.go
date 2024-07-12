// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"github.com/go-git/go-git/v5"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func determineGitSha(repositoryPath string) (*string, error) {
	repo, err := git.PlainOpen(repositoryPath)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	logging.Debugf("Swagger Repository Commit SHA is %q", commit)
	return &commit, nil
}
