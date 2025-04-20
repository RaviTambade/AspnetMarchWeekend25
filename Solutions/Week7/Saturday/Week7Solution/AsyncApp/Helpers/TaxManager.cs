using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncApp.Helpers
{


    // This delegate defines the signature for tax calculation methods.
    
    public delegate decimal TaxCalculationDelegate(decimal amount);



    // This class is responsible for managing tax calculations.
    //bussiness logic for tax calculation
    public class TaxManager
    {

        public static decimal CalculateIncomeTax(decimal income)
        {
            decimal taxRate = 0.2m; // Example tax rate

            return income * taxRate;
        }
        public static decimal CalculateSalesTax(decimal amount)
        {
            decimal salesTaxRate = 0.07m; // Example sales tax rate
            return amount * salesTaxRate;
        }
        public static decimal CalculatePropertyTax(decimal propertyValue)
        {
            decimal propertyTaxRate = 0.015m; // Example property tax rate
            return propertyValue * propertyTaxRate;
        }

        public static decimal CalculateCapitalGainsTax(decimal capitalGains)
        {
            decimal capitalGainsTaxRate = 0.15m; // Example capital gains tax rate
            return capitalGains * capitalGainsTaxRate;
        }
        public static decimal CalculateCorporateTax(decimal corporateIncome)
        {
            decimal corporateTaxRate = 0.25m; // Example corporate tax rate
            return corporateIncome * corporateTaxRate;
        }

        public static decimal CalculateWealthTax(decimal netWorth)
        {
            decimal wealthTaxRate = 0.01m; // Example wealth tax rate
            return netWorth * wealthTaxRate;
        }
    }
}
