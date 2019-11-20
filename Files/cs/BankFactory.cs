using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates
{
    public static class BankFactory
    {
        #region Enum
        public enum SupportedBanks { 
            BOC = 0,
            CBR = 1,
            NBU = 2,
            ECB = 3
        }
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
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Events
        #endregion

        #region Methods
        public static IBank GetBank(SupportedBanks supportedBanks) {

            switch (supportedBanks) {
                case SupportedBanks.BOC:
                    return new BankOfCanada();

                case SupportedBanks.CBR:
                    return new CentralBankOfRussia();

                case SupportedBanks.NBU:
                    return new NationalBankOfUkraine();

                case SupportedBanks.ECB:
                    return new EuropeanCentralBank();
                default: return null;
            }
        }

        #endregion
    }
}
