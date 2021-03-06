/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.TimeSeries.NMEA.SentenceFormats;
using Machine.Specifications;

namespace Dolittle.TimeSeries.NMEA.for_SentenceFormats.given
{
    public class a_HEHDT_parser
    {
        protected static HEHDT parser;
        Establish context = () => parser = new HEHDT();
    }
}