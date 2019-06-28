/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dolittle.TimeSeries.NMEA
{
    /// <summary>
    /// Defines how a format for a sentence is to be parsed
    /// </summary>
    public interface ISentenceFormat
    {
        /// <summary>
        /// Gets the talker of the sentence
        /// </summary>
        string Talker { get; }

        /// <summary>
        /// Gets the setence identifier 
        /// </summary>
        string Identitifer { get; }

        /// <summary>
        /// Parse the sentence values and return an instance of a type representing it
        /// </summary>
        /// <param name="values">The values to parse</param>
        /// <returns>A parsed instance</returns>
        object Parse(IEnumerable<string> values);
    }
}