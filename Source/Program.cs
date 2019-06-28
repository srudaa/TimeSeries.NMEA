/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Dolittle.TimeSeries.Modules.Booting;

namespace Dolittle.TimeSeries.NMEA
{

    class Program
    {
        static void Main()
        {

            
            // $GPRMC,151437,A,2146.826,N,11858.672,E,18.2,209.,250619,03.,W*60
            var client = new TcpClient("127.0.0.1", 2101);
            using(var stream = client.GetStream())
            {
                var started = false;
                var lineBuilder = new StringBuilder();
                for(;;)
                {
                    var result = stream.ReadByte();
                    if( result == -1 ) break;

                    var character = (char)result;
                    switch(character)
                    {
                        case '$': started = true; break;
                        case '\n': {
                            Console.WriteLine(lineBuilder.ToString());
                            lineBuilder = new StringBuilder();

                        } break;
                    }
                    if( started ) lineBuilder.Append(character);
                }
            }

            //Bootloader.Configure(_ => {}).Start().Wait();
        }
    }
}