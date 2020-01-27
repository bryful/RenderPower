using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BRY;

using Codeplex.Data;
/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace RenderPower
{
    public partial class Form1 : Form
    {
        private string m_WatchFolder = "";
        public string WatchFolder
        {
            get { return m_WatchFolder; }

            set
            {
                m_WatchFolder = value;
                ChkWatchFolder();
            }
        }
        //-------------------------------------------------------------
        private bool m_IsStartup = false;
        public bool IsStartup
        {
            get { return m_IsStartup; }
            set
            {
                if (m_IsStartup != value)
                {
                    m_IsStartup = value;
                    if (CbIsStartup.Checked != value)
                    {
                        CbIsStartup.Checked = value;
                    }
                }
            }
        }
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            CbIsStartup.CheckedChanged += CbStartAndStart_CheckedChanged;
        }
        //-------------------------------------------------------------
        private void CbStartAndStart_CheckedChanged(object sender, EventArgs e)
        {
            m_IsStartup = CbIsStartup.Checked;
        }

        /// <summary>
        /// コントロールの初期化はこっちでやる
        /// </summary>
        protected override void InitLayout()
        {
            base.InitLayout();
        }
        //-------------------------------------------------------------
        /// <summary>
        /// フォーム作成時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //設定ファイルの読み込み
            JsonPref pref = new JsonPref();
            if (pref.Load())
            {
                bool ok = false;
                Size sz = pref.GetSize("Size", out ok);
                if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                string s = pref.GetString("WatchFolder", out ok);
                if (ok) WatchFolder = s;
                bool iss = pref.GetBool("IsStartup", out ok);
                if (ok)
                {
                    CbIsStartup.Checked = iss;
                    IsStartup = iss;
                }

            }
            this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
        }
        //-------------------------------------------------------------
        /// <summary>
        /// フォームが閉じられた時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //設定ファイルの保存
            JsonPref pref = new JsonPref();
            pref.SetSize("Size", this.Size);
            pref.SetPoint("Point", this.Location);

            pref.SetString("WatchFolder", m_WatchFolder);
            pref.SetBool("IsStartup", m_IsStartup);
            pref.Save();

        }
        //-------------------------------------------------------------
        /// <summary>
        /// ドラッグ＆ドロップの準備
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// ドラッグ＆ドロップの本体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(files.Length>0)
            {
                foreach(string p in files)
                {
                    if (Directory.Exists(p)==true)
                    {
                        WatchFolder = p;
                        break;
                    }
                }
            }

        }
        //-------------------------------------------------------------
        /// <summary>
        /// ダミー関数
        /// </summary>
        /// <param name="cmd"></param>
        public void GetCommand(string[] cmd)
        {
            if (cmd.Length > 0)
            {
                foreach (string s in cmd)
                {
                    listBox1.Items.Add(s);
                }
            }
        }
        /// <summary>
        /// メニューの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // ******************************************************************************
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ******************************************************************************
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppInfoDialog.ShowAppInfoDialog();
        }
        // ******************************************************************************
        private void BtnSelectWatchFolder_Click(object sender, EventArgs e)
        {
            SelectWatchFolder();
        }
        // ******************************************************************************
        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectWatchFolder();
        }
        // ******************************************************************************
        private void SelectWatchFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select Watch folder";
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.SelectedPath = m_WatchFolder;
            dlg.ShowNewFolderButton = false;

            //ダイアログを表示する
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {

                WatchFolder = dlg.SelectedPath;
            }
        } 
        private void ChkWatchFolder()
        {
            BtnWatchStop.Enabled = false;
            bool ok = Directory.Exists(m_WatchFolder);
            BtnWatchStart.Enabled = ok;
            CbIsStartup.Enabled = ok;
            if (ok == false)
            {
                m_WatchFolder = "";
                TbWatchFolder.Text = "";
            }
            else
            {
                if (TbWatchFolder.Text != m_WatchFolder)
                {
                    TbWatchFolder.Text = m_WatchFolder;
                }
            }
        }
        // ******************************************************************************
    }
}
