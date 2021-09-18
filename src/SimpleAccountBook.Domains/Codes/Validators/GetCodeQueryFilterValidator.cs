using FluentValidation;
using SimpleAccountBook.Domains.Codes.Models;
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

        public class CodeInsertRequestModelValidator : AbstractValidator<CodeInsertRequestModel>
        {
            public CodeInsertRequestModelValidator()
            {
                RuleFor(x => x.ParentId).NotNull().NotEqual(Guid.Empty)
                    .WithMessage("{PropertyName} should be empty.")
                    .WithErrorCode("ERROR-1000");
                RuleFor(x => x.Text).NotNull().NotEmpty()
                    .WithMessage("{PropertyName} should not be empty.")
                    .WithErrorCode("ERROR-1000");
                RuleFor(x => x.Ordinal).GreaterThan(0)
                    .WithMessage("{PropertyName} should be greater than 0.")
                    .WithErrorCode("ERROR-1000");
            }
        }

        public class CodeUpdateRequestModelValidator : AbstractValidator<CodeUpdateRequestModel>
        {
            public CodeUpdateRequestModelValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                    .WithMessage("{PropertyName} should be empty.")
                    .WithErrorCode("ERROR-1000");
                RuleFor(x => x.ParentId).NotNull().NotEqual(Guid.Empty)
                    .WithMessage("{PropertyName} should be empty.")
                    .WithErrorCode("ERROR-1000");
                RuleFor(x => x.Text).NotNull().NotEmpty()
                    .WithMessage("{PropertyName} should not be empty.")
                    .WithErrorCode("ERROR-1000");
                RuleFor(x => x.Ordinal).GreaterThan(0)
                    .WithMessage("{PropertyName} should be greater than 0.")
                    .WithErrorCode("ERROR-1000");
            }
        }

        public class CodeDeleteRequestModelValidator : AbstractValidator<CodeDeleteRequestModel>
        {
            public CodeDeleteRequestModelValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                    .WithMessage("{PropertyName} should be empty.")
                    .WithErrorCode("ERROR-1000");
            }
        }
    }
}
