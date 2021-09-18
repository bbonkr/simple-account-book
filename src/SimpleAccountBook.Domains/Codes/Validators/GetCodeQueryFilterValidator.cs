using FluentValidation;
using SimpleAccountBook.Domains.Codes.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Validators
{
    public class GetCodeQueryFilterValidator : AbstractValidator<GetCodesQueryFilter>
    {
        public GetCodeQueryFilterValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0)
                .WithMessage("{PropertyName} should be greater than 0.")
                .WithErrorCode("ERROR-1000");
            RuleFor(x => x.Limit).GreaterThan(0)
                .WithMessage("{PropertyName} should be greater than 0.")
                .WithErrorCode("ERROR-1000");
        }
    }
}
