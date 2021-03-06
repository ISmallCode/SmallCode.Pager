﻿using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.Pager
{
    public static class HtmlHelper
    {
        public static IHtmlContent PagedListPager(this IHtmlHelper html,
                                                   IPageList list,
                                                   Func<int, string> generatePageUrl)
        {
          
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul = CompleteUlBefore(ul, list, generatePageUrl);
            for (int i = 1; i <= list.PageCount; i++)
            {
                string temp = generatePageUrl(i);
                ul.InnerHtml.Append(GenerateItem(temp, i, list.PageNumber));
            }
            ul = CompleteUlAfter(ul, list, generatePageUrl);
            return ul;
        }

        public static TagBuilder GenerateItem(string href, int page, int index)
        {
            TagBuilder link = new TagBuilder("a");
            link.Attributes["href"] = href;
            link.InnerHtml.SetContent(page.ToString());
            TagBuilder li = new TagBuilder("li");
            if (page == index)
            {
                li.AddCssClass("active");
            }
            li.InnerHtml.SetContent(link);
            return li;
        }

        public static TagBuilder CompleteUlBefore(TagBuilder ul, IPageList list, Func<int, string> generatePageUrl)
        {
            if (list.PageCount >= list.PageNumber && list.PageNumber > 1)
            {
                TagBuilder nextLi = new TagBuilder("li");
                TagBuilder LastA = new TagBuilder("a");
                LastA.Attributes["href"] = generatePageUrl(list.PageNumber - 1);
                LastA.InnerHtml.SetContent("上一页");
                nextLi.InnerHtml.SetContent(LastA);
                ul.InnerHtml.Append(nextLi);
            }
            return ul;
        }

        public static TagBuilder CompleteUlAfter(TagBuilder ul, IPageList list, Func<int, string> generatePageUrl)
        {
            if (list.PageCount > list.PageNumber && list.PageNumber >= 1)
            {
                TagBuilder nextLi = new TagBuilder("li");
                TagBuilder nextA = new TagBuilder("a");
                nextA.Attributes["href"] = generatePageUrl(list.PageNumber + 1);
                nextA.InnerHtml.SetContent("下一页");
                nextLi.InnerHtml.SetContent(nextA);
                ul.InnerHtml.Append(nextLi);
            }
            return ul;
        }
    }
}
