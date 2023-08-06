/* 
 * Author: Jacob Paulin
 * Date: Aug 4, 2023
 * Modified: Aug 4, 2023
 */
using cst8333ApplicationByJacobPaulin.BusinessLayer;
using MindFusion.Charting.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace cst8333ApplicationByJacobPaulin.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GraphsView.xaml
    /// </summary>
    /// <author>Jacob Paulin</author>
    public partial class GraphsView : Page
    {
        private DataController Controller;
        private IList<VegetableRecord> VegetableRecords;
        private IList<VegetableRecord> TargetRecords;
        private DoubleCollection yData;
        private DoubleCollection xData;

        /// <summary>
        /// Constructor for the graph page, in here
        /// we will run code that will initialize the
        /// user interface
        /// </summary>
        /// <author>Jacob Paulin</author>
        public GraphsView()
        {
            InitializeComponent();

            // Initialize the data controller
            Controller = new DataController();

            Init();
        }

        /// <summary>
        /// Using a external async function called from the 
        /// contructor to make use of the await keyword
        /// </summary>
        /// <author>Jacob Paulin</author>
        public async void Init()
        {
            // Get all the records from the DB
            VegetableRecords = await Controller.ReadAllVegetableRecord();

            // Load the combo boxes
            ComboBoxRefDate.ItemsSource = (await Controller.ReadAllVegetableRecord()).Select(r => r.RefDate).Distinct().ToList();
            ComboBoxRefDate.SelectedIndex = 0;

            // Refresh the graph data
            RefreshGraph();
        }

        /// <summary>
        /// Event handler for the combo box which is triggered 
        /// every time something is selected in the combo box
        /// </summary>
        /// <param name="sender">Event action sender</param>
        /// <param name="e">Event arguments</param>
        /// <author>Jacob Paulin</author>
        private void ComboBoxRefDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Refresh the content of the graph
            RefreshGraph();
        }

        /// <summary>
        /// Generates a list of vegetable records for the sepcified ref date
        /// </summary>
        /// <param name="refDate">The ref date to search for</param>
        /// <returns>A list of all vegetable records for the specified ref date</returns>
        /// <author>Jacob Paulin</author>
        private IList<VegetableRecord> GenerateTargetRecordsForRefDate(string refDate)
            => VegetableRecords.Where(r => r.RefDate == refDate).ToList();

        /// <summary>
        /// Refreshes the contents of the displayed graph
        /// </summary>
        /// <author>Jacob Paulin</author>
        private void RefreshGraph()
        {
            // Generate the target records
            TargetRecords = GenerateTargetRecordsForRefDate((string)ComboBoxRefDate.SelectedItem);

            // Set the data vars
            yData = new DoubleCollection(TargetRecords.Select(r => (double)r.Value));
            xData = new DoubleCollection();
            List<string> xTargets = TargetRecords.Where(r => r.Vector != null).Select(r => r.Vector).Distinct().ToList();
            foreach (var item in xTargets)
            {
                xData.Add(xTargets.IndexOf(item) + 1);
            }

            // Set the title
            barChart.Title = $"Value For Ref Date {(string)ComboBoxRefDate.SelectedItem}";

            // Clear the series on the chart and create a new one
            barChart.Series.Clear();
            BarSeries series = new BarSeries();
    
            // Configure the X axis
            series.XData = xData;
            series.XAxis = barChart.XAxes[0];
            series.XAxis.Title = "Vector";
            series.XAxis.LabelType = LabelType.CustomText;
            series.XAxis.Labels = xTargets;
            series.XAxis.LabelRotationAngle = 295;

            // Configure the Y axis
            series.YData = yData;
            series.YAxis = barChart.YAxes[0];
            series.YAxis.Interval = 1000;
            series.YAxis.Title = "Value";
        
            // Add the new series to the chart
            barChart.Series.Add(series);
        }
    }
}
