using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RenderPower
{
    public class RenderInfoFile
    {
        public static readonly string RifExt = ".rif";
        public static readonly string RifListExt = ".rifList";
        public static readonly string StopOrderExt = ".rifStopOrder";


        private string m_AerenderPath = "";
        public string AerenderPath
        {
            get { return m_AerenderPath; }
        }
        private string m_AepPath = "";
        public string AepPath
        {
            get { return m_AepPath; }
        }
        private int m_BlockCount = 50;
        public int BlockCount
        {
            get { return m_BlockCount; }
        }
        private int m_StartFrame = 1;
        public int StartFrame
        {
            get { return m_StartFrame; }
        }
        private int m_EndFrame = 1;
        public int EndFrame
        {
            get { return m_EndFrame; }
        }        
        // ************************************************************
        public RenderInfoFile()
        {
            Init();
        }
        // ************************************************************
        public void Init()
        {
            m_AerenderPath = "";
            m_AepPath = "";
            m_BlockCount = 50;
            m_StartFrame = 0;
            m_EndFrame = 0;
        }
        // ************************************************************
        private string Wtc(string s)
        {
            string ret = s.Trim();
            if (ret.Length < 2) return ret;

            if( (ret[0]=='\"')&& (ret[s.Length-1] == '\"'))
            {
                ret = ret.Substring(1, ret.Length - 2);
            }
            return ret;
        }
        // ************************************************************
        public bool Load(string p)
        {
            bool ret = false;
            Init();
            if (File.Exists(p) == false) return ret;

            try
            {
                string[] lines = File.ReadAllLines(p, Encoding.GetEncoding("utf-8"));
                if (lines.Length>=6)
                {
                    if (lines[0] == "RIF v1.00")
                    {
                        foreach (string s in lines)
                        {
                            string s2 = s.Trim();
                            if ((s2 == "") || (s2[0] == '#')) continue;
                            string[] sa = s2.Split(':');
                            if (sa.Length >= 2)
                            {
                                string tag = sa[0].ToLower();
                                int v = 0;
                                switch (tag)
                                {
                                    case "aerender":
                                        string aer = Wtc(sa[1]);
                                        if (File.Exists(aer) == true) {
                                            m_AerenderPath = aer;
                                        }
                                        break;
                                    case "aep":
                                        string aep = Wtc(sa[1]);
                                        if (File.Exists(aep) == true)
                                        {
                                            m_AepPath= aep;
                                        }
                                        break;
                                    case "blockcount":
                                        if (int.TryParse(sa[1], out v))
                                        {
                                            if (v >= 1)
                                            {
                                                m_BlockCount = v;
                                            }

                                        }
                                        break;
                                    case "startframe":
                                        if (int.TryParse(sa[1], out v))
                                        {
                                            if (v >= 0)
                                            {
                                                m_StartFrame = v;
                                            }

                                        }
                                        break;
                                    case "lastframe":
                                        if (int.TryParse(sa[1], out v))
                                        {
                                            if (v >= 0)
                                            {
                                                m_StartFrame = v;
                                            }

                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                ret = ((m_AerenderPath != "") && (m_AepPath != "") && (m_BlockCount > 0) && (m_StartFrame >= 0) && (m_StartFrame <= m_EndFrame));
            }
            catch
            {
                ret = false;
            }
            finally
            {
            }
            return ret;
        }
        // ************************************************************
    }
}
