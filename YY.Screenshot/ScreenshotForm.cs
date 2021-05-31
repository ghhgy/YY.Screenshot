using System;
using System.Drawing;
using System.Windows.Forms;

namespace YY.Screenshot
{
    internal partial class ScreenshotForm : Form
    {
        private Point startPoint; // 按下的点
        private Point endPoint; // 松开的点
        private Pen pen1 = new Pen(Color.Black, 1);
        public Image img2; //截图后的图片
        private bool leftBtisDown = false;  // 鼠标左键是否按下
        public bool isCopyToClipboard = false;  // 是否复制到剪贴板
        public ScreenshotForm()
        {
            InitializeComponent();
            //双缓冲
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.ShowInTaskbar = false;
            this.TopMost = true;
        }

        private void ScreenshotForm_Load(object sender, EventArgs e)
        {

            // 让ScreenshotForm和屏幕一样大小
            Visible = false;

            Size sz1 = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);//屏幕Size
            Size = sz1;
            Location = new Point(0, 0);

            Image img1 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g1 = Graphics.FromImage(img1);
            g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), sz1);
            g1.DrawRectangle(pen1, 0, 0, sz1.Width, sz1.Height);    // 红线画边框
            BackgroundImage = img1;
            Cursor = Cursors.Cross;

            Visible = true;

        }

        private void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            leftBtisDown = true;

            startPoint = e.Location; //记录按下的点

        }

        private void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            //Hide();
            leftBtisDown = false;

            endPoint = e.Location; //记录松开的点

            try
            {
                img2 = new Bitmap(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            catch
            {
                return;
            }
            Graphics g2 = Graphics.FromImage(img2);
            Point r = new Point();
            Size sz = new Size();
            Point upperLeftDestinationPoint = new Point((int)-pen1.Width, (int)-pen1.Width);
            string warningMessage = "图片太小,请重新选择";
            if ((endPoint.X - startPoint.X) > 0 && (endPoint.Y - startPoint.Y) > 0)
            {
                r.X = startPoint.X;
                r.Y = startPoint.Y;

                sz = new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, upperLeftDestinationPoint, sz); //右下截图
            }
            else if ((endPoint.X - startPoint.X) > 0 && (endPoint.Y - startPoint.Y) < 0)
            {
                r.X = startPoint.X;
                r.Y = endPoint.Y;
                sz = new Size(endPoint.X - startPoint.X, startPoint.Y - endPoint.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, upperLeftDestinationPoint, sz); //右上截图
            }
            else if ((endPoint.X - startPoint.X) < 0 && (endPoint.Y - startPoint.Y) > 0)
            {
                r.X = endPoint.X;
                r.Y = startPoint.Y;
                sz = new Size(startPoint.X - endPoint.X, endPoint.Y - startPoint.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, upperLeftDestinationPoint, sz); //左下截图
            }
            else if ((endPoint.X - startPoint.X) < 0 && (endPoint.Y - startPoint.Y) < 0)
            {
                r.X = endPoint.X;
                r.Y = endPoint.Y;
                sz = new Size(startPoint.X - endPoint.X, startPoint.Y - endPoint.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, upperLeftDestinationPoint, sz); //左上截图
            }



            if (isCopyToClipboard) { Clipboard.SetImage(img2); }

            Close();

        }

        private void ScreenshotForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftBtisDown == false)
            {
                return;
            }
            endPoint = e.Location;
            if (leftBtisDown == true)
            {
                drawRec();
            }
        }

        private Size sz = new Size();
        private Point r = new Point();   //矩形左上方的点
        private Rectangle rec = new Rectangle();

        private void drawRec()
        {
            Graphics g = CreateGraphics();
            Refresh();

            if ((endPoint.X - startPoint.X) > 0 && (endPoint.Y - startPoint.Y) > 0)
            {
                sz = new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                rec = new Rectangle(startPoint, sz);
                g.DrawRectangle(pen1, rec);

            }
            else if ((endPoint.X - startPoint.X) > 0 && (endPoint.Y - startPoint.Y) < 0)
            {
                r.X = startPoint.X;
                r.Y = endPoint.Y;
                sz = new Size(endPoint.X - startPoint.X, startPoint.Y - endPoint.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
            else if ((endPoint.X - startPoint.X) < 0 && (endPoint.Y - startPoint.Y) > 0)
            {
                r.X = endPoint.X;
                r.Y = startPoint.Y;
                sz = new Size(startPoint.X - endPoint.X, endPoint.Y - startPoint.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
            else if ((endPoint.X - startPoint.X) < 0 && (endPoint.Y - startPoint.Y) < 0)
            {
                r.X = endPoint.X;
                r.Y = endPoint.Y;
                sz = new Size(startPoint.X - endPoint.X, startPoint.Y - endPoint.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
        }

    }
}
