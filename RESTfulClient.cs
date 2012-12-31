using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using SFWinformsClient.Helpers;
using System.Collections.Generic;
using SFWinformsClient.Model.Product;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using SFWinformsClient.Model.User;
using SFWinformsClient.Model.News;

namespace SFWinformsClient
{
    public partial class RESTfulClient : Form
    {

        #region initialize
        public RESTfulClient()
        {
            InitializeComponent();
            helper = new ClaimsAuthenticationHelper();
        }
        #endregion

        #region Login & Logout


        private void Login_button_Click(object sender, EventArgs e)
        {   

            //set the credentials
            string sfUrl = this.url.Text;
            string username = this.username.Text;
            string password = this.password.Text;

            helper.SignIn(username, password, sfUrl);
                        
            DisableLogin();
            
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            if (helper.SignOut())
            {
                EnableLogin();
            }
        }


        //logout whenever user presses X

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            helper.SignOut();
        }

        #endregion

        #region UI Refresh

        private void EnableLogin()
        {

            this.Login_button.Enabled = true;
            this.username.Enabled = true;
            this.password.Enabled = true;
            this.Logout_button.Enabled = false;
            this.url.Enabled = true;
            this.comboBox1.Enabled = true;
        }


        private void DisableLogin()
        {
            this.Login_button.Enabled = false;
            this.username.Enabled = false;
            this.password.Enabled = false;
            this.url.Enabled = false;

            this.ListNewsButton.Enabled = true;
            this.Logout_button.Enabled = true;
            this.comboBox1.Enabled = false;
        }
            

        #endregion

        #region List the items

        private void ListNewsButtonClick(object sender, EventArgs e)
        {

            //Listing the roles
            string rolesResult = null;

            helper.CallService(ServiceHelper.NewsUrl, null, "GET", out rolesResult, "application/json");

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(rolesResult)))
            {
                DataContractJsonSerializer rolesSerializer = new DataContractJsonSerializer(typeof(NewsItems));

                NewsItems rolesData = (NewsItems)rolesSerializer.ReadObject(ms);

                foreach (NewsItem item in rolesData.Items)
                {
                    NewsList.Items.Add(item);

                }

              

            }

  

        }

        #endregion   

        #region Select an Authentication Mode

        private void RESTfulClient_Load(object sender, EventArgs e)
        {
            
            
            helper = new FormsAuthenticationHelper();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == (int)AuthenticationModes.Forms)
                helper = new FormsAuthenticationHelper();
            
            else
                helper = new ClaimsAuthenticationHelper();
               


        }


        #endregion

        private IAuthenticationHelper helper;
          

        enum AuthenticationModes { Forms = 0, Claims };

        #region Display the new Window
        private void NewsList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if(!OrdersList.CheckedItems.Contains(OrdersList.SelectedItem))
            //{
            //    OrderItem selectedItem = (OrderItem)OrdersList.SelectedItem;

            //    var about = new AboutThisOrder(selectedItem, helper);
            //    about.Show();
            //}
        }

        #endregion


        #region Create the product
        private void button1_Click(object sender, EventArgs e)
        {
            string responseBody;
            Product product = new Product();

            //"sf_ec_prdct_mp3:#Telerik.Sitefinity.DynamicTypes.Model"

            product.Item = new ProductItem();
            product.Item.Title = new Title();
            product.Item.Title.PersistedValue = "Product 100";
            product.Item.Title.Value = "Product 100";
            product.Item.Description = new Description();
            product.Item.Description.PersistedValue = "Product 100 desc";
            product.Item.Description.Value = "Product 100 desc";
            product.Item.Weight = 1;
            product.Item.DisplayPrice = 1;
            product.Item.Price = 1;
            product.Item.UrlName = new UrlName();
            product.Item.UrlName.PersistedValue = "product-104";
            product.Item.UrlName.Value = "product-104";
            product.Item.PublicationDate = DateTime.Now;

            product.Item.SaleStartDate = null;
            product.Item.SaleEndDate = null;
            product.Item.IsActive = true;
            product.Item.Status = 2;
            product.Item.Thumbnail = new Thumbnail();
            product.Item.Thumbnail.Album = null;
            product.Item.Id = Guid.Empty.ToString();
            product.Item.AssociateBuyerWithRole = Guid.Empty.ToString();
            product.Item.Owner = Guid.Empty.ToString();
            product.Item.PublicationDate = DateTime.Now;
         

            product.Item.Thumbnail.AlbumId = Guid.Empty.ToString();
            product.Item.Thumbnail.Id = Guid.Empty.ToString();

            product.Item.TaxClassId = Guid.Empty.ToString();
            



            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateParseHandling = DateParseHandling.DateTime;
            settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            string jsonString = JsonConvert.SerializeObject(product,settings);
           
            string replacedString = Regex.Replace(jsonString,"\"","\\\"");
            replacedString = String.Format("\"{0}\"", replacedString);

            byte[] data = Encoding.UTF8.GetBytes(replacedString);
            helper.CallService(ServiceHelper.ProductsUrl + "/00000000-0000-0000-0000-000000000000/?itemType=Telerik.Sitefinity.DynamicTypes.Model.sf_ec_prdct_generalproduct&providerName=&managerType=&provider=&workflowOperation=", data, "PUT", out responseBody, "application/json");
            textBox1.Text = replacedString;

            var a = responseBody;
            textBox2.Text = a;
        }

#endregion
    


    }
}
