using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Solid.WebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]//Razorun içinde nasıl kullanmak istersem öyle isimlendiriyorum
    public class PagingTagHelper:TagHelper
    {
        //kaç tane sayfa
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        //bir sayfada kac veri
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        //page bilgisi
        [HtmlAttributeName("current-category")]
        public int  CurrentCategory{ get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }


        // TagHelper oluşturma
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //html i div içine al
            output.TagName = "div";
            StringBuilder stringbuilder = new StringBuilder(); // bunu nevlemem gerek
            stringbuilder.Append("<ul class='pagination'>"); // yapı sayfalama

            //sayfa 1 den başlar ve safyaSayisi 1 yada 1 e esit oldugunda i birer artar
            for (int i = 1; i <= PageCount; i++)
            {
                //ul içine li bas fakat i eğer CurrentPage ise onu active yap değilse default bas
                stringbuilder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");

                //linki format olarak değeri CurrentCategori ile bas
                stringbuilder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory, i);

                //liyi kapar
                stringbuilder.Append("</li>");
            }
            //sonra bu yapıyı liste olarak HtmlContenin içine bas
            output.Content.SetHtmlContent(stringbuilder.ToString());
            base.Process(context, output);
        }


    }
}
