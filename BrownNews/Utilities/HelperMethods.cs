using BrownNews.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace BrownNews.Utilities
{
    public static class HelperMethods
    {
        public static Uri HttpToHttps(this Uri uri)
        {
            Uri imgUri = null;
            if (uri != null)
            {
                imgUri = new UriBuilder(uri)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1
                }.Uri;
            }
            return imgUri;
        }


        public static int CalculatePagesForPagination(int totalResults, int pageSize)
        {
            if (totalResults < pageSize)
            {
                return 1;
            }

            // Using dev account on NewsApi.org so can only fetch 100 results
            // Setting it to 96 to round off as we use 12 results per page
            if (totalResults > 96)
            {
                totalResults = 96;
            }

            int pages = totalResults / pageSize;
            if (totalResults % pageSize >= 1) pages++;
            return pages;
        }

        public static ApiClient.ApiClient SetupUrlAndClient(string API_KEY, NewsType newsType = NewsType.TopHeadlines, params string[] urlParams)
        {
            var uriStr = "";
            switch (newsType)
            {
                case NewsType.TopHeadlines:
                    uriStr = "https://newsapi.org/v2/top-headlines/?apiKey=" + API_KEY;
                    break;
                case NewsType.Everything:
                    uriStr = "https://newsapi.org/v2/everything/?apiKey=" + API_KEY;
                    break;
                default:
                    uriStr = "https://newsapi.org/v2/top-headlines/?apiKey=" + API_KEY;
                    break;
            }
            foreach (var item in urlParams)
            {
                uriStr += $"&{item}";
            }
            return new ApiClient.ApiClient(new Uri(uriStr));
        }

        public static string GenerateEmailHash(string email)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(email.ToLower()));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        public static byte[] ZipIt(this List<SourceFile> sFiles)
        {
            // get the source files
            List<SourceFile> sourceFiles = sFiles;

            // the output bytes of the zip
            byte[] fileBytes = null;

            // create a working memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // create a zip
                using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    // interate through the source files
                    foreach (SourceFile f in sourceFiles)
                    {
                        // add the item name to the zip
                        ZipArchiveEntry zipItem = zip.CreateEntry(f.Name + "." + f.Extension);
                        // add the item bytes to the zip entry by opening the original file and copying the bytes 
                        using (MemoryStream originalFileMemoryStream = new MemoryStream(f.FileBytes))
                        {
                            using (Stream entryStream = zipItem.Open())
                            {
                                originalFileMemoryStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
                fileBytes = memoryStream.ToArray();
            }

            // return zip
            return fileBytes;
        }

        public enum NewsType
        {
            TopHeadlines,
            Everything
        }
    }
}
