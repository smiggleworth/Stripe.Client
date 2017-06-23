using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Stripe.Client.Sdk.Models
{
    public class EventData
    {
        private readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>
        {
            {"account", typeof(Account)},
            {"application_fee", typeof(ApplicationFee)},
            {"bank_account", typeof(BankAccount)},
            {"bitcoin_reciever", typeof(BitcoinReceiver)},
            {"card", typeof(Card)},
            {"charge", typeof(Charge)},
            {"coupon", typeof(Coupon)},
            {"customer", typeof(Customer)},
            {"discount", typeof(Discount)},
            {"dispute", typeof(Dispute)},
            {"fee_refund", typeof(ApplicationFeeRefund)},
            {"invoice", typeof(Invoice)},
            {"invoiceitem", typeof(InvoiceItem)},
            {"order", typeof(Order)},
            {"plan", typeof(Plan)},
            {"product", typeof(Product)},
            {"recipient", typeof(Recipient)},
            {"sku", typeof(Sku)},
            {"subscription", typeof(Subscription)},
            {"transfer", typeof(Transfer)}
        };

        private object _object;

        public object Object
        {
            get => _object;
            set => _object = Deserialize(value);
        }

        public dynamic PreviousAttributes { get; set; }

        private object Deserialize(object value)
        {
            var o = value as JObject;
            if (o == null)
            {
                return null;
            }

            var key = o["object"].ToString();
            if (string.IsNullOrWhiteSpace(key) || !_typeMap.ContainsKey(key))
            {
                return null;
            }

            var type = _typeMap[key];
            return o.ToObject(type);
        }
    }
}