using System;
using System.Collections.Generic;
using System.Linq;

using AsyncApp.Helpers;
//direct call
//Blocking call
/*
//Invoking actual methods (functions)
decimal  incomeTax=TaxManager.CalculateIncomeTax(150000);
decimal salesTax = TaxManager.CalculateSalesTax(1000);
decimal propertyTax = TaxManager.CalculatePropertyTax(300000);
*/

//indrect call
//Callback mechanism
//wrapper for function pointer in C# is Delegate
//delegate
//Object Oriented typesafe function pointer

//Create instance of delegate
//register the method with the delegate
//attaching actions(methods) to the delegate
TaxCalculationDelegate incomeTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculateIncomeTax);
TaxCalculationDelegate salesTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculateSalesTax);
TaxCalculationDelegate propertyTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculatePropertyTax);
TaxCalculationDelegate capitalGainsTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculateCapitalGainsTax);
TaxCalculationDelegate corporateTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculateCorporateTax);
TaxCalculationDelegate wealthTaxCalculation = new TaxCalculationDelegate(TaxManager.CalculateWealthTax);

//Invoke the delegate
decimal amount = 500000;

//Invoke the delegate
//Dynamicall invoking method indirectly

TaxCalculationDelegate  proxyTaxCalculator = incomeTaxCalculation;
//Multicast Delegate
//Attach  additional delegates to proxyTaxCalculator
//attaching other methods to the delegate using multicat mechanism

proxyTaxCalculator += salesTaxCalculation;
proxyTaxCalculator += propertyTaxCalculation;
proxyTaxCalculator += capitalGainsTaxCalculation;
proxyTaxCalculator += corporateTaxCalculation;
proxyTaxCalculator += wealthTaxCalculation;

//establishing chain of delegates
//Invoke the delegate
//proxyTaxCalculator(amount);    //only one delegate will be invoked
//proxyTaxCalculator.Invoke(amount); //only one delegate will be invoked

//Invoke all delegates
//initiate  a chain reaction by invoking the proxy delegate
////Nuclear fusion
//Taxation Fusion
//proxyTaxCalculator.DynamicInvoke(amount); //all delegates will be invoked
//Asynchronous invocation
/*IAsyncResult asyncResult =proxyTaxCalculator.BeginInvoke(amount, null, null); //all delegates will be invoked

//wait for the result
asyncResult.AsyncWaitHandle.WaitOne(); //all delegates will be invoked

//get the result
decimal result = proxyTaxCalculator.EndInvoke(asyncResult); //all delegates will be invoked
Console.WriteLine($"Total Tax: {result}"); //all delegates will be invoked

*/

