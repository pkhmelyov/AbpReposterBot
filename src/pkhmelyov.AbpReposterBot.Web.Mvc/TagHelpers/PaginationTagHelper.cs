using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.TagHelpers
{
    [HtmlTargetElement("pagination", TagStructure = TagStructure.WithoutEndTag)]
    public class PaginationTagHelper : TagHelper
    {
        public int TotalItemsCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageNumber { get; set; }
        public Func<int, string> BuildUrl { get; set; }

        private bool ShouldBeShown => ((float) TotalItemsCount) / PageSize > 1;
        private int PagesCount => TotalItemsCount / PageSize + TotalItemsCount % PageSize;
        private bool IsFirstPage => CurrentPageNumber == 1;
        private bool PossibleGoBack => CurrentPageNumber > 1;
        private bool PossibleGoForward => CurrentPageNumber < PagesCount;
        private bool IsLastPage => CurrentPageNumber == PagesCount;
        private int FirstPageToDisplay
        {
            get
            {
                int x = CurrentPageNumber - 2;
                return x < 1 ? 1 : x;
            }
        }
        private int LastPageToDisplay
        {
            get
            {
                int x = CurrentPageNumber + 2;
                return x > PagesCount ? PagesCount : x;
            }
        }
        private string FirstPageClass => !IsFirstPage ? "waves-effect" : "disabled";
        private string PreviousPageClass => PossibleGoBack ? "waves-effect" : "disabled";
        private string NthPageClass(int i) => CurrentPageNumber != i ? "waves-effect" : "active";
        private string NextPageClass => PossibleGoForward ? "waves-effect" : "disabled";
        private string LastPageClass => !IsLastPage ? "waves-effect" : "disabled";
        private string FirstPageLink => !IsFirstPage
            ? $@"<a href=""{BuildUrl(1)}""><i class=""material-icons"">first_page</i></a>"
            : @"<a href=""#""><i class=""material-icons"">first_page</i></a>";
        private string PreviousPageLink => PossibleGoBack
            ? $@"<a href=""{BuildUrl(CurrentPageNumber - 1)}""><i class=""material-icons"">chevron_left</i></a>"
            : @"<a href=""#""><i class=""material-icons"">chevron_left</i></a>";
        private string NextPageLink => PossibleGoForward
            ? $@"<a href=""{BuildUrl(CurrentPageNumber + 1)}""><i class=""material-icons"">chevron_right</i></a>"
            : @"<a href=""#""><i class=""material-icons"">chevron_right</i></a>";
        private string LastPageLink => !IsLastPage
            ? $@"<a href=""{BuildUrl(PagesCount)}""><i class=""material-icons"">last_page</i></a>"
            : @"<a href=""#""><i class=""material-icons"">last_page</i></a>";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!ShouldBeShown)
            {
                output.SuppressOutput();
                return;
            }

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "ul";
            output.Attributes.Add("class", "pagination");
            output.PreContent.SetHtmlContent($@"
                <li class=""{FirstPageClass}"">{FirstPageLink}</li>
                <li class=""{PreviousPageClass}"">{PreviousPageLink}</li>
            ");
            for(int i = FirstPageToDisplay; i <= LastPageToDisplay; i++)
            {
                output.Content.AppendHtml($@"
                    <li class=""{NthPageClass(i)}""><a href=""{BuildUrl(i)}"">{i}</a></li>
                ");
            }
            output.PostContent.SetHtmlContent($@"
                <li class=""{NextPageClass}"">{NextPageLink}</li>
                <li class=""{LastPageClass}"">{LastPageLink}</li>
            ");
        }
    }
}