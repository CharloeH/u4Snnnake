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
        int i = 0;
        int z = 0;
        Rectangle rectangleEat = new Rectangle();
        Random r = new Random();
        List randomList = new List();
        Rectangle rectanglePlayer = new Rectangle();
        Point pointHorizontal;
        Point pointVertical;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()

        {
            
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
            InitializeComponent();
            
            

        }
       
        private void gameTimer_Tick(object sender, EventArgs e)
        {

            movePlayer();

        }

        private void movePlayer()
        {
            int i = 0;
            pointHorizontal = new Point(i, 0);
            pointVertical = new Point(0, z);
            if (Keyboard.IsKeyDown(Key.S))
            {

                i = 1;
                
                while (i == 1)
                {
                    Canvas.SetTop(rectanglePlayer, pointVertical.Y);
                    z = z + 10;
                    if(Keyboard.IsKeyUp(Key.S))
                    {
                        i = 0;
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                i = 2;
                Canvas.SetTop(rectanglePlayer, pointVertical.Y);
                while (i == 2)
                {
                    z = z - 10;
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {

                Canvas.SetLeft(rectanglePlayer, pointHorizontal.X);
                i = i - 10;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {


                Canvas.SetLeft(rectanglePlayer, pointHorizontal.X);
                i = i + 10;
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

            int x_pos = r.Next(0,50);
            int y_pos = r.Next(0,34);
            

            
            rectangleEat.Fill = Brushes.Red;
            rectangleEat.Height = 10;
            rectangleEat.Width = 10;

            Canvas.SetTop(rectangleEat, y_pos*10);
            Canvas.SetLeft(rectangleEat, x_pos*10);
            canvas.Children.Add(rectangleEat);


        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                canvas.Children.Clear();
                GenerateEat();
                this.i = 0;
                this.z = 0;
                GeneratePlayer();
            }
           
               
            
        }
    }
}
