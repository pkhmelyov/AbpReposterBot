using Microsoft.AspNetCore.Razor.TagHelpers;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.TagHelpers
{
    [HtmlTargetElement("fancy-checkbox", TagStructure = TagStructure.WithoutEndTag)]
    public class FancyCheckboxTagHelper : TagHelper
    {
        private const string CHECKED = "check_box";
        private const string UNCHECKED = "check_box_outline_blank";
        public bool Checked { get; set; }
        public string Color { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "i";
            output.Attributes.SetAttribute("class", "material-icons");
            output.Attributes.SetAttribute("style", $"color: {Color}");
            output.Content.SetContent(Checked ? CHECKED : UNCHECKED);
        }
    }
}