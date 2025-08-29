using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace WDFacebook
{
    public partial class Form1 : Form
    {
        private IWebDriver driverFacebook_76_phuc = null;

        public object SeleniumExtras { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }
        // Khởi tạo trình duyệt Chrome nếu chưa có
        private void InitializeDriverFacebook()
        {
            if (driverFacebook_76_phuc == null)
            {
                ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService();
                chromeService.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driverFacebook_76_phuc = new ChromeDriver(chromeService, options);
            }
        }

        // Hàm đăng nhập Facebook
        private void LoginFacebook_76_phuc(string username_76_phuc, string password_76_phuc)
        {
            if (string.IsNullOrEmpty(username_76_phuc) || string.IsNullOrEmpty(password_76_phuc))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitializeDriverFacebook();
            driverFacebook_76_phuc.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(3000);

            try
            {
                // Điền thông tin đăng nhập và bấm nút login
                driverFacebook_76_phuc.FindElement(By.Id("email")).SendKeys(username_76_phuc);
                driverFacebook_76_phuc.FindElement(By.Id("pass")).SendKeys(password_76_phuc);
                driverFacebook_76_phuc.FindElement(By.Name("login")).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Không thể đăng nhập Facebook!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Gửi lời mời kết bạn đến một profile cụ thể
        private void SendFriendRequest_76_phuc(string profileUrl_76_phuc)
        {
            //InitializeDriverFacebook();
            //string username_76_phuc = "plehoang641@gmail.com";
            //string password_76_phuc = "Asdjklzxc..";
            //LoginFacebook_76_phuc(username_76_phuc, password_76_phuc);
            driverFacebook_76_phuc.Navigate().GoToUrl(profileUrl_76_phuc);
            Thread.Sleep(5000);

            try
            {
                // Tìm nút "Thêm bạn bè" và bấm vào
                IWebElement addFriendButton = driverFacebook_76_phuc.FindElement(By.XPath("//div[@aria-label='Thêm bạn bè']"));
                addFriendButton.Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Không tìm thấy nút 'Thêm bạn bè'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bình luận vào một bài viết theo link
        private void CommentOnPost_76_phuc(string postUrl_76_phuc, string comment_76_phuc)
        {
            driverFacebook_76_phuc.Navigate().GoToUrl(postUrl_76_phuc);
            Thread.Sleep(5000);

            try
            {
                // Dùng JavaScript để tương với phần tử (ví dụ như focus vào phần tử)
                IJavaScriptExecutor js = (IJavaScriptExecutor)driverFacebook_76_phuc;

                // Scroll nhẹ xuống để chắc chắn render phần comment
                js.ExecuteScript("window.scrollBy(0, 300);");
                Thread.Sleep(1000);

                // Tìm phần tử là ô viết bình luận – có role='textbox' và aria-label chứa 'Viết bình luận'
                // Đây là phần tử dạng <div contenteditable="true">, không phải <textarea> hay <input>
                IWebElement commentBox = driverFacebook_76_phuc.FindElement(
                    By.XPath("//div[@role='textbox' and contains(@aria-label, 'Viết bình luận')]"));

                // Dùng JavaScript để focus vào ô bình luận (vì Click() có thể bị lỗi nếu bị che)
                js.ExecuteScript("arguments[0].focus();", commentBox);
                commentBox.Click();
                Thread.Sleep(500);
                commentBox.SendKeys(comment_76_phuc);
                Thread.Sleep(500);
                commentBox.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Không tìm thấy ô bình luận trên trang!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi comment: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        ////up một bài viết có hình ảnh 
        //private void PostFacebookWithImage_76_phuc(string imagePath_76_phuc, string content_76_phuc)
        //{
        //    try
        //    {
        //        var wait_76_phuc = new WebDriverWait(driverFacebook_76_phuc, TimeSpan.FromSeconds(10));

        //        // Bấm vào ô tạo bài viết
        //        var createPostButton_76_phuc = wait_76_phuc.Until(driver =>
        //            driver.FindElement(By.XPath("//span[contains(text(), 'bạn đang nghĩ gì')]/ancestor::div[@role='button']"))
        //        );
        //        createPostButton_76_phuc.Click();
        //        Thread.Sleep(2000);

        //        // Nhập nội dung bài viết
        //        var contentBox_76_phuc = wait_76_phuc.Until(driver =>
        //            driver.FindElement(By.XPath("//div[@aria-label='Lê ơi,bạn đang nghĩ gì thế?']"))
        //        );
        //        contentBox_76_phuc.SendKeys(content_76_phuc);
        //        Thread.Sleep(1500);

        //        // Chọn input file và gửi ảnh
        //        var inputFile_76_phuc = driverFacebook_76_phuc.FindElement(By.XPath("//input[@type='file']"));
        //        inputFile_76_phuc.SendKeys(imagePath_76_phuc);
        //        Thread.Sleep(4000); // Chờ tải ảnh lên

        //        // Nhấn nút "Đăng"
        //        var postButton_76_phuc = wait_76_phuc.Until(driver =>
        //            driver.FindElement(By.XPath("//div[@aria-label='Đăng']"))
        //        );
        //        postButton_76_phuc.Click();

        //        MessageBox.Show("Đăng bài thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi đăng bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}




        //private void btopen_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog_76_phuc = new OpenFileDialog())
        //    {
        //        openFileDialog_76_phuc.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
        //        if (openFileDialog_76_phuc.ShowDialog() == DialogResult.OK)
        //        {
        //            string imagePath = openFileDialog_76_phuc.FileName;
        //            pictureBox1.Image = Image.FromFile(imagePath);
        //            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        //            // Lưu đường dẫn ảnh tạm vào Tag
        //            pictureBox1.Tag = imagePath;
        //        }
        //    }
        //}

        //private void btup_Click(object sender, EventArgs e)
        //{
        //    string imagePath_76_phuc = pictureBox1.Tag?.ToString();
        //    string content_76_phuc = txtnoidung.Text;

        //    if (string.IsNullOrEmpty(imagePath_76_phuc))
        //    {
        //        MessageBox.Show("Vui lòng chọn ảnh để đăng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (!File.Exists(imagePath_76_phuc))
        //    {
        //        MessageBox.Show("Đường dẫn ảnh không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    PostFacebookWithImage_76_phuc(content_76_phuc,imagePath_76_phuc);
        //}




        private void Button1_Click(object sender, EventArgs e)
        {
            //string username_76_phuc = "plehoang641@gmail.com";
            //string password_76_phuc = "Asdjklzxc..";
            //LoginFacebook_76_phuc(username_76_phuc, password_76_phuc);
            string username_76_phuc;
            string password_76_phuc;
            username_76_phuc = txtusername.Text;
            password_76_phuc = txtpass.Text;
            LoginFacebook_76_phuc(username_76_phuc, password_76_phuc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string linkpost_76_phuc;
            string cmt_76_phuc;
            linkpost_76_phuc = txtlinkcmt.Text;
            cmt_76_phuc = txtcmt.Text;
            CommentOnPost_76_phuc(linkpost_76_phuc,cmt_76_phuc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String link_76_phuc;
            link_76_phuc= txtprofile.Text;
            SendFriendRequest_76_phuc(link_76_phuc);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
