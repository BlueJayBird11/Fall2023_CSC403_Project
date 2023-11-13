using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class LanguageSelectScreen : Form
    {
        public LanguageSelectScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EnglishButtonClick(object sender, EventArgs e)
        {
            LanguageSelector selector = new LanguageSelector();
            FrmLevel languageSelectScreen = new FrmLevel(selector, "English");
            languageSelectScreen.Show();
        }

        private void SpanishButtonClick(object sender, EventArgs e)
        {
            LanguageSelector selector = new LanguageSelector();
            FrmLevel languageSelectScreen = new FrmLevel(selector, "Spanish");
            languageSelectScreen.Show();
        }

        private void GermanButtonClick(object sender, EventArgs e)
        {
            LanguageSelector selector = new LanguageSelector();
            FrmLevel languageSelectScreen = new FrmLevel(selector, "German");
            languageSelectScreen.Show();
        }

        private void LatinButtonClick(object sender, EventArgs e)
        {
            LanguageSelector selector = new LanguageSelector();
            FrmLevel languageSelectScreen = new FrmLevel(selector, "Latin");
            languageSelectScreen.Show();
        }
    }
}
