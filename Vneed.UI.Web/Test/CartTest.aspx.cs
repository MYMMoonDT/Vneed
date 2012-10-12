using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.Model;
using Vneed.BLL;

namespace Vneed.UI.Web.Test
{
    public partial class CartTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void Refresh()
        {
            //显示当前购物车内容
            //正常情况下，用户名应该是使用AuthenticationService.GetUser().UserID获得的(注意没有登陆时的跳转判断)，这里为了方便演示，使用了硬编码的UserID
            Table1.Rows.Clear();
            List<CartRecord> currentCart = CartService.GetCartRecodByUserID(8);
            foreach (CartRecord cr in currentCart)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = ItemService.GetItemByItemID(cr.ItemID).Title;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "    " + cr.Count + "个";
                tr.Cells.Add(tc);
                Table1.Rows.Add(tr);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //添加物品1，这个按钮模拟了单个商品页面上的“加入购物车”按钮
            CartRecord cr = new CartRecord();
            cr.UserID = 8;
            cr.ItemID = "55ddd15c-f6b7-4b2f-aa1d-ac9382510e8a";
            cr.Count = 1;
            CartService.AddCartRecord(cr);
            Refresh();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //修改物品2的数量，这个按钮模拟了购物车页面上修改商品数量的按钮
            //“从0到1的添加”与“从1到N的更新”两个操作统一使用AddCartRecord接口
            CartRecord cr = new CartRecord();
            cr.UserID = 8;
            cr.ItemID = "b0066833-211a-4f63-ad19-e43c77edae8d";
            cr.Count = Int32.Parse(TextBox1.Text);
            CartService.AddCartRecord(cr);
            Refresh();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //这个按钮模拟了购物车页面上删除商品的按钮
            //只需指定UserID与ItemID即可
            CartRecord cr = new CartRecord();
            cr.UserID = 8;
            cr.ItemID = "55ddd15c-f6b7-4b2f-aa1d-ac9382510e8a";
            CartService.DeleteCartRecord(cr);
            Refresh();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }
    }
}