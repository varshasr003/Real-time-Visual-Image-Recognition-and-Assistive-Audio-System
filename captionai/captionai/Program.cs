using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace captionai
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string OrginalFilePath = "";
        public static string sliceFilePath = "";
        public static Bitmap croppedimage;
        public static Bitmap hflipimage;
        public static Bitmap vflipimage;
        public static Bitmap a1;
        public static Bitmap a2;
        public static Bitmap a3;
        public static Bitmap a4;
        public static Bitmap hog;
        public static Bitmap canny;
        public static Bitmap blackImage;

        public static string detectionFilePath = "";
        public static string ccap = "@#@#@#";


        public static string orgfilepath = "";
        public static string userid = "104";
        public static string picpath = "";
        public static string username = "";
        public static string usertype = "";
        public static string binary = "";
        public static string bitcode = "";
        public static string folderpath = "";
        public static double train_cnn = 92;
        public static double train_mcnn = 99.1;
        public static double test_cnn = 91.2;
        public static double test_mcnn = 98.7;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Startup());
        }
    }
}
