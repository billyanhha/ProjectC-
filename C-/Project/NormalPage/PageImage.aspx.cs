using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Project.NormalPage
{
    public partial class PageImage : System.Web.UI.Page
    {

        string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["id"] == null)
            {
                Response.Redirect("/error");
            }
            else
            {
                int id;
                bool tryParse = int.TryParse(Page.RouteData.Values["id"].ToString(), out id);
                if (tryParse && id > 0)
                {
                    if (!IsPostBack)
                    {
                        renderImage(id);
                    }
                }
                else
                {

                }
            }
        }

        private void renderImage(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connStr);
                String query = "Select avatar , contentType from users where id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@id", id));
                connection.Open();
                ChocuModel.Image image = new ChocuModel.Image();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    image.data = dr["avatar"] as byte[];
                    image.contentType = dr["contentType"].ToString();
                }
                if (image.data != null)
                {
                    Response.ContentType = (image.contentType);
                    Response.BinaryWrite(image.data);
                    Response.Flush();
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(Server.MapPath("~/") + "images\\default_user.png");
                    // The byte[] to save the data in
                    byte[] data = new byte[fileInfo.Length];
                    using (FileStream fs = fileInfo.OpenRead())
                    {
                        fs.Read(data, 0, data.Length);
                    }

                    string ext = Path.GetExtension(fileInfo.Name);
                    Response.ContentType = (ext);
                    Response.BinaryWrite(data);
                    Response.Flush();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}