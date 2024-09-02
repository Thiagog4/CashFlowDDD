using CashFlow.Application.UseCases.Expanses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace TestProject1.Expanses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        
        
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }
    
    
    [Fact]
    public void Error_Title_Empty()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(f => f.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
    }
    
    [Fact]
    public void Error_Date_Future()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.Now.AddDays(1);
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(f => f.ErrorMessage == ResourceErrorMessages.FUTURE_DATE);
    }
    
    [Fact]
    public void Error_Amount_LessThanZero()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = -1;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(f => f.ErrorMessage == ResourceErrorMessages.AMOUNT_GREATER_ZERO);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amount_LessThanZero_Theory(decimal amount)
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(f => f.ErrorMessage == ResourceErrorMessages.AMOUNT_GREATER_ZERO);
    }
    
    [Fact]
    public void Error_PaymentType_Invalid()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType) 100;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(f => f.ErrorMessage == ResourceErrorMessages.INVALID_PAYAMENT_TYPE);
    }
    
    [Fact]
    public void Error_All()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        request.Date = DateTime.Now.AddDays(1);
        request.Amount = -1;
        request.PaymentType = (PaymentType) 100;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(4);
    }
    
}