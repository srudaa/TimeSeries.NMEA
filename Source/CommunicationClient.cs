/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.DependencyInversion;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Dolittle.TimeSeries.Modules;

namespace Dolittle.TimeSeries.NMEA
{
    /// <summary>
    /// 
    /// </summary>
    public class CommunicationClient : ICommunicationClient
    {
        readonly ISerializer _serializer;
        readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="logger"></param>
        public CommunicationClient(ISerializer serializer, ILogger logger)
        {
            _serializer = serializer;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Task SendAsJson(Output output, object payload)
        {
             _logger.Information($"Send as JSON to '{output}'");
            var outputMessageString = _serializer.ToJson(payload, SerializationOptions.CamelCase);
            _logger.Information($"Payload: '{outputMessageString}'");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Task SendRaw(Output output, byte[] payload)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="subscriber"></param>
        /// <typeparam name="T"></typeparam>
        public void SubscribeTo<T>(Input input, Subscriber<T> subscriber)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Bindings : ICanProvideBindings
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<ICommunicationClient>().To<CommunicationClient>();
        }
    }
}