#pragma checksum "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eadecc90216b4a2f72d62b88413290d587e62f16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GenerateFile), @"mvc.1.0.view", @"/Views/Home/GenerateFile.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\_ViewImports.cshtml"
using QR_Code_Generator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\_ViewImports.cshtml"
using QR_Code_Generator.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eadecc90216b4a2f72d62b88413290d587e62f16", @"/Views/Home/GenerateFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93b220b2e01842ed076c8c001dc676d7b1df703d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GenerateFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Byte[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
  
    ViewData["Title"] = "GenerateFile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
 using (Html.BeginForm(null, null, FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table>
        <tbody>
            <tr>
                <td>
                    <label>Enter text for creating QR Code</label>
                </td>
                <td>
                    <input type=""text"" name=""qrText"" />
                </td>
            </tr>
            <tr>
                <td colspan=""2"">
                    <button>Submit</button>
                </td>
            </tr>
        </tbody>
    </table>
");
#nullable restore
#line 27 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
  
    if (Model != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>QR Code Successfully Generated</h3>\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 678, "\"", 758, 1);
#nullable restore
#line 32 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
WriteAttributeValue("", 684, String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Model)), 684, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 33 "C:\Users\Admin\source\repos\QR_Code_Generator\QR_Code_Generator\Views\Home\GenerateFile.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Byte[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
