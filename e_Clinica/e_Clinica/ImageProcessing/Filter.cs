using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace e_Clinica.ManejoImagen
{
    public class Filter
    {
        public bool _elipse = false;
        public double _brightness = 0;
        public int _quantity;
        public int _tone; 

        public Bitmap GrayScale(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin.Clone();
            Grayscale _filterGray = new Grayscale(0.2125, 0.7154, 0.0721);
            Threshold filter = new Threshold(100);
            //filter.ApplyInPlace(bmp);
            bmp = _filterGray.Apply(bmp); 
            
            return bmp; 
        }

        public Bitmap SobelEdges(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin;
            SobelEdgeDetector _filterSobel = new SobelEdgeDetector();    
            _filterSobel.ApplyInPlace(bmp);
            
            return bmp; 
        }

        public Bitmap GetBrightness(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin.Clone();
            int px = 0;
            
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    double b = 0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B;
                    //double b = c.GetBrightness(); 
                    _brightness += b; 
                    px++; 
                }
            }
            _brightness = _brightness / px;

            int difBright = 150 - (int)_brightness;
            BrightnessCorrection _filterB = new BrightnessCorrection(difBright);
            _filterB.ApplyInPlace(bmp);
            
            return bmp; 
        }

        public Bitmap BlurImage(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin;
            GaussianBlur _filterS = new GaussianBlur();
            _filterS.ApplyInPlace(bmp);
            return bmp;
        }

        public Bitmap Binarizacion(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = new Bitmap(imgOrigin); 
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    // Color del pixel
                    Color col = bmp.GetPixel(i, j);
                    // Escala de grises
                    byte gris = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                    // Blanco o negro
                    byte value = 0;
                    if (gris > 150)
                    {
                        value = 255;
                    }
                    // Asginar nuevo color
                    Color nuevoColor = System.Drawing.Color.FromArgb(value, value, value);
                    bmp.SetPixel(i, j, nuevoColor);

                }
            }
            return bmp;
        }

        public Bitmap DetectElipse(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin;
            Bitmap bmpAux = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppRgb);  

            BitmapData bmData = bmpAux.LockBits(
                        new Rectangle(0, 0, bmpAux.Width, bmpAux.Height),
                        ImageLockMode.ReadWrite, bmpAux.PixelFormat);

            //Turn background to black 
            ColorFiltering cFilter = new ColorFiltering();
            cFilter.Red = new IntRange(0, 60);
            cFilter.Green = new IntRange(0, 60);
            cFilter.Blue = new IntRange(0, 60);
            cFilter.FillOutsideRange = false;

            cFilter.ApplyInPlace(bmData);
            //cFilter.Apply(bmData);

            //Blob --> finding shapes 
            BlobCounter _blob = new BlobCounter();
            //Investigar a fondo 
            _blob.FilterBlobs = true;
            _blob.MinHeight = 30;
            _blob.MinWidth = 30;

            //Process the image, with magic
            _blob.ProcessImage(bmData);
            //Found shapes
            Blob[] _blobs = _blob.GetObjectsInformation();
            bmpAux.UnlockBits(bmData);

            //Check found shapes
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            shapeChecker.MinAcceptableDistortion = 0.7f;
            shapeChecker.RelativeDistortionLimit = 0.08f;
            //color shapes
            Graphics g = Graphics.FromImage(bmpAux);
            Pen yellowPen = new Pen(Color.Yellow, 2);

            if (_blobs.Length != 0)
                _elipse = true; 

            for (int i = 0; i < _blobs.Length; i++)
            {
                //Obtains the edges of the shape
                List<IntPoint> edgePoints = _blob.GetBlobsEdgePoints(_blobs[i]); 
                //Points to the center of the shape        
                AForge.Point center;
                float radius;

                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    //Draw founded shape
                    g.DrawEllipse(yellowPen,
                        (float)(center.X - radius), (float)(center.Y - radius),
                        (float)(radius * 2), (float)(radius * 2));
                }
                
            }
            yellowPen.Dispose();
            g.Dispose();
            return bmpAux; 
        }

        

        public Color PredominantColor(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin;
            GetBrightness(bmp);
            List<Color> colors = new List<Color>();
            List<int> red = new List<int>(); 
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);
                    if (clr.R < 180 && clr.G < 100 && clr.B < 80)
                    {
                        r += clr.R;
                        g += clr.G;
                        b += clr.B;
                        total++;

                        if (!red.Contains(clr.R))
                        {
                            red.Add(clr.R);
                            colors.Add(clr); 
                        }
                    }
                }
            }
            r /= total;
            g /= total;
            b /= total;

            _quantity = colors.Count;
            _tone = r; 

            return Color.FromArgb(r, g, b);
        }

        public Bitmap CutImage(System.Drawing.Image imgOrigin)
        {
            Bitmap bmp = (Bitmap)imgOrigin;
            GetBrightness(bmp);
            Bitmap bmpAux = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppRgb);
            ColorFiltering cFilter = new ColorFiltering();
            cFilter.Red = new IntRange(170, 255);
            cFilter.Green = new IntRange(100, 255);
            cFilter.Blue = new IntRange(80, 255);
            cFilter.FillOutsideRange = false;
            cFilter.ApplyInPlace(bmpAux);

            return bmpAux;
        }

        public Bitmap getCut(System.Drawing.Point inP, System.Drawing.Point finP, System.Drawing.Image imgOrigin)
        {
            Crop cut = null;
            Bitmap bmp = (Bitmap)imgOrigin;
            if (inP.X < finP.X && inP.Y < finP.Y)
                cut = new Crop(new Rectangle(inP.X, inP.Y, finP.X - inP.X, finP.Y - inP.Y));
            else if (inP.X > finP.X && inP.Y > finP.Y)
                cut = new Crop(new Rectangle(finP.X, finP.Y, inP.X - finP.X, inP.Y - finP.Y));
            else if (inP.X < finP.X && inP.Y > finP.Y)
                cut = new Crop(new Rectangle(inP.X, finP.Y, finP.X - inP.X, inP.Y - finP.Y));
            else if (inP.X > finP.X && inP.Y < finP.Y)
                cut = new Crop(new Rectangle(finP.X, inP.Y, inP.X - finP.X, finP.Y - inP.Y));
            bmp = cut.Apply(bmp);
            ResizeNearestNeighbor filter = new ResizeNearestNeighbor(bmp.Width * 2, bmp.Height * 2);
            bmp = filter.Apply(bmp);
            return bmp;
        }

        
    }
}
