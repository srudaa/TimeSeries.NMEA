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
    public class VDVBW : ISentenceFormat
    {
        /// <inheritdoc/>
        public string Talker => "VD";

        /// <inheritdoc/>
        public string Identitifer => "VBW"; 

        /// <inheritdoc/>
        public IEnumerable<ParsedResult> Parse(string[] values)
        {

            return new[] {

                new ParsedResult("LongitudinalSpeedThroughWater", new Measurement<float>
                {
                    Value = (float.Parse(values[0])*1852)/3600
                    
                }),
                new ParsedResult("TransverseSpeedThroughWater", new Measurement<float>
                {
                    Value = (float.Parse(values[1])*1852)/3600
                    
                }),
                new ParsedResult("LongitudinalSpeedOverGround", new Measurement<float>
                {
                    Value = (float.Parse(values[3])*1852)/3600
                    
                }),
                new ParsedResult("TransverseSpeedOverGround", new Measurement<float>
                {
                    Value = (float.Parse(values[4])*1852)/3600
                    
                })
                
            };
        }
    }
}