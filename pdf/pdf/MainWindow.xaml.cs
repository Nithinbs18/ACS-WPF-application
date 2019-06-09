using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.Data;
using System.Collections.ObjectModel;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace pdf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<dummy> dum = new ObservableCollection<dummy>();
        DataTable dtOrderDetail;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                dum.Add(new dummy { id=i, des="asd"+i});
            }
            Grd_dum.ItemsSource = this.dum;

            try
            {
                var dataSet = new DataSet();
                var dataTable = new DataTable();
                dataSet.Tables.Add(dataTable);

                // we assume that the properties of DataSourceVM are the columns of the table
                // you can also provide the type via the second parameter
                dataTable.Columns.Add("id");
                dataTable.Columns.Add("des");

                foreach (var element in dum)
                {
                    var newRow = dataTable.NewRow();

                    // fill the properties into the cells
                    newRow["Property1"] = element.id.ToString();
                    newRow["Property2"] = element.des;

                    dataTable.Rows.Add(newRow);
                }

                this.dtOrderDetail = dataTable;
                // Do excel export
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Source);
            }

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //W_multi win = new W_multi();
        //    //win.Show();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            //if (OrderGridView.ItemsSource != null)
            //{
            //DataTable dtOrderDetail = ((DataView)OrderGridView.ItemsSource).Table;
            //DataTable dtOrderDetail = ((DataView)Grd_dum.ItemsSource).Table;
            //DataTable dtRestaurantInfo = GlobalClass.GetRestaurantInfo();
                string AddressLine1 = "";
                string AddressLine2 = "";
                //if (dtRestaurantInfo != null)
                //{
                //    if (dtRestaurantInfo.Rows.Count > 0)
                //    {
                //        AddressLine1 = dtRestaurantInfo.Rows[0]["RestaurantName"].ToString() + ", " + dtRestaurantInfo.Rows[0]["Address"].ToString();
                //        AddressLine2 = "Phone: " + dtRestaurantInfo.Rows[0]["PhoneNumber"].ToString() + "    " + dtRestaurantInfo.Rows[0]["WebsiteURL"].ToString() + "    " + dtRestaurantInfo.Rows[0]["Email"].ToString();
                //    }
                //}
                ReportParameter[] arrParams = new ReportParameter[6];
            //arrParams[0] = new ReportParameter("rpm_Date", GlobalClass.GetCurrentDateTime().ToShortDateString());
            //arrParams[1] = new ReportParameter("rpm_CustomerName", txbCustomerName.Text);
            //arrParams[2] = new ReportParameter("rpm_OrderNo", txbOrderNo.Text);
            //arrParams[3] = new ReportParameter("rpm_TableNo", txbTableNo.Text);
            //arrParams[4] = new ReportParameter("rpm_AddressLine1", AddressLine1);
            //arrParams[5] = new ReportParameter("rpm_AddressLine2", AddressLine2);

            arrParams[0] = new ReportParameter("rpm_Date", "dateeeeeeeeeeeeeeeeeeeeeexxxxxxxxxx");
            arrParams[1] = new ReportParameter("rpm_CustomerName", "nuuuummmmmmmmmmmm");
            arrParams[2] = new ReportParameter("rpm_OrderNo", "nuuuummmmmmmmmmmm");
            arrParams[3] = new ReportParameter("rpm_TableNo", "nuuuummmmmmmmmmmm");
            arrParams[4] = new ReportParameter("rpm_AddressLine1", AddressLine1);
            arrParams[5] = new ReportParameter("rpm_AddressLine2", AddressLine2);
            string reportPath = Environment.CurrentDirectory + "\\ReportSrc";
                ReportPrintClass objReportPrintClass = new ReportPrintClass("PublicDataSet_OrderDetail", dtOrderDetail, reportPath + "\\Report_Receipt.rdlc", arrParams, 8.27, 11.69, 0.5, 0.5, 0.2, 0.2);

                PrinterSettings ps = new PrinterSettings();
                PrinterSettings.StringCollection printersList = PrinterSettings.InstalledPrinters;
                //string[] arrPrinters = new string[printersList.Count];
                //for (int i = 0; i < printersList.Count; i++)
                //{
                //    arrPrinters[i] = printersList[i];

                //}
                //Cursor = Cursors.Arrow;
                //CustomPrintDialog objCustomPrintDialog = new CustomPrintDialog(arrPrinters);
                //if (objCustomPrintDialog.ShowDialog() == true)
                //{
                //    objReportPrintClass.Print(objCustomPrintDialog.printerName, 1);
                //}
                objReportPrintClass.Dispose();
            //}
        }
    }

}

