#pragma checksum "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/Home/Resume.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6d55eca5db145d1808bb622d72524551f90d264"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Resume), @"mvc.1.0.view", @"/Views/Home/Resume.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Resume.cshtml", typeof(AspNetCore.Views_Home_Resume))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/_ViewImports.cshtml"
using MyWebsite;

#line default
#line hidden
#line 2 "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/_ViewImports.cshtml"
using MyWebsite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6d55eca5db145d1808bb622d72524551f90d264", @"/Views/Home/Resume.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14bf0c60da990f661adaa9664a06f2d7e591e205", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Resume : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 2 "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/Home/Resume.cshtml"
  
    ViewBag.Title = "My résumé";

#line default
#line hidden
            BeginContext(39, 213, true);
            WriteLiteral("\n<div class=\"resume\">\n    <h3 class=\"resume\"> What resume do you want to view? </h3>\n    <div class=\"resume\">\n        <button>Hospitality</button>\n        <button>Web Dev/Data Analytics</button>\n    </div>\n</div>\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
