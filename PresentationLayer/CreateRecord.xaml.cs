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
    public partial class CreateRecord : Page
    {
        private DataController Controller;

        public CreateRecord()
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();
        }

        #region Interaction Events
        private void ButtonSaveRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonSaveRecord) Save recrod button pushed");

            VegetableRecord newRecord = new VegetableRecord();
            //{
            //    RefDate = TextBoxRefDate.Text,
            //    Geo = TextBoxGeo.Text,
            //    DGUID = TextBoxDGUID.Text,
            //    TypeOfProduct = TextBoxTypeOfProduct.Text,
            //    TypeOfStorage = TextBoxTypeOfStorage.Text,
            //    UOM = TextBoxUOM.Text,
            //    UOMID = int.Parse(TextBoxUOMID.Text),
            //    ScalarFactor = TextBoxScalarFactor.Text,
            //    ScalarId = int.Parse(TextBoxScalarId.Text),
            //    Vector = TextBoxVector.Text,
            //    Coordinate = TextBoxCoordinate.Text,
            //    Value = int.Parse(TextBoxValue.Text),
            //    Status = TextBoxStatus.Text,
            //    Symbol = TextBoxSymbol.Text,
            //    Terminated = TextBoxTerminated.Text,
            //    Decimals = int.Parse(TextBoxDecimals.Text)
            //};

            if (!string.IsNullOrWhiteSpace(TextBoxRefDate.Text))
            {
                newRecord.RefDate = TextBoxRefDate.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxGeo.Text))
            {
                newRecord.Geo = TextBoxGeo.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxDGUID.Text))
            {
                newRecord.DGUID = TextBoxDGUID.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxTypeOfProduct.Text))
            {
                newRecord.TypeOfProduct = TextBoxTypeOfProduct.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxTypeOfStorage.Text))
            {
                newRecord.TypeOfStorage = TextBoxTypeOfStorage.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxUOM.Text))
            {
                newRecord.UOM = TextBoxUOM.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxUOMID.Text) && int.TryParse(TextBoxUOMID.Text, out int _UOMID))
            {
                newRecord.UOMID = _UOMID;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxScalarFactor.Text))
            {
                newRecord.ScalarFactor = TextBoxScalarFactor.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxScalarId.Text) && int.TryParse(TextBoxUOMID.Text, out int _ScalarId))
            {
                newRecord.ScalarId = _ScalarId;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxVector.Text))
            {
                newRecord.Vector = TextBoxVector.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxCoordinate.Text))
            {
                newRecord.Coordinate = TextBoxCoordinate.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxValue.Text) && int.TryParse(TextBoxUOMID.Text, out int _Value))
            {
                newRecord.Value = _Value;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxStatus.Text))
            {
                newRecord.Status = TextBoxStatus.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxSymbol.Text))
            {
                newRecord.Symbol = TextBoxSymbol.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxTerminated.Text))
            {
                newRecord.Terminated = TextBoxTerminated.Text;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxDecimals.Text) && int.TryParse(TextBoxUOMID.Text, out int _Decimals))
            {
                newRecord.Decimals = _Decimals;
            }

            Log("(ButtonSaveRecord) Trying to save record");
            bool operation = Controller.CreateRecord(newRecord);
            if (operation)
            {
                Log($"(ButtonSaveRecord) Displaying success message");
                MessageBox.Show("Successfully save record");
            }
            else
            {
                Log($"(ButtonSaveRecord) Displaying failed message");
                MessageBox.Show("Failed to save data");
            }

            Log("(ButtonSaveRecord) Navigating to home page");
            NavigationService.Navigate(new Home());
        }
        #endregion

        #region Methods
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] CreateRecord.xaml.cs: {msg}");
        #endregion
    }
}
