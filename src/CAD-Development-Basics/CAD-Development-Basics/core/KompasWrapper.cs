using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CAD_Development_Basics.core
{
    public class KompasWrapper
    {
        private string KompasObject;

        public void RunKompas()
        {
            DialogResult dialogResult = MessageBox.Show("Компас запущен");
        }
    }
}