using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();

        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterExpenseJson, Expense>();
        }

        private void EntityToResponse()
        {
            CreateMap<Expense, ResponseRegisteredExpenseJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
        }
    }
}
