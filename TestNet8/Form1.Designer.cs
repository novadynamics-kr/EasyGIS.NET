namespace TestNet8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sfMap1 = new EGIS.Controls.SFMap();
            crsSelectionControl1 = new EGIS.Controls.CRSSelectionControl();
            shapeFileListControl1 = new EGIS.Controls.ShapeFileListControl();
            SuspendLayout();
            // 
            // sfMap1
            // 
            sfMap1.DefaultMapCursor = Cursors.Default;
            sfMap1.DefaultSelectionCursor = Cursors.Hand;
            sfMap1.EnabledSelectKeys = EGIS.Controls.SelectKeys.ControlKey | EGIS.Controls.SelectKeys.ShiftKey | EGIS.Controls.SelectKeys.AltKey;
            sfMap1.Location = new Point(-3, 239);
            sfMap1.MapBackColor = Color.FromArgb(0, 0, 64);
            sfMap1.Margin = new Padding(4);
            sfMap1.MaxZoomLevel = double.MaxValue;
            sfMap1.MinZomLevel = 0D;
            sfMap1.MouseWheelZoomMode = EGIS.Controls.MouseWheelZoomMode.Default;
            sfMap1.Name = "sfMap1";
            sfMap1.PanSelectMode = EGIS.Controls.PanSelectMode.Pan;
            sfMap1.RenderQuality = EGIS.ShapeFileLib.RenderQuality.Auto;
            sfMap1.Size = new Size(223, 175);
            sfMap1.TabIndex = 5;
            sfMap1.UseMemoryStreams = false;
            sfMap1.UseMercatorProjection = false;
            sfMap1.ZoomToSelectedExtentWhenCtrlKeydown = false;
            // 
            // crsSelectionControl1
            // 
            crsSelectionControl1.Location = new Point(313, 37);
            crsSelectionControl1.Margin = new Padding(4, 3, 4, 3);
            crsSelectionControl1.Name = "crsSelectionControl1";
            crsSelectionControl1.SelectedCRS = null;
            crsSelectionControl1.Size = new Size(490, 377);
            crsSelectionControl1.TabIndex = 4;
            // 
            // shapeFileListControl1
            // 
            shapeFileListControl1.Location = new Point(6, 37);
            shapeFileListControl1.Map = null;
            shapeFileListControl1.Margin = new Padding(4, 3, 4, 3);
            shapeFileListControl1.Name = "shapeFileListControl1";
            shapeFileListControl1.Size = new Size(278, 173);
            shapeFileListControl1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sfMap1);
            Controls.Add(crsSelectionControl1);
            Controls.Add(shapeFileListControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private EGIS.Controls.SFMap sfMap1;
        private EGIS.Controls.CRSSelectionControl crsSelectionControl1;
        private EGIS.Controls.ShapeFileListControl shapeFileListControl1;
    }
}
