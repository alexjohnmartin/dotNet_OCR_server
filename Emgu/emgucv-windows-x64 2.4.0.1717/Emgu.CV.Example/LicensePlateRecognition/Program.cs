//----------------------------------------------------------------------------
//  Copyright (C) 2004-2012 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Runtime.InteropServices;

namespace LicensePlateRecognition
{
    class Program
    {
        private static LicensePlateDetector _licensePlateDetector;

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

        static void Main(string[] args)
        {
            var result = LicensePlateRecognitionInit();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}