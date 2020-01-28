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

namespace RenderPower
{
    public class RenderWatcher
    {
        // ******************************************************************
        public delegate void ChangeEventHandler(object sender, FileSystemEventArgs e);
        public event ChangeEventHandler Changed;
        protected virtual void OnChanged(FileSystemEventArgs e)
        {
            Changed?.Invoke(this, e);
        }
        // ******************************************************************
        public delegate void RifListupEventHandler(object sender, EventArgs e);
        public event RifListupEventHandler RifListuped;
        protected virtual void OnRifListuped(EventArgs e)
        {
            RifListuped?.Invoke(this, e);
        }
        // ******************************************************************
        public delegate void WatchStartEventHandler(object sender, EventArgs e);
        public event WatchStartEventHandler Watchsterted;
        protected virtual void OnWatchsterted(EventArgs e)
        {
            Watchsterted?.Invoke(this, e);
        }
        // ******************************************************************
        private bool m_IsWatching = false;
        public bool IsWatching {  get { return m_IsWatching; } }
        // ******************************************************************

        private FileSystemWatcher m_watch = null;
        private string m_WatchFolder = "";
        private string m_WatchFilter = "";

        // ******************************************************************
        private List<FileInfo> m_RifFiles = new List<FileInfo>();
        public string[] RifFiles
        {
            get {
                string [] ret = new string[m_RifFiles.Count];
                for (int i=0; i<ret.Length;i++)
                {
                    ret[i] = m_RifFiles[i].FullName;
                }
                return ret;
            }
        }

        // ******************************************************************
        public string WatchFolder
        {
            get { return m_WatchFolder; }
            set
            {
                if (m_IsWatching == false)
                {
                    m_WatchFolder = value;
                }
            }
        }
        // ******************************************************************
        public string WatchFilter
        {
            get { return m_WatchFilter; }
            set
            {
                if (m_IsWatching == false)
                {
                    m_WatchFilter = value;
                }
            }
        }
        // ******************************************************************
        public RenderWatcher()
        {
            if (m_WatchFilter == "") m_WatchFilter = "*" + RenderInfoFile.RifExt;

        }
        // ******************************************************************
        public void StartWatch(Form form)
        {
            if (m_watch != null) return;
            m_RifFiles = RifListupFiles(m_WatchFolder);
            OnRifListuped(new EventArgs());

            m_watch = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess,
                Filter = m_WatchFilter,
                Path = m_WatchFolder

            };


            m_watch.Created += ListUpdate;
            m_watch.Changed += ListUpdate;
            m_watch.Renamed += ListUpdate;
            m_watch.Deleted += ListUpdate;
            m_watch.SynchronizingObject = form;
            m_watch.EnableRaisingEvents = true;
            m_IsWatching = true;
            OnWatchsterted(new EventArgs());
        }
        // ******************************************************************
        private void ListUpdate(object sender, FileSystemEventArgs e)
        {
            OnChanged(e);
            List<FileInfo> lst = RifListupFiles(m_WatchFolder);
            bool igg = true;
            int cnt = lst.Count;
            if (m_RifFiles.Count ==cnt)
            {
                igg = false;
                for ( int i=0; i<cnt;i++)
                {
                    if (m_RifFiles[i].FullName != lst[i].FullName)
                    {
                        igg = true;
                        break;
                    }
                    else if (m_RifFiles[i].LastWriteTime != lst[i].LastWriteTime)
                    {
                        igg = true;
                        break;
                    }
                }
            }
            if (igg==true)
            {
                m_RifFiles.Clear();
                m_RifFiles = lst.ToList<FileInfo>();
                OnRifListuped(new EventArgs());
            }
        }
        // ******************************************************************
        public void StopWatch()
        {
            if (m_watch != null) return;
            {
                m_watch.EnableRaisingEvents = false;
                m_watch.Dispose();
                m_watch = null;
                m_IsWatching = false;
            }
        }
        // ******************************************************************
        private List<FileInfo> RifListupFiles(string p)
        {
            List<FileInfo> ret = new List<FileInfo>();
            if (Directory.Exists(p) == false) return ret;
            string []  lst = Directory.GetFiles(p, m_WatchFilter).OrderBy(f => File.GetLastWriteTime(f)).ToArray<string>();
            if( lst.Length>0)
            {
                foreach(string s in lst)
                {
                    ret.Add(new FileInfo(s));
                }
            }
            return ret;
        }
    }
}
