namespace ezMix.App.Models
{
    public class FooterLink
    {
        public string Label { get; }
        public string ActionValue { get; }
        public string Icon
        {
            get
            {
                switch (Label)
                {
                    case "Website": return "🌐";
                    case "Facebook": return "📘";
                    case "Youtube": return "▶️";
                    case "Zalo": return "💬";
                    case "Email": return "✉️";
                    case "Hotline": return "📞";
                    default: return "🔗";
                }
            }
        }

        public FooterLink(string label, string actionValue)
        {
            Label = label;
            ActionValue = actionValue;
        }
    }
}
