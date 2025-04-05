using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FunWithShape
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum ShapeType
        {
            Circle,
            Rectangle,
            Line
        };
        private ShapeType _selectedShape;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CircleRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedShape = ShapeType.Circle;
        }

        private void RectRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedShape = ShapeType.Rectangle;
        }

        private void LineRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedShape = ShapeType.Line;
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Shape shapeToRender = null;

            switch (_selectedShape)
            {
                case ShapeType.Circle:
                    shapeToRender = new Ellipse { Fill = Brushes.Red, Width = 35, Height = 35 };
                    break;
                case ShapeType.Rectangle:
                    shapeToRender = new Rectangle { Fill = Brushes.Green, Width = 35, Height = 35, RadiusX = 10, RadiusY = 10 };
                    break;
                case ShapeType.Line:
                    shapeToRender = new Line { Stroke = Brushes.Blue, Width = 35, Height = 35, X1 = 0, Y1 = 0, X2 = 50, Y2 = 0, StrokeThickness = 10, StrokeStartLineCap = PenLineCap.Round, StrokeEndLineCap = PenLineCap.Round };
                    break;
                default:
                    return;
            }

            // set start position of each shape
            Canvas.SetLeft(shapeToRender, e.GetPosition(DrawingCanvas).X - (shapeToRender.Width / 2.0));
            Canvas.SetTop(shapeToRender, e.GetPosition(DrawingCanvas).Y - (shapeToRender.Height / 2.0));

            // add shape object to canvas
            DrawingCanvas.Children.Add(shapeToRender);
        }

        private void DrawingCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point position = e.GetPosition(DrawingCanvas);
            MousePositionText.Text = $"X: {position.X}, Y: {position.Y}";
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (DrawingCanvas.Children.Count == 0)
                return;

            MessageBoxResult result = MessageBox.Show(
                "Area you sure to clear canvas?",
                "Confirm Clear",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                DrawingCanvas.Children.Clear();
            }
        }
    }
}