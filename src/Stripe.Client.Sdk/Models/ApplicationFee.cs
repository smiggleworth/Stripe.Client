using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class ApplicationFee : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public bool LiveMode { get; set; }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public Account AccountModel { get; set; }

        public object Account
        {
            set { Expandable<Account>.Deserialize(value, s => AccountId = s, o => AccountModel = o); }
        }

        public int Amount { get; set; }

        public string Application { get; set; }

        [JsonIgnore]
        public string BalanceTransactionId { get; set; }

        [JsonIgnore]
        public BalanceTransaction BalanceTransactionModel { get; set; }

        public object BalanceTransaction
        {
            set
            {
                Expandable<BalanceTransaction>.Deserialize(value, s => BalanceTransactionId = s,
                    o => BalanceTransactionModel = o);
            }
        }

        [JsonIgnore]
        public string CardId { get; set; }

        [JsonIgnore]
        public Card CardModel { get; set; }

        public object Card
        {
            set { Expandable<Card>.Deserialize(value, s => CardId = s, o => CardModel = o); }
        }

        [JsonIgnore]
        public string ChargeId { get; set; }

        [JsonIgnore]
        public Charge ChargeModel { get; set; }

        public object Charge
        {
            set { Expandable<Charge>.Deserialize(value, s => ChargeId = s, o => ChargeModel = o); }
        }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public bool Refunded { get; set; }

        public Pagination<ApplicationFeeRefund> Refunds { get; set; }

        public int AmountRefunded { get; set; }
    }
}