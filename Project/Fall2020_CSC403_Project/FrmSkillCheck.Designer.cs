using System.Windows.Forms;
using Fall2020_CSC403_Project.code;

namespace Fall2020_CSC403_Project
{
    partial class FrmSkillCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel panelQuestion;
        private PictureBox pictureBoxQuestionImage;
        private Button btnSubmit;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            player = Game.player;            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "SkillCheck";

            this.panelQuestion = new System.Windows.Forms.Panel();
            this.pictureBoxQuestionImage = new System.Windows.Forms.PictureBox();
            // Other controls and properties may follow

            // panelQuestion
            this.panelQuestion.Location = new System.Drawing.Point(12, 12);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(400, 200);
            // Other properties for panelQuestion

            // pictureBoxQuestionImage
            this.pictureBoxQuestionImage.Location = new System.Drawing.Point(12, 130);
            this.pictureBoxQuestionImage.Name = "pictureBoxQuestionImage";
            this.pictureBoxQuestionImage.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxQuestionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // Other properties for pictureBoxQuestionImage

            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSubmit.Location = new System.Drawing.Point(12, 100); // Adjust the position as needed
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 25);
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // Set other properties for btnSubmit as needed

            // FrmSkillCheck
            this.Controls.Add(this.btnSubmit);

            this.ResumeLayout(false);

            // FrmSkillCheck
            this.ClientSize = new System.Drawing.Size(824, 600);
            this.Controls.Add(this.pictureBoxQuestionImage);
            this.Controls.Add(this.panelQuestion);
            // Add other controls to the form

            this.Name = "FrmSkillCheck";
            this.Text = "Skill Check Form";
            this.ResumeLayout(false);
        }

        #endregion
    }
}