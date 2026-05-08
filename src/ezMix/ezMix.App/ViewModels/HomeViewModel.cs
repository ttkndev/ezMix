using ezMix.App.Assets.Core;
using System.Collections.ObjectModel;

namespace ezMix.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string Title => "Trang chủ";
        public string Description => "Giải pháp xây dựng ứng dụng WPF theo kiến trúc MVVM với UI nhất quán, responsive và dễ mở rộng.";

        public ObservableCollection<string> Highlights { get; } = new ObservableCollection<string>
        {
            "Kiến trúc MVVM tách biệt UI và logic nghiệp vụ",
            "Hệ thống Design Tokens để đồng bộ màu sắc và typography",
            "Khả năng mở rộng module theo từng màn hình",
            "Tối ưu trải nghiệm hiển thị trên nhiều độ phân giải"
        };
    }
}
