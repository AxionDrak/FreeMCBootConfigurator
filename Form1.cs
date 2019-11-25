using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FreeMCBootConfigurator
{
    public partial class Form1 : Form
    {
        private static string _file = "FREEMCB.CNF";
        private static int _CNFversion = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Quickstart
            cbQuickstart.SelectedIndex = 0;
            //General
            cbFastBoot.SelectedIndex = 0;
            cbDebug.SelectedIndex = 1;
            nupPadDelay.Value = 1;
            //OSD Settings
            cbHackedOS.SelectedIndex = 0;
            cbScrollMenu.SelectedIndex = 0;
            cbDisplayItems.SelectedIndex = 3;
            cbVMode.SelectedIndex = 0;
            cbSkipMC.SelectedIndex = 1;
            cbSkipHDD.SelectedIndex = 1;
            cbSkipDiscBoot.SelectedIndex = 0;
            cbSkipSonyLogo.SelectedIndex = 0;
            cbGoToBrowser.SelectedIndex = 0;
            //ESR Path
            cbESRPath1.SelectedIndex = 0;
            cbESRPath2.SelectedIndex = 2;
            cbESRPath3.SelectedIndex = 2;
            // E1 Launch Keys
            cbE1Auto.SelectedIndex = 0;



        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void verifyFile()
        {
            //StreamWriter streamW = new StreamWriter(_file, true);
            // Verifica se o arquivo existe, retorna true, neguei a condição, então se o arquivo não existir ele entra no IF.
            //if (!File.Exists(_file))
            if (!File.Exists(_file))
            {
                // Cria um arquivo, no caso, cria o arquivo informado na variável _file.
                File.Create(_file);
            }
            /*
            else
            {
                MessageBox.Show("Arquivo SYSTEM.CNF já existe!\r\nO arquivo será sobrescrito!", "AVISO!");
                // Apaga o arquivo, caso ele já exista.
                //File.Delete(_file);
            }*/
        }

        public static void writeData(int _cnf, String _fastBoot, String _debub, String _nupPadDelay, String _hacked_OSDSYS, String _vmode, String _skipMC, String _skipHDD)
        {
            FileInfo arquivo = new FileInfo(_file);
            arquivo.Delete();
            //StreamWriter streamW = new StreamWriter(_file, true);

            //Create new SafeFileDialog instance
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Salvar CNF";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "FREEMCB.CNF";
            saveFileDialog1.DefaultExt = "CNF";
            saveFileDialog1.Filter = "Arquivo CNF (*.CNF)|*.CNF";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            //Display dialog and see if OK button was pressed
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Save file to file name specified to SafeFileDialog
                StreamWriter streamW = new StreamWriter(saveFileDialog1.FileName);

                //Chama nosso método que cria o arquivo caso ele não exista.
                verifyFile();

                /*Através do objeto streamW acessamos o método WriteLine e passamos os textos que queremos gravar.
                 * 
                 */
                streamW.WriteLine("# ----------------------------------------\r\n" +
                    "# Free MCBoot Config File\r\n" +
                    "# must be in mc?:/SYS-CONF/FREEMCB.CNF or mass:/FREEMCB.CNF\r\n" +
                    "# ----------------------------------------\r\n" +
                    "CNF_version = " + _CNFversion +
                    "\r\n# ----------------------------------------" +
                    "\r\nDebug_Screen = " + _debub +
                    "\r\nFastBoot = " + _fastBoot +
                    "\r\npad_delay = " + _nupPadDelay +
                    "\r\n# ----------------------------------------\r\n" +
                    "# OSDSYS Settings\r\n" +
                    "# ----------------------------------------" +
                    "\r\nhacked_OSDSYS = " + _hacked_OSDSYS +
                    "\r\nOSDSYS_video_mode = " + _vmode + 
                    "\r\nOSDSYS_Skip_Disc = " + 
                    "\r\nOSDSYS_Skip_Logo = " +
                    "\r\nOSDSYS_Inner_Browser = " +
                    "\r\nOSDSYS_selected_color = 0x10,0x80,0xE0,0x80" +
                    "\r\nOSDSYS_unselected_color = 0x33,0x33,0x33,0x80" +
                    "\r\nOSDSYS_scroll_menu = " +
                    "\r\nOSDSYS_menu_x = " +
                    "\r\nOSDSYS_menu_y = " +
                    "\r\nOSDSYS_enter_x = " +
                    "\r\nOSDSYS_enter_y = " +
                    "\r\nOSDSYS_version_x = " +
                    "\r\nOSDSYS_version_y = " +
                    "\r\nOSDSYS_cursor_max_velocity = " +
                    "\r\nOSDSYS_cursor_acceleration = " +
                    "\r\nOSDSYS_num_displayed_items = " +
                    "\r\nOSDSYS_Skip_MC = " + _skipMC +
                    "\r\nOSDSYS_Skip_HDD = " + _skipHDD +
                    "\r\n# ----------------------------------------\r\n" +
                    "# Control Shortcuts\r\n" +
                    "# ----------------------------------------");


            








                    //+ "elf.Replace(" ", "") + ";1" + "\r\n" + "VER = " + version.Replace(" ", "") + "\r\n" + "VMODE = " + region + "\r\n" + "HDDUNITPOWER = " + hddunit);
                streamW.Close();
                    // Exibe uma mensagem informando que os dados foram gravados.
                    //MessageBox.Show("Arquivo SYSTEM.CNF gravado com sucesso!", "AVISO!");

                //streamW.Close();
            }
        }

        private void TsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented!", "NOTICE!");
            /*
            string _curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            Help.ShowHelp(this, "file://" + _curDir + "\\zrc.chm");
            */
        }

        private void BtnSaveCNF_Click(object sender, EventArgs e)
        {
                    writeData(_CNFversion,
                        cbDebug.SelectedIndex.ToString(), 
                        cbFastBoot.SelectedIndex.ToString(), 
                        nupPadDelay.Text, 
                        cbHackedOS.SelectedIndex.ToString(),
                        cbVMode.SelectedIndex.ToString(), 
                        cbSkipMC.SelectedIndex.ToString(), 
                        cbSkipHDD.SelectedIndex.ToString());
               
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented!", "NOTICE!");
        }

        private void CbE1Auto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbE1Auto.SelectedIndex == 0 || cbE1Auto.SelectedIndex == 1 || cbE1Auto.SelectedIndex == 2)
            {
                txtE1Auto.Text = null;
                txtE1Auto.Enabled = false;                
            }
            else
            {
                txtE1Auto.Enabled = true;
            }
        }
    }
}
