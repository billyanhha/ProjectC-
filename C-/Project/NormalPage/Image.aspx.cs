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
    public partial class Image : System.Web.UI.Page
    {

        string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.QueryString["pid"];
            string imageId = Request.QueryString["imageId"];

            if (!string.IsNullOrEmpty(pid) && !string.IsNullOrEmpty(imageId))
            {
                if (!IsPostBack)
                {
                    renderImage(pid, imageId);
                }
            }
            else
            {
                Response.Redirect("/error");
            }
        }

        private void renderImage(string pid, string imageId)
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = "Select [image_data] , [contentType] from [images] where [index] = @imageId and [product_id] = @pid";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@imageId", imageId));
                command.Parameters.Add(new SqlParameter("@pid", pid));

                connection.Open();
                ChocuModel.Image image = new ChocuModel.Image();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    image.data = dr["image_data"] as byte[];
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

            } finally
            {
                connection.Close();
            }
        }
    }
}
