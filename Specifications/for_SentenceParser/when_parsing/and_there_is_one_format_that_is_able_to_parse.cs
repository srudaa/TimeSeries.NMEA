/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Machine.Specifications;

namespace Dolittle.TimeSeries.NMEA.for_SentenceParser.when_parsing
{
    public class and_there_is_one_format_that_is_able_to_parse : given.one_format
    {
        const string exepected_result = "Fourty Two";
        static object result;

        Establish context = () => format.Setup(_ => _.Parse(values)).Returns(exepected_result);

        Because of = () => 
        {
            result = sentence_parser.Parse(valid_format);
        };


        It should_return_the_expected_result = () => result.ShouldEqual(exepected_result);
    }
}