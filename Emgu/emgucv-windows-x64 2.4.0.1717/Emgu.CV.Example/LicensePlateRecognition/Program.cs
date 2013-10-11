using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

namespace LicensePlateRecognition
{
    class Program
    {
        private static LicensePlateDetector _licensePlateDetector;
        private static Tesseract _ocr;

        private static List<string> LicensePlateRecognitionInit()
        {
            _licensePlateDetector = new LicensePlateDetector();

            var image = new Image<Bgr, byte>("license-plate.jpg");

            // time the detection process
            Stopwatch watch = Stopwatch.StartNew();

            var licensePlateImagesList = new List<Image<Gray, byte>>();
            var filteredLicensePlateImagesList = new List<Image<Gray, byte>>();

            var licenseBoxList = new List<MCvBox2D>();
            var words = _licensePlateDetector.DetectLicensePlate(
               image,
               licensePlateImagesList,
               filteredLicensePlateImagesList,
               licenseBoxList);

            watch.Stop(); //stop the timer

            return words;
        }

        private static string OcrInitalizer()
        {
            _ocr = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);
            string result = string.Empty;
            try
            {
                var image = new Image<Bgr, byte>("IMAG0280.jpg");




                using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                {
                    gray.Save(@"C:\Users\Nino\DesktopIMAG0280.jpg");
                    
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                   
                    _ocr.Recognize(gray);
                    Tesseract.Charactor[] charactors = _ocr.GetCharactors();
                    
                    //String text = String.Concat( Array.ConvertAll(charactors, delegate(Tesseract.Charactor t) { return t.Text; }) );
                    result = _ocr.GetText();
                    watch.Stop();

                    var total = watch.ElapsedMilliseconds;
                }
            }
            catch (Exception exception)
            {
               
            }

            return result;
        }

        static void Main(string[] args)
        {
            //var result = LicensePlateRecognitionInit();
            var ocrResult = OcrInitalizer();
        }
    }
}