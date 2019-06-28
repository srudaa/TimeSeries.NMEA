/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Machine.Specifications;

namespace Dolittle.TimeSeries.NMEA.for_SentenceParser.when_parsing
{
    public class and_there_are_two_formats_with_one_format_that_is_able_to_parse : given.two_formats
    {
        const string exepected_result = "Fourty Two";
        static object result;

        Establish context = () => second_format.Setup(_ => _.Parse(second_format_values)).Returns(exepected_result);

        Because of = () => result = sentence_parser.Parse(second_format_sample);

        It should_return_the_expected_result = () => result.ShouldEqual(exepected_result);
    }
}