using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Bitmap Img;
        public Filter Filter;
        public Form1()
        {
            InitializeComponent();
            FilterTypeBox.DataSource = Enum.GetValues(typeof(FilterType));

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG(*.JPG)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Img = (Bitmap)Image.FromFile(open.FileName);
                pictureBox1.Image = Img;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JPG(*.JPG)|*.jpg";
            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }
        
        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
           
            Process(Filter);
            
            MessageBox.Show((DateTime.Now - dt).ToString());
        }
        private void Process(Filter filter)
        {
            IExecution execution = new MultiThreadExecution();


            Thread thread = new Thread(delegate () {
                pictureBox1.Image = execution.Execute(Img, filter);
            }
            );

            thread.Start();
            thread.Join();
        }
        private void FilterTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterType filterType;
            Enum.TryParse<FilterType>(FilterTypeBox.SelectedValue.ToString(), out filterType);
            IFilterFactory filterFactory = new FilterFactory();
            Filter = filterFactory.Create(filterType);
            Division.Text = Filter.Division.ToString();
            Offset.Text = Filter.Offset.ToString();
        }
        
        private void Offset_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Offset.Text, out int offset);
            Filter.Offset = offset; 
        }

        private void Division_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Division.Text, out int division);
            Filter.Division = division;
        }
    }
}
