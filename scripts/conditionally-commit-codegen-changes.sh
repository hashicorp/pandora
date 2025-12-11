#!/bin/bash
# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0


if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
  git add --all
  git commit -m "$1"
  echo "::set-output name=has_changes_to_push::true"
else
  echo "::set-output name=has_changes_to_push::false"
fi