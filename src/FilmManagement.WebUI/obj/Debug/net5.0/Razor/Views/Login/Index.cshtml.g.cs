#pragma checksum "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4ee4dee532eb85a7b5e4779ff0198890baf5e25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
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
#line 1 "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\_ViewImports.cshtml"
using FilmManagement.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\_ViewImports.cshtml"
using FilmManagement.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4ee4dee532eb85a7b5e4779ff0198890baf5e25", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"324c8843fa4d6f5d6234244a741890a997ade2b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\Login\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .alert {
        padding: 20px;
        background-color: #f44336;
        color: white;
    }

    .closebtn {
        margin-left: 15px;
        color: white;
        font-weight: bold;
        float: right;
        font-size: 16px;
        line-height: 16px;
        cursor: pointer;
        transition: 0.3s;
    }

        .closebtn:hover {
            color: black;
        }
</style>

<div class=""wrapper bg-white"">
    <div class=""h4 text-muted text-center pt-2"">Welcome to </div>
    <div class=""h2 text-center"">Big Star</div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d4ee4dee532eb85a7b5e4779ff0198890baf5e254367", async() => {
                WriteLiteral("\r\n        <div class=\"form-group py-2\">\r\n            <div class=\"input-field\"> <span class=\"far fa-user p-2\"></span> <input id=\"Username\" type=\"text\" placeholder=\"Username or Email\" required");
                BeginWriteAttribute("class", " class=\"", 841, "\"", 849, 0);
                EndWriteAttribute();
                WriteLiteral(@"> </div>
        </div>
        <div class=""form-group py-1 pb-2"">
            <div class=""input-field""> <span class=""fas fa-lock p-2""></span> <input id=""Password"" type=""password"" placeholder=""Password"" required onkeypress=""return checkKeyPress(event);""");
                BeginWriteAttribute("class", " class=\"", 1106, "\"", 1114, 0);
                EndWriteAttribute();
                WriteLiteral(@"> <button type=""button"" class=""btn bg-white text-muted""> <span class=""far fa-eye-slash toggle-password""></span> </button> </div>
        </div>
        <div class=""d-flex align-items-start"">
            <div class=""remember""> <label class=""option text-muted""> Remember me <input type=""radio"" name=""radio""> <span class=""checkmark""></span> </label> </div>
");
                WriteLiteral("        </div> <button class=\"btn btn-block text-center my-3\" id=\"btnSubmit\" type=\"button\">Submit</button>\r\n        <div class=\"text-center pt-3 text-muted\">Not a member? <a href=\"#\" id=\"btnRegis\">Register</a></div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <div class=""alert"" style=""display: none"">
        <span class=""closebtn"" onclick=""this.parentElement.style.display='none';"">&times;</span>
        <div id=""msg""></div>
    </div>
</div>
<script type=""text/javascript"">
    $(""body"").on('click', '.toggle-password', function () {
        $(this).toggleClass(""fa-eye fa-eye-slash"");
        var input = $(""#Password"");
        if (input.attr(""type"") === ""password"") {
            input.attr(""type"", ""text"");
        } else {
            input.attr(""type"", ""password"");
        }
    });

    function checkKeyPress(e) {
        // look for window.event in case event isn't passed in
        e = e || window.event;
        if (e.keyCode == 13) {
            document.getElementById('btnSubmit').click();
            return false;
        }
        return true;
    }

    $(function () {
        $(""#btnRegis"").click(function () {
            $.ajax({
                type: ""GET"",
                url: ""/Login/Register"",
                succ");
            WriteLiteral("ess: function (response) {\r\n                    window.location.href = \'");
#nullable restore
#line 75 "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\Login\Index.cshtml"
                                       Write(Url.Action("Register", "Login"));

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
        });

        $(""#btnSubmit"").click(function () {
            var data = { // to be replaced with form values
                Password: $(""#Password"").val(),
                Username: $(""#Username"").val(),
            };
                $.ajax({
                    type: ""POST"",
                    url: """);
#nullable restore
#line 93 "D:\HuynhHuuPhuc-Round2-Test\src\FilmManagement.WebUI\Views\Login\Index.cshtml"
                     Write(Url.Action("Index", "Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    data: JSON.stringify(data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.redirectToUrl) {
                            return window.location.href = response.redirectToUrl;
                        }
                        $("".alert"").css(""display"", ""block"");
                        document.getElementById(""msg"").innerHTML = response;
                    },
                    failure: function (response) {
                        window.location.href = response.redirectToUrl;
                    },
                    error: function (response) {
                        window.location.href = response.redirectToUrl;
                    }
                });
            });
    });
</script>");
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