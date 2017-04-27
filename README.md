# Stripe.Client

Do you want a .NET Stripe API that is all async?

## Basics

This library attempts to follow the Stripe documentation, so check that out. Each Stripe resource is mapped to a client to wrap the interaction. For example the charge on Stripe would be mapped to ChargeClient. The clients all have easy-to-use async Tasks to make calls to Stripe. Arguments are in simple models, but again check out the Stripe docs to understand whats-what. 

Some properties are nicely handled for you. For example dates are serialized/deserialized to/from epoch. However I left amounts alone, you will need to convert you $1.50 to 150 and back again. 

## Example

    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Client.Sdk.Clients.Core;
    using Stripe.Client.Sdk.Models.Arguments;
    
    namespace YourApp
    {
        public class YourLogic
        {
            private static readonly ILog _log = GetSomeLogger();
    
            private readonly IChargeClient _chargeClient;
    
            public YourLogic(IChargeClient chargeClient)
            {
                _chargeClient = chargeClient;
            }
    
            public async Task YourMethod(string cardToken, decimal amount, CancellationToken cancellationToken)
            {
                // map your args to the arguments for the client
                var args = new ChargeCreateArguments
                {
                    Amount = (int)(amount * 100), // move the decimal
                    CardToken = cardToken
                };
    
                // await the method, pass the cancellation token for good form
                var result = await _chargeClient.CreateCharge(args, cancellationToken);
                if (result.Success)
                {
                    // use the result.Model to access the stripe object
                    var charge = result.Model;
                    _log.Info("Charge Success " + charge.Id);
                }
                else
                {
                    // handle failure
                    _log.Warn(result.Error.Message);
                }
            }
        }
    }

## Credits

- Several strategies and classes courtesy of [stripe.net](https://github.com/jaymedavis/stripe.net)
