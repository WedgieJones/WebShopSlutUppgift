using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class ReceiptModel : PageModel
    {
        //This class creates the receipt. Giving the order a datetime-stamp and attaching a card + changing isPaid to true.
        private readonly DA_Receipt _Receipt;
        private readonly DA_Order _Order;
        private readonly DA_Customer _Customer;
        private readonly DA_CreditCard _CreditCard;

        public ReceiptModel(DA_Receipt da_Receipt, DA_Order da_Order, DA_Customer da_Customer, DA_CreditCard da_CreditCard)
        {
            _Receipt = da_Receipt;
            _Order = da_Order;
            _Customer = da_Customer;
            _CreditCard = da_CreditCard;
        }
        public Order PaidOrder { get; set; }
        public Receipt Receipt { get; set; } = new Receipt();
        public Customer Customer { get; set; } = new Customer();
		public decimal TotalSum { get; set; }


		public void OnGet(Guid OrderId)
        {
            //First a check to see if the Guid is empty. If not it gets info on the Order.
            if (OrderId != Guid.Empty)
            {
                PaidOrder = _Order.LoadById(OrderId);
            }
            //Creating the receipt.
            var customer = _Customer.LoadById(PaidOrder.CustomerId.Value);
            Customer = customer;
            var custCreditCard = _CreditCard.LoadById(customer.CustomerId);

            Receipt.DateTime = DateTimeOffset.Now;
            Receipt.Order = PaidOrder;
            Receipt.CreditCard = custCreditCard;
            Receipt.ReceiptId = Guid.NewGuid();
            PaidOrder.IsPaid = true;

            TotalSum = PaidOrder.Products.Sum(p => p.CurrentPrice);

            //When the payment is made the isPaid on the Order i changed to true.
            _Order.UpdateOrder(OrderId, PaidOrder.IsPaid);

            //The receipt is loaded to the file.
            _Receipt.Save(Receipt);
        }
    }
}
