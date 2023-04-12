﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mikeys_Mummy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-next")]
    public class PaginationTagHelper : TagHelper
    {
        //dynamically creating the page links
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageNext { get; set; } //This the same thing as the "page-next" attribute for the tag helper
        public string PageAction { get; set; } //this will tell you which page to go to with the button
        public string PageClass { get; set; } //This allows you to make css class for each page 
        public bool PageClassEnabled { get; set; } //this will show if you are on that num of Page using the diff css btn classes
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i < (PageNext.TotalPages + 1); i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageNext.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                tb.AddCssClass(PageClass); //This allows you to make class for each page 
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}
