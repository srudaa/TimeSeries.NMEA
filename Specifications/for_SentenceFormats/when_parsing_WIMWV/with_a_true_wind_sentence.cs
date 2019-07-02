/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Machine.Specifications;
using Dolittle.TimeSeries.NMEA.SentenceFormats;
using System.Linq;

namespace Dolittle.TimeSeries.NMEA.for_SentenceFormats.when_parsing_WIMWV
{
    public class with_a_true_wind_sentence : given.a_WIMWV_parser
    {
        static string[] values = new[] { "325","T","018.3","M"};

        Because of = () => results = parser.Parse(values).ToList();

        
        It should_return_two_result = () => results.Count.ShouldEqual(2);

        It should_return_a_true_wind_angle = () => ShouldContainAMeasurementWithTypeAndValue<float>("WindAngleTrue", 325);

        It should_return_a_true_wind_speed = () => ShouldContainAMeasurementWithTypeAndValue<float>("WindSpeedTrue", 18.3f);

    }
}