namespace PaintFinal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитькакToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btn_select = new Button();
            btn_clear = new Button();
            btn_line = new Button();
            btn_rect = new Button();
            btn_ellipse = new Button();
            btn_eraser = new Button();
            btn_pencil = new Button();
            btn_fill = new Button();
            btn_color = new Button();
            pic_color = new Button();
            panel2 = new Panel();
            label1 = new Label();
            trackBar1 = new TrackBar();
            pic = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DarkSlateGray;
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, redoToolStripMenuItem, undoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1390, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.Click += menuStrip1_Click;
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.BackColor = Color.DarkSlateGray;
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, toolStripSeparator, сохранитьToolStripMenuItem, сохранитькакToolStripMenuItem, toolStripSeparator1, выходToolStripMenuItem });
            файлToolStripMenuItem.ForeColor = Color.DarkSalmon;
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "&Файл";
            файлToolStripMenuItem.Click += файлToolStripMenuItem_Click;
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Image = (Image)resources.GetObject("создатьToolStripMenuItem.Image");
            создатьToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            создатьToolStripMenuItem.Size = new Size(173, 22);
            создатьToolStripMenuItem.Text = "&Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Image = (Image)resources.GetObject("открытьToolStripMenuItem.Image");
            открытьToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            открытьToolStripMenuItem.Size = new Size(173, 22);
            открытьToolStripMenuItem.Text = "&Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(170, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Image = (Image)resources.GetObject("сохранитьToolStripMenuItem.Image");
            сохранитьToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьToolStripMenuItem.Size = new Size(173, 22);
            сохранитьToolStripMenuItem.Text = "&Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // сохранитькакToolStripMenuItem
            // 
            сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            сохранитькакToolStripMenuItem.Size = new Size(173, 22);
            сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            сохранитькакToolStripMenuItem.Click += сохранитькакToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(170, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(173, 22);
            выходToolStripMenuItem.Text = "Вы&ход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            redoToolStripMenuItem.ForeColor = Color.DarkSalmon;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(29, 20);
            redoToolStripMenuItem.Text = "↪️";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            undoToolStripMenuItem.ForeColor = Color.DarkSalmon;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(29, 20);
            undoToolStripMenuItem.Text = "↩️";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(btn_select);
            panel1.Controls.Add(btn_clear);
            panel1.Controls.Add(btn_line);
            panel1.Controls.Add(btn_rect);
            panel1.Controls.Add(btn_ellipse);
            panel1.Controls.Add(btn_eraser);
            panel1.Controls.Add(btn_pencil);
            panel1.Controls.Add(btn_fill);
            panel1.Controls.Add(btn_color);
            panel1.Controls.Add(pic_color);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1390, 91);
            panel1.TabIndex = 1;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // btn_select
            // 
            btn_select.Cursor = Cursors.Hand;
            btn_select.FlatAppearance.BorderSize = 0;
            btn_select.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_select.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_select.FlatStyle = FlatStyle.Flat;
            btn_select.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_select.ForeColor = Color.DarkSalmon;
            btn_select.Image = (Image)resources.GetObject("btn_select.Image");
            btn_select.ImageAlign = ContentAlignment.TopCenter;
            btn_select.Location = new Point(132, 12);
            btn_select.Name = "btn_select";
            btn_select.Size = new Size(69, 62);
            btn_select.TabIndex = 10;
            btn_select.Text = "Select";
            btn_select.TextAlign = ContentAlignment.BottomCenter;
            btn_select.UseVisualStyleBackColor = true;
            btn_select.Click += btn_select_Click;
            // 
            // btn_clear
            // 
            btn_clear.Cursor = Cursors.Hand;
            btn_clear.FlatAppearance.BorderSize = 0;
            btn_clear.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_clear.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_clear.FlatStyle = FlatStyle.Flat;
            btn_clear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_clear.ForeColor = Color.DarkSalmon;
            btn_clear.Image = Properties.Resources.free_icon_mop_8033451__1_;
            btn_clear.ImageAlign = ContentAlignment.TopCenter;
            btn_clear.Location = new Point(655, 12);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(69, 62);
            btn_clear.TabIndex = 9;
            btn_clear.Text = "Clear";
            btn_clear.TextAlign = ContentAlignment.BottomCenter;
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_line
            // 
            btn_line.Cursor = Cursors.Hand;
            btn_line.FlatAppearance.BorderSize = 0;
            btn_line.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_line.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_line.FlatStyle = FlatStyle.Flat;
            btn_line.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_line.ForeColor = Color.DarkSalmon;
            btn_line.Image = Properties.Resources.free_icon_diagonal_line_815446;
            btn_line.ImageAlign = ContentAlignment.TopCenter;
            btn_line.Location = new Point(580, 12);
            btn_line.Name = "btn_line";
            btn_line.Size = new Size(69, 62);
            btn_line.TabIndex = 7;
            btn_line.Text = "Line";
            btn_line.TextAlign = ContentAlignment.BottomCenter;
            btn_line.UseVisualStyleBackColor = true;
            btn_line.Click += btn_line_Click;
            // 
            // btn_rect
            // 
            btn_rect.Cursor = Cursors.Hand;
            btn_rect.FlatAppearance.BorderSize = 0;
            btn_rect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_rect.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_rect.FlatStyle = FlatStyle.Flat;
            btn_rect.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_rect.ForeColor = Color.DarkSalmon;
            btn_rect.Image = Properties.Resources.free_icon_square_3964478__1_;
            btn_rect.ImageAlign = ContentAlignment.TopCenter;
            btn_rect.Location = new Point(505, 12);
            btn_rect.Name = "btn_rect";
            btn_rect.Size = new Size(69, 62);
            btn_rect.TabIndex = 6;
            btn_rect.Text = "Rectangle";
            btn_rect.TextAlign = ContentAlignment.BottomCenter;
            btn_rect.UseVisualStyleBackColor = true;
            btn_rect.Click += btn_rect_Click;
            // 
            // btn_ellipse
            // 
            btn_ellipse.Cursor = Cursors.Hand;
            btn_ellipse.FlatAppearance.BorderSize = 0;
            btn_ellipse.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_ellipse.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_ellipse.FlatStyle = FlatStyle.Flat;
            btn_ellipse.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ellipse.ForeColor = Color.DarkSalmon;
            btn_ellipse.Image = Properties.Resources.free_icon_circle_3964477;
            btn_ellipse.ImageAlign = ContentAlignment.TopCenter;
            btn_ellipse.Location = new Point(430, 12);
            btn_ellipse.Name = "btn_ellipse";
            btn_ellipse.Size = new Size(69, 62);
            btn_ellipse.TabIndex = 5;
            btn_ellipse.Text = "Ellipse";
            btn_ellipse.TextAlign = ContentAlignment.BottomCenter;
            btn_ellipse.UseVisualStyleBackColor = true;
            btn_ellipse.Click += btn_ellipse_Click;
            // 
            // btn_eraser
            // 
            btn_eraser.Cursor = Cursors.Hand;
            btn_eraser.FlatAppearance.BorderSize = 0;
            btn_eraser.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_eraser.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_eraser.FlatStyle = FlatStyle.Flat;
            btn_eraser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_eraser.ForeColor = Color.DarkSalmon;
            btn_eraser.Image = Properties.Resources.free_icon_eraser_2661282;
            btn_eraser.ImageAlign = ContentAlignment.TopCenter;
            btn_eraser.Location = new Point(355, 12);
            btn_eraser.Name = "btn_eraser";
            btn_eraser.Size = new Size(69, 62);
            btn_eraser.TabIndex = 4;
            btn_eraser.Text = "Eraser";
            btn_eraser.TextAlign = ContentAlignment.BottomCenter;
            btn_eraser.UseVisualStyleBackColor = true;
            btn_eraser.Click += btn_eraser_Click;
            // 
            // btn_pencil
            // 
            btn_pencil.Cursor = Cursors.Hand;
            btn_pencil.FlatAppearance.BorderSize = 0;
            btn_pencil.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_pencil.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_pencil.FlatStyle = FlatStyle.Flat;
            btn_pencil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_pencil.ForeColor = Color.DarkSalmon;
            btn_pencil.Image = Properties.Resources.free_icon_pencil_1046346;
            btn_pencil.ImageAlign = ContentAlignment.TopCenter;
            btn_pencil.Location = new Point(280, 12);
            btn_pencil.Name = "btn_pencil";
            btn_pencil.Size = new Size(69, 62);
            btn_pencil.TabIndex = 3;
            btn_pencil.Text = "Pencil";
            btn_pencil.TextAlign = ContentAlignment.BottomCenter;
            btn_pencil.UseVisualStyleBackColor = true;
            btn_pencil.Click += btn_pencil_Click;
            // 
            // btn_fill
            // 
            btn_fill.Cursor = Cursors.Hand;
            btn_fill.FlatAppearance.BorderSize = 0;
            btn_fill.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_fill.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_fill.FlatStyle = FlatStyle.Flat;
            btn_fill.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_fill.ForeColor = Color.DarkSalmon;
            btn_fill.Image = Properties.Resources.free_icon_paint_bucket_4686706;
            btn_fill.ImageAlign = ContentAlignment.TopCenter;
            btn_fill.Location = new Point(205, 12);
            btn_fill.Name = "btn_fill";
            btn_fill.Size = new Size(69, 62);
            btn_fill.TabIndex = 2;
            btn_fill.Text = "Fill";
            btn_fill.TextAlign = ContentAlignment.BottomCenter;
            btn_fill.UseVisualStyleBackColor = true;
            btn_fill.Click += btn_fill_Click;
            // 
            // btn_color
            // 
            btn_color.Cursor = Cursors.Hand;
            btn_color.FlatAppearance.BorderSize = 0;
            btn_color.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 64, 64);
            btn_color.FlatAppearance.MouseOverBackColor = Color.Teal;
            btn_color.FlatStyle = FlatStyle.Flat;
            btn_color.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_color.ForeColor = Color.DarkSalmon;
            btn_color.Image = Properties.Resources.free_icon_paint_6138257;
            btn_color.ImageAlign = ContentAlignment.TopCenter;
            btn_color.Location = new Point(57, 12);
            btn_color.Name = "btn_color";
            btn_color.Size = new Size(69, 62);
            btn_color.TabIndex = 1;
            btn_color.Text = "Color";
            btn_color.TextAlign = ContentAlignment.BottomCenter;
            btn_color.UseVisualStyleBackColor = true;
            btn_color.Click += btn_color_Click;
            // 
            // pic_color
            // 
            pic_color.BackColor = SystemColors.ActiveCaptionText;
            pic_color.Location = new Point(9, 26);
            pic_color.Name = "pic_color";
            pic_color.Size = new Size(42, 36);
            pic_color.TabIndex = 0;
            pic_color.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(trackBar1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 929);
            panel2.Name = "panel2";
            panel2.Size = new Size(1390, 69);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSalmon;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(207, 25);
            label1.TabIndex = 1;
            label1.Text = "CHANGE PEN WIDTH";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(0, 34);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(984, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Dock = DockStyle.Fill;
            pic.Location = new Point(0, 115);
            pic.Name = "pic";
            pic.Size = new Size(1390, 814);
            pic.TabIndex = 3;
            pic.TabStop = false;
            pic.Paint += pic_Paint;
            pic.MouseClick += pic_MouseClick;
            pic.MouseDown += pic_MouseDown;
            pic.MouseHover += pic_MouseHover;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 998);
            Controls.Add(pic);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитькакToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Button btn_color;
        private Button pic_color;
        private PictureBox pic;
        private Button btn_line;
        private Button btn_rect;
        private Button btn_ellipse;
        private Button btn_eraser;
        private Button btn_pencil;
        private Button btn_fill;
        private Button btn_clear;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private TrackBar trackBar1;
        private Label label1;
        private Button btn_select;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
