using System.Windows.Forms;

namespace MonitorBlackOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ディスプレイ全部しゅとく
            Screen[] screens = Screen.AllScreens;
            // 取得したディスプレイ全部にまっくろなだけのフォームをはりつける
            foreach (Screen screen in screens)
            {
                var window = new CoverWindow { Location = screen.Bounds.Location };
                window.Show();
            }

            Application.Run();
        }
    }
}
