using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tesstnet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bitmap image = new Bitmap(@"C:\Users\Nino\Documents\PbpHackthone\dotNet_OCR_server\images\IMAG0253_cropped.jpg");
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
                ocr.Init(@"C:\Users\Nino\Desktop\tessdata", "eng", false); // To use correct tessdata
                List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
                foreach (tessnet2.Word word in result)
                    Console.WriteLine("{0} : {1}", word.Confidence, word.Text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read(); 
        }
    }
}
