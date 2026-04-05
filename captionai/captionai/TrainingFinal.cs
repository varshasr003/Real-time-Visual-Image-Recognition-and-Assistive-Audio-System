using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using System.Diagnostics;
using System.IO;


namespace captionai
{
    public partial class TrainingFinal : Form
    {
        private const string Cfg = "yolov3.cfg";
        private const string Weight = "yolov3.weights";
        private const string Names = "coco.names";
        private const string Location = "../../Content/";
        private static readonly Scalar[] Colors = Enumerable.Repeat(false, 80).Select(x => Scalar.RandomColor()).ToArray();
        private static readonly string[] Labels = File.ReadAllLines(Path.Combine(Location, Names)).ToArray();
        public static string xx = "";
        public TrainingFinal()
        {
            InitializeComponent();
            pictureBox7.Image = (System.Drawing.Image)System.Drawing.Image.FromFile(Program.OrginalFilePath);
        }
        public void SaveFile()
        {
            string[] filelist = Directory.GetFiles(Application.StartupPath + "\\dataset", "*.png");
            int i = filelist.Length;
            i++;
            System.Drawing.Bitmap bmp1 = new System.Drawing.Bitmap(pictureBox7.Image);
            bmp1.Save(Application.StartupPath + "\\dataset\\dataset_" + i.ToString() + ".png", ImageFormat.Png);

            string[] filelist1 = Directory.GetFiles(Application.StartupPath + "\\Temp", "*.png");
            int i1 = filelist.Length;
            i1++;
            System.Drawing.Bitmap bmp2 = Program.croppedimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.canny;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.hflipimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            i1++;
            bmp2 = Program.vflipimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.hog;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a1;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a2;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a3;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a4;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            var image = Program.OrginalFilePath;
            var cfg = Path.Combine(Location, Cfg);
            var model = Path.Combine(Location, Weight);
            const float threshold = 0.5f;       //for confidence 
            const float nmsThreshold = 0.3f;    //threshold for nms


            //get image
            var org = new Mat(image);


            var blob = CvDnn.BlobFromImage(org, 1.0 / 255, new Size (416, 416), new Scalar(), true, false);

            //load model and config, if you got error: "separator_index < line.size()", check your cfg file, must be something wrong.
            var net = CvDnn.ReadNetFromDarknet(cfg, model);
            #region set preferable
            net.SetPreferableBackend(3);
            /*
            0:DNN_BACKEND_DEFAULT 
            1:DNN_BACKEND_HALIDE 
            2:DNN_BACKEND_INFERENCE_ENGINE
            3:DNN_BACKEND_OPENCV 
             */
            net.SetPreferableTarget(0);
            /*
            0:DNN_TARGET_CPU 
            1:DNN_TARGET_OPENCL
            2:DNN_TARGET_OPENCL_FP16
            3:DNN_TARGET_MYRIAD 
            4:DNN_TARGET_FPGA 
             */
            #endregion

            //input data
            net.SetInput(blob);

            //get output layer name
            var outNames = net.GetUnconnectedOutLayersNames();
            //create mats for output layer
            var outs = outNames.Select(_ => new Mat()).ToArray();

            #region forward model
            Stopwatch sw = new Stopwatch();
            sw.Start();

            net.Forward(outs, outNames);

            sw.Stop();
            //  listBox1.Items.Add($"Runtime:{sw.ElapsedMilliseconds} ms");
            //Console.WriteLine($"Runtime:{sw.ElapsedMilliseconds} ms");
            #endregion

            //get result from all output
            GetResult(outs, org, threshold, nmsThreshold);

            //using (new Window("died.tw", org))
            //{
            //    Cv2.WaitKey();
            //}
            //System.Drawing.Bitmap bmp = MatToBitmap(org);

        }
        public static System.Drawing.Bitmap MatToBitmap(Mat image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        }
        private void Draw(Mat image, int classes, float confidence, float probability, double centerX, double centerY, double width, double height)
        {
            //label formating
            var label = $"{Labels[classes]} {probability * 100:0.00}%";
            // listBox1.Items.Add($"confidence {confidence * 100:0.00}% {label}");
            //  listBox2.Items.Add(Labels[classes].ToString());
            listBox1.Items.Add(Labels[classes].ToString());
            var x1 = (centerX - width / 2) < 0 ? 0 : centerX - width / 2; //avoid left side over edge
            //draw result
            image.Rectangle(new Point(x1, centerY - height / 2), new Point(centerX + width / 2, centerY + height / 2), Colors[classes], 2);
            var textSize = Cv2.GetTextSize(label, HersheyFonts.HersheyTriplex, 0.5, 1, out var baseline);
            Cv2.Rectangle(image, new Rect(new Point(x1, centerY - height / 2 - textSize.Height - baseline),
                new Size(textSize.Width, textSize.Height + baseline)), Colors[classes], Cv2.FILLED);
            var textColor = Cv2.Mean(Colors[classes]).Val0 < 70 ? Scalar.White : Scalar.Black;
            Cv2.PutText(image, label, new Point(x1, centerY - height / 2 - baseline), HersheyFonts.HersheyTriplex, 0.5, textColor);
        }
        private void GetResult(IEnumerable<Mat> output, Mat image, float threshold, float nmsThreshold, bool nms = true)
        {
            //for nms
            var classIds = new List<int>();
            var confidences = new List<float>();
            var probabilities = new List<float>();
            var boxes = new List<Rect2d>();

            var w = image.Width;
            var h = image.Height;
            /*
             YOLO3 COCO trainval output
             0 1 : center                    2 3 : w/h
             4 : confidence                  5 ~ 84 : class probability 
            */
            const int prefix = 5;   //skip 0~4

            foreach (var prob in output)
            {
                for (var i = 0; i < prob.Rows; i++)
                {
                    var confidence = prob.At<float>(i, 4);
                    if (confidence > threshold)
                    {
                        //get classes probability
                        Cv2.MinMaxLoc(prob.Row[i].ColRange(prefix, prob.Cols), out _, out Point max);
                        var classes = max.X;
                        var probability = prob.At<float>(i, classes + prefix);

                        if (probability > threshold) //more accuracy, you can cancel it
                        {
                            //get center and width/height
                            var centerX = prob.At<float>(i, 0) * w;
                            var centerY = prob.At<float>(i, 1) * h;
                            var width = prob.At<float>(i, 2) * w;
                            var height = prob.At<float>(i, 3) * h;

                            if (!nms)
                            {
                                // draw result (if don't use NMSBoxes)
                                Draw(image, classes, confidence, probability, centerX, centerY, width, height);
                                continue;
                            }

                            //put data to list for NMSBoxes
                            classIds.Add(classes);
                            confidences.Add(confidence);
                            probabilities.Add(probability);
                            boxes.Add(new Rect2d(centerX, centerY, width, height));
                        }
                    }
                }
            }

            if (!nms) return;

            //using non-maximum suppression to reduce overlapping low confidence box
            CvDnn.NMSBoxes(boxes, confidences, threshold, nmsThreshold, out int[] indices);

            //listBox1.Items.Add($"NMSBoxes drop {confidences.Count - indices.Length} overlapping result.");

            foreach (var i in indices)
            {
                var box = boxes[i];
                Draw(image, classIds[i], confidences[i], probabilities[i], box.X, box.Y, box.Width, box.Height);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            cnnrnn obj = new cnnrnn();

         

           
            MessageBox.Show("Training Completed");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
