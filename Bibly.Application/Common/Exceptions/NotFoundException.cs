﻿using FluentValidation.Results;

namespace Bibly.Application.Common.Exceptions;

public class NotFoundException:Exception
{
}

public class ValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; set; } = [];

    public ValidationException()
    : base("One or more validation failures have occurred.")
    {

    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
    : this()
    {
        Errors = failures
        .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
        .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

}