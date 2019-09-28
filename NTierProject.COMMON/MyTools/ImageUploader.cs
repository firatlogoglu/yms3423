using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NTierProject.COMMON.MyTools
{
    public class ImageUploader
    {
        /*
         1=> dosya zaten var.
         2=> dosya tipi yanlış
         3=> dosya boş.
             */

        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');

                //yukarıdaki işlemin arından bize teslim edilen isim ve uzantıyı parçalara ayırdık.

                /*
                    fatihGorsel.png
                    0=fatihGorsel
                    1=png
                 */


                string extension = fileArray[fileArray.Length - 1].ToLower();
                string fileName = uniqueName + "." + extension;


                if (extension == "jpg" || extension == "png" || extension == "gif" || extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }

            }
            else
            {
                return "3";
            }
        }
    }
}

