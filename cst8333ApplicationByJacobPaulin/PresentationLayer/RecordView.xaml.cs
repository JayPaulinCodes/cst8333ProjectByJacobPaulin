/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;
using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace cst8333ApplicationByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for RecordView.xaml
    /// </summary>
    /// <author>Jacob Paulin</author>
    public partial class RecordView : Page
    {
        #region Variables
        private VegetableRecord SelectedRecord;
        private DataController Controller;
        #endregion

        /// <summary>
        /// Constructor for the main window, in here
        /// we will run code that will initialize the
        /// user interface
        /// </summary>
        /// <param name="record">The record to view</param>
        /// <author>Jacob Paulin</author>
        public RecordView(VegetableRecord record)
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();

            // Update the selected record
            SelectedRecord = record;

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
        /// <summary>
        /// Interaction method triggered when the delete record
        /// button is pushed. Will then try to delete the record and
        /// then show a success or failure message
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ButtonDeleteRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonDeleteRecord) Delete recrod button pushed");

            Log("(ButtonDeleteRecord) Trying to delete record");
            bool operation = Controller.DeleteRecord(SelectedRecord);
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

        /// <summary>
        /// Interaction method triggered when the save record
        /// button is pushed, builds a new record object
        /// and tries to save it showing a failure or success
        /// message after.
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ButtonSaveRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonSaveRecord) Save recrod button pushed");

            // Create the record object and assign the entered fields
            VegetableRecord newRecord = new VegetableRecord();

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
            bool operation = Controller.UpdateRecord(SelectedRecord, newRecord);
            if (operation)
            {
                Log($"(ButtonSaveRecord) Displaying success message");
                MessageBox.Show("Successfully saved record");
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
        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] RecordView.xaml.cs: {msg}");
        #endregion
    }
}
