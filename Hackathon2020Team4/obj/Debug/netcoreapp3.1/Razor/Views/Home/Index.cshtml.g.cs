#pragma checksum "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70969754785f51b4bd9d17e6e66932170f3c5bae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\_ViewImports.cshtml"
using Hackathon2020Team4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\_ViewImports.cshtml"
using Hackathon2020Team4.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
using Hackathon2020Team4.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70969754785f51b4bd9d17e6e66932170f3c5bae", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7bf7fdc3995a499bf9c719d64f927920d8e48c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "CampusIT";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
 if (SignInManager.IsSignedIn(User))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
     if (User.IsInRole("entrant"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>Очікуйте підтвердження адміністратором</h3>\r\n");
#nullable restore
#line 16 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <h1 class=""display-4"">CAMPUS IT</h1>
        <h2>Вітаємо!</h2>
        <p class=""lead"">Відома ураїнська ІТ компанія, спільно з одним із навчальних вищих закладів, розробила інформаційну систему IT Campus для супроводження навчального процесу підготовки IT-спеціалістів.</p>
        <p><a href=""http://asp.net"" class=""btn btn-primary btn-lg"">Дізнатись більше</a></p>
    </div>
");
#nullable restore
#line 26 "D:\Development\Hackathon2020\Hackathon2020Team4\Hackathon2020Team4\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"tlkio\" data-channel=\"campusitchat\" style=\"width:100%;height:400px;\"></div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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
