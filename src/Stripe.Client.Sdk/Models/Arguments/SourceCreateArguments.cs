using System.Collections.Generic;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SourceCreateArguments
    {
        /// <summary>
        ///     The type of the source to create.Required unless customer and orginal_source are specified (see the Shared card
        ///     Sources guide)
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        ///     Amount associated with the source.This is the amount for which the source will be chargeable once ready.Required
        ///     for single_use sources.
        /// </summary>
        public int Amount { get; set; }


        /// <summary>
        ///     Three-letter ISO code for the currency associated with the source. This is the currency for which the source will
        ///     be chargeable once ready.
        /// </summary>
        public string Currency { get; set; }


        /// <summary>
        ///     The authentication flow of the source to create. flow is one of redirect, receiver, code_verification, none.It is
        ///     generally inferred unless a type supports multiple flows.
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        ///     A set of key/value pairs that you can attach to a source object. It can be useful for storing additional
        ///     information about the source in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Information about the owner of the payment instrument that may be used or required by particular source types.
        /// </summary>
        [ChildModel]
        public OwnerArguments Owner { get; set; }

        /// <summary>
        ///     Parameters required for the redirect flow.Required if the source is authenticated by a redirect(flow is redirect).
        /// </summary>
        public Redirect Redirect { get; set; }

        /// <summary>
        ///     An arbitrary string to be displayed on your customer’s statement.As an example, if your website is RunClub and the
        ///     item you’re charging for is a race ticket, you may want to specify a statement_descriptor of RunClub 5K race
        ///     ticket.While many payment types will display this information, some may not display it at all.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        ///     An optional token used to create the source.When passed, token properties will override source parameters.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Either reusable or single_use.Whether this source should be reusable or not. Some source types may or may not be
        ///     reusable by construction, while other may leave the option at creation.If an incompatible value is passed, an error
        ///     will be returned.
        /// </summary>
        public string Usage { get; set; }
    }
}