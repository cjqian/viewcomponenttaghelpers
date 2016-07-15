﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Razor.Directives;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;

namespace ViewComponentTagHelpers
{
    /// <summary>
    /// An instance of MvcRazorHost. We take in the compilation service as well to force compilation of generated tag helper code.
    /// </summary>
    public class ViewComponentMvcRazorHost : MvcRazorHost
    {
        public ViewComponentMvcRazorHost(
            IChunkTreeCache chunkTreeCache,
            IViewComponentDescriptorProvider viewComponentDescriptorProvider,
            ICompilationService compilationService)
            : base(chunkTreeCache, new ViewComponentTagHelpersDescriptorResolver(new TagHelperTypeResolver(), viewComponentDescriptorProvider, compilationService))
        {
            //Line 21 too long! < 120
            // CR: Wrap existing resolver instaed of create new
            TagHelperDescriptorResolver = new ViewComponentTagHelpersDescriptorResolver(
                new TagHelperTypeResolver(),
                viewComponentDescriptorProvider,
                compilationService);
        }
    }
}