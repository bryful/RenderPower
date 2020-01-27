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
        public delegate void ListupEventHandler(object sender, EventArgs e);
        public event ListupEventHandler Listuped;
        protected virtual void OnListuped(EventArgs e)
        {
            Listuped?.Invoke(this, e);
        }
        // ******************************************************************
        private bool m_IsWatching = false;
        public bool IsWatching {  get { return m_IsWatching; } }
        // ******************************************************************

        private FileSystemWatcher m_watch = null;
        private string m_TargetPath = "";
        private string m_TargetFilter = "";

        // ******************************************************************
        private string[] m_ListFiles = new string[0];
        public string[] ListFiles
        {
            get { return m_ListFiles; }
        }

        // ******************************************************************
        public string TargetFolder
        {
            get { return m_TargetPath; }
            set { m_TargetPath = value; }
        }
        // ******************************************************************
        public string TargetFilter
        {
            get { return m_TargetFilter; }
            set { m_TargetFilter = value; }
        }
        // ******************************************************************
        public RenderWatcher()
        {
            if (m_TargetFilter == "") m_TargetFilter = "*.rif";

        }
        // ******************************************************************
        public void StartWatch(Form form)
        {
            if (m_watch != null) return;
            m_ListFiles = ListupFiles(m_TargetPath);
            OnListuped(new EventArgs());

            m_watch = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess,
                Filter = m_TargetFilter,
                Path = m_TargetPath

            };


            m_watch.Created += ListUpdate;
            m_watch.Changed += ListUpdate;
            m_watch.Renamed += ListUpdate;
            m_watch.Deleted += ListUpdate;
            m_watch.SynchronizingObject = form;
            m_watch.EnableRaisingEvents = true;
            m_IsWatching = true;
        }
        // ******************************************************************
        private void ListUpdate(object sender, FileSystemEventArgs e)
        {
            OnChanged(e);
            m_ListFiles = ListupFiles(m_TargetPath);
            OnListuped(new EventArgs());
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
        private string[] ListupFiles(string p)
        {
            string[] ret = new string[0];
            if (Directory.Exists(p) == false) return ret;

            ret = Directory.GetFiles(p, m_TargetFilter);
            return ret;
        }
    }
}
