#pragma checksum "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d15f0e3de2240720f107913b50aa3d2988df9fa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_Index), @"mvc.1.0.view", @"/Views/Movie/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d15f0e3de2240720f107913b50aa3d2988df9fa2", @"/Views/Movie/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"324c8843fa4d6f5d6234244a741890a997ade2b7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Movie_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    var lstData = ViewBag.Data as IEnumerable<FilmManagement.Core.Models.Movie.MovieModel>;
    string currentUsername = ViewBag.CurrentUsername as string;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<style>
    body {
        min-height: 100vh;
        background: #fafafa;
    }


    .social-link {
        width: 30px;
        height: 30px;
        border: 1px solid #ddd;
        display: flex;
        align-items: center;
        justify-content: center;
        color: #666;
        border-radius: 50%;
        transition: all 0.3s;
        font-size: 0.9rem;
    }

        .social-link:hover,
        .social-link:focus {
            background: #ddd;
            text-decoration: none;
            color: #555;
        }

    .progress {
        height: 10px;
    }
</style>
<div>
    <h2 style=""font-size: 20px; margin: 10px 0"" class=""font-weight-bold mb-2"">Welcome, <span class=""font-italic text-muted mb-4""><strong>");
#nullable restore
#line 39 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
                                                                                                                                     Write(currentUsername);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span><a style=\"float: right; font-size: 20px\" href=\"#\" id=\"btnLogOut\">Log out <i class=\"fa fa-sign-out\" aria-hidden=\"true\"></i></a></h2>\r\n</div>\r\n\r\n<div class=\"row pb-5 mb-4\">\r\n");
#nullable restore
#line 43 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
     foreach (var item in lstData)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-3 col-md-6 mb-4 mb-lg-0\">\r\n            <!-- Card-->\r\n            <div class=\"card shadow-sm border-0 rounded\">\r\n                <div class=\"card-body p-0\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d15f0e3de2240720f107913b50aa3d2988df9fa26258", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1551, "~/imgs/", 1551, 7, true);
#nullable restore
#line 49 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
AddHtmlAttributeValue("", 1558, item.Image, 1558, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"p-4\">\r\n                        <h5 class=\"mb-0\" style=\"height: 3em\">");
#nullable restore
#line 51 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
                                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"small text-muted\">\r\n                            <span style=\"float:left; line-height: 2\">");
#nullable restore
#line 53 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
                                                                 Write(item.LikeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" likes</span>\r\n\r\n                            <span style=\"float:right; margin-left: 1em\">\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1994, "\"", 2030, 3);
            WriteAttributeValue("", 2004, "voteDisLike(\'", 2004, 13, true);
#nullable restore
#line 56 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
WriteAttributeValue("", 2017, item.Id, 2017, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2027, "\');", 2027, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" id=""voteDisLike"" class=""social-link"" style=""cursor: pointer"">
                                    <i class=""fa fa-thumbs-o-down"" aria-hidden=""true""></i>
                                </a>
                            </span>
                            <span style=""float:right"">
                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 2352, "\"", 2385, 3);
            WriteAttributeValue("", 2362, "voteLike(\'", 2362, 10, true);
#nullable restore
#line 61 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
WriteAttributeValue("", 2372, item.Id, 2372, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2382, "\');", 2382, 3, true);
            EndWriteAttribute();
            WriteLiteral(@" id=""voteLike"" class=""social-link"" style=""cursor: pointer"">
                                    <i class=""fa fa-thumbs-o-up"" aria-hidden=""true""></i>
                                </a>
                            </span>
                        </p>
");
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n            <hr style=\"border: none; height: 0.2em\" />\r\n        </div>\r\n");
#nullable restore
#line 72 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<script type=""text/javascript"">
    function voteLike(id) {
        var data = { // to be replaced with form values
            MovieId: id,
            IsLike: true
        };
        $.ajax({
                type: ""POST"",
                url: """);
#nullable restore
#line 82 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
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
                },
                failure: function (response) {
                    debugger;
                    alert(response.responseText);
                }
            });
    }

    function voteDisLike(id) {
        var data = {
            MovieId: id,
            IsLike: false
        };
        $.ajax({
                type: ""POST"",
                url: """);
#nullable restore
#line 105 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
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
                },
                failure: function (response) {
                    debugger;
                    alert(response.responseText);
                }
            });
    }

    $(""#btnLogOut"").click(function () {
        $.ajax({
            type: ""GET"",
            url: """);
#nullable restore
#line 124 "C:\Users\PC-PHUCHUYNH\Downloads\n\HuynhHuuPhucRound2\src\FilmManagement.WebUI\Views\Movie\Index.cshtml"
             Write(Url.Action("Logout", "Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                // pending response for ui
                window.location.href = ""Login/Index"";
            }
        });
    });
</script>");
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
