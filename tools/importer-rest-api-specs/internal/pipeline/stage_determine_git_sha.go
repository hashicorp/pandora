// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import "github.com/go-git/go-git/v5"

func (p *Pipeline) determineGitCommitSHA() (*string, error) {
	repo, err := git.PlainOpen(p.opts.RestAPISpecsDirectory)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	return &commit, nil
}
