using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code
{
    public abstract class Potion : Item
    {
        public bool used = false;
        public Potion(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description) : base(initPos, collider, picturebox, name, description)
        {
        }

        public void PlayDrinkSound()
        {
            ; // None right now
        }

        public abstract void UseEffect();
    }

    public class PotionOfHealing : Potion
    {
        Player player;
        public PotionOfHealing(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description, Player player) : base(initPos, collider, picturebox, name, description)
        {
            this.player = player;
        }

        public override void UseEffect()
        {
            // throw new NotImplementedException();
            player.AlterHealth(10);
            if (player.Health > 20)
            {
                player.AlterHealth(-(player.Health % 20));
            }
        }
    }

    public class PotionOfBrightness : Potion
    {
        int[] shownPoint = { 199, 20 };
        int[] showSize = { 1600, 1000 };
        public PotionOfBrightness(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description) : base(initPos, collider, picturebox, name, description)
        {
        }

        public override void UseEffect()
        {
            MakeBoxVisable();
            DimBox(); // not finished
        }

        public void MakeBoxVisable()
        {
            PictureBox.Location = new Point(shownPoint[0], shownPoint[1]);
            PictureBox.Size = new Size(showSize[0], showSize[1]);
            IsShown = true;
        }

        async Task WaitToDim()
        {
            await Task.Delay(1);
        }

        public async void DimBox()
        {
            for (int i = 100; i > 0; i--)
            {
                await WaitToDim();
            }
        }
    }
}
