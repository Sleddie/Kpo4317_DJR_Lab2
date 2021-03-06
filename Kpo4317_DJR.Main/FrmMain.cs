using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kpo4317_DJR.Lib;

namespace Kpo4317_DJR.Main
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            txtboxLogPath.Text = AppGlobalSettings.LogPath;
            txtboxDataFileName.Text = AppGlobalSettings.DataFileName;
        }

        private List<SemiConductor> semiconductorList = new List<SemiConductor>();
        private BindingSource bsSemiConductors = new BindingSource();

        private void mnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                ISemiconductorListLoader loader = AppGlobalSettings.SemiconductorFactory.CreateSemiconductorListLoader();
                loader.Execute();
                bsSemiConductors.DataSource = loader.semiconductorList;
                dgvSemiConductors.DataSource = bsSemiConductors;
            }
            //обработка исключения "Метод не реализован"
            catch (NotImplementedException ex)
            {
                MessageBox.Show("Ошибка №1: " + ex.Message);
                LogUtility.ErrorLog("Ошибка №1: " + ex.Message);
            }
            //обработка остальных исключений
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка №2: " + ex.Message);
                LogUtility.ErrorLog(ex);
            }
        }

        private void mnOpenSemiconductor_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSemiConductor frmSemiConductor = new FrmSemiConductor();

                SemiConductor semiconductor = (bsSemiConductors.Current as SemiConductor);
                frmSemiConductor.SetSemiconductor(semiconductor);

                frmSemiConductor.ShowDialog();
            }
            //обработка исключения "Метод не реализован"
            catch (NotImplementedException ex)
            {
                MessageBox.Show("Ошибка №1: " + ex.Message);
                LogUtility.ErrorLog("Ошибка №1: " + ex.Message);

            }
        }
    }
}
