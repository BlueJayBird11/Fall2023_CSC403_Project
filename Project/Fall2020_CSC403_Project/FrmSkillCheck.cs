using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fall2020_CSC403_Project.code;
using MyGameLibrary;

namespace Fall2020_CSC403_Project
{
    public partial class FrmSkillCheck : Form
    {
        private FrmBattle battleForm;
        public static FrmSkillCheck instance = null;
        private Questions currentQuestion;
        private Enemy enemy;
        private Player player;

        public FrmSkillCheck(Questions question, Enemy enemy, Form battleForm)
        {
            InitializeComponent();
            currentQuestion = question;
            this.enemy = enemy;
            this.battleForm = (FrmBattle)battleForm;
            InitializeQuestion();

        }

        private void InitializeQuestion()
        {
            for (int i = 0; i < currentQuestion.options.Length; i++)
            {
                // Create a RadioButton for each option
                RadioButton radioButton = new RadioButton();
                radioButton.Text = currentQuestion.options[i];
                radioButton.Tag = currentQuestion.options[i]; // Store the option in Tag for easy retrieval

                radioButton.Location = new System.Drawing.Point(10, 20 * i); // Adjust the Y-coordinate as needed

                // Add the RadioButton to the panel
                panelQuestion.Controls.Add(radioButton);
            }

            // Display the image, assuming you have a PictureBox named pictureBoxQuestionImage
            pictureBoxQuestionImage.Image = currentQuestion.image;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Find the selected RadioButton in the panel
            RadioButton selectedRadioButton = panelQuestion.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            if (selectedRadioButton != null)
            {
                // Check the selected answer against the correct answer
                string selectedAnswer = selectedRadioButton.Tag.ToString();
                bool isCorrect = currentQuestion.isCorrect(selectedAnswer);
                if (isCorrect)
                {
                    enemy.AlterHealth(-5);
                }
                else
                {
                    player.AlterHealth(-5);
                }

                // Display appropriate feedback to the user
                Close();
                MessageBox.Show(isCorrect ? "Correct! +5 Damage Dealt" : "Incorrect! -5 Health", "Result");
                battleForm.healthCheck(sender,e);
             
            }
            else
            {
                // No option selected
                MessageBox.Show("Please select an answer.", "Warning");
            }
        }

    }
}
