using cst8333ProjectByJacobPaulin.BusinessLayer;
using cst8333ProjectByJacobPaulin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace cst8333ProjectByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for RecordView.xaml
    /// </summary>
    public partial class RecordView : Page
    {
        public event EventHandler RecordActionComplete;
        private VegetableRecord selectedRecord { get; set; }
        private DataController Controller;

        public RecordView(VegetableRecord record)
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();

            // Update the selected record
            selectedRecord = record;

            // Pre-fill the text boxes
            TextBoxRefDate.Text = record.RefDate;
            TextBoxGeo.Text = record.Geo;
            TextBoxDGUID.Text = record.DGUID;
            TextBoxTypeOfProduct.Text = record.TypeOfProduct;
            TextBoxTypeOfStorage.Text = record.TypeOfStorage;
            TextBoxUOM.Text = record.UOM;
            TextBoxUOMID.Text = record.UOMID.ToString();
            TextBoxScalarFactor.Text = record.ScalarFactor;
            TextBoxScalarId.Text = record.ScalarId.ToString();
            TextBoxVector.Text = record.Vector;
            TextBoxCoordinate.Text = record.Coordinate;
            TextBoxValue.Text = record.Value.ToString();
            TextBoxStatus.Text = record.Status;
            TextBoxSymbol.Text = record.Symbol;
            TextBoxTerminated.Text = record.Terminated;
            TextBoxDecimals.Text = record.Decimals.ToString();
        }

        #region Interaction Events
        private void ButtonDeleteRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonDeleteRecord) Delete recrod button pushed");

            Log("(ButtonDeleteRecord) Trying to delete record");
            bool operation = Controller.DeleteRecord(selectedRecord);
            if (operation)
            {
                Log($"(ButtonDeleteRecord) Displaying success message");
                MessageBox.Show("Successfully deleted record");
            }
            else
            {
                Log($"(ButtonDeleteRecord) Displaying failed message");
                MessageBox.Show("Failed to delete data");
            }

            Log("(ButtonDeleteRecord) Navigating to home page");
            NavigationService.Navigate(new Home());
        }

        private void ButtonSaveRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonSaveRecord) Save recrod button pushed");

            VegetableRecord newRecord = new VegetableRecord()
            {
                RefDate = TextBoxRefDate.Text,
                Geo = TextBoxGeo.Text,
                DGUID = TextBoxDGUID.Text,
                TypeOfProduct = TextBoxTypeOfProduct.Text,
                TypeOfStorage = TextBoxTypeOfStorage.Text,
                UOM = TextBoxUOM.Text,
                UOMID = int.Parse(TextBoxUOMID.Text),
                ScalarFactor = TextBoxScalarFactor.Text,
                ScalarId = int.Parse(TextBoxScalarId.Text),
                Vector = TextBoxVector.Text,
                Coordinate = TextBoxCoordinate.Text,
                Value = int.Parse(TextBoxValue.Text),
                Status = TextBoxStatus.Text,
                Symbol = TextBoxSymbol.Text,
                Terminated = TextBoxTerminated.Text,
                Decimals = int.Parse(TextBoxDecimals.Text)
            };

            Log("(ButtonSaveRecord) Trying to save record");
            bool operation = Controller.UpdateRecord(newRecord, selectedRecord);
            if (operation)
            {
                Log($"(ButtonSaveRecord) Displaying success message");
                MessageBox.Show("Successfully deleted record");
            }
            else
            {
                Log($"(ButtonSaveRecord) Displaying failed message");
                MessageBox.Show("Failed to delete data");
            }

            Log("(ButtonSaveRecord) Navigating to home page");
            NavigationService.Navigate(new Home());
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] RecordView.xaml.cs: {msg}");
        #endregion

        #region Events
        private void RecordActionCompleted(EventArgs e)
        {
            if (RecordActionComplete != null)
            {
                RecordActionComplete(this, e);
            }
        }
        #endregion
    }
}
