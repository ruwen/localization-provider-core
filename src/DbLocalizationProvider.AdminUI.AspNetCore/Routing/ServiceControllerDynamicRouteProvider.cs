// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DbLocalizationProvider.AdminUI.AspNetCore.Routing;

public class ServiceControllerDynamicRouteProvider : IApplicationModelProvider
{
    private readonly UiConfigurationContext _context;

    public ServiceControllerDynamicRouteProvider(UiConfigurationContext context)
    {
        _context = context;
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context) { }

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
        var serviceControllerModel =
            context.Result.Controllers.FirstOrDefault(c => c.ControllerType.IsAssignableFrom(typeof(ServiceController)));

        if (serviceControllerModel == null)
        {
            return;
        }

        var selectorModel = serviceControllerModel.Selectors.FirstOrDefault();
        if (selectorModel is { AttributeRouteModel: { } })
        {
            selectorModel.AttributeRouteModel.Template = _context.RootUrl + "/api/service";
        }
    }

    public int Order => -1000 + 10;
}
