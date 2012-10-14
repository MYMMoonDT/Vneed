using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vneed.BLL;
using Vneed.Model;

namespace Vneed.UI.Web.WebUserControl.V2
{
    public partial class CartTableControl : System.Web.UI.UserControl
    {
        private bool isReayOnly = false;

        public bool IsReadyOnly
        {
            get { return this.isReayOnly; }
            set { this.isReayOnly = value; }
        }

        public delegate void UpdateProductNumInCartEventHandler();

        private UpdateProductNumInCartEventHandler _UpdateProductNumInCart;

        public event UpdateProductNumInCartEventHandler UpdateProductNumInCart
        {
            add 
            {
                this._UpdateProductNumInCart += value;
            }
            remove
            {
                this._UpdateProductNumInCart -= value;
            }
        }

        protected void OnUpdateProductNumInCart()
        {
            if (this._UpdateProductNumInCart != null)
            {
                this._UpdateProductNumInCart.Invoke();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            renderCartTable();
        }

        private TableRow renderCartTableItem(CartRecord cartRecord)
        {
            Item item = ItemService.GetItemByItemID(cartRecord.ItemID);
            TableRow tr = new TableRow();
            
            TableCell tc = new TableCell();
            Panel cartTableItemProductContainer = new Panel();
            cartTableItemProductContainer.CssClass = "cartTableItemProductContainer";
            Panel cartTableItemProductImageContainer = new Panel();
            cartTableItemProductImageContainer.CssClass = "cartTableItemProductImageContainer";
            Image img = new Image();
            img.ImageUrl = item.ImageUrl;
            cartTableItemProductImageContainer.Controls.Add(img);
            Panel cartTableItemProductTextContainer = new Panel();
            cartTableItemProductTextContainer.CssClass = "cartTableItemProductTextContainer";
            Label label = new Label();
            label.Text = item.Title;
            cartTableItemProductTextContainer.Controls.Add(label);
            cartTableItemProductContainer.Controls.Add(cartTableItemProductImageContainer);
            cartTableItemProductContainer.Controls.Add(cartTableItemProductTextContainer);
            tc.Controls.Add(cartTableItemProductContainer);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel cartTableItemNumContainer = new Panel();
            cartTableItemNumContainer.CssClass = "cartTableItemNumContainer";
            if (!isReayOnly)
            {
                cartTableItemNumContainer.Controls.Add(renderProductNumSelector(cartRecord));
            }
            else
            {
                Label numLabel = new Label();
                numLabel.Text = cartRecord.Count.ToString();
                cartTableItemNumContainer.Controls.Add(numLabel);
            }
            tc.Controls.Add(cartTableItemNumContainer);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel cartTableItemPriceContainer = new Panel();
            cartTableItemPriceContainer.CssClass = "cartTableItemPriceContainer";
            Label pricelabel = new Label();
            pricelabel.Text = "￥" + item.Price;
            cartTableItemPriceContainer.Controls.Add(pricelabel);
            tc.Controls.Add(cartTableItemPriceContainer);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel cartTableItemOptionContainer = new Panel();
            cartTableItemOptionContainer.CssClass = "cartTableItemOptionContainer";
            if (!isReayOnly)
            {
                LinkButton deleteLink = new LinkButton();
                deleteLink.Text = "删除";
                deleteLink.ID = "delete_" + cartRecord.ItemID;
                deleteLink.Click += DeleteLinkButton_Click;
                cartTableItemOptionContainer.Controls.Add(deleteLink);
            }
            else
            { 
                
            }
            tc.Controls.Add(cartTableItemOptionContainer);
            tr.Controls.Add(tc);

            return tr;
        }

        private Table renderProductNumSelector(CartRecord cartRecord)
        {
            Table table = new Table();
            TableRow tr = new TableRow();
            
            TableCell tc = new TableCell();
            Panel productDetailMinusProductIcon = new Panel();
            productDetailMinusProductIcon.CssClass = "productDetailMinusProductIcon";
            tc.Controls.Add(productDetailMinusProductIcon);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel panel = new Panel();
            TextBox textBox = new TextBox();
            textBox.CssClass = "productDetailProductNumText";
            textBox.Text = cartRecord.Count.ToString();
            textBox.ID = "num_" + cartRecord.ItemID;
            panel.Controls.Add(textBox);
            tc.Controls.Add(panel);
            tr.Controls.Add(tc);

            tc = new TableCell();
            Panel productDetailPlusProductIcon = new Panel();
            productDetailPlusProductIcon.CssClass = "productDetailPlusProductIcon";
            tc.Controls.Add(productDetailPlusProductIcon);
            tr.Controls.Add(tc);

            table.Controls.Add(tr);
            return table;
        }

        private void renderCartTable()
        {
            this.CartTable.Rows.Clear();
            this.CartTableBottomPanel.Controls.Clear();

            List<CartRecord>  currentCart = CartService.GetCartRecodByUserID(AuthenticationService.GetUser().UserID);
            if (currentCart.Count <= 0)
                return;

            TableRow tr = new TableRow();
            TableHeaderCell th = new TableHeaderCell();
            th.Text = "商品";
            tr.Controls.Add(th);

            th = new TableHeaderCell();
            th.Text = "数量";
            tr.Controls.Add(th);

            th = new TableHeaderCell();
            th.Text = "Vneed价";
            tr.Controls.Add(th);

            th = new TableHeaderCell();
            th.Text = "操作";
            tr.Controls.Add(th);

            this.CartTable.Controls.Add(tr);

            foreach (CartRecord cartRecord in currentCart)
            {
                this.CartTable.Controls.Add(renderCartTableItem(cartRecord));
            }

            renderCartTableBottom(currentCart);
        }

        private void renderCartTableBottom(List<CartRecord> currentCart)
        {
            Panel cartTableBottomContainer = new Panel();
            cartTableBottomContainer.CssClass = "cartTableBottomContainer";
            //Panel cartTableTotalPriceAndOptionContainer = new Panel();
            //cartTableTotalPriceAndOptionContainer.CssClass = "cartTableTotalPriceAndOptionContainer";
            
            Panel cartTableTotalPriceContainer = new Panel();
            cartTableTotalPriceContainer.CssClass = "cartTableTotalPriceContainer";
            Label priceLabel = new Label();
            priceLabel.Text = "总计:&nbsp;" + ProductsTotalPriceInCart(currentCart);
            cartTableTotalPriceContainer.Controls.Add(priceLabel);

            //Panel cartTableOptionContainer = new Panel();
            //cartTableOptionContainer.CssClass = "cartTableOptionContainer";
            //HyperLink continueShoppingHyperLink = new HyperLink();
            //continueShoppingHyperLink.Text = "继续购物&gt;";
            //Button payForProductInCartButton = new Button();
            //payForProductInCartButton.CssClass = "cartTableButton";
            //payForProductInCartButton.Text = "结算";
            //cartTableOptionContainer.Controls.Add(continueShoppingHyperLink);
            //cartTableOptionContainer.Controls.Add(payForProductInCartButton);

            //cartTableTotalPriceAndOptionContainer.Controls.Add(cartTableTotalPriceContainer);
            //cartTableTotalPriceAndOptionContainer.Controls.Add(cartTableOptionContainer);
            cartTableBottomContainer.Controls.Add(cartTableTotalPriceContainer);
            this.CartTableBottomPanel.Controls.Add(cartTableBottomContainer);
        }

        private String ProductsTotalPriceInCart(List<CartRecord> currentCart)
        {
            Decimal totalPrice = 0;
            foreach (CartRecord cartRecord in currentCart)
            {
                totalPrice += cartRecord.Count * ItemService.GetItemByItemID(cartRecord.ItemID).Price;
            }
            return totalPrice.ToString();
        }

        protected void DeleteLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton deleteLinkButton = (LinkButton)sender;
            String deleteItemID = deleteLinkButton.ID.Substring("delete_".Length);
            CartRecord deleteCartRecord = new CartRecord();
            deleteCartRecord.ItemID = deleteItemID;
            deleteCartRecord.UserID = AuthenticationService.GetUser().UserID;
            CartService.DeleteCartRecord(deleteCartRecord);
            //OnUpdateProductNumInCart();
            //renderCartTable();
            Response.Redirect(Request.Url.ToString());
        }
    }
}