using ezMix.App.Assets.Core;
using ezMix.App.Models;
using System.Collections.ObjectModel;

namespace ezMix.App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Title => "Giới thiệu";
        public string Summary => "ezMix tập trung xây dựng giao diện chuyên nghiệp, dễ dùng và ổn định trên mọi kích thước màn hình.";

        public ObservableCollection<string> Capabilities { get; } = new ObservableCollection<string>
        {
            "Thiết kế giao diện đồng bộ theo design system",
            "Tư vấn kiến trúc và nâng cấp ứng dụng WPF",
            "Triển khai tính năng mới nhanh theo yêu cầu"
        };

        public ObservableCollection<FooterLink> ContactItems { get; } = new ObservableCollection<FooterLink>
        {
            new FooterLink("Website", "https://ttkndev.com"),
            new FooterLink("Facebook", "https://www.facebook.com"),
            new FooterLink("Youtube", "https://www.youtube.com"),
            new FooterLink("Zalo", "https://zalo.me/g/rxncpe995"),
            new FooterLink("Email", "mailto:ttkndev@gmail.com"),
            new FooterLink("Hotline", "tel:+84775426999")
        };
    }
}
