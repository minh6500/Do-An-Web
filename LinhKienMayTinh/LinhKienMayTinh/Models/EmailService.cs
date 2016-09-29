using System.Net;
using System.Net.Mail;
using System.Text;

namespace LinhKienMayTinh.Models
{
    //class gui mail
    public class EmailService
    {
        /// <summary>
        /// Hàm thực thi gửi mail trong MVC
        /// </summary>
        /// <param name="smtpUserName">Tên đăng nhập của smtp server: vd : luutrangminh@gmail.com</param>
        /// <param name="smtpPassword">Mật khẩu đăng nhập</param>
        /// <param name="smtpHost">smtp của Host: vd: smtp.gmail.com</param>
        /// <param name="smtpPort">Port:vd: 25 - gmail</param>
        /// <param name="toEmail">Email của người nhận</param>
        /// <param name="subject">Chủ đề email</param>
        /// <param name="body">Nội dung thư gửi</param>
        /// <returns>True - Thành công / False - Thất bại</returns>
        public bool Send(string smtpUserName , string smtpPassword ,string smtpHost, int smtpPort, string toEmail , string subject , string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true; //bảo mật https
                    smtpClient.Host = smtpHost; //host
                    smtpClient.Port = smtpPort; //port
                    smtpClient.UseDefaultCredentials = true; //
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true, //Cho phép nội dung html
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };
                    msg.To.Add(toEmail);
                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}