using Autofac;
using Stripe.Client.Sdk.Clients;
using System.Net.Http;

namespace Stripe.Client.Autofac.Modules
{
    public class StripeClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var sdk = typeof(IStripeClient).Assembly;

            builder.RegisterType<HttpClient>().AsSelf().InstancePerDependency();

            builder.RegisterAssemblyTypes(sdk)
                .Where(t => t.Name.EndsWith("Client"))
                .AsImplementedInterfaces().InstancePerDependency();
        }
    }
}