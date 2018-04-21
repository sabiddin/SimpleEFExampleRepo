using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleEFExample.DAL;

namespace SimpleEFExample
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        public void BindData() {
            if (Request.QueryString["CategoryID"]!=null)
            {
                var CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                using (NorthwindDataContext context = new NorthwindDataContext())
                {
                    List<Products> products = context.Products.Where(p => p.CategoryID == CategoryID).ToList();
                    gvProducts.DataSource = products;
                    gvProducts.DataBind();                    
                    lblMessage.Text = $"{products.Count} products were found";                    
                }
            }
            else
            {
                lblMessage.Text = "Error: Category ID was not provided";
            }
           
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["CategoryID"] != null)
            {
                var CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                Response.Redirect($"~/AddProduct.aspx?CategoryID={CategoryID}&Action=Add");
            }
            else
            {
                lblMessage.Text = "Error: Category ID is needed.";
            }
        }
    }
}