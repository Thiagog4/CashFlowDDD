using CashFlow.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expanses.GetById
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    }
}
