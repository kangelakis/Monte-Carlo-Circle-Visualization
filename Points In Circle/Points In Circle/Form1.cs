using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Points_In_Circle
{
    public partial class Form1 : Form
    {
        private List<Point> Points = new List<Point>();
        private Point middle = new Point();
        private int width = 300, height = 300; //Sizes of rectangle
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            middle.X = panel1.Width / 2;
            middle.Y = panel1.Height / 2;
            int x = middle.X - width / 2;
            int y = middle.Y - height / 2;
            int radius = (int)Math.Sqrt(Math.Pow(middle.X - x, 2));
            float c = 0;

            Rectangle rect = new Rectangle(x, y, width, height);

            foreach (Point p in Points)
            {
                int distance = (int)Math.Sqrt(Math.Pow(middle.X - p.X, 2) + Math.Pow(middle.Y - p.Y, 2));
                if (distance <= radius)
                {
                    e.Graphics.FillRectangle((Brush)Brushes.Lime, p.X, p.Y, 1, 1);
                    c++;
                }
                else
                {
                    e.Graphics.FillRectangle((Brush)Brushes.Red, p.X, p.Y, 1, 2.5f);
                }
                
            }
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255,Color.Black), 3), rect);
            e.Graphics.DrawEllipse(new Pen(Color.FromArgb(190,Color.White), 3), rect);
            e.Graphics.FillRectangle((Brush)Brushes.Black, middle.X, middle.Y, 4, 4); //Draws a point at the center of the screen

            if (Points.Count > 0)
            {
                float results = (c / Points.Count * 4);
                resultsTextbox.Text = results.ToString();
            }
            
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Points.Clear(); //Clear if any previous points
            Random rand = new Random();
            middle.X = panel1.Width / 2;
            middle.Y = panel1.Height / 2;
            int x = middle.X - width / 2;
            int y = middle.Y - height / 2;

            try
            {
                int numOfPoints = Int32.Parse(pointsTextbox.Text);
                for (int i = 0; i < numOfPoints; i++)
                {
                    int randX = rand.Next(x, x + width);
                    int randY = rand.Next(y, y + height);
                    Points.Add(new Point(randX, randY));

                }
                panel1.Invalidate(); //Update the panel with the new points
            }
            catch(Exception){}
            

            
        }

       
    }
}
