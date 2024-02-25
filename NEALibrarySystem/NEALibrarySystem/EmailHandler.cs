using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace NEALibrarySystem
{
    /// <summary>
    /// Used to send emails via the Gmail API
    /// </summary>
    public static class EmailHandler
    {
        static string[] Scopes = { GmailService.Scope.GmailSend };
        static string ApplicationName = "NEALibrarySystem";

        static string Base64UrlEncode(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        /// <summary>
        /// Sends emails
        /// </summary>
        /// <param name="receiver">Email address to send to</param>
        /// <param name="subject">Title of email</param>
        /// <param name="content">Contents of email</param>
        /// <param name="canErrorMessage">Whether error message is displayed if something goes wrong</param>
        public static void Send(string receiver, string subject, string content, bool canErrorMessage = false)
        {
            try
            {
                UserCredential credential;

                //read your credentials file
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("NEALibrarySystem.Resources.credentials.json"))
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    path = Path.Combine(path, ".credentials/gmail-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(path, true)).Result;
                }

                string message = $"To: {receiver}\r\nSubject: {subject}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n<h1>{content}</h1>";
                //call your gmail service
                var service = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = ApplicationName });
                var msg = new Google.Apis.Gmail.v1.Data.Message();
                msg.Raw = Base64UrlEncode(message.ToString());
                service.Users.Messages.Send(msg, "me").Execute();
            }
            catch
            {
                if (canErrorMessage)
                    MessageBox.Show("Error: cannot send emails");
            }
        }
    }
}

