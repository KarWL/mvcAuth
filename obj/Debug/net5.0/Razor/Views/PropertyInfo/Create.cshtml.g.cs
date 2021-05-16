#pragma checksum "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\PropertyInfo\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "276008931446ee443502045676a5306fc8dfff68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PropertyInfo_Create), @"mvc.1.0.view", @"/Views/PropertyInfo/Create.cshtml")]
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
#line 1 "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\_ViewImports.cshtml"
using mvcApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\_ViewImports.cshtml"
using mvcApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"276008931446ee443502045676a5306fc8dfff68", @"/Views/PropertyInfo/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52df0d815a22bdcd89173f508c418763036f5e6b", @"/Views/_ViewImports.cshtml")]
    public class Views_PropertyInfo_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mvcApp.Models.ApplicationUser>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\PropertyInfo\Create.cshtml"
  
    ViewData["Title"] = "Property Management";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Create Property</h2>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "276008931446ee443502045676a5306fc8dfff683481", async() => {
                WriteLiteral(@"
    <div class=""mb-3"">
        <label class=""form-label"" for=""fname"">Asset Name:</label>
        <input class=""form-control""  type=""text"" id=""Name"" name=""Name"" placeholder=""Asset Name"" />
    </div>

    <div class=""mb-3"">
        <label class=""form-label"" for=""fname"">Asset Type:</label><br>
        <input class=""form-control""  type=""text"" id=""Type"" name=""Type"" placeholder=""Asset Type"" />
    </div>

    <div class=""mb-3"">
        <label class=""form-label"" for=""fname"">Asset Description:</label>
        <input class=""form-control""  type=""text"" id=""Description"" name=""Description"" placeholder=""Description"" />
        <input type=""text"" id=""UserId"" name=""UserId"" placeholder=""Id""");
                BeginWriteAttribute("value", " value=\"", 825, "\"", 842, 1);
#nullable restore
#line 21 "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\PropertyInfo\Create.cshtml"
WriteAttributeValue("", 833, Model.Id, 833, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden=True />\r\n    </div>\r\n    <input value=\"Create\" class=\"btn btn-primary\" onclick=\"CreatePropertyInfo()\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<script type=""text/javascript"">
    function CreatePropertyInfo() {
        $.ajax({
            type: ""POST"",
            url: ""/PropertyInfo/CreatePropertyInfo"",
            data: {
                ""Name"": $(Name).val(),
                ""Type"": $(Type).val(),
                ""Description"": $(Description).val(),
                ""UserId"": $(UserId).val()
            },
            success: function (response) {
                window.location.href = ""/PropertyInfo/Details/"" + '");
#nullable restore
#line 39 "C:\Users\leeka\OneDrive\Documents\MVC\mvcApp\Views\PropertyInfo\Create.cshtml"
                                                              Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        });
    };
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mvcApp.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
