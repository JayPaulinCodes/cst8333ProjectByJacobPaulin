/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: July 19, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace cst8333ApplicationByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for RecordView.xaml
    /// </summary>
    /// <author>Jacob Paulin</author>
    public partial class CreateRecord : Page
    {
        private DataController Controller;

        /// <summary>
        /// Constructor for the create record window, 
        /// in here we will run code that will initialize 
        /// the user interface
        /// </summary>
        /// <author>Jacob Paulin</author>
        public CreateRecord()
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();
        }

        #region Interaction Events
        /// <summary>
        /// Interaction method triggered when the save record
        /// button is pushed. Will then try to save the record and
        /// then show a success or failure message
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private async void ButtonSaveRecord(object sender, RoutedEventArgs e)
        {
            Log("(ButtonSaveRecord) Save recrod button pushed");

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
            bool operation = await Controller.CreateVegetableRecord(newRecord);
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
        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] CreateRecord.xaml.cs: {msg}");
        #endregion
    }
}
