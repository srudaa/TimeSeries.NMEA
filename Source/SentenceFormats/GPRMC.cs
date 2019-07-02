/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes;

namespace Dolittle.TimeSeries.NMEA.SentenceFormats
{
    /// <summary>
    /// Represents the format of "Recommended Minimum Navigation Information"
    /// </summary>
    public class GPRMC : ISentenceFormat
    {
        /// <inheritdoc/>
        public string Talker => "GP";

        /// <inheritdoc/>
        public string Identitifer => "RMC";

        /// <inheritdoc/>
        public IEnumerable<ParsedResult> Parse(string[] values)
        {
            var latitude = float.Parse(values[2]);
            var longitude = float.Parse(values[4]);
            if( values[3] == "S" ) latitude = -latitude;
            if( values[5] == "W" ) longitude = -longitude;

            return new[] {
                new ParsedResult("Position", new Coordinate
                {
                    Latitude = new Measurement<float>
                    {
                        Value = latitude
                    },
                    Longitude = new Measurement<float>
                    {
                        Value = longitude
                    }
                }),
                new ParsedResult("Speed", new Measurement<float>
                {
                    Value = (float.Parse(values[6])*1852)/3600
                })
            };
        }
    }
}