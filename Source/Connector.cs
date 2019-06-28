/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Net.Sockets;
using System.Text;
using Dolittle.Logging;
using Dolittle.TimeSeries.Modules;
using Dolittle.TimeSeries.Modules.Connectors;

namespace Dolittle.TimeSeries.NMEA
{
    /// <summary>
    /// Represents a <see cref="IAmAPullConnector">pull connector</see> for Modbus
    /// </summary>
    public class Connector : IAmAStreamingConnector
    {
        /// <inheritdoc/>
        public event DataReceived DataReceived = (tag, value, timestamp) => { };
        readonly ConnectorConfiguration _configuration;
        readonly ILogger _logger;
        readonly ISentenceParser _parser;      

        /// <summary>
        /// Initializes a new instance of <see cref="Connector"/>
        /// </summary>
        /// <param name="configuration">The <see cref="ConnectorConfiguration">configuration</see></param>
        /// <param name="parser"><see cref="ISentenceParser"/> for parsing the NMEA sentences</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public Connector(
            ConnectorConfiguration configuration,
            ISentenceParser parser,
            ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _parser = parser;
        }

        /// <inheritdoc/>
        public Source Name => "NMEA";

        /// <inheritdoc/>
        public void Connect()
        {
            var client = new TcpClient(_configuration.Ip, _configuration.Port);
            using(var stream = client.GetStream())
            {
                var started = false;
                var sentenceBuilder = new StringBuilder();
                for (;;)
                {
                    var result = stream.ReadByte();
                    if (result == -1) break;

                    var character = (char) result;
                    switch (character)
                    {
                        case '$':
                            started = true;
                            break;
                        case '\n':
                            {
                                var sentence = sentenceBuilder.ToString();
                                if (_parser.CanParse(sentence))
                                {
                                    var output = _parser.Parse(sentence);
                                    DataReceived("SOMETHING",output, Timestamp.UtcNow);
                                }

                                sentenceBuilder = new StringBuilder();

                            }
                            break;
                    }
                    if (started) sentenceBuilder.Append(character);
                }
            }
        }
   }
}