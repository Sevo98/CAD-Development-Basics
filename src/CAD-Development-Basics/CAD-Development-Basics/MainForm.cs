using System;
using System.Windows.Forms;
using Core;
using Kompas;

namespace CAD_Development_Basics
{
    //TODO: XML
    public partial class MainForm : Form
    {
	    private Parameters _parameters;
        public MainForm()
        {
            InitializeComponent();
            _parameters = new Parameters();
        }

        private void buttonOpenDrawing_Click(object sender, EventArgs e)
        {
            Drawing drawing = new Drawing();
            drawing.Show();
        }



        private void buttonBuild_Click(object sender, EventArgs e)
        {
            //TODO: RSDN
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите построить модель с данными значениями?", 
	            "Внимание!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
	            _parameters.HeightBody = (int)numericBody.Value;
	            _parameters.HeightEdge = (int)numericVisor.Value;
                _parameters.DiameterArea = (int)numericArea.Value;
	            _parameters.DiameterBoltHeadHoles = (int)numericHead.Value;
	            _parameters.DiameterBoltThreadHoles = (int)numericThread.Value;
                var builder = new Builder(_parameters);
                builder.BuildModel();
            }
            else if (dialogResult == DialogResult.No)
            {
                //...
            }
        }
	}
}
