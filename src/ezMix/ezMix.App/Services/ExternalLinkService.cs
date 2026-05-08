using System.Diagnostics;

namespace ezMix.App.Services
{
    public class ExternalLinkService : IExternalLinkService
    {
        public void Open(string urlOrScheme)
        {
            if (string.IsNullOrWhiteSpace(urlOrScheme))
            {
                return;
            }

            var startInfo = new ProcessStartInfo(urlOrScheme)
            {
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }
    }
}
