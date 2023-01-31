using System.Windows.Forms;

namespace MonitorBlackOut
{
    /// <summary>
    /// Application.Exit()を何度も呼ばないように管理するためのシングルトン
    /// </summary>
    public sealed class ApplicationHandler
    {
        // シングルトンのテンプレその1 自身のクラスのインスタンスをprivateで持たせる
        private static ApplicationHandler instance = new ApplicationHandler();
        private object lockObj = new object();
        // 管理用フラグ
        private bool willOfExit = false;

        /// <summary>
        /// シングルトンのテンプレその2 コンストラクタはprivate
        /// </summary>
        private ApplicationHandler()
        { 
        }

        /// <summary>
        /// シングルトンのテンプレその3 使うときはこれを呼んでインスタンスを取得してください
        /// </summary>
        /// <returns></returns>
        public static ApplicationHandler GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// フォームを全部閉じます。既に閉じようとしている場合に呼ばれても何もしません。
        /// </summary>
        public void ApplicationExit()
        {
            lock (lockObj)
            {
                if (!willOfExit)
                {
                    willOfExit = true;
                    Application.Exit();
                }
            }
        }
    }
}
