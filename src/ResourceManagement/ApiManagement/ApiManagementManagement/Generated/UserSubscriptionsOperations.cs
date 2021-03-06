// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.ApiManagement
{
    /// <summary>
    /// Operations for managing User Subscriptions.
    /// </summary>
    internal partial class UserSubscriptionsOperations : IServiceOperations<ApiManagementClient>, IUserSubscriptionsOperations
    {
        /// <summary>
        /// Initializes a new instance of the UserSubscriptionsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal UserSubscriptionsOperations(ApiManagementClient client)
        {
            this._client = client;
        }
        
        private ApiManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.ApiManagement.ApiManagementClient.
        /// </summary>
        public ApiManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// List all user subscriptions of the Api Management service instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='serviceName'>
        /// Required. The name of the Api Management service.
        /// </param>
        /// <param name='uid'>
        /// Required. User identifier.
        /// </param>
        /// <param name='query'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List Subscriptions operation response details.
        /// </returns>
        public async Task<SubscriptionListResponse> ListAsync(string resourceGroupName, string serviceName, string uid, QueryParameters query, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (serviceName == null)
            {
                throw new ArgumentNullException("serviceName");
            }
            if (uid == null)
            {
                throw new ArgumentNullException("uid");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("serviceName", serviceName);
                tracingParameters.Add("uid", uid);
                tracingParameters.Add("query", query);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + "Microsoft.ApiManagement";
            url = url + "/service/";
            url = url + Uri.EscapeDataString(serviceName);
            url = url + "/users/";
            url = url + Uri.EscapeDataString(uid);
            url = url + "/subscriptions";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-02-14");
            List<string> odataFilter = new List<string>();
            if (query != null && query.Filter != null)
            {
                odataFilter.Add(Uri.EscapeDataString(query.Filter));
            }
            if (odataFilter.Count > 0)
            {
                queryParameters.Add("$filter=" + string.Join(null, odataFilter));
            }
            if (query != null && query.Top != null)
            {
                queryParameters.Add("$top=" + Uri.EscapeDataString(query.Top.Value.ToString()));
            }
            if (query != null && query.Skip != null)
            {
                queryParameters.Add("$skip=" + Uri.EscapeDataString(query.Skip.Value.ToString()));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    SubscriptionListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new SubscriptionListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            SubscriptionPaged resultInstance = new SubscriptionPaged();
                            result.Result = resultInstance;
                            
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    SubscriptionContract subscriptionContractInstance = new SubscriptionContract();
                                    resultInstance.Values.Add(subscriptionContractInstance);
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        subscriptionContractInstance.IdPath = idInstance;
                                    }
                                    
                                    JToken userIdValue = valueValue["userId"];
                                    if (userIdValue != null && userIdValue.Type != JTokenType.Null)
                                    {
                                        string userIdInstance = ((string)userIdValue);
                                        subscriptionContractInstance.UserIdPath = userIdInstance;
                                    }
                                    
                                    JToken productIdValue = valueValue["productId"];
                                    if (productIdValue != null && productIdValue.Type != JTokenType.Null)
                                    {
                                        string productIdInstance = ((string)productIdValue);
                                        subscriptionContractInstance.ProductIdPath = productIdInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        subscriptionContractInstance.Name = nameInstance;
                                    }
                                    
                                    JToken stateValue = valueValue["state"];
                                    if (stateValue != null && stateValue.Type != JTokenType.Null)
                                    {
                                        SubscriptionStateContract stateInstance = ((SubscriptionStateContract)Enum.Parse(typeof(SubscriptionStateContract), ((string)stateValue), true));
                                        subscriptionContractInstance.State = stateInstance;
                                    }
                                    
                                    JToken createdDateValue = valueValue["createdDate"];
                                    if (createdDateValue != null && createdDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime createdDateInstance = ((DateTime)createdDateValue);
                                        subscriptionContractInstance.CreatedDate = createdDateInstance;
                                    }
                                    
                                    JToken startDateValue = valueValue["startDate"];
                                    if (startDateValue != null && startDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime startDateInstance = ((DateTime)startDateValue);
                                        subscriptionContractInstance.StartDate = startDateInstance;
                                    }
                                    
                                    JToken expirationDateValue = valueValue["expirationDate"];
                                    if (expirationDateValue != null && expirationDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime expirationDateInstance = ((DateTime)expirationDateValue);
                                        subscriptionContractInstance.ExpirationDate = expirationDateInstance;
                                    }
                                    
                                    JToken endDateValue = valueValue["endDate"];
                                    if (endDateValue != null && endDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime endDateInstance = ((DateTime)endDateValue);
                                        subscriptionContractInstance.EndDate = endDateInstance;
                                    }
                                    
                                    JToken notificationDateValue = valueValue["notificationDate"];
                                    if (notificationDateValue != null && notificationDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime notificationDateInstance = ((DateTime)notificationDateValue);
                                        subscriptionContractInstance.NotificationDate = notificationDateInstance;
                                    }
                                    
                                    JToken primaryKeyValue = valueValue["primaryKey"];
                                    if (primaryKeyValue != null && primaryKeyValue.Type != JTokenType.Null)
                                    {
                                        string primaryKeyInstance = ((string)primaryKeyValue);
                                        subscriptionContractInstance.PrimaryKey = primaryKeyInstance;
                                    }
                                    
                                    JToken secondaryKeyValue = valueValue["secondaryKey"];
                                    if (secondaryKeyValue != null && secondaryKeyValue.Type != JTokenType.Null)
                                    {
                                        string secondaryKeyInstance = ((string)secondaryKeyValue);
                                        subscriptionContractInstance.SecondaryKey = secondaryKeyInstance;
                                    }
                                    
                                    JToken stateCommentValue = valueValue["stateComment"];
                                    if (stateCommentValue != null && stateCommentValue.Type != JTokenType.Null)
                                    {
                                        string stateCommentInstance = ((string)stateCommentValue);
                                        subscriptionContractInstance.StateComment = stateCommentInstance;
                                    }
                                }
                            }
                            
                            JToken countValue = responseDoc["count"];
                            if (countValue != null && countValue.Type != JTokenType.Null)
                            {
                                long countInstance = ((long)countValue);
                                resultInstance.TotalCount = countInstance;
                            }
                            
                            JToken nextLinkValue = responseDoc["nextLink"];
                            if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                            {
                                string nextLinkInstance = ((string)nextLinkValue);
                                resultInstance.NextLink = nextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// List all user subscriptions of the Api Management service instance.
        /// </summary>
        /// <param name='nextLink'>
        /// Required. NextLink from the previous successful call to List
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List Subscriptions operation response details.
        /// </returns>
        public async Task<SubscriptionListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            if (nextLink == null)
            {
                throw new ArgumentNullException("nextLink");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("nextLink", nextLink);
                TracingAdapter.Enter(invocationId, this, "ListNextAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + nextLink;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    SubscriptionListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new SubscriptionListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            SubscriptionPaged resultInstance = new SubscriptionPaged();
                            result.Result = resultInstance;
                            
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    SubscriptionContract subscriptionContractInstance = new SubscriptionContract();
                                    resultInstance.Values.Add(subscriptionContractInstance);
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        subscriptionContractInstance.IdPath = idInstance;
                                    }
                                    
                                    JToken userIdValue = valueValue["userId"];
                                    if (userIdValue != null && userIdValue.Type != JTokenType.Null)
                                    {
                                        string userIdInstance = ((string)userIdValue);
                                        subscriptionContractInstance.UserIdPath = userIdInstance;
                                    }
                                    
                                    JToken productIdValue = valueValue["productId"];
                                    if (productIdValue != null && productIdValue.Type != JTokenType.Null)
                                    {
                                        string productIdInstance = ((string)productIdValue);
                                        subscriptionContractInstance.ProductIdPath = productIdInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        subscriptionContractInstance.Name = nameInstance;
                                    }
                                    
                                    JToken stateValue = valueValue["state"];
                                    if (stateValue != null && stateValue.Type != JTokenType.Null)
                                    {
                                        SubscriptionStateContract stateInstance = ((SubscriptionStateContract)Enum.Parse(typeof(SubscriptionStateContract), ((string)stateValue), true));
                                        subscriptionContractInstance.State = stateInstance;
                                    }
                                    
                                    JToken createdDateValue = valueValue["createdDate"];
                                    if (createdDateValue != null && createdDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime createdDateInstance = ((DateTime)createdDateValue);
                                        subscriptionContractInstance.CreatedDate = createdDateInstance;
                                    }
                                    
                                    JToken startDateValue = valueValue["startDate"];
                                    if (startDateValue != null && startDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime startDateInstance = ((DateTime)startDateValue);
                                        subscriptionContractInstance.StartDate = startDateInstance;
                                    }
                                    
                                    JToken expirationDateValue = valueValue["expirationDate"];
                                    if (expirationDateValue != null && expirationDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime expirationDateInstance = ((DateTime)expirationDateValue);
                                        subscriptionContractInstance.ExpirationDate = expirationDateInstance;
                                    }
                                    
                                    JToken endDateValue = valueValue["endDate"];
                                    if (endDateValue != null && endDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime endDateInstance = ((DateTime)endDateValue);
                                        subscriptionContractInstance.EndDate = endDateInstance;
                                    }
                                    
                                    JToken notificationDateValue = valueValue["notificationDate"];
                                    if (notificationDateValue != null && notificationDateValue.Type != JTokenType.Null)
                                    {
                                        DateTime notificationDateInstance = ((DateTime)notificationDateValue);
                                        subscriptionContractInstance.NotificationDate = notificationDateInstance;
                                    }
                                    
                                    JToken primaryKeyValue = valueValue["primaryKey"];
                                    if (primaryKeyValue != null && primaryKeyValue.Type != JTokenType.Null)
                                    {
                                        string primaryKeyInstance = ((string)primaryKeyValue);
                                        subscriptionContractInstance.PrimaryKey = primaryKeyInstance;
                                    }
                                    
                                    JToken secondaryKeyValue = valueValue["secondaryKey"];
                                    if (secondaryKeyValue != null && secondaryKeyValue.Type != JTokenType.Null)
                                    {
                                        string secondaryKeyInstance = ((string)secondaryKeyValue);
                                        subscriptionContractInstance.SecondaryKey = secondaryKeyInstance;
                                    }
                                    
                                    JToken stateCommentValue = valueValue["stateComment"];
                                    if (stateCommentValue != null && stateCommentValue.Type != JTokenType.Null)
                                    {
                                        string stateCommentInstance = ((string)stateCommentValue);
                                        subscriptionContractInstance.StateComment = stateCommentInstance;
                                    }
                                }
                            }
                            
                            JToken countValue = responseDoc["count"];
                            if (countValue != null && countValue.Type != JTokenType.Null)
                            {
                                long countInstance = ((long)countValue);
                                resultInstance.TotalCount = countInstance;
                            }
                            
                            JToken nextLinkValue = responseDoc["nextLink"];
                            if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                            {
                                string nextLinkInstance = ((string)nextLinkValue);
                                resultInstance.NextLink = nextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
