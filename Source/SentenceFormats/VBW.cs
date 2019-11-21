/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes;

namespace Dolittle.TimeSeries.NMEA.SentenceFormats
{
    /// <summary>
    /// Represents the format of "Dual Ground/Water Speed (should probably implement only send if status is valid, see documentation)"
    /// </summary>
    public class VBW : ISentenceFormat
    {
        /// <inheritdoc/>
        public string Identitifer => "VBW";

        /// <inheritdoc/>
        public IEnumerable<ParsedResult> Parse(string[] values)
        {
            Dictionary<int, string> tags = new Dictionary<int, string>()
                                      {
                                          {0,"LongitudinalSpeedThroughWater"},
                                          {1, "TransverseSpeedThroughWater"},
                                          {3,"LongitudinalSpeedOverGround"},
                                          {4,"TransverseSpeedOverGround"}
                                      };

            foreach (KeyValuePair<int, string> tag in tags)
            {
                if (!string.IsNullOrEmpty(values[tag.Key]))
                {
                    yield return new ParsedResult(tag.Value, new Measurement<float>
                    {
                        Value = (float.Parse(values[tag.Key]) * 1852) / 3600

                    });
                }
            }
        }
    }
}
