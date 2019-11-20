# Exchange Rates  [![Logo](https://www.creatio.com/sites/default/files/2019-10/creatio-main-logo.svg)](https://github.com/sindresorhus/awesome#readme)

This project adds necessary classes to obtain curent and historic Exchange Rates from 
- European Central Bank
- Bank of Canada
- Central Bank of the Russian Federation
- National Bank of Ukraine

## Usage
- Get Rates from Bank of Canada
  http://k_krylov_nb:8060/0/rest/ExchangeRate_WS/ExecuteGet?bankId=0&date=2019-11-20&currency=USD
```C#
public BankResult ExecuteGet(int bankId, string date, string currency) {
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
}
```


## Tools
- [Clio](https://github.com/Advance-Technologies-Foundation/clio) - CLI Library to create packages.
- [Bpmonline.SDK](https://www.nuget.org/packages/BpmonlineSDK/) - Provides project template for development code for bpm'online platform.

## Documentation
- [Creatio](https://academy.creatio.com/documents/technic-sdk/7-15/creatio-development-guide) - Creatio Development Guide
- [ECB](https://sdw-wsrest.ecb.europa.eu/help/) - European Central Bank API Documention
- [BOC](https://www.bankofcanada.ca/valet/docs) - Bank of Canada Valet API Documentation
- [CBR](https://www.cbr.ru/development/DWS/) Central Bank of the Russian Federation API Documentation
- [NBU](https://old.bank.gov.ua/control/en/publish/article?art_id=82367624&cat_id=25365629) - National Bank of Ukraine API Documentation