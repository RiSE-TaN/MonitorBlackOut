using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonitorBlackOut
{
    /// <summary>
    /// 黒いウィンドウが画面を覆う！
    /// </summary>
    internal class CoverWindow : Form
    {
        //================================================
        // 定数
        //================================================
        // Binary Black Hole
        private static readonly string windowName = "BLACK OUT";
        private static readonly Color defaultColor = Color.Black;

        //===============================================
        // メンバ変数
        //===============================================
        private readonly ApplicationHandler appHandler;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mutexID"></param>
        public CoverWindow()
        {
            // シングルトンのインスタンス取得
            appHandler = ApplicationHandler.GetInstance();
            // しょきか
            InitializeComponent();
        }

        //================================================
        // プライベートメソッド
        //================================================
        /// <summary>
        /// フォームの初期化処理
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            // みためのせってい
            this.Text = windowName;
            this.BackColor = defaultColor;
            this.ShowIcon = false;
            // フォームの開始位置をLocationで変更できるように
            this.StartPosition= FormStartPosition.Manual;
            // フルスクリーン表示
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            // イベントをとうろく
            this.Click += new EventHandler(WindowClick);
            this.KeyDown += new KeyEventHandler(WindowKeyDown);
            this.FormClosed += new FormClosedEventHandler(WindowClosed);

            this.ResumeLayout(false);
        }

        //==================================================
        // フォームイベント
        //==================================================
        private void WindowClick(object sender, EventArgs e)
        {
            appHandler.ApplicationExit();
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            // Enter固定なのどうかと思うので、気が向いたら別のところに出したい
            if (e.KeyCode == Keys.Enter)
            {
                appHandler.ApplicationExit();
            }
        }

        private void WindowClosed(object sender, FormClosedEventArgs e)
        {
            // これが最後に閉じられたフォームだった時に、アプリケーションを終了させる
            // 閉じるボタンで順次閉じられていった場合の対処
            if (Application.OpenForms.Count == 0)
            {
                appHandler.ApplicationExit();
            }
        }
    }
}
