using Fall2020_CSC403_Project.code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code
{
    public class Item : Character
    {
        public Image Img { get; set; }
        public PictureBox pictureBox { get; set; }

        public bool IsShown = false;

        int[] shownPoint = { 0, 0 };
        int[] hidePoint = { 0, 0 };

        private String name;
        private String description;

        public Item(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description) : base(initPos, collider)
        {
            pictureBox = picturebox;
            this.name = name;
            this.description = description;
            HideItem();
        }
        
        public void PlaceItem(int x, int y)
        {
            Console.WriteLine(x + ", " + y);
            pictureBox.Location = new Point(x, y);
        }

        public void HideItem()
        {
            pictureBox.Visible = false;
            pictureBox.Enabled = false;
        }

        public void ShowItem()
        {
            pictureBox.Visible = true;
            pictureBox.Enabled = true;
        }

        public String GetName()
        {
            return name;
        }

        public String GetDescription()
        {
            return description;
        }
    }
}
