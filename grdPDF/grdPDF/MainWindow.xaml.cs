using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//using Windows;
//using Windows.Storage.Pickers;
//using Windows.UI.Popups;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;

namespace grdPDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Orders> finalBillOrder = new ObservableCollection<Orders>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                finalBillOrder.Add(new Orders { orderNo = i, details = "des" + i, quantity = i, status = 2, tableNo = i });
            }
        }



    private void OnButtonClick(object sender, RoutedEventArgs e)
        {

            //Create a new PDF document
            PdfDocument doc = new PdfDocument();

            //Add a new PDF page
            PdfPage page = doc.Pages.Add();

            // Create PDF graphics for a page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            PdfFont font3 = new PdfStandardFont(PdfFontFamily.Courier, 7);
            PdfPen pen = new PdfPen(System.Drawing.Color.Black);


            //Draw the text
            graphics.DrawString("High on Flavours", font, PdfBrushes.Black, new PointF(190, 0));
            graphics.DrawString("experience India ...", font2, PdfBrushes.Black, new PointF(300, 20));
            graphics.DrawString("Bonhoefferstraße 4/1, 69123 Heidelberg", font3, PdfBrushes.Black, new PointF(185, 40));
            graphics.DrawString("Ph no: +49 12345678910        Email: order@highonflavours.com", font3, PdfBrushes.Black, new PointF(150, 50));
            graphics.DrawLine(pen, new PointF (0, 60), new PointF (950,60));
            graphics.DrawLine(pen, new PointF(0, page.Graphics.ClientSize.Height - 100), new PointF(950, page.Graphics.ClientSize.Height - 100));
            graphics.DrawString("Total:", font2, PdfBrushes.Black, new PointF(400, page.Graphics.ClientSize.Height - 80));



            //Create a new PDF grid
            PdfGrid grid = new PdfGrid();

            //Add the data source
            grid.DataSource = finalBillOrder;

            //Apply built-in grid style
            //grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable6Colorful);

            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();

            //Set the layout type as paginate
            layoutFormat.Layout = PdfLayoutType.OnePage;

            //Draws the grid to the PDF page
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, 75), new SizeF(page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height - 100)), layoutFormat);

            //Save the PDF stream to physical file
            doc.Save("outputGRD.pdf");
            System.Diagnostics.Process.Start("outputGRD.pdf");
            doc.Close(true);

        }
    }

    public class Orders
    {
        public int orderNo { get; set; }
        public int tableNo { get; set; }
        //public Products orderItem { get; set; }
        public string details { get; set; }
        public float quantity { get; set; }
        public int status { get; set; }
        
    }

    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public int category { get; set; }
    }
}
