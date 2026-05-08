namespace ezMix.App.Models
{
    public class FooterLink
    {
        public string Label { get; }
        public string ActionValue { get; }

        public FooterLink(string label, string actionValue)
        {
            Label = label;
            ActionValue = actionValue;
        }
    }
}
