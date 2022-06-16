using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public static class ScreenCapture
    {
        static string theFolder = @"C:\temp";
        static string theFile = @"\Capture.png";
        public static void GrabIt(string message = "", string theQuery = "")
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(SystemInformation.VirtualScreen.Width,
                                                   SystemInformation.VirtualScreen.Height,
                                                   PixelFormat.Format32bppArgb);

                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen
                //captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureGraphics.CopyFromScreen(SystemInformation.VirtualScreen.X,
                           SystemInformation.VirtualScreen.Y,
                           0,
                           0,
                           SystemInformation.VirtualScreen.Size,
                           CopyPixelOperation.SourceCopy);



                if (!System.IO.Directory.Exists(theFolder))
                    System.IO.Directory.CreateDirectory(theFolder);

                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save($"{theFolder}{theFile}", System.Drawing.Imaging.ImageFormat.Png);

                //Displaying the Successfull Result

                SendEmail(message, theQuery);

                //                MessageBox.Show("Screen Captured");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Unable to auto-send bug report: {ex.Message}");
            }
        }

        static void SendEmail(string message, string theQuery)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("crismtp01.chec.local");  // new SmtpClient("glirvexc02.greenlight.com");
            mail.From = new MailAddress("steve.straley@mrcooper.com");
            mail.To.Add("steve.straley@mrcooper.com");
            mail.Subject = "Error from API Field Updater";
            mail.Body = $"Client Box {Environment.MachineName} [{message}]";
            if (!string.IsNullOrEmpty(theQuery))
            {
                mail.Body += "";
                mail.Body += theQuery;
            }

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment($"{theFolder}{theFile}");
            mail.Attachments.Add(attachment);

            //            SmtpServer.Port = 587;
            //            SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password");
            //            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        //string toEmailAddress = "steve.straley@mrcooper.com";
        //string fromEmailAddress = "steve.straley@mrcooper.com";
        //MailMessage mail = new MailMessage(fromEmailAddress, toEmailAddress, "API Field Updater", body);
        //mail.IsBodyHtml = true;
        //SmtpClient client = new SmtpClient("glirvexc02.greenlight.com");
        //try
        //{
        //    client.Send(mail);
        //}
        //catch (Exception ex)
        //{
        //    lblError.Text += ex.Message;
        //}

        //        if (string.IsNullOrEmpty(SmtpHost)) SmtpHost = string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("SmtpHost"))
        //                ? ConfigurationManager.AppSettings["MailServer"] : ConfigurationManager.AppSettings["SmtpHost"];
        //            int SmtpPort = string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("SmtpPort"))
        //                ? Convert.ToInt32(ConfigurationManager.AppSettings["MailPort"]) : Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);

        //            if (string.IsNullOrEmpty(SmtpHost))
        //                throw new Exception("GFSFramework - SmtpHost is not found");
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(MailFrom);
        //        mailMessage.To.Add(MailTo);
        //            mailMessage.Subject = MailSubject;
        //            mailMessage.Body = MailBody;
        //            mailMessage.IsBodyHtml = true;

        //            if (liAttachments != null)
        //            {
        //                foreach (Attachment attachment in liAttachments)
        //                {
        //                    mailMessage.Attachments.Add(attachment);
        //                }
        //}
    }
}
