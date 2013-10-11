using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

namespace OCR
{
    static class Program
    {
        private static Tesseract _ocr;

        static void Main(string[] args)
        {
            // _ocr = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);
            try
            {
                var image = new Image<Bgr, byte>("IMAG0277.jpg");

                using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                {
                    _ocr.Recognize(gray);
                    Tesseract.Charactor[] charactors = _ocr.GetCharactors();

                    //String text = String.Concat( Array.ConvertAll(charactors, delegate(Tesseract.Charactor t) { return t.Text; }) );
                    String text = _ocr.GetText();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
