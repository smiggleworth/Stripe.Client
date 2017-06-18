using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PayoutCreateArguments
    {
        /// <summary>
        ///   A positive integer in cents representing how much to payout.
        /// </summary>
        [Required]
        public int  Amount { get; set; }

        /// <summary>
        /// Three-letter ISO currency code, in lowercase.Must be a supported currency.
        /// </summary>
          [Required]
        public string    Currency { get; set; }

        /// <summary>
        /// An arbitrary string attached to the object. Often useful for displaying to users.This will be unset if you POST an empty value.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   The ID of a bank account or a card to send the payout to.If no destination is supplied, the default external account for the specified currency will be used.
        /// </summary>
        public string     Destination { get; set; }

        /// <summary>
        ///  A set of key/value pairs that you can attach to a payout object. It can be useful for storing additional information about the payout in a structured format.
        /// </summary>
        public Dictionary<string,string> Metadata { get; set; }

        /// <summary>
        /// The method used to send this payout, which can be standard or instant.instant is only supported for payouts to debit cards. (See Instant payouts for marketplaces for more information.)
        /// </summary>
        public string     Method { get; set; }

        /// <summary>
        /// The source balance to draw this payout from.Balances for different payment sources are kept separately.You can find the amounts with the balances API.Valid options are: alipay_account, bank_account, and card.
        /// </summary>
        public string SourceType { get; set; }


        /// <summary>
        /// A string to be displayed on the recipient’s bank or card statement.This may be at most 22 characters.Attempting to use a statement_descriptor longer than 22 characters will return an error.Note: Most banks will truncate this information and/or display it inconsistently.Some may not display it at all.
        /// </summary>
        [StringLength(22)]
        public string StatementDescriptor { get; set; }
    }
}
