using System.Net.Http;
using Autofac;
using Stripe.Client.Sdk.Clients;

namespace Stripe.Client.Autofac.Modules
{
    public class StripeClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var sdk = typeof(IStripeClient).Assembly;

            builder.RegisterType<HttpClient>().AsSelf();

            builder.RegisterAssemblyTypes(sdk)
                .Where(t => t.Name.EndsWith("Client"))
                .AsImplementedInterfaces();
        }
    }
}