using SimpleEFExample.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleEFExample
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public string Action { get {
                return Request.QueryString["Action"];
            }
        }
        public string ProductID
        {
            get
            {
                return Request.QueryString["ProductID"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                Initialize();                
            }
        }
        public void LoadCategories()
        {
            using (NorthwindDataContext context = new NorthwindDataContext())
            {
                List<Categories> categories = context.Categories.ToList();
                ddlCategories.DataSource = categories;
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataBind();
                if (Request.QueryString["CategoryID"] != null)
                    ddlCategories.SelectedValue= Request.QueryString["CategoryID"];

            }
        }

        public void Initialize() {
            LoadCategories();
            btnSave.Text = Action;
            if (!string.IsNullOrEmpty(Request.QueryString["ProductID"]))
            {
                var productID = Convert.ToInt32(ProductID);
                using (NorthwindDataContext db=new NorthwindDataContext())
                {
                    Products product = db.Products.FirstOrDefault(p => p.ProductID == productID);
                    if (product!=null)
                    {
                        txtProductName.Text = product.ProductName;
                        txtInStock.Text = product.UnitsInStock.ToString();
                        txtUnitPrice.Text = product.UnitPrice.ToString();
                       ddlCategories.SelectedValue = product.CategoryID.ToString();                                              
                    }                    
                }
            }           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Action == "Add")
            {
                AddNewProduct();
            }
            else if (Action == "Edit")
            {
                UpdateProduct();
            }
            else if (Action == "Delete")
            {
                DeleteProduct();
            }
            Response.Redirect($"~/ProductList.aspx?CategoryID={ddlCategories.SelectedValue}");
        }

        private void DeleteProduct()
        {
            var productID = Convert.ToInt32(ProductID);
            using (NorthwindDataContext db = new NorthwindDataContext())
            {
                var product = db.Products.FirstOrDefault(p => p.ProductID == productID);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        private void UpdateProduct()
        {
            var productID = Convert.ToInt32(ProductID);
            int unitsInStock = txtInStock.Text != string.Empty ? Convert.ToInt32(txtInStock.Text) : 0;
            decimal unitPrice = txtUnitPrice.Text != string.Empty ? Convert.ToDecimal(txtUnitPrice.Text) : 0.0m;
            using (NorthwindDataContext db = new NorthwindDataContext())
            {
                var product = db.Products.FirstOrDefault(p => p.ProductID == productID);
                product.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                product.ProductName = txtProductName.Text;
                product.Discontinued = chkDiscontinued.Checked ? true : false;
                product.UnitsInStock = (short)unitsInStock;
                product.UnitPrice = unitPrice;                
                db.SaveChanges();
            }
        }

        private void AddNewProduct()
        {
            int unitsInStock = txtInStock.Text != string.Empty ? Convert.ToInt32(txtInStock.Text) : 0;
            decimal unitPrice = txtUnitPrice.Text != string.Empty ? Convert.ToDecimal(txtUnitPrice.Text) : 0.0m;
            Products product = new Products()
            {
                CategoryID = Convert.ToInt32(ddlCategories.SelectedValue),
                ProductName = txtProductName.Text,
                Discontinued = chkDiscontinued.Checked ? true : false,
                UnitsInStock = (short)unitsInStock,
                UnitPrice = unitPrice
            };

            using (NorthwindDataContext db = new NorthwindDataContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}