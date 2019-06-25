/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Dolittle.Logging;
using Dolittle.TimeSeries.Modules;
using Dolittle.TimeSeries.Modules.Connectors;

namespace Dolittle.TimeSeries.NMEA
{
    /// <summary>
    /// Represents a <see cref="IAmAPullConnector">pull connector</see> for Modbus
    /// </summary>
    public class Connector : IAmAPullConnector
    {
        readonly ConnectorConfiguration _configuration;
        readonly ILogger _logger;
        TcpClient _client;

        /// <summary>
        /// Initializes a new instance of <see cref="Connector"/>
        /// </summary>
        /// <param name="configuration">The <see cref="ConnectorConfiguration">configuration</see></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public Connector(
            ConnectorConfiguration configuration,
            ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <inheritdoc/>
        public Source Name => "Modbus";

        /// <inheritdoc/>
        public IEnumerable<TagWithData> GetAllData()
        {
            MakeSureClientIsConnected();

            throw new NotImplementedException();

        }

        /// <inheritdoc/>
        public object GetData(Tag tag)
        {
            throw new NotImplementedException();
        }

        void MakeSureClientIsConnected()
        {
            if( _client != null && !_client.Connected ) 
            {
                _client.Dispose();
                _client = null;
            }

            if (_client == null)
            {
                _client = new TcpClient(_configuration.Ip, _configuration.Port);
            }
        }
    }
}