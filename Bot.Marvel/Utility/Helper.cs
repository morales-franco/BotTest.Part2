using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bot.Marvel.Utility
{
    public static class Helper
    {
        public static string ImagePathBuilder(string path, string extension, string imageFormat)
        {
            StringBuilder imageBuilder = new StringBuilder();
            imageBuilder.Append(path);
            imageBuilder.Append("/" + imageFormat);
            imageBuilder.Append("." + extension);

            return imageBuilder.ToString();
        }
    }
}