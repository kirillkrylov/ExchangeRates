using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates
{
    public interface IBankResult
    {
        string HomeCurrency { get; set; }
        decimal ExchangeRate { get; set; }
        DateTime RateDate { get; set; }
        string BankName { get; set; }
    }
    public sealed class BankResult : IBankResult
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
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        public string HomeCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime RateDate { get; set; }
        public string BankName { get; set; }
        #endregion

        #region Events
        #endregion

        #region Methods
        #endregion
    }
}
