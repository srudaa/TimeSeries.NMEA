/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes;

namespace Dolittle.TimeSeries.NMEA.Formats
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
        public object Parse(IEnumerable<string> values)
        {
            var geolocation = new Geolocation();

            return geolocation;
        }
    }
}