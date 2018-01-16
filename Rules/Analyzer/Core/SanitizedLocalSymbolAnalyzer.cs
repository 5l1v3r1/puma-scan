﻿/* 
 * Copyright(c) 2016 - 2018 Puma Security, LLC (https://www.pumascan.com)
 * 
 * Project Leader: Eric Johnson (eric.johnson@pumascan.com)
 * Lead Developer: Eric Mead (eric.mead@pumascan.com)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 */

using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using Puma.Security.Rules.Common;
using Puma.Security.Rules.Configuration.Core;

namespace Puma.Security.Rules.Analyzer.Core
{
    internal class SanitizedLocalSymbolAnalyzer : ISanitizedLocalSymbolAnalyzer
    {
        private readonly ICleansedMethodsProvider _cleansedMethodsProvider;

        public SanitizedLocalSymbolAnalyzer(ICleansedMethodsProvider cleansedMethodsProvider)
        {
            _cleansedMethodsProvider = cleansedMethodsProvider;
        }
        public bool IsSymbolSanitized(ILocalSymbol localSymbol, DiagnosticId ruleId = DiagnosticId.None)
        {
            //Filter by namespace
            IEnumerable<CleanseMethod> methods = _cleansedMethodsProvider.GetByRuleId(ruleId).Where(i => string.Compare(i.Namespace, localSymbol.ContainingNamespace.ToString()) == 0);
            if (methods.Count() == 0)
                return false;

            //Filter by type: ContainingType (Namespace.Type)
            methods = methods.Where(i => i.Type.Equals("*") || string.Compare(string.Join(".", i.Namespace, i.Type), localSymbol.ContainingType.ToDisplayString()) == 0);
            if (methods.Count() == 0)
                return false;

            //Filter by method name
            methods = methods.Where(i => i.Method.Equals("*") || string.Compare(i.Method, localSymbol.Name) == 0);
            if (methods.Count() == 0)
                return false;

            return true;
        }
    }
}