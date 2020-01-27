using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace RenderPower
{
    public enum RISTATUS
    {
        WAIT = 0,
        RENDERING,
        FINISHED
    }

    public class RenderInfoListItem
    {
        public int Start = 0;
        public int Last = 0;
        public string PCName = "";
        public int Index = 0;
        public RISTATUS Status = RISTATUS.WAIT;
        //
        public RenderInfoListItem()
        {

        }
        public void Init()
        {
            Start = 0;
            Last = 0;
            PCName = "";
            Index = 0;
            Status = RISTATUS.WAIT;
        }
        public string ToStr()
        {
            return String.Format("{0},{1},{2},{3},{4}", Start, Last, PCName, Index,Status);
        }
        public bool FromStr(string s)
        {
            bool ret = false;
            Init();
            if (s .Length<=4) return ret;
            string[] sa = s.Split(',');
            if (sa.Length < 4) return ret;
            int v = 0;
            if (int.TryParse(sa[0],out v))
            {
                Start = v;
            }
            else
            {
                return ret;
            }
            if (int.TryParse(sa[1], out v))
            {
                Last = v;
            }
            else
            {
                return ret;
            }
            PCName = sa[2];
            if (int.TryParse(sa[3], out v))
            {
                Index = v;
            }
            if (int.TryParse(sa[4], out v))
            {
                switch(v)
                {
                    case (int)RISTATUS.WAIT:
                        Status = RISTATUS.WAIT;
                        break;
                    case (int)RISTATUS.RENDERING:
                        Status = RISTATUS.RENDERING;
                        break;
                    case (int)RISTATUS.FINISHED:
                    default:
                        Status = RISTATUS.FINISHED;
                        break;
                }
            }
            ret = true;
            return ret;
        }
    }
    public class RenderInfoList
    {
        public List<RenderInfoListItem> Items = new List<RenderInfoListItem>(); 
        public RenderInfoList()
        {

        }
        // **********************************************************************
        public void MakeList(int s, int l, int bc)
        {
            Items.Clear();
            int len = l - s + 1;
            int c = len / bc;
            int cd = len % bc;
            
            if(c>0)
            {
                for ( int i=0; i<c; i++)
                {
                    RenderInfoListItem ri = new RenderInfoListItem
                    {
                        Start = s + i * bc,
                        Last = s + (i + 1) * bc - 1
                    };
                    Items.Add(ri);
                }
            }
            if(cd>0)
            {
                RenderInfoListItem ri = new RenderInfoListItem
                {
                    Start = s + c * bc,
                    Last = l
                };
                Items.Add(ri);
            }


        }
        // **********************************************************************
        public void Sort()
        {
            Items.Sort((a, b) => a.Start - b.Start);
        }
        // **********************************************************************
        public bool Load(string p)
        {
            bool ret = false;
            if (File.Exists(p) == false) return ret;
            string[] lines = File.ReadAllLines(p, Encoding.GetEncoding("utf-8"));
            if (lines.Length <= 0) return ret;

            for ( int i=0; i< lines.Length;i++)
            {
                RenderInfoListItem ri = new RenderInfoListItem();
                if ( ri.FromStr(lines[i]))
                {
                    Items.Add(ri);
                }
            }
            if (Items.Count <= 0) return ret;
            Sort();
            ret = true;
            return ret;
        }
        // **********************************************************************
        public bool Write(string p)
        {
            bool ret = false;

            try
            {
                int cnt = Items.Count;
                if (cnt <= 0) return ret;

                string str = "";
                for (int i = 0; i < cnt; i++)
                {
                    str += Items[i].ToStr() + "\r\n";
                }
                if( File.Exists(p)==true)
                {
                    File.Delete(p);
                }
                File.WriteAllText(p, str, Encoding.GetEncoding("utf-8"));
                ret = File.Exists(p);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
        // **********************************************************************
    }
}
