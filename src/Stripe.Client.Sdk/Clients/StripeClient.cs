using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Configuration;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Extensions;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Resolvers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients
{
    public class StripeClient : IStripeClient
    {
        private static readonly Version StripeClientVersion = Assembly.GetExecutingAssembly().GetName().Version;

        private readonly string _apiEndpoint = "https://api.stripe.com";
        private readonly IStripeConfiguration _configuration;

        private readonly HttpClient _httpClient;
        private readonly string _stripeVersion = "2016-02-29";

        public List<string> Expandables { get; set; }

        public StripeClient(HttpClient httpClient, IStripeConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<StripeResponse<TResponse>> Get<TResponse>(StripeRequest<TResponse> stripeRequest,
            CancellationToken cancellationToken)
        {
            var uri = await GetUri(stripeRequest.UrlPath);
            var message = GetHttpRequestMessage(uri, HttpMethod.Get);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public async Task<StripeResponse<TResponse>> Get<TRequest, TResponse>(
            StripeRequest<TRequest, TResponse> stripeRequest, CancellationToken cancellationToken)
        {
            var uri = await GetUri(stripeRequest.UrlPath, stripeRequest.Model);
            var message = GetHttpRequestMessage(uri, HttpMethod.Get);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public async Task<StripeResponse<TResponse>> Post<TResponse>(
            StripeRequest<TResponse> stripeRequest, CancellationToken cancellationToken)
        {
            var uri = await GetUri(stripeRequest.UrlPath);
            var message = GetHttpRequestMessage(uri, HttpMethod.Post, null, stripeRequest.IdempotencyKey);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public async Task<StripeResponse<TResponse>> Post<TRequest, TResponse>(
            StripeRequest<TRequest, TResponse> stripeRequest, CancellationToken cancellationToken)
        {
            var uri = await GetUri(stripeRequest.UrlPath);
            var content = GetFormUrlEncodedContent(stripeRequest.Model);
            var message = GetHttpRequestMessage(uri, HttpMethod.Post, content, stripeRequest.IdempotencyKey);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public async Task<StripeResponse<TResponse>> Upload<TRequest, TResponse>(
            StripeRequest<TRequest, TResponse> stripeRequest, CancellationToken cancellationToken)
            where TRequest : IFileUpload
        {
            var uri = await GetUri(stripeRequest.UrlPath);
            var content = GetMultipartFormDataContent(stripeRequest.Model);
            var message = GetHttpRequestMessage(uri, HttpMethod.Post, content, stripeRequest.IdempotencyKey);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public async Task<StripeResponse<TResponse>> Delete<TResponse>(
            StripeRequest<TResponse> stripeRequest, CancellationToken cancellationToken)
        {
            var uri = await GetUri(stripeRequest.UrlPath);
            var message = GetHttpRequestMessage(uri, HttpMethod.Delete);
            var response = await GetStripeResponse<TResponse>(message, cancellationToken);
            return response;
        }

        public void Dispose()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
            }
        }

        internal async Task<StripeResponse<T>> GetStripeResponse<T>(HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(_configuration.SecretKey));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            _httpClient.DefaultRequestHeaders.Add("Stripe-Version", _stripeVersion);
            using (var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken))
            {
                var content = await response.Content.ReadAsStringAsync();
                var stripeResponse = new StripeResponse<T>();
                if (response.IsSuccessStatusCode)
                {
                    stripeResponse.Model = Deserialize<T>(content);
                }
                else
                {
                    var errorEnvelope = Deserialize<StripeErrorEnvelope>(content);
                    stripeResponse.Error = errorEnvelope.Error;
                }
                return stripeResponse;
            }
        }

        internal HttpRequestMessage GetHttpRequestMessage(Uri uri, HttpMethod method, HttpContent content = null,
            Guid? idempotencyKey = null)
        {
            var request = new HttpRequestMessage(method, uri);

            if (content != null)
            {
                request.Content = content;
            }

            if (!string.IsNullOrWhiteSpace(_configuration.AccountId))
            {
                request.Headers.Add("Stripe-Account", _configuration.AccountId);
            }

            if (idempotencyKey.HasValue)
            {
                request.Headers.Add("Idempotency-Key", idempotencyKey.Value.ToString());
            }

            var version = StripeClientVersion.ToString();
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Stripe-Client", version));
            request.Headers.Add("Stripe-Version", _stripeVersion);

            return request;
        }

        internal FormUrlEncodedContent GetFormUrlEncodedContent<T>(T model)
        {
            var keyValuePairs = GetAllKeyValuePairs(model).ToList();
            if (!keyValuePairs.Any())
            {
                return null;
            }
            var content = new FormUrlEncodedContent(keyValuePairs);
            return content;
        }

        internal MultipartFormDataContent GetMultipartFormDataContent<T>(T model) where T : IFileUpload
        {
            throw new NotImplementedException();
            //            var content = new MultipartFormDataContent();
            //            var byteConent = new ByteArrayContent(model.Content);
            //            content.Add(byteConent);
        }

        internal async Task<Uri> GetUri(string urlPath)
        {
            return await GetUri<object>(urlPath, null);
        }

        internal async Task<Uri> GetUri<T>(string urlPath, T model)
        {
            var uriBuilder = new UriBuilder(_apiEndpoint)
            {
                Path = "v1/" + urlPath
            };
            if (model == null && !Expandables.Any())
            {
                return uriBuilder.Uri;
            }
            var content = GetFormUrlEncodedContent(model);
            if (content == null)
            {
                return uriBuilder.Uri;
            }
            uriBuilder.Query = await content.ReadAsStringAsync();
            return uriBuilder.Uri;
        }

        internal IEnumerable<KeyValuePair<string, string>> GetAllKeyValuePairs<T>(T model)
        {
            return model == null ? GetExpandableKeyValue() : GetModelKeyValuePairs(model).Union(GetExpandableKeyValue());
        }

        internal IEnumerable<KeyValuePair<string, string>> GetExpandableKeyValue()
        {
            if (Expandables != null && Expandables.Any())
            {
                foreach (var item in Expandables)
                {
                    yield return new KeyValuePair<string, string>("expand[]", item);
                }
            }
        }

        internal static IEnumerable<KeyValuePair<string, string>> GetModelKeyValuePairs<T>(T model, string parent = null)
        {
            // At this point data should be validated by the calling business layer
            // If validation fails just let it blow up
            Validator.ValidateObject(model, new ValidationContext(model), true);

            var hasParent = !string.IsNullOrWhiteSpace(parent);

            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                var attributes = propertyInfo.GetCustomAttributes().ToList();
                if (attributes.OfType<JsonIgnoreAttribute>().Any())
                {
                    continue;
                }

                var propertyValue = propertyInfo.GetValue(model);
                if (propertyValue == null)
                {
                    continue;
                }

                var propertyName = propertyInfo.Name.ToSnakeCase();
                var key = hasParent ? parent + "[" + propertyName + "]" : propertyName;

                if (attributes.OfType<ChildModelAttribute>().Any())
                {
                    if (IsValidChildModel(propertyValue))
                    {
                        var enumerable = propertyValue as IEnumerable;
                        if (enumerable != null)
                        {
                            var i = 0;
                            foreach (var item in enumerable)
                            {
                                var keyi = key + "[" + i + "]";
                                foreach (var child in GetModelKeyValuePairs(item, keyi))
                                {
                                    yield return child;
                                }
                                i++;
                            }
                            continue;
                        }
                        foreach (var child in GetModelKeyValuePairs(propertyValue, key))
                        {
                            yield return child;
                        }
                        continue;
                    }
                }

                var dictionary = propertyValue as Dictionary<string, string>;
                if (dictionary != null)
                {
                    foreach (var pair in dictionary)
                    {
                        var metadataKey = key + "[" + pair.Key + "]";
                        yield return new KeyValuePair<string, string>(metadataKey, pair.Value);
                    }
                    continue;
                }

                var value = GetValue(propertyValue, attributes);
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                yield return new KeyValuePair<string, string>(key, value);
            }
        }

        internal static string GetValue(object propertyValue, List<Attribute> attributes)
        {
            if (attributes.OfType<JsonConverterAttribute>().Any())
            {
                var converterType = attributes.OfType<JsonConverterAttribute>().Select(x => x.ConverterType).Single();
                if (converterType == typeof(EpochConverter))
                {
                    var dateTime = propertyValue as DateTime?;
                    return dateTime?.ToEpoch().ToString() ?? string.Empty;
                }
            }
            return propertyValue.ToString();
        }

        internal static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver()
            });
        }

        private static bool IsValidChildModel(object obj)
        {
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.DBNull:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Empty:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.String:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return false;
                default:
                    return true;
            }
        }
    }
}
