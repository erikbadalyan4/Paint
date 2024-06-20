using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static PaintFinal.Form1;

namespace PaintFinal
{

    public partial class Form1 : Form
    {
        int SavingFormat = 0;//0 - файл еще не был сохранен; 1 - сохранен в jpeg; 2 - сохранен в bmp;
        string FilePath;//Путь файла
        Bitmap bm;
        Bitmap BooferBimtmap;
        bool BMisModif;
        Rectangle BooferRect;
        Graphics g;
        bool paint = false;
        bool Selecting = true;
        bool Dragging = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index = 0;
        int x, y, sX, sY, cX, cY;
        ColorDialog cd = new ColorDialog();
        Color new_color = Color.Black;
        Color old_color;
        public class History
        {
            private List<Bitmap> Undostates = new List<Bitmap>();
            private List<Bitmap> Redostates = new List<Bitmap>();
            private bool Select;
            public void UndoAddState(Bitmap state)
            {
                if (Undostates.Count == 15)
                {
                    Undostates[0].Dispose();
                    Undostates.RemoveAt(0);
                }
                Undostates.Add(state);
            }
            public void UndoAddState(Bitmap state, bool Sel)
            {
                if (Undostates.Count == 15)
                {
                    Undostates[0].Dispose();
                    Undostates.RemoveAt(0);
                }
                Select = Sel;
                Undostates.Add(state);
            }
            public void RedoAddState(Bitmap state)
            {
                if (Redostates.Count == 15)
                {
                    Redostates[0].Dispose();
                    Redostates.RemoveAt(0);
                }
                Redostates.Add(state);
            }
            public bool CanUndo()
            {
                return Undostates.Count > 0;
            }
            public bool CanRedo()
            {
                return Redostates.Count > 0;
            }

            public Bitmap Undo(Bitmap thisTimeBipmap)
            {
                if (Undostates.Count() > 0)
                {
                    RedoAddState(thisTimeBipmap);
                    Bitmap ReturnedBM = Undostates.Last();
                    Undostates.RemoveAt(Undostates.Count - 1);
                    return ReturnedBM;
                }
                return null;
            }
            public Bitmap UndoSelect()
            {
                if (Undostates.Count() > 0)
                {
                    Bitmap ReturnedBM = Undostates.Last();
                    Undostates.RemoveAt(Undostates.Count - 1);
                    return ReturnedBM;
                }
                return null;
            }

