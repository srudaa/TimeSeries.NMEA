/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.NMEA.SentenceFormats;
using Machine.Specifications;

namespace Dolittle.TimeSeries.NMEA.for_SentenceFormats.given
{
    public class a_WIMWV_parser : parsed_results
    {
        protected static WIMWV parser;
        Establish context = () =>
        {
            parser = new WIMWV();
        };
    }
}