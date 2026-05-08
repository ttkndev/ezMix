using System;
using System.Linq;
using System.Windows;

namespace ezMix.App.Services
{
    /// <summary>
    /// ThemeService – Dịch vụ đổi theme (Dark/Light) khi đang chạy ứng dụng.
    ///
    /// CÁCH HOẠT ĐỘNG:
    /// - WPF dùng MergedDictionaries để stack các ResourceDictionary.
    /// - Khi đổi theme, ta tìm entry hiện tại (ThemeDark/ThemeLight),
    ///   xóa đi rồi thêm entry mới vào đúng vị trí ban đầu.
    /// - Vì các Brush dùng {DynamicResource}, WPF tự cập nhật UI ngay lập tức.
    ///
    /// CÁCH DÙNG (trong ViewModel hoặc code-behind):
    ///   ThemeService.Instance.ToggleTheme();
    ///   bool isDark = ThemeService.Instance.IsDarkMode;
    ///
    /// ĐĂNG KÝ VỚI DI CONTAINER (trong App.xaml.cs hoặc Startup):
    ///   services.AddSingleton&lt;ThemeService&gt;();
    /// </summary>
    public class ThemeService
    {
        // ══ Singleton (hoặc dùng DI) ══
        private static ThemeService? _instance;
        public static ThemeService Instance => _instance ??= new ThemeService();

        // ══ Đường dẫn tới 2 file theme ══
        private const string DarkThemeUri  = "Assets/Styles/ThemeDark.xaml";
        private const string LightThemeUri = "Assets/Styles/ThemeLight.xaml";

        // ══ Trạng thái hiện tại ══
        public bool IsDarkMode { get; private set; } = true;

        // ══ Sự kiện thông báo khi đổi theme ══
        public event Action<bool>? ThemeChanged;

        private ThemeService() { }

        /// <summary>
        /// Đổi qua lại giữa Dark và Light mode.
        /// </summary>
        public void ToggleTheme()
        {
            SetTheme(!IsDarkMode);
        }

        /// <summary>
        /// Đặt theme cụ thể.
        /// </summary>
        /// <param name="isDark">True = Dark Mode, False = Light Mode</param>
        public void SetTheme(bool isDark)
        {
            if (IsDarkMode == isDark) return;

            IsDarkMode = isDark;

            var mergedDicts = Application.Current.Resources.MergedDictionaries;

            // Xác định URI cần xóa và URI cần thêm
            var oldUri = isDark ? LightThemeUri : DarkThemeUri;
            var newUri = isDark ? DarkThemeUri  : LightThemeUri;

            // Tìm ResourceDictionary cũ theo Source URI
            var oldDict = mergedDicts.FirstOrDefault(d =>
                d.Source?.OriginalString?.EndsWith(
                    isDark ? "ThemeLight.xaml" : "ThemeDark.xaml",
                    StringComparison.OrdinalIgnoreCase) == true);

            // Ghi lại vị trí để insert vào đúng chỗ (vị trí 0 = theme luôn load đầu tiên)
            int insertIndex = oldDict != null ? mergedDicts.IndexOf(oldDict) : 0;

            // Xóa theme cũ
            if (oldDict != null)
                mergedDicts.Remove(oldDict);

            // Thêm theme mới vào đúng vị trí
            var newDict = new ResourceDictionary
            {
                Source = new Uri(newUri, UriKind.Relative)
            };
            mergedDicts.Insert(insertIndex, newDict);

            // Thông báo cho các subscriber (ViewModel listen để cập nhật IsDarkMode binding)
            ThemeChanged?.Invoke(IsDarkMode);
        }

        /// <summary>
        /// Load theme từ setting đã lưu (gọi khi khởi động app).
        /// </summary>
        /// <param name="savedIsDark">Giá trị lưu từ user settings</param>
        public void LoadSavedTheme(bool savedIsDark)
        {
            // Mặc định App.xaml đã load ThemeDark.
            // Nếu user cần Light, swap ngay khi startup.
            IsDarkMode = true; // Reflect trạng thái mặc định trong App.xaml
            if (!savedIsDark)
                SetTheme(false);
        }
    }
}
