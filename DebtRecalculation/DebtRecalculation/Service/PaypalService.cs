using System;

namespace DebtRecalculation.Service
{
    class PaypalService : IOnlinePaymentService
    {
        public double PaymentFee(double amount)
        {
            return amount + amount * 0.02;
        }

        public double Interest(double amount, int months)
        {
            double val = amount + (amount * 0.01 * months);
            double interestAmount = PaymentFee(val);
            
            return interestAmount;
        }
    }
}
