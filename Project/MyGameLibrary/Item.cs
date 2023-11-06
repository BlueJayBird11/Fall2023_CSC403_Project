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
        public PictureBox PictureBox { get; set; }

        public bool IsShown = false;

        int[] shownPoint = { 0, 0 };
        int[] hidePoint = { 0, 0 };

        private String name;
        private String description;

        public Item(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description) : base(initPos, collider)
        {
            PictureBox = picturebox;
            this.name = name;
            this.description = description;
        }
        
        public void PlaceItem(int x, int y)
        {
            PictureBox.Location = new Point(shownPoint[0], shownPoint[1]);
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
