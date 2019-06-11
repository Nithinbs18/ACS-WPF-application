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

namespace restaurant
{
    public class PrintBill
    {
        //public static ObservableCollection<printBillData> finalBillOrder = new ObservableCollection<printBillData>();
        
        public PrintBill(ObservableCollection<printBillData> finalBillOrderPrint, string name, string total)
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
            graphics.DrawLine(pen, new PointF(0, 60), new PointF(950, 60));
            graphics.DrawLine(pen, new PointF(0, page.Graphics.ClientSize.Height - 100), new PointF(950, page.Graphics.ClientSize.Height - 100));
            graphics.DrawString("Total:   "+ total+" EURO", font2, PdfBrushes.Black, new PointF(400, page.Graphics.ClientSize.Height - 80));

            //Create a new PDF grid
            PdfGrid grid = new PdfGrid();

            //Add the data source
            grid.DataSource = finalBillOrderPrint;

            //Apply built-in grid style
            //grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable6Colorful);

            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();

            //Set the layout type as paginate
            layoutFormat.Layout = PdfLayoutType.OnePage;

            //Draws the grid to the PDF page
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, 75), new SizeF(page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height - 100)), layoutFormat);

            //Save the PDF stream to physical file
            doc.Save(name + ".pdf");
            System.Diagnostics.Process.Start(name+".pdf");
            doc.Close(true);

        }
    }
    public class printBillData
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }

    }
}
