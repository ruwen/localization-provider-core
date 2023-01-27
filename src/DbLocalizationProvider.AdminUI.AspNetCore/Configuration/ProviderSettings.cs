// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System.Collections.Generic;
using DbLocalizationProvider.Export;

namespace DbLocalizationProvider.AdminUI.AspNetCore.Configuration;

/// <summary>
/// Settings class to be used by plug-in providers
/// </summary>
public class ProviderSettings
{
    /// <summary>
    /// List of exporters configured by plug-ins
    /// </summary>
    public List<IResourceExporter> Exporters { get; set; } = new();
}
