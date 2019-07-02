/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace Dolittle.TimeSeries.NMEA.for_SentenceFormats.given
{
    public class parsed_results
    {
        protected static IList<ParsedResult> results;

        protected static void ShouldContainAMeasurementWithTypeAndValue<T>(string type, T value)
        {
            var result = results.Single(_ => _.Type == type);
            result.ShouldNotBeNull();
            result.Result.ShouldBeAssignableTo(typeof(Measurement<T>));
            var measurement = result.Result as Measurement<T>;
            measurement.Value.ShouldEqual(value);
        }
    }
}