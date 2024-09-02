using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        // var faker = new Faker();
        
        // return new RequestRegisterExpenseJson
        // {
        //     Amount = faker.Finance.Amount(),
        //     Date = faker.Date.Past(),
        //     Description = faker.Lorem.Sentence(),
        //     Title = faker.Lorem.Sentence(),
        //     PaymentType = faker.PickRandom<PaymentType>()
        // };
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(expense => expense.Title, faker => faker.Lorem.Sentence())
            .RuleFor(expense => expense.Description, faker => faker.Lorem.Sentence())
            .RuleFor(expense => expense.Date, faker => faker.Date.Past())
            .RuleFor(expense => expense.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(expense => expense.Amount, faker => faker.Finance.Amount());
    }
}