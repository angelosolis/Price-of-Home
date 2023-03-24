using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceOfHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double homePrice = InputValues("Enter the price of the home: ");
            double interestRate = InputValues("Enter the current interest rate (as a whole number): ") / 100;
            double downPaymentPercentage = InputValues("Enter the percentage of the total price made as down payment (as a whole number): ") / 100;

            double downPayment = DownPayment(homePrice, downPaymentPercentage);
            double financedAmount = FinancedAmount(homePrice, downPayment);
            double monthlyPayment = MonthlyPayment(financedAmount, interestRate);
            double totalInterest = TotalInterest(monthlyPayment, financedAmount);

            Display(downPayment, financedAmount, monthlyPayment, totalInterest);
        }

        static double InputValues(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        static double DownPayment(double homePrice, double downPaymentPercentage)
        {
            return homePrice * downPaymentPercentage;
        }

        static double FinancedAmount(double homePrice, double downPayment)
        {
            return homePrice - downPayment;
        }

        static double MonthlyPayment(double financedAmount, double interestRate)
        {
            int months = 30 * 12;
            double rate = interestRate / 12;
            return financedAmount * (rate / (1 - Math.Pow(1 + rate, -months)));
        }

        static double TotalInterest(double monthlyPayment, double financedAmount)
        {
            int months = 30 * 12;
            return (monthlyPayment * months) - financedAmount;
        }

        static void Display(double downPayment, double financedAmount, double monthlyPayment, double totalInterest)
        {
            Console.WriteLine($"Down Payment: {downPayment:C}");
            Console.WriteLine($"Financed Amount: {financedAmount:C}");
            Console.WriteLine($"Monthly Payment: {monthlyPayment:C}");
            Console.WriteLine($"Total Interest Paid Over Thirty Years: {totalInterest:C}");
        }
    }
}
