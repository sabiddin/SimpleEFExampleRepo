using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleEFExample.DAL;

namespace SimpleEFExample
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            using (NorthwindDataContext context = new NorthwindDataContext())
            {
                List<Categories> categories = context.Categories.ToList();
                gvCategories.DataSource = categories;
                gvCategories.DataBind();
            }
        }
    }
}