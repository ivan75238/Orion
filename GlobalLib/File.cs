using System.Net;
using System.Text;

namespace GlobalLib
{
    public class ApiFile
    {
        public static string Upload(string filename_hd, string filename_api, ApiFilePath path)
        {
            string apiPath = "";
            switch (path)
            {
                case ApiFilePath.News:
                    apiPath = "image/News/";
                    break;
            }
            var wc = new WebClient();
            var responseArray = wc.UploadFile($"{functions.Translate("ApiUrl")}File.Upload&filename={filename_api}&path={apiPath}", filename_hd);
            return Encoding.ASCII.GetString(responseArray);
        }
    }
}
