#pragma checksum "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Login\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf26532751aa1484534da8d573488a1e34c4b40b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Register), @"mvc.1.0.view", @"/Views/Login/Register.cshtml")]
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
#line 1 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\_ViewImports.cshtml"
using FilmManagement.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\_ViewImports.cshtml"
using FilmManagement.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf26532751aa1484534da8d573488a1e34c4b40b", @"/Views/Login/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"324c8843fa4d6f5d6234244a741890a997ade2b7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
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
#line 1 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Login\Register.cshtml"
   
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
<script type=""text/javascript"">
        $(function () {
            $(""#btnRedirectLogin"").click(function () {
                $.ajax({
                    type: ""GET"",
                    url: ""/Login/Index"",
                    success: function (response) {
                        window.location.href = '/Login/Index';
                    }
                });
            });
        });
</script>
<div class=""wrapper bg-white"">
    <div class=""h4 text-muted text-center pt-2"">Welcome to </div>
    <div class=""h2 text-center"">Big Star</div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf26532751aa1484534da8d573488a1e34c4b40b4955", async() => {
                WriteLiteral("\r\n        <div class=\"form-group py-2\">\r\n            <div class=\"input-field\"> <span class=\"far fa-user p-2\"></span> <input id=\"Username\" type=\"text\" placeholder=\"Username\" required");
                BeginWriteAttribute("class", " class=\"", 1248, "\"", 1256, 0);
                EndWriteAttribute();
                WriteLiteral("> </div>\r\n        </div>\r\n        <div class=\"form-group py-2\">\r\n            <div class=\"input-field\"> <span class=\"far fa-user p-2\"></span> <input id=\"Email\" type=\"text\" placeholder=\"Email\" required");
                BeginWriteAttribute("class", " class=\"", 1456, "\"", 1464, 0);
                EndWriteAttribute();
                WriteLiteral("> </div>\r\n        </div>\r\n        <div class=\"form-group py-1 pb-2\">\r\n            <div class=\"input-field\"> <span class=\"fas fa-lock p-2\"></span> <input id=\"Password\" type=\"text\" placeholder=\"Password\" required");
                BeginWriteAttribute("class", " class=\"", 1675, "\"", 1683, 0);
                EndWriteAttribute();
                WriteLiteral(@"> <button type=""button"" class=""btn bg-white text-muted""> <span class=""far fa-eye-slash toggle-password""></span> </button> </div>
        </div>
        <div class=""form-group py-1 pb-2"">
            <div class=""input-field""> <span class=""fas fa-lock p-2""></span> <input id=""RePassword"" type=""text"" placeholder=""Re-Password"" required");
                BeginWriteAttribute("class", " class=\"", 2019, "\"", 2027, 0);
                EndWriteAttribute();
                WriteLiteral(@"> <button type=""button"" class=""btn bg-white text-muted""> <span class=""far fa-eye-slash toggle-repassword""></span> </button> </div>
        </div>
        <button type=""button"" id=""registerUser"" class=""btn btn-block text-center my-3"">Submit</button>
        <div class=""text-center pt-3 text-muted"">Have an account? <a href=""#"" id=""btnRedirectLogin"">Log in</a></div>
    ");
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

    $(""body"").on('click', '.toggle-repassword', function () {
        $(this).toggleClass(""fa-eye fa-eye-slash"");
        var input = $(""#RePassword"");
        if (input.attr(""type"") === ""password"") {
            input.attr(""type"", ""text"");
        } else {
            input.attr(""type"", ""password"");
        }
    });

    $(""#registerUser"").click(function () {
        var email = $(""#Email"").val();
        var userName = $(""#Username"").val();
      ");
            WriteLiteral(@"  var passWord = $(""#Password"").val();
        var rePassWord = $(""#RePassword"").val();
        if (passWord != rePassWord) {
            $("".alert"").css(""display"", ""block"");
            return document.getElementById(""msg"").innerHTML = ""RePassword not match"";
        }
        var data = { // to be replaced with form values
            Password: passWord,
            Username: userName,
            Email: email,
        };
        $.ajax({
            type: ""POST"",
            url: """);
#nullable restore
#line 100 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Login\Register.cshtml"
             Write(Url.Action("Register", "Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response == true) {
                }
                $("".alert"").css(""display"", ""block"");
                document.getElementById(""msg"").innerHTML = response;
            }
        });
    });

    function registerUser(id) {
        var data = { // to be replaced with form values
            MovieId: id,
            IsLike: true
        };
        $.ajax({
                type: ""POST"",
                url: """);
#nullable restore
#line 120 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Login\Register.cshtml"
                 Write(Url.Action("InteractMovie", "Movie"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.code == 0) {
                    }
                    location.reload();
                }
            });
        }
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
