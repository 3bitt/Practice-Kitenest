using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.TagHelpers
{
    [HtmlTargetElement("pagination", TagStructure = TagStructure.WithoutEndTag)]
    public class PaginationTagHelper : TagHelper
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string RouteUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            
            output.TagName = "";
            output.PreContent.AppendHtml("<div class=\"pagination col-md-6\">");

            for (int i = 0; i < TotalPages; ++i)
            {
                if (i + 1 == CurrentPage)
                {
                    output.Content.AppendHtml("<div class=\"Page Current\">");
                    output.Content.AppendHtml("<span>");
                    output.Content.Append($"{i + 1}");
                    output.Content.AppendHtml("</span>");
                    output.Content.AppendHtml("</div>");
                }
                else
                {
                    output.Content.AppendHtml($"<a class=\"Page\" href=\"?page={i + 1}\">");  //&{RouteUrl}\">");
                    output.Content.AppendHtml("<span>");
                    output.Content.Append($"{i + 1}");
                    output.Content.AppendHtml("</span>");
                    output.Content.AppendHtml("</a>");
                }
            }

            output.PostContent.AppendHtml(@"</div>");
        }
    }
}