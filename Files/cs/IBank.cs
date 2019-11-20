using System;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public interface IBank
    {
        Task<IBankResult> GetRateAsync(string currency, DateTime date);
    }
}