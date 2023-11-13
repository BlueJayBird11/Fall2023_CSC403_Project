using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            if (used || player.Health >= 20)
            {
                return;
            }

            player.AlterHealth(10);
            
            if (player.Health > 20)
            {
                player.AlterHealth(-(player.Health % 20));
            }
            pictureBox.Visible = false;

            used = true;
        }
    }

    public class PotionOfGrowth : Potion
    {
        Player player;

        public PotionOfGrowth(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description, Player player) : base(initPos, collider, picturebox, name, description)
        {
            this.player = player;
        }

        public override void UseEffect()
        {
            if (player.sizeChanging == false)
            {
                player.Stretch();
            }
        }
    }

    public class PotionOfShrink : Potion
    {
        Player player;
        public PotionOfShrink(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description, Player player) : base(initPos, collider, picturebox, name, description)
        {
            this.player = player;
        }

        public override void UseEffect()
        {
            if (player.sizeChanging == false)
            {
                player.Shrink();
            }
        }
    }

    public class PotionOfBrightness : Potion
    {
        int[] shownPoint = { 199, 20 };
        int[] showSize = { 1600, 1000 };

        Character flash;
        PictureBox picFlash;
        Image original;

        public PotionOfBrightness(Vector2 initPos, Collider collider, PictureBox picturebox, string name, string description, Character flash, PictureBox picFlash) : base(initPos, collider, picturebox, name, description)
        {
            this.flash = flash;
            this.picFlash = picFlash;
        }

        public override void UseEffect()
        {
            FlashScreen();
            DimBox(); // not finished
        }

        public void FlashScreen()
        {
            picFlash.Visible = true;
            ChangeOpacity(255);
            picFlash.Location = new Point(0,0);
            picFlash.Size = new Size(1200, 1000);

        }

        public void MakeBoxVisable()
        {
            pictureBox.Location = new Point(shownPoint[0], shownPoint[1]);
            pictureBox.Size = new Size(showSize[0], showSize[1]);
            IsShown = true;
        }

        public void ChangeOpacity(int val)
        {
            // Bitmap bmp = new Bitmap()
            if (original == null)
            {
                original = (Bitmap)picFlash.BackgroundImage.Clone();
            }
            picFlash.BackColor = Color.Transparent;
            picFlash.BackgroundImage = SetAlpha((Bitmap)original, val);
        }

        // Credit: function found at: https://stackoverflow.com/questions/44749869/picturebox-slider-control-transparency
        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, a, 0},
            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
            g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        async Task WaitToDim()
        {
            await Task.Delay(1);
        }

        public async void DimBox()
        {
            for (int i = 255; i > 0; i-=3)
            {
                ChangeOpacity(i);
                await WaitToDim();
            }
            picFlash.Visible = false;
        }
    }
}
