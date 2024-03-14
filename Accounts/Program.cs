using System;

namespace Accounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var ordinaryAccount = new OrdinaryAccount { Balance = 1500 };
            Calculator.CalculateInterest(ordinaryAccount);
            Console.WriteLine($"Начисленные проценты для обычного аккаунта: {ordinaryAccount.Interest}");

            var salaryAccount = new SalaryAccount { Balance = 2500 };
            Calculator.CalculateInterest(salaryAccount);
            Console.WriteLine($"Начисленные проценты для зарплатного аккаунта: {salaryAccount.Interest}");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }

    public abstract class Account
    {
        public double Balance { get; set; }
        public double Interest { get; set; }
    }

    public interface IInterestCalculator
    {
        void CalculateInterest();
    }

    public static class Calculator
    {
        public static void CalculateInterest(IInterestCalculator interestCalculator)
        {
            interestCalculator.CalculateInterest();
        }
    }

    public class OrdinaryAccount : Account, IInterestCalculator
    {
        public void CalculateInterest()
        {
            if (Balance < 1000)
                Interest = Balance * 0.02;
            else
                Interest = Balance * 0.04;
        }
    }

    public class SalaryAccount : Account, IInterestCalculator
    {
        public void CalculateInterest()
        {
            Interest = Balance * 0.05;
        }
    }
}
