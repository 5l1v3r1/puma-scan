/* 
 * Copyright(c) 2016 Puma Security, LLC (https://www.pumascan.com)
 * 
 * Project Leader: Eric Johnson (eric.johnson@pumascan.com)
 * Lead Developer: Eric Mead (eric.mead@pumascan.com)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 */

using System.Collections.Immutable;

using Autofac;

using Puma.Security.Rules.Analyzer;
using Puma.Security.Rules.Analyzer.Injection.Sql;
using Puma.Security.Rules.Base;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Puma.Security.Rules.Suites
{
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public class SqlInjectionDiagnosticSuite : BaseSyntaxDiagnosticSuite
    {
        public SqlInjectionDiagnosticSuite()
        {
            Analyzers = new IAnalyzer[]
            {
                Container.Resolve<LinqSqlInjectionAnalyzer>(),
                Container.Resolve<SqlCommandInjectionAnalyzer>(),
                Container.Resolve<EfQueryCommandInjectionAnalyzer>()
            }.ToImmutableArray();
        }
    }
}