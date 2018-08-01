/* 
 * Copyright(c) 2016 - 2018 Puma Security, LLC (https://www.pumascan.com)
 * 
 * Project Leader: Eric Johnson (eric.johnson@pumascan.com)
 * Lead Developer: Eric Mead (eric.mead@pumascan.com)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 */

using CommandLine;

namespace Puma.Security.Parser
{
    public class Options
    {
        [Option('w', "workspace", Required = true, HelpText = "Jenkins workspace root directory")]
        public string Workspace { get; set; }

        [Option('f', "file", Required = true, HelpText = "Build file to parse")]
        public string BuildFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file name")]
        public string OutputFile { get; set; }
    }
}