#pragma checksum "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/Home/Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f944737c3165ff7e346e6aea5e6c5caff582db1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contact.cshtml", typeof(AspNetCore.Views_Home_Contact))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f944737c3165ff7e346e6aea5e6c5caff582db1", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14bf0c60da990f661adaa9664a06f2d7e591e205", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/Home/Contact.cshtml"
  
    ViewBag.Title = "Where To Find Me:";

#line default
#line hidden
            BeginContext(46, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(51, 13, false);
#line 4 "/Users/seb/RiderProjects/MyWebsite/MyWebsite/Views/Home/Contact.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(64, 789, true);
            WriteLiteral(@"</h2>

<script type=""text/javascript"" src=""https://platform.linkedin.com/badges/js/profile.js"" async defer></script>

<div class=""grid-container""; align=""center"">
    <div class=""LI-profile-badge"" data-version=""v1"" data-size=""medium"" data-locale=""en_US"" data-type=""horizontal"" data-theme=""dark"" data-vanity=""sebastian-muir-smith-71ba8015b""><a class=""LI-simple-link"" href='https://au.linkedin.com/in/sebastian-muir-smith-71ba8015b?trk=profile-badge'>Sebastian Muir-smith</a></div>
    <p>
    <address>
        <strong>All Enquiries:</strong>   <a href=""mailto:sebastian@muirsmith.com"">sebastian@muirsmith.com</a><br />
        <strong>Follow me on Facebook:</strong> <a href=""https://www.facebook.com/seb.muirsmith"">https://www.facebook.com/seb.muirsmith</a>
    </address>
    </p>
</div>");
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
