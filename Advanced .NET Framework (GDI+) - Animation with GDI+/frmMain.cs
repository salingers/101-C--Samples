//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

public class frmMain : System.Windows.Forms.Form
{
    #region " Windows Form Designer generated code "

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.Run(new frmMain());
    }

    public frmMain()
    {
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.
        AssemblyInfo ainfo = new AssemblyInfo();
        this.Text = ainfo.Title;

    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.

    private System.Windows.Forms.RadioButton optWink;

    private System.Windows.Forms.RadioButton optBall;

    private System.Windows.Forms.Timer tmrAnimation;

    private System.Windows.Forms.RadioButton optText;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        this.tmrAnimation = new System.Windows.Forms.Timer(this.components);
        this.optWink = new System.Windows.Forms.RadioButton();
        this.optBall = new System.Windows.Forms.RadioButton();
        this.optText = new System.Windows.Forms.RadioButton();
        this.SuspendLayout();
        // 
        // tmrAnimation
        // 
        this.tmrAnimation.Enabled = true;
        this.tmrAnimation.Tick += new System.EventHandler(this.TimerOnTick);
        // 
        // optWink
        // 
        resources.ApplyResources(this.optWink, "optWink");
        this.optWink.Checked = true;
        this.optWink.Name = "optWink";
        this.optWink.TabStop = true;
        this.optWink.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
        // 
        // optBall
        // 
        resources.ApplyResources(this.optBall, "optBall");
        this.optBall.Name = "optBall";
        this.optBall.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
        // 
        // optText
        // 
        resources.ApplyResources(this.optText, "optText");
        this.optText.Name = "optText";
        // 
        // frmMain
        // 
        resources.ApplyResources(this, "$this");
        this.BackColor = System.Drawing.SystemColors.Window;
        this.Controls.Add(this.optText);
        this.Controls.Add(this.optBall);
        this.Controls.Add(this.optWink);
        this.MaximizeBox = false;
        this.Name = "frmMain";
        this.Load += new System.EventHandler(this.frmMain_Load);
        this.ResumeLayout(false);

    }

    #endregion


    //' In milliseconds
    const int WINK_TIMER_INTERVAL = 150;
    protected Image[] arrImages = new Image[4];
    protected int intCurrentImage = 0;
    protected int j = 1;

    const int BALL_TIMER_INTERVAL = 25;  //' In milliseconds;
    private int intBallSize = 16; //' fraction of client area;
    private int intMoveSize = 4; //' fraction of ball size;
    private Bitmap bitmap;
    private int intBallPositionX, intBallPositionY;
    private int intBallRadiusX, intBallRadiusY;
    private int intBallMoveX, intBallMoveY;
    private int intBallBitmapWidth, intBallBitmapHeight;
    private int intBitmapWidthMargin, intBitmapHeightMargin;

    const int TEXT_TIMER_INTERVAL = 15;  //' In milliseconds;
    protected int intCurrentGradientShift = 10;
    protected int intGradiantStep = 5;

    // This subroutine handles the Load event for the Form.
    private void frmMain_Load(object sender, System.EventArgs e)
    {
        // Fills the image array for the Winking Eye example.
        int i;
        for (i = 0; i <= 3; i++)
        {
            string sFileName = "..\\..\\Eye" + (i + 1).ToString() + ".png";

            arrImages[i] = new Bitmap(sFileName);
        }
    }

    // This subroutine handles the CheckChanged event for the radio buttons.
    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e) //optWink.CheckedChanged, optBall.CheckedChanged;
    {
        if (optWink.Checked)
        {
            tmrAnimation.Interval = WINK_TIMER_INTERVAL;
        }
        else if (optBall.Checked)
        {
            tmrAnimation.Interval = BALL_TIMER_INTERVAL;
        }
        else if (optText.Checked)
        {
            tmrAnimation.Interval = TEXT_TIMER_INTERVAL;
        }

        OnResize(EventArgs.Empty);
    }

    // This subroutine handles the Tick event for the Timer. 
    // This is where the animation takes place.
    protected void TimerOnTick(object obj, EventArgs ea)
    {
        if (optWink.Checked)
        {
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx = CreateGraphics();
            // Call DrawImage, using Overload #8, which takes the current image to be
            // displayed, the X and Y coordinates (which, in this case centers the 
            // image in the client area), and the image's width and height.
            grfx.DrawImage
                (arrImages[intCurrentImage]
                , Convert.ToInt32((ClientSize.Width - arrImages[intCurrentImage].Width) / 2)
                , Convert.ToInt32((ClientSize.Height - arrImages[intCurrentImage].Height) / 2)
                , arrImages[intCurrentImage].Width
                , arrImages[intCurrentImage].Height);
            // It is always a good idea to call Dispose for objects that expose this
            // method instead of waiting for the Garbage Collector to do it for you.
            // This almost always increases the application's performance.
            grfx.Dispose();
            // Loop through the images.
            intCurrentImage += j;

            if (intCurrentImage == 3)
            {
                // This is the last image of the four, so reverse the animation
                // order so that the eye closes.
                j = -1;
            }
            else if (intCurrentImage == 0)
            {
                // This is the first image of the four, so reverse the animation
                // order so that the eye opens again.
                j = 1;
            }
        }
        else if (optBall.Checked)
        {
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx = CreateGraphics();

            // Draw the bitmap containing the ball on the Form.
            grfx.DrawImage
                (bitmap
                , Convert.ToInt32(intBallPositionX - intBallBitmapWidth / 2)
                , Convert.ToInt32(intBallPositionY - intBallBitmapHeight / 2)
                , intBallBitmapWidth
                , intBallBitmapHeight);
            grfx.Dispose();

            // Increment the ball position by the distance it has
            // moved in both X and Y after being redrawn.
            intBallPositionX += intBallMoveX;
            intBallPositionY += intBallMoveY;

            // Reverse the ball's direction when it hits a boundary.

            if ((intBallPositionX + intBallRadiusX >= ClientSize.Width)
                || (intBallPositionX - intBallRadiusX <= 0))
            {
                intBallMoveX = -intBallMoveX;
                Microsoft.VisualBasic.Interaction.Beep();
            }
            // Set the Y boundary at 40 instead of 0 so the ball does not bounce
            // into controls on the Form.

            if ((intBallPositionY + intBallRadiusY >= ClientSize.Height)
                || (intBallPositionY - intBallRadiusY <= 40))
            {
                intBallMoveY = -intBallMoveY;
                Microsoft.VisualBasic.Interaction.Beep();
            }
        }
        else if (optText.Checked)
        {
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx = CreateGraphics();
            // Set the font type, text, and determine its size.

            Font font = new Font("Microsoft Sans Serif", 96,
                FontStyle.Bold, GraphicsUnit.Point);

            string strText = "GDI+!";

            SizeF sizfText = new SizeF(grfx.MeasureString(strText, font));

            // Set the point at which the text will be drawn: centered
            // in the client area.

            PointF ptfTextStart =
                new PointF(Convert.ToSingle(ClientSize.Width - sizfText.Width) / 2
                    , Convert.ToSingle(ClientSize.Height - sizfText.Height) / 2);

            // Set the gradient start and end point, the latter being adjusted
            // by a changing value to give the animation affect.
            PointF ptfGradientStart = new PointF(0, 0);
            PointF ptfGradientEnd = new PointF(intCurrentGradientShift, 200);
            // Instantiate the brush used for drawing the text.
            LinearGradientBrush grBrush =
                new LinearGradientBrush(ptfGradientStart
                    , ptfGradientEnd
                    , Color.Blue
                    , BackColor);

            // Draw the text centered on the client area.
            grfx.DrawString(strText, font, grBrush, ptfTextStart);
            grfx.Dispose();
            // Shift the gradient, reversing it when it gets to a certain value.
            intCurrentGradientShift += intGradiantStep;

            if (intCurrentGradientShift == 500)
            {
                intGradiantStep = -5;
            }
            else if (intCurrentGradientShift == -50)
            {
                intGradiantStep = 5;
            }
        }
    }

    // This method overrides the OnResize method in the base Control class. OnResize 
    // raises the Resize event, which occurs when the control (in this case, the 
    // Form) is resized.
    protected override void OnResize(EventArgs ea)
    {
        if (optWink.Checked)
        {
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx = CreateGraphics();
            // You could also call grfx.Clear(BackColor) or this.Invalidate() to clear
            // off the screen.
            this.Refresh();
            grfx.Dispose();
        }
        else if (optBall.Checked)
        {
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx = CreateGraphics();
            grfx.Clear(BackColor);
            // Set the radius of the ball to a fraction of the width or height
            // of the client area, whichever is less.
            double dblRadius = Math.Min(ClientSize.Width / grfx.DpiX,
                ClientSize.Height / grfx.DpiY) / intBallSize;

            // Set the width and height of the ball in most cases the DPI is
            // identical in the X and Y axes.
            intBallRadiusX = Convert.ToInt32(dblRadius * grfx.DpiX);
            intBallRadiusY = Convert.ToInt32(dblRadius * grfx.DpiY);
            grfx.Dispose();

            // Set the distance the ball moves to 1 pixel or a fraction of the
            // ball's size, whichever is greater. This means that the distance the 
            // ball moves each time it is drawn is proportional to its size, which 
            // is, in turn, proportional to the size of the client area. Thus, when 
            // the client area is shrunk the ball slows down, and when it is 
            // increased, the ball speeds up. 
            intBallMoveX = Convert.ToInt32(Math.Max(1, intBallRadiusX / intMoveSize));
            intBallMoveY = Convert.ToInt32(Math.Max(1, intBallRadiusY / intMoveSize));

            // Notice that the value of the ball's movement also serves the
            // margin around the ball, which determines the size of the actual 
            // bitmap on which the ball is drawn. Thus, the distance the ball moves 
            // is exactly equal to the size of the bitmap, which permits the previous 
            // image of the ball to be erased before the next image is drawn, all 
            // without an inordinate amount of flickering.
            intBitmapWidthMargin = intBallMoveX;
            intBitmapHeightMargin = intBallMoveY;
            // Determine the actual size of the Bitmap on which the ball is drawn by
            // adding the margins to the ball's dimensions.
            intBallBitmapWidth = 2 * (intBallRadiusX + intBitmapWidthMargin);
            intBallBitmapHeight = 2 * (intBallRadiusY + intBitmapHeightMargin);
            // Create a new bitmap, passing in the width and height
            bitmap = new Bitmap(intBallBitmapWidth, intBallBitmapHeight);
            // Obtain the Graphics object exposed by the Bitmap, clear the existing 
            // ball, and draw the new ball.
            grfx = Graphics.FromImage(bitmap);
            grfx.Clear(BackColor);
            grfx.FillEllipse(Brushes.Red, new Rectangle(intBallMoveX,
                    intBallMoveY, 2 * intBallRadiusX, 2 * intBallRadiusY));
            grfx.Dispose();
            // Reset the ball's position to the center of the client area.
            intBallPositionX = Convert.ToInt32(ClientSize.Width / 2);
            intBallPositionY = Convert.ToInt32(ClientSize.Height / 2);

        }
        else if (optText.Checked)
        {
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx = CreateGraphics();
            grfx.Clear(BackColor);
        }
    }
}

