// Copyright (c) Markus Meyer. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace HappyCoding.Regex.Cmd
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            string text = File.ReadAllText("./wiki-http-status-codes.txt");
            var pattern = "[0-9]{3,3}";

            System.Text.RegularExpressions.Regex regex = new (pattern);
            var matchesEnurmator = regex.Matches(text).GetEnumerator();
            SortedList<int, int> httpStatusCodes = new ();

            while (matchesEnurmator.MoveNext())
            {
                if (int.TryParse(matchesEnurmator.Current.ToString(), out int code))
                {
                    if (!httpStatusCodes.ContainsKey(code))
                    {
                        httpStatusCodes.Add(code, 0);
                    }
                    else
                    {
                        httpStatusCodes[code] = httpStatusCodes[code]++;
                    }
                }
            }

            foreach (var code in httpStatusCodes)
            {
                Console.WriteLine(code.Key);
            }

            Console.WriteLine($"Count of codes: {httpStatusCodes.Count}");

            Console.ReadLine();
        }
    }
}
