using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonitor.Pages
{
    public class AccountPage : BasePage
    {
        private static string END_POINT = "my-account";

        private static readonly By ProfileIconBy = By.ClassName("avatar-component");
        private static readonly By FileInputBy = By.CssSelector("input[type='file']");
        private static readonly By ImageSourceBy = By.CssSelector("img.is-rounded");

        private string localPath = @"D:\1c.jpg";

        public AccountPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public AccountPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return Driver.FindElement(ProfileIconBy).Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void EditProfileIcon()
        {
            string filePath = localPath;

            Driver.FindElement(FileInputBy).SendKeys(filePath);
        }

        public bool CompareWebImageWithLocal()
        {
            string url = Driver.FindElement(ImageSourceBy).GetAttribute("src");

            byte[] imageWeb = LoadImageFromUrl(url);

            byte[] imageLocal = LoadImageFromDisk(localPath);
            
            return CompareTwoImages(imageWeb, imageLocal);           
        }

        private static byte[] LoadImageFromUrl(string url)
        {
            using var client = new HttpClient();

            using var response = client.Send(new HttpRequestMessage(HttpMethod.Get, url));

            using var memoryStream = new MemoryStream();

            response.Content.ReadAsStream().CopyTo(memoryStream);

            return memoryStream.ToArray();
        }

        private static byte[] LoadImageFromDisk(string path)
        {
            return File.ReadAllBytes(path);
        }

        private static bool CompareTwoImages(byte[] imageWeb, byte[] imageLocal)
        {
            return imageWeb.SequenceEqual(imageLocal);
        }
    }
}