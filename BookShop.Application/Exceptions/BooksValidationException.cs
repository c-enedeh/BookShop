﻿using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Application.Exceptions
{
    public class BooksValidationException : System.Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public BooksValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public BooksValidationException(List<ValidationFailure> failures) : this()
        {
            var propertyNames = failures.Select(e => e.PropertyName).Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures.Where(e => e.PropertyName == propertyName).Select(e => e.ErrorMessage).ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
