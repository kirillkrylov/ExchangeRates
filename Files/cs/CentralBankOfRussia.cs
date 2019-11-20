using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using CbrDailyInfo;
namespace ExchangeRates
{
    public sealed class CentralBankOfRussia : IBank
    {
        #region Enum
        #endregion

        #region Delegates
        #endregion

        #region Interface
        #endregion

        #region Struct
        #endregion

        #region Class
        #endregion

        #region Constants
        private const string homeCurrency = "RUB";
        private const string bankName = "Central bank of the Russian Federation";
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        public string HomeCurrency => homeCurrency;

        public DateTime RateDate { get; private set;}
        #endregion

        #region Events
        #endregion

        #region Methods
        public Task<IBankResult> GetRateAsync(string currency, DateTime date)
        {
            IBankResult bankResult = new BankResult()
            {
                ExchangeRate = -1m,
                RateDate = date,
                HomeCurrency = homeCurrency,
                BankName = bankName
            };


            DailyInfoSoap client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
            Task<ArrayOfXElement> fxRates = client.GetCursOnDateAsync(date);
            
            List<XElement> Results = fxRates.Result.Nodes;
            foreach (XElement result in Results)
            {
                if (result.Name.LocalName == "diffgram")
                {
                    XElement ValuteData = result.Element("ValuteData");
                    IEnumerable<XElement> ValueOnDate = ValuteData.Elements();
                    foreach (XElement ValuteCursOnDate in ValueOnDate)
                    {
                        IEnumerable<XElement> Properties = ValuteCursOnDate.Elements();

                        string Currency = ValuteCursOnDate.Element("VchCode").Value;

                        decimal FxRate = decimal.Zero;
                        decimal.TryParse(ValuteCursOnDate.Element("Vcurs").Value, out FxRate);

                        decimal multiplier = decimal.Zero;
                        decimal.TryParse(ValuteCursOnDate.Element("Vnom").Value, out multiplier);

                        if (Currency == currency)
                        {
                            FxRate /= multiplier;
                            bankResult.ExchangeRate = FxRate;                            
                            return Task.FromResult(bankResult);
                        }
                    }
                }
            }
            return Task.FromResult(bankResult);
        }
        #endregion
    }
}
