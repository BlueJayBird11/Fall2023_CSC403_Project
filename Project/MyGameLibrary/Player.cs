using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Fall2020_CSC403_Project.code
{
    public class Player : BattleCharacter
    {
        public bool[] _movementBools = new bool[] { false, false, false, false };
        public Vector2 Size { get; set; }
        PictureBox pictureBox { get; set; }
        // float tempF = F 0.0;
        float[] OgSize = { (float)0.0, (float)0.0 };
        float[] NewSize = { (float)0.0, (float)0.0 };
        int sizeState = 1;
        public bool sizeChanging = false;
        const int PADDING = 7;

        public Player(Vector2 initPos, Collider collider, Vector2 initSize, PictureBox picture) : base(initPos, collider)
        {
            Size = initSize;
            pictureBox = picture;
            OgSize[0] = Size.x;
            OgSize[1] = Size.y;

            NewSize[0] = Size.x;
            NewSize[1] = Size.y;
        }

        public int MovementValue()
        {
            int movementCount = 0;
            foreach (bool movementBool in _movementBools)
            {
                if (movementBool) { movementCount++; }
            }
            return movementCount;
        }

        async Task StrechDelay()
        {
            await Task.Delay(1);
        }

        private Collider CreateCollider(PictureBox pic, int padding)
        {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        public async void Stretch()
        {
            sizeState+=2;
            sizeChanging = true;
            for (float i = NewSize[0]; i < NewSize[0]+100; i += 1)
            {
                await StrechDelay();
                pictureBox.Size = new System.Drawing.Size((int)i, (int)OgSize[1]);
                
            }
            Collider newCollider = CreateCollider(pictureBox, PADDING);
            ChangeCollider(newCollider);
            NewSize[0] = NewSize[0] + 100;
            sizeChanging = false;
        }

        public async void Shrink()
        {
            sizeState--;
            sizeChanging = true;
            if (sizeState < 0) 
            {
                this.AlterHealth(-21);
            }
            for (float i = NewSize[0]; i > NewSize[0] - 50; i -= 1)
            {
                await StrechDelay();
                pictureBox.Size = new System.Drawing.Size((int)i, (int)OgSize[1]);
            }
            Collider newCollider = CreateCollider(pictureBox, PADDING);
            ChangeCollider(newCollider);
            NewSize[0] = NewSize[0] - 50;
            sizeChanging = false;
        }
    }
}

