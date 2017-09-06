namespace Stripe.Client.Sdk.Models
{
    public class CodeVerification
    {
        /// <summary>
        ///     The number of attempts remaining to authenticate the source object with a verification code.
        /// </summary>
        public int AttemptsRemaining { get; set; }


        /// <summary>
        ///     The status of the code verification, either pending, succeeded or failed.
        /// </summary>
        public string Status { get; set; }
    }
}