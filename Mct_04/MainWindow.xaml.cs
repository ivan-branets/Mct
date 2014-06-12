namespace Mct_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawCircle();
        }

        private void DrawCircle()
        {
            const int r = 155;

            var centerX = (int) Width / 2;
            var centerY = (int) Height / 2 - 20;

            var circle = new Circle(r, centerX, centerY);
            Polygon.Points = circle.GetPoints();
        }
    }
}