            public Bitmap Redo(Bitmap thisTimeBipmap)
            {
                if (Redostates.Count() > 0)
                {
                    UndoAddState(thisTimeBipmap);
                    Bitmap ReturnedBM = Redostates.Last();
                    Redostates.RemoveAt(Redostates.Count - 1);
                    return ReturnedBM;
                }
                return null;
            }
            public void ClearRedo()
            {
                foreach (Bitmap bitmap in Redostates)
                {
                    bitmap.Dispose();
                }
                Redostates.Clear();
            }
            public void Clear()
            {
                foreach (Bitmap bitmap in Undostates)
                {
                    bitmap.Dispose();
                }
                Undostates.Clear();
                foreach (Bitmap bitmap in Redostates)
                {
                    bitmap.Dispose();
                }
                Redostates.Clear();
            }

        }
        History history = new History();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "JPEG (*.jpg; *.jpeg)|*.jpg; *.jpeg|BMP (*.bmp)|*.bmp|All Files (*.*)|*.*";
            saveFileDialog1.Filter = "JPEG (*.jpg; *.jpeg)|*.jpg; *.jpeg|BMP (*.bmp)|*.bmp";
            openFileDialog1.FileName = "";
            this.Width = 1000;
            this.Height = 700;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            undoToolStripMenuItem.ForeColor = Color.Gray;
            redoToolStripMenuItem.ForeColor = Color.Gray;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            erase.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            erase.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.DoubleBuffered = true;
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Bitmap TimeBitmap;
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            history.ClearRedo();
            py = e.Location;
            cX = e.X;
            cY = e.Y;
            if (index == 1 || index == 2)
            {
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                BMisModif = true;
            }
            if (Selecting && !BooferRect.Contains(x, y))
            {
                SelectionDelete();
                Selecting = false;
            }
            else if (Selecting && BooferRect.Contains(x, y) && !Dragging)
            {
                Dragging = true;
                try
                {
                    TimeBitmap = bm.Clone(BooferRect, bm.PixelFormat);
                    g.DrawRectangle(Pens.White, BooferRect.X - 1, BooferRect.Y - 1, BooferRect.Width + 1, BooferRect.Height + 1);
                    g.FillRectangle(Brushes.White, BooferRect);
                    index = 11;
                    Selecting = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Выделение вышло за границы файла!");
                    SelectionDelete();
                    index = 0;
                    Dragging = false;
                }


            }


        }


        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            
            x = e.X; y = e.Y;
            if (paint) { sX = e.X - cX; sY = e.Y - cY; }
            else { sX = 0; sY = 0; }
            if (paint)
            {
                switch (index)
                {
                    case 1:
                        px = e.Location;
                        g.DrawLine(p, px, py);
                        py = px;
                        BMisModif = true;
                        break;
                    case 2:
                        px = e.Location;
                        g.DrawLine(erase, px, py);
                        py = px;
                        BMisModif = true;
                        break;
                    default:
                        // Обработка других случаев, если необходимо
                        break;
                }
            }
            pic.Refresh();

        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {

            if (index == 3)
            {
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                g.DrawEllipse(p, cX, cY, sX, sY);
                BMisModif = true;
            }
            else if (index == 4)
            {
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                g.DrawRectangle(p, Math.Min(cX, x), Math.Min(cY, y), Math.Abs(sX), Math.Abs(sY));
                BMisModif = true;
            }
            else if (index == 5)
            {
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }

                g.DrawLine(p, cX, cY, x, y);
                BMisModif = true;
            }
            else if (index == 8)
            {

                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                Pen SelectPen = new Pen(Color.Black);
                SelectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                BooferRect = new Rectangle(Math.Min(cX, x) + 1, Math.Min(cY, y) + 1, Math.Abs(sX) - 1, Math.Abs(sY) - 1);
                g.DrawRectangle(SelectPen, Math.Min(cX, x), Math.Min(cY, y), Math.Abs(sX), Math.Abs(sY));
                Selecting = true;

            }
            else if (index == 11)
            {
                if (Dragging)
                {
                    Dragging = false;
                    g.DrawImage(TimeBitmap, (int)(x - TimeBitmap.Width / 2), (int)(y - TimeBitmap.Height / 2));
                    BooferRect = new Rectangle();
                    index = 8;
                }
            }
            paint = false;
            sX = x - cX; sY = y - cY;
            


        }


        private void btn_pencil_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 1;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 2;
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 3;
        }

        private void btn_rect_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 4;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 5;
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                else if (index == 4)
                {
                    g.DrawRectangle(p, Math.Min(cX, x), Math.Min(cY, y), Math.Abs(sX), Math.Abs(sY));
                }
                else if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
                else if (index == 8)
                {
                    Pen SelectPen = new Pen(Color.Black);
                    SelectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(SelectPen, Math.Min(cX, x), Math.Min(cY, y), Math.Abs(sX), Math.Abs(sY));

                }
                if (Dragging && TimeBitmap != null)
                {
                    g.DrawImage(TimeBitmap, (int)(x - TimeBitmap.Width / 2), (int)(y - TimeBitmap.Height / 2));
                }
            }
            if (history.CanUndo())
            {
                undoToolStripMenuItem.ForeColor = Color.DarkSalmon;
            }
            else
            {
                undoToolStripMenuItem.ForeColor = Color.Gray;
            }
            if (history.CanRedo())
            {
                redoToolStripMenuItem.ForeColor = Color.DarkSalmon;
            }
            else
            {
                redoToolStripMenuItem.ForeColor = Color.Gray;
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;
            BMisModif = true;
            history.Clear();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            cd.ShowDialog();
            old_color = p.Color;
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;

        }
        public void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            // Получаем цвет пикселя изображения в заданных координатах
            Color cx = bm.GetPixel(x, y);
            // Проверяем, совпадает ли цвет пикселя с цветом, который нужно заменить
            
            if (cx == old_color)
            {
                // Если цвет совпадает, добавляем координаты пикселя в стек
                sp.Push(new Point(x, y));
                // Заменяем цвет пикселя на новый цвет
                bm.SetPixel(x, y, new_color);
            }
            
        }

        public void Fill(Bitmap bm, int x, int y, Color new_clr)
        {
            // Получаем цвет пикселя изображения в заданных координатах
            Color old_color = bm.GetPixel(x, y);
            // Создаем стек для хранения координат пикселей, которые нужно заменить
            Stack<Point> pixel = new Stack<Point>();
            // Добавляем начальные координаты пикселя в стек и заменяем цвет на новый цвет
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_clr);
            // Если новый цвет совпадает с текущим цветом, завершаем функцию
            if (old_color == new_clr) return;
            // Пока в стеке есть элементы
            while (pixel.Count > 0)
            {
                // Извлекаем координаты пикселя из стека
                Point pt = (Point)pixel.Pop();
                // Проводим проверку и замену цвета для соседних пикселей
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    // Вызываем функцию validate для каждого из соседних пикселей
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_color);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_color);
                }
            }
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            // Вычисляем координаты пикселя на изображении в соответствии с координатами, полученными от PictureBox
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {

            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            // При клике мыши на PictureBox
            if (index == 7)
            {
                // Добавляем текущее состояние изображения в стек отмены изменений
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                // Получаем координаты пикселя изображения, соответствующие координатам клика мыши
                Point point = set_point(pic, e.Location);
                // Заменяем цвет пикселей, начиная с заданной точки, на новый цвет
                if (new_color.ToArgb() != bm.GetPixel(point.X, point.Y).ToArgb()) 
                {
                    Fill(bm, point.X, point.Y, new_color);
                }
                
                BMisModif = true;
            }
            
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 7;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Selecting == false)
            {
                Bitmap previousState = history.Undo(bm);
                if (previousState != null)
                {
                    bm = new Bitmap(previousState);
                    g = Graphics.FromImage(bm);
                    pic.Image = bm;
                }
            }
            else
            {
                SelectionDelete();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            erase.Width = trackBar1.Value*5;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap previousState = history.Redo(bm);
            if (previousState != null)
            {
                bm = new Bitmap(previousState);
                g = Graphics.FromImage(bm);
                pic.Image = bm;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            //if (trackBar1.Value == 1)
            //{
            //    erase.Width = 10;
            //}
            //else 
            //{
            //    erase.Width = trackBar1.Value * 5;
            //}
            erase.Width = trackBar1.Value * 5;
            p.Width = trackBar1.Value * 3;
            
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (Selecting)
            {
                SelectionDelete();
                Selecting = false;
            }
            index = 8;
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && Selecting)
            {
                BooferBimtmap = bm.Clone(BooferRect, bm.PixelFormat);
                Clipboard.SetImage(BooferBimtmap);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                pic.Focus();
                if (Clipboard.ContainsImage())
                {
                    if (Selecting)
                    {
                        SelectionDelete();
                        Selecting = false;
                    }
                    if (!Selecting)
                    {
                        history.UndoAddState(new Bitmap(bm));
                    }
                    BooferBimtmap = (Bitmap)Clipboard.GetImage();
                    g.DrawImage(BooferBimtmap, (int)(x - BooferBimtmap.Width / 2), (int)(y - BooferBimtmap.Height / 2));
                    pic.Refresh();
                    BMisModif = true;

                }
            }
            else if (e.Control && e.KeyCode == Keys.X && Selecting)
            {
                BooferBimtmap = bm.Clone(BooferRect, bm.PixelFormat);
                Clipboard.SetImage(BooferBimtmap);
                Rectangle TimeRect = BooferRect;
                pic.Refresh();
                if (Selecting)
                {
                    SelectionDelete();
                    Selecting = false;
                }
                if (!Selecting)
                {
                    history.UndoAddState(new Bitmap(bm));
                }
                g.FillRectangle(Brushes.White, TimeRect);
                pic.Refresh();
                BMisModif = true;
            }
        }

        private void pic_MouseHover(object sender, EventArgs e)
        {

        }
        void SelectionDelete()
        {
            Selecting = false;
            BooferRect = new Rectangle();
            Bitmap previousState = history.UndoSelect();
            if (previousState != null)
            {
                bm = new Bitmap(previousState);
                g = Graphics.FromImage(bm);
                pic.Image = bm;
            }
        }
        void NewFile()
        {
            history.Clear();
            BMisModif = false;
            index = 0;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BMisModif == false)
            {

                SavingFormat = 0;
                FilePath = null;
                g.Clear(Color.White);
                openFileDialog1.FileName = null;
                saveFileDialog1.FileName = null;
                NewFile();
                return;
            };
            DialogResult MBox = MessageBox.Show("Файл был изменен.\nСохранить изменения?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            switch (MBox)
            {
                case DialogResult.No:
                    SavingFormat = 0;
                    FilePath = null;
                    g.Clear(Color.White);
                    openFileDialog1.FileName = null;
                    saveFileDialog1.FileName = null;
                    NewFile();
                    return;
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    switch (SavingFormat)
                    {
                        case 0:
                            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                            try
                            {
                                switch (saveFileDialog1.FilterIndex)
                                {
                                    case 1:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Jpeg);
                                        BMisModif = false;
                                        SavingFormat = 1;
                                        break;
                                    case 2:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Bmp);
                                        BMisModif = false;
                                        SavingFormat = 2;
                                        break;
                                }
                                SavingFormat = 0;
                                FilePath = null;
                                g.Clear(Color.White);
                                openFileDialog1.FileName = null;
                                saveFileDialog1.FileName = null;
                                NewFile();
                            }
                            catch (System.Exception Ситуация)
                            {
                                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

                        case 1:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {
                                    bm.Save(FilePath, ImageFormat.Jpeg);
                                    BMisModif = false;
                                    SavingFormat = 0;
                                    FilePath = null;
                                    g.Clear(Color.White);
                                    openFileDialog1.FileName = null;
                                    saveFileDialog1.FileName = null;
                                    NewFile();
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                        case 2:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {
                                    bm.Save(FilePath, ImageFormat.Bmp);
                                    BMisModif = false;
                                    SavingFormat = 0;
                                    FilePath = null;
                                    g.Clear(Color.White);
                                    openFileDialog1.FileName = null;
                                    saveFileDialog1.FileName = null;
                                    NewFile();
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image LoadedImage;
            if (BMisModif == false)
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                if (openFileDialog1.FileName == null) return;
                try
                {
                    switch (System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower())
                    {
                        case ".bmp":
                            FilePath = openFileDialog1.FileName;
                            LoadedImage = Image.FromFile(FilePath);
                            openFileDialog1.FileName = "";
                            this.Width = LoadedImage.Width + 16;
                            this.Height = LoadedImage.Height + 223;
                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                            g = Graphics.FromImage(bm);
                            g.DrawImage(LoadedImage, 0, 0);
                            pic.Image = bm;
                            NewFile();
                            LoadedImage.Dispose();
                            SavingFormat = 2;
                            break;
                        case ".jpeg":
                            FilePath = openFileDialog1.FileName;
                            LoadedImage = Image.FromFile(FilePath);
                            openFileDialog1.FileName = "";
                            this.Width = LoadedImage.Width + 16;
                            this.Height = LoadedImage.Height + 223;
                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                            g = Graphics.FromImage(bm);
                            g.DrawImage(LoadedImage, 0, 0);
                            pic.Image = bm;
                            NewFile();
                            LoadedImage.Dispose();
                            SavingFormat = 1;
                            break;
                        case ".jpg":
                            FilePath = openFileDialog1.FileName;
                            LoadedImage = Image.FromFile(FilePath);
                            openFileDialog1.FileName = "";
                            this.Width = LoadedImage.Width + 16;
                            this.Height = LoadedImage.Height + 223;
                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                            g = Graphics.FromImage(bm);
                            g.DrawImage(LoadedImage, 0, 0);
                            pic.Image = bm;
                            NewFile();
                            LoadedImage.Dispose();
                            SavingFormat = 1;
                            break;
                    }
                }
                catch (System.IO.FileNotFoundException Ситуация)
                {
                    MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (System.Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }
            DialogResult MBox = MessageBox.Show("Файл был изменен.\nСохранить изменения?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            switch (MBox)
            {
                case DialogResult.No:
                    if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                    if (openFileDialog1.FileName == null) return;
                    try
                    {
                        switch (System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower())
                        {
                            case ".bmp":
                                FilePath = openFileDialog1.FileName;
                                LoadedImage = Image.FromFile(FilePath);
                                openFileDialog1.FileName = "";
                                this.Width = LoadedImage.Width + 16;
                                this.Height = LoadedImage.Height + 223;
                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                g = Graphics.FromImage(bm);
                                g.DrawImage(LoadedImage, 0, 0);
                                pic.Image = bm;
                                NewFile();
                                LoadedImage.Dispose();
                                SavingFormat = 2;
                                break;
                            case ".jpeg":
                                FilePath = openFileDialog1.FileName;
                                LoadedImage = Image.FromFile(FilePath);
                                openFileDialog1.FileName = "";
                                this.Width = LoadedImage.Width + 16;
                                this.Height = LoadedImage.Height + 223;
                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                g = Graphics.FromImage(bm);
                                g.DrawImage(LoadedImage, 0, 0);
                                pic.Image = bm;
                                NewFile();
                                LoadedImage.Dispose();
                                SavingFormat = 1;
                                break;
                            case ".jpg":
                                FilePath = openFileDialog1.FileName;
                                LoadedImage = Image.FromFile(FilePath);
                                openFileDialog1.FileName = "";
                                this.Width = LoadedImage.Width + 16;
                                this.Height = LoadedImage.Height + 223;
                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                g = Graphics.FromImage(bm);
                                g.DrawImage(LoadedImage, 0, 0);
                                pic.Image = bm;
                                NewFile();
                                LoadedImage.Dispose();
                                SavingFormat = 1;
                                break;
                        }
                    }
                    catch (System.IO.FileNotFoundException Ситуация)
                    {
                        MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (System.Exception Ситуация)
                    {
                        MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return;
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    switch (SavingFormat)
                    {
                        case 0:
                            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                            try
                            {
                                switch (saveFileDialog1.FilterIndex)
                                {
                                    case 1:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Jpeg);
                                        BMisModif = false;
                                        SavingFormat = 1;
                                        break;
                                    case 2:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Bmp);
                                        BMisModif = false;
                                        SavingFormat = 2;
                                        break;
                                }
                                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                                if (openFileDialog1.FileName == null) return;
                                try
                                {
                                    switch (System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower())
                                    {
                                        case ".bmp":
                                            FilePath = openFileDialog1.FileName;
                                            LoadedImage = Image.FromFile(FilePath);
                                            openFileDialog1.FileName = "";
                                            this.Width = LoadedImage.Width + 16;
                                            this.Height = LoadedImage.Height + 223;
                                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                            g = Graphics.FromImage(bm);
                                            g.DrawImage(LoadedImage, 0, 0);
                                            pic.Image = bm;
                                            NewFile();
                                            LoadedImage.Dispose();
                                            SavingFormat = 2;
                                            break;
                                        case ".jpeg":
                                            FilePath = openFileDialog1.FileName;
                                            LoadedImage = Image.FromFile(FilePath);
                                            openFileDialog1.FileName = "";
                                            this.Width = LoadedImage.Width + 16;
                                            this.Height = LoadedImage.Height + 223;
                                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                            g = Graphics.FromImage(bm);
                                            g.DrawImage(LoadedImage, 0, 0);
                                            pic.Image = bm;
                                            NewFile();
                                            LoadedImage.Dispose();
                                            SavingFormat = 1;
                                            break;
                                        case ".jpg":
                                            FilePath = openFileDialog1.FileName;
                                            LoadedImage = Image.FromFile(FilePath);
                                            openFileDialog1.FileName = "";
                                            this.Width = LoadedImage.Width + 16;
                                            this.Height = LoadedImage.Height + 223;
                                            bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                            g = Graphics.FromImage(bm);
                                            g.DrawImage(LoadedImage, 0, 0);
                                            pic.Image = bm;
                                            NewFile();
                                            LoadedImage.Dispose();
                                            SavingFormat = 1;
                                            break;
                                    }
                                }
                                catch (System.IO.FileNotFoundException Ситуация)
                                {
                                    MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                return;
                            }
                            catch (System.Exception Ситуация)
                            {
                                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

                        case 1:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {
                                    bm.Save(FilePath, ImageFormat.Jpeg);
                                    BMisModif = false;
                                    if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                                    if (openFileDialog1.FileName == null) return;
                                    try
                                    {
                                        switch (System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower())
                                        {
                                            case ".bmp":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 2;
                                                break;
                                            case ".jpeg":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 1;
                                                break;
                                            case ".jpg":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 1;
                                                break;
                                        }
                                    }
                                    catch (System.IO.FileNotFoundException Ситуация)
                                    {
                                        MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    catch (System.Exception Ситуация)
                                    {
                                        MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    return;
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                        case 2:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {
                                    bm.Save(FilePath, ImageFormat.Bmp);
                                    BMisModif = false;
                                    if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                                    if (openFileDialog1.FileName == null) return;
                                    try
                                    {
                                        switch (System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower())
                                        {
                                            case ".bmp":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 2;
                                                break;
                                            case ".jpeg":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 1;
                                                break;
                                            case ".jpg":
                                                FilePath = openFileDialog1.FileName;
                                                LoadedImage = Image.FromFile(FilePath);
                                                openFileDialog1.FileName = "";
                                                this.Width = LoadedImage.Width + 16;
                                                this.Height = LoadedImage.Height + 223;
                                                bm = new Bitmap(LoadedImage.Width, LoadedImage.Height, PixelFormat.Format32bppArgb);
                                                g = Graphics.FromImage(bm);
                                                g.DrawImage(LoadedImage, 0, 0);
                                                pic.Image = bm;
                                                NewFile();
                                                LoadedImage.Dispose();
                                                SavingFormat = 1;
                                                break;
                                        }
                                    }
                                    catch (System.IO.FileNotFoundException Ситуация)
                                    {
                                        MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    catch (System.Exception Ситуация)
                                    {
                                        MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    return;
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (SavingFormat)
            {
                case 0:
                    if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        switch (saveFileDialog1.FilterIndex)
                        {
                            case 1:
                                FilePath = saveFileDialog1.FileName;
                                saveFileDialog1.FileName = "";
                                bm.Save(FilePath, ImageFormat.Jpeg);
                                BMisModif = false;
                                SavingFormat = 1;
                                break;
                            case 2:
                                FilePath = saveFileDialog1.FileName;
                                saveFileDialog1.FileName = "";
                                bm.Save(FilePath, ImageFormat.Bmp);
                                BMisModif = false;
                                SavingFormat = 2;
                                break;
                        }
                    }
                    catch (System.Exception Ситуация)
                    {
                        MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case 1:
                    if (!string.IsNullOrEmpty(FilePath))
                    {
                        try
                        {

                            bm.Save(FilePath, ImageFormat.Jpeg);
                            BMisModif = false;
                        }
                        catch (System.Exception Ситуация)
                        {
                            MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(FilePath))
                    {
                        try
                        {
                            bm.Save(FilePath, ImageFormat.Bmp);
                            BMisModif = false;
                        }
                        catch (System.Exception Ситуация)
                        {
                            MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    break;
            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        FilePath = saveFileDialog1.FileName;
                        saveFileDialog1.FileName = "";
                        bm.Save(FilePath, ImageFormat.Jpeg);
                        BMisModif = false;
                        SavingFormat = 1;
                        break;
                    case 2:
                        FilePath = saveFileDialog1.FileName;
                        saveFileDialog1.FileName = "";
                        bm.Save(FilePath, ImageFormat.Bmp);
                        BMisModif = false;
                        SavingFormat = 2;
                        break;
                }
            }
            catch (System.Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BMisModif == false) return;
            DialogResult MBox = MessageBox.Show("Файл был изменен.\nСохранить изменения?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            switch (MBox)
            {
                case DialogResult.No:
                    return;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    switch (SavingFormat)
                    {
                        case 0:
                            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                            try
                            {
                                switch (saveFileDialog1.FilterIndex)
                                {
                                    case 1:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Jpeg);
                                        BMisModif = false;
                                        SavingFormat = 1;
                                        break;
                                    case 2:
                                        FilePath = saveFileDialog1.FileName;
                                        saveFileDialog1.FileName = "";
                                        bm.Save(FilePath, ImageFormat.Bmp);
                                        BMisModif = false;
                                        SavingFormat = 2;
                                        break;
                                }
                            }
                            catch (System.Exception Ситуация)
                            {
                                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

                        case 1:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {

                                    bm.Save(FilePath, ImageFormat.Jpeg);
                                    BMisModif = false;
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                        case 2:
                            if (!string.IsNullOrEmpty(FilePath))
                            {
                                try
                                {
                                    bm.Save(FilePath, ImageFormat.Bmp);
                                    BMisModif = false;
                                }
                                catch (System.Exception Ситуация)
                                {
                                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
