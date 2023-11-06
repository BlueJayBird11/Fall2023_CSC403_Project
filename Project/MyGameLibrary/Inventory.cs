using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code
{
    public class Inventory : Character
    {
        public Image Img { get; set; }
        public PictureBox PictureBox { get; set; }

        public bool IsShown = false;

        int[] shownPoint = { 199, 20 };
        int[] hidePoint = { 199, -400 };

        // item list
        Item[] items = { };

        public Inventory(Vector2 initPos, Collider collider, PictureBox picturebox) : base(initPos, collider)
        {
            PictureBox = picturebox;
            DisableCollider();
            HideBox();
        }

        public void ShowBox()
        {

            PictureBox.Location = new Point(shownPoint[0], shownPoint[1]);
            IsShown = true;
        }

        public void HideBox()
        {
            PictureBox.Location = new Point(hidePoint[0], hidePoint[1]);
            IsShown = false;
        }

        public void ToggleBox()
        {
            if (IsShown)
            {
                HideBox();
            }
            else
            {
                ShowBox();
            }
        }

        public void DescribeItem()
        {
            // Say the item name and description using the DialogueBox
            ;
        }
    }
}
