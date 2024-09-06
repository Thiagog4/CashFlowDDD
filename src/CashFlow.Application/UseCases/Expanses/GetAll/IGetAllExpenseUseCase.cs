using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expanses.GetAll;

public interface IGetAllExpenseUseCase
{
    Task<ResponseExpensesJson> Execute();
}