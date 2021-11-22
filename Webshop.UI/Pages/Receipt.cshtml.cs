using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class ReceiptModel : PageModel
    {
        private readonly DA_Receipt _Receipt;
        private readonly DA_Order _Order;
        private readonly DA_Customer _Customer;

        public ReceiptModel(DA_Receipt da_Receipt, DA_Order da_Order, DA_Customer da_Customer)
        {
            CreditCard = new CreditCard();
            PaidOrder = new Order();
            Customer = new Customer();
            Receipt = new Receipt();
            _Receipt = da_Receipt;
            _Order = da_Order;
            _Customer = da_Customer;
        }
        public Order PaidOrder { get; set; }
        public Receipt Receipt { get; set; }
        public Customer Customer { get; set; }
        public CreditCard CreditCard { get; set; }  


        public void OnGet(Guid OrderId)
        {
            Receipt.DateTime = DateTimeOffset.Now;
            Receipt.Order = PaidOrder;
            Receipt.CreditCard.CustomerId = PaidOrder.CustomerId;

            if (OrderId.ToString() != null )
            {
                PaidOrder = (Order)_Order.GetById(OrderId);
            }

        }
    }
}
