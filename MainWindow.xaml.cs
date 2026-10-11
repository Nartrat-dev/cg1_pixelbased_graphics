using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CG_Labor1
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        byte[] pixels;
        int stride;
        int width;
        int height;

        private void loadPixBuffer()
        {
            Uri ur = new Uri("../../Campus.png", UriKind.Relative);
            BitmapImage imag = new BitmapImage(ur);
            WriteableBitmap wbitmap = new WriteableBitmap(imag); // Bgra32
            width = wbitmap.PixelWidth;
            height = wbitmap.PixelHeight;
            pixels = new byte[width * height * 4];
            stride = wbitmap.BackBufferStride;
            wbitmap.CopyPixels(pixels, stride, 0);
        }

        public MainWindow()
        {
            InitializeComponent();
            loadPixBuffer();
        }

        /**
         * Aufgabe 1: Zeichen Sie ein Dreieck
         */
        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            int width = 500;
            int height = 500;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Rgb24, null);
            byte[] pixel = new byte[height * width * 3];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    if (y - x < 0)
                    {
                        pixel[(y * width + x) * 3 + 2] = 255;
                    }

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 3 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Aufgabe 2: Pixel aus einem Bild extrahieren und wieder ausgeben
         */
        private void Campus_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Bgr32, null);
            byte[] pixel = new byte[height * width * 4];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    pixel[(y * width + x) * 4] = pixels[(y * width + x) * 4];
                    pixel[(y * width + x) * 4 + 1] = pixels[(y * width + x) * 4 + 1];
                    pixel[(y * width + x) * 4 + 2] = pixels[(y * width + x) * 4 + 2];

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 4 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Aufgabe 3: Farbkanäle einzeln ausgeben
         */
        private void RGBCheckboxCampus_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Bgr32, null);
            byte[] pixel = new byte[height * width * 4];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    if (Red_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 2] = pixels[(y * width + x) * 4 + 2];
                    }
                    if (Green_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 1] = pixels[(y * width + x) * 4 + 1];
                    }
                    if (Blue_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 0] = pixels[(y * width + x) * 4 + 0];
                    }

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 4 * width, 0);
            myImage.Source = wbitmap;
        }

        // Checkboxes
        private void Red_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Blue_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Green_Checked(object sender, RoutedEventArgs e)
        {

        }

        /**
         * Aufgabe 4: Bild invertieren farbig
         */
        private void RGBCheckboxCampusInverted_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Bgr32, null);
            byte[] pixel = new byte[height * width * 4];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    if (Red_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 2] = (byte)(255 - (int)pixels[(y * width + x) * 4 + 2]); // red
                    }
                    if (Green_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 1] = (byte)(255 - (int)pixels[(y * width + x) * 4 + 1]); // green
                    }
                    if (Blue_Checkbox.IsChecked == true)
                    {
                        pixel[(y * width + x) * 4 + 0] = (byte)(255 - (int)pixels[(y * width + x) * 4 + 0]); // blue
                    }

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 4 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Aufgabe 5: Umwandeln in Graustufenbild
         */
        private void GrayscaleImage_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Gray8, null);
            byte[] pixel = new byte[height * width];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    pixel[(y * width + x)] =
                        (byte)(
                            (double)(pixels[(y * width + x) * 4]) * 0.0722         //blau
                            + (double)(pixels[(y * width + x) * 4 + 1]) * 0.7152    //green
                            + (double)(pixels[(y * width + x) * 4 + 2]) * 0.2126   //red
                        );

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 1 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Aufgabe 6: Graustufenbild invertieren
         */
        private void GrayscaleImageInverted_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Gray8, null);
            byte[] pixel = new byte[height * width];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    pixel[(y * width + x)] =
                        (byte)(
                            255 - (
                                (int)(pixels[(y * width + x) * 4]) * 0.0722         //blau
                                + (int)(pixels[(y * width + x) * 4 + 1]) * 0.7152    //green
                                + (int)(pixels[(y * width + x) * 4 + 2]) * 0.2126   //red
                            )
                        );

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 1 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Aufgabe 7: Schwellwertoperation
         */
        private void ApplyThreshhold()
        {
            // Return if ValueChanged is called prior to InitilizeComponent
            if (pixels == null || myImage == null || Sliderino == null)
                return;

            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Gray8, null);
            byte[] pixel = new byte[height * width];

            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {

                    if (Sliderino.Value <
                        (int)(pixels[(y * width + x) * 4]) * 0.0722         //blau
                        + (int)(pixels[(y * width + x) * 4 + 1]) * 0.7152   //green
                        + (int)(pixels[(y * width + x) * 4 + 2]) * 0.2126   //red
                    )
                    {
                        pixel[(y * width + x)] = (byte)255;                 //white
                    }
                    else
                    {
                        pixel[(y * width + x)] = (byte)0;                   //black
                    }

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 1 * width, 0);
            myImage.Source = wbitmap;
        }

        private void GrayscaleImageThreshhold_Click(object sender, RoutedEventArgs e)
        {
            ApplyThreshhold();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ApplyThreshhold();
        }

        /**
         * Aufgabe 8: Gamma-Korrektur Graustufenbild
         */
        private void ApplyGamma()
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Gray8, null);
            byte[] pixel = new byte[height * width];


            // fill Array
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {


                    double gamma = SliderinosSohn.Value;

                    double newValue = Math.Pow(
                        (double)(pixels[(y * width + x) * 4]) * 0.0722          // blau
                        + (double)(pixels[(y * width + x) * 4 + 1]) * 0.7152    // green
                        + (double)(pixels[(y * width + x) * 4 + 2]) * 0.2126    // rojo
                        ,
                        (gamma / 255)
                        );


                    pixel[(y * width + x)] = (byte)(newValue * 255);

                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 1 * width, 0);
            myImage.Source = wbitmap;
        }

        private void Gamma_Click(object sender, RoutedEventArgs e)
        {
            ApplyGamma();
        }

        private void Slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ApplyGamma();
        }


        /**
        * Aufgabe 9: Nutzung einer Palette (Falschfarbendarstellung)
        */
        private void GrayscalePalette_Click(object sender, RoutedEventArgs e)
        {
            int width = this.width;
            int height = this.height;
            WriteableBitmap wbitmap = new WriteableBitmap(width, height, 0, 0, PixelFormats.Bgra32, null);
            byte[] pixel = new byte[height * width * 4];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    byte greyscale = (byte)(
                            (double)(pixels[(y * width + x) * 4]) * 0.0722
                            + (double)(pixels[(y * width + x) * 4 + 1]) * 0.7152
                            + (double)(pixels[(y * width + x) * 4 + 2]) * 0.2126
                        );

                    // 0 -> red, 255 -> blue
                    pixel[(y * width + x) * 4 + 0] = greyscale;             // blue
                    pixel[(y * width + x) * 4 + 1] = 0;                     // green
                    pixel[(y * width + x) * 4 + 2] = (byte)(255-greyscale); // red
                    pixel[(y * width + x) * 4 + 3] = 255;                   // alpha
                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            wbitmap.WritePixels(rect, pixel, 4 * width, 0);
            myImage.Source = wbitmap;
        }

        /**
         * Extra-Challenge 1: Nutzung einer Palette für Gamma-Korrektur
         */


        /**
         * Extra-Challenge 2: Gamma-Korrektur im Farbbild
         */


    }
}