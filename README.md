# ezMix

Ứng dụng desktop WPF (.NET Framework) theo mô hình MVVM, tập trung vào kiến trúc rõ ràng và giao diện responsive trên nhiều độ phân giải.

## Tech stack
- C# / WPF
- .NET Framework 4.8
- `Microsoft.Extensions.DependencyInjection` cho DI
- ResourceDictionary cho Design Tokens (Color/Brush/Semantic)

## Cấu trúc chính
- `ViewModels/`: Quản lý state và command theo từng màn hình.
- `Views/`: Giao diện XAML cho Home/About.
- `Services/`: Tách navigation và mở external links để dễ test.
- `Assets/Styles/`: Token màu, brush, semantic và style component.

## Build & Run
### Yêu cầu
- Windows + Visual Studio 2022 (hoặc mới hơn)
- .NET Framework 4.8 Developer Pack

### Chạy ứng dụng
1. Mở `src/ezMix/ezMix.slnx` bằng Visual Studio.
2. Chọn project startup: `ezMix.App`.
3. Build solution (`Ctrl+Shift+B`).
4. Run (`F5`).

## Coding conventions
- Theo MVVM: không đặt business logic trong code-behind View.
- ViewModel chỉ giao tiếp external resource qua service interface.
- Token giao diện được quản lý theo lớp:
  - `Colors.xaml`: mã màu gốc.
  - `Brushes.xaml`: brush từ color token.
  - `SemanticTokens.xaml`: token ngữ nghĩa cho text/overlay.
- Ưu tiên layout co giãn (`Grid`, `ScrollViewer`, `WrapPanel` có kiểm soát) để tránh vỡ UI ở kích thước nhỏ.
