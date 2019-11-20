using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Terrasoft.Core;
using Terrasoft.Web.Common;

namespace ExchangeRates
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ExchangeRate_WS: BaseService
	{
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ExecutePost(string script) {
			return UserConnection.CurrentUser.Name;
		}

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public BankResult ExecuteGet(int bankId, string date, string currency) {
            //http://k_krylov_nb:8060/0/rest/ExchangeRate_WS/ExecuteGet?bankId=0&date=2019-11-20&currency="RUB"

            DateTime.TryParse(date, out DateTime dt);
            IBank bank = BankFactory.GetBank((BankFactory.SupportedBanks)bankId);

            IBankResult bankResult = Task.Run(() => bank.GetRateAsync(currency.ToUpper(), dt)).Result;
            BankResult result = new BankResult
            {
                ExchangeRate = bankResult.ExchangeRate,
                RateDate = bankResult.RateDate,
                HomeCurrency = bankResult.HomeCurrency,
                BankName = bankResult.BankName
            };
            return result;
            //return bankResult;
		}
	}
}