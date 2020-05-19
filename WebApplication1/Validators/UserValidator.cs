using FluentValidation;
using SOLID;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.Forename)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage($"Special characters and alphaneumeric characters not allowed apart from  a-zA-Z0-9");
            //RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            RuleFor(x => x.Address).ListAddfailureExample(10);
            //RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
            RuleFor(x => x.Subscription).ListMustContainFewerThan(2);

        }
    }

    public static class MyCustomValidators
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {

            return ruleBuilder.Must((rootObject, list, context) => {
                context.MessageFormatter.AppendArgument("MaxElements", num);
                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
        } //used to add custom numbers to message 

        public static IRuleBuilderInitial<T, TElement> ListAddfailureExample<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, int num)
        {

            return ruleBuilder.Custom((list, context) => {
             context.AddFailure("The address cannot be null");
             context.AddFailure("The second validation for same property");
            });
        }
    }
}
