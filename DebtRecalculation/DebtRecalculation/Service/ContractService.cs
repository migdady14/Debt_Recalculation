using DebtRecalculation.Entites;
using System;

namespace DebtRecalculation.Service
{
    class ContractService
    {
        public IOnlinePaymentService paymentService;

        public ContractService(IOnlinePaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            for (int i = 0; i < months; i++)
            {
                int month = i + 1;
                double val = contract.TotalValue / months;
                Installment inst = new Installment(contract.Date.AddMonths(month), paymentService.Interest(val, month));
                contract.Installments.Add(inst);
            }
            foreach (Installment i in contract.Installments)
            {
                System.Console.WriteLine($@"{i.DueDate.ToString("dd/MM/yyyy")} - {i.Amount.ToString("F2")}");
            }
        }
    }
}
