using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ImageCode
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tmp = RndNum(4);
            HttpCookie a = new HttpCookie("ImageV", tmp);
            Response.Cookies.Add(a);
            this.ValidateCode(tmp);
        }
        private void ValidateCode(string VNum)
        {

            Bitmap Img = null;
            Graphics g = null;
            MemoryStream ms = null;
            int gheight = VNum.Length * 12;
            Img = new Bitmap(gheight, 25);
            g = Graphics.FromImage(Img);
            //生成随机生成器
            Random random = new Random();
            //背景颜色
            g.Clear(Color.White);
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(Img.Width);
                int y = random.Next(Img.Height);
                Img.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            int z =6;//干扰线条数
            for (int i = 0; i < z; i++)
            {
                int x1 = random.Next(Img.Width);
                int x2 = random.Next(Img.Width);
                int y1 = random.Next(Img.Height);
                int y2 = random.Next(Img.Height);
                int r = random.Next(255);
                int green = random.Next(255);
                int b = random.Next(255);
                g.DrawLine(new Pen(Color.FromArgb(r,green,b), 1), x1, y1, x2, y2);//根据坐标画线
            }
            //文字字体
            Font f = new Font("Arial Black ", 12);
            //文字颜色
            SolidBrush s = new SolidBrush(Color.Blue);
            g.DrawString(VNum, f, s, 3, 3);
            ms = new MemoryStream();
            Img.Save(ms, ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "image/Jpeg ";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            Img.Dispose();
            Response.End();
        }
        private string RndNum(int VcodeNum)
        {
            string Vchar = "2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,M,N,P" +
            ",Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,g,k,m,n,p,q,r,s,t,u,v,w,x,y,z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = " ";
            int temp = -1;
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(54);
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
    }
}