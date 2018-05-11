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

namespace u4Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        Rectangle rectanglePlayer = new Rectangle();
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()

        {
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
            InitializeComponent();
            GenerateEat();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.W))
            {
                GeneratePlayer();
                
            }
        }

        private void GeneratePlayer()
        {
            this.rectanglePlayer = new Rectangle();
            rectanglePlayer.Height = 10;
            rectanglePlayer.Width = 10;
            
            rectanglePlayer.Fill = Brushes.LawnGreen;
            canvas.Children.Add(rectanglePlayer);
        }

        private void GenerateEat()
        {
            
            int x_pos = r.Next(0,525);
            int y_pos = r.Next(0,350);

            Rectangle rectangleEat = new Rectangle();
            rectangleEat.Fill = Brushes.Red;
            rectangleEat.Height = 10;
            rectangleEat.Width = 10;

            Canvas.SetTop(rectangleEat, x_pos);
            Canvas.SetLeft(rectangleEat, y_pos);
            canvas.Children.Add(rectangleEat);
           
        }

       
          
        
    }
}
