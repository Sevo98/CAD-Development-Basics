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
        /// <summary>
        /// Открытие окна с чертежем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenDrawing_Click(object sender, EventArgs e)
        {
            Drawing drawing = new Drawing();
            drawing.Show();
        }
        /// <summary>
        /// Построение детали
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }
        /// <summary>
        /// Построение детали с дополнительным функционалом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CheckBoxCylinder_CheckedChanged(object sender, EventArgs e)
		{
			_parameters.CylinderEdge = checkBoxCylinder.Checked;
		}
	}
}
