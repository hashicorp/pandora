#!/bin/bash

if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
  git add --all
  git commit -m "data: regenerating based on the latest Swagger"
  echo "::set-output name=has_changes_to_push::true"
else
  echo "::set-output name=has_changes_to_push::false"
fi