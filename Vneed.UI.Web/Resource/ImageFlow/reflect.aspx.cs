using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

public partial class reflect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IODrawImage();
    }

    private void IODrawImage()
    {
        string stringwid = Request.QueryString["width"].ToString();
        string imgr = Request.QueryString["img"].ToString();       

       //get image from file
        string strFilename;
        System.Drawing.Image i;
        strFilename = Server.MapPath(imgr);
        i = System.Drawing.Image.FromFile(strFilename);

       //calculate new dimensions to redraw image to new size
        int wid = Convert.ToInt32(stringwid);
        decimal wid_d = Convert.ToDecimal(wid);
        decimal imgwid_d = Convert.ToDecimal(i.Width);
        decimal newhei = (wid_d / imgwid_d) * i.Height;
        int hei = Convert.ToInt32(newhei);  

       //create image
        System.Drawing.Bitmap b = new System.Drawing.Bitmap(wid, (hei) + hei/2, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(b);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawImage(i, 0, 0, wid, hei);

       //create reflection
        i.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
        g.DrawImage(i, 0, hei, wid, hei);

       //add shading to reflection
        string grdblack;
        System.Drawing.Image gr;
        grdblack = Server.MapPath("reflect.png");
        gr = System.Drawing.Image.FromFile(grdblack);
        g.DrawImage(gr, 0, hei, wid, hei);        

       //set the content type
        Response.ContentType = "image/png";        

       //png must be writen to a memory stream to work.
        MemoryStream MemStream = new MemoryStream();
        b.Save(MemStream, System.Drawing.Imaging.ImageFormat.Png);
        MemStream.WriteTo(Response.OutputStream);
        
        b.Dispose();
    }
}