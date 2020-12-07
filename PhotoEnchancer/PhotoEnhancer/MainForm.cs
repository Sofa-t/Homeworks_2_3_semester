using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Panel parametresPanel;
        Photo originalPhoto;
        Photo resultPhoto;
        List<NumericUpDown> parametrControls;
        public MainForm()
        {
            InitializeComponent();

            //LoadPicture((Bitmap)Image.FromFile("cat.jpg"));
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (parametresPanel != null)
                this.Controls.Remove(parametresPanel);

            parametresPanel = new Panel();

            parametresPanel.Left = comboBoxFilters.Left;
            parametresPanel.Width = comboBoxFilters.Width;
            parametresPanel.Top = comboBoxFilters.Bottom + 10;
            parametresPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - 20;

            var filter = comboBoxFilters.SelectedItem as IFilter;

            if (filter == null)
                return;
            else
            {
                parametrControls = new List<NumericUpDown>();

                var paramsInfo = filter.GetParametersInfo();
                for (var i = 0; i < paramsInfo.Length; i++)
                {
                    var label = new Label();
                    label.Height = 20;
                    label.Width = parametresPanel.Width - 50;
                    label.Left = 0;
                    label.Top = i * (label.Height + 10);
                    label.Text = paramsInfo[i].Name;
                    parametresPanel.Controls.Add(label);

                    var inputBox = new NumericUpDown();
                    inputBox.Width = 50;
                    inputBox.Height = label.Height;
                    inputBox.Left = label.Right;
                    inputBox.Top = label.Top;
                    inputBox.DecimalPlaces = 2;
                    inputBox.Minimum = (decimal)paramsInfo[i].MinValue;
                    inputBox.Maximum = (decimal)paramsInfo[i].MaxValue;
                    inputBox.Increment = (decimal)paramsInfo[i].Increment;
                    inputBox.Value = (decimal)paramsInfo[i].DefailtValue;
                    parametrControls.Add(inputBox);
                    parametresPanel.Controls.Add(inputBox);
                }
            }


            

            this.Controls.Add(parametresPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var filter = comboBoxFilters.SelectedItem as IFilter;

            var parameters = new double[parametrControls.Count];
            for (var i = 0; i < parameters.Length; i++)
                parameters[i] = (double)parametrControls[i].Value;

            resultPhoto = filter.Process(originalPhoto, parameters);
            pictureBoxResult.Image = Convertors.Photo2Bitmap(resultPhoto);

            saveToolStripMenuItem.Enabled = true;
        }

        private void LoadPicture(Bitmap bmp)
        {
            originalPhoto = Convertors.Bitmap2Photo(bmp);
            pictureBoxOriginal.Image = bmp;
            pictureBoxResult.Image = null;

        }

        private void SavePicture(Photo photo, string filename)
        {
            var bmp = Convertors.Photo2Bitmap(photo);
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void AddFilter(IFilter filter)
        {
            comboBoxFilters.Items.Add(filter);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonApply.Visible = true;
                comboBoxFilters.Visible = true;

                if (comboBoxFilters.SelectedIndex == -1)
                    comboBoxFilters.SelectedIndex = 0;

                LoadPicture((Bitmap)Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SavePicture(resultPhoto, saveFileDialog1.FileName);
        }
    }
}
