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

        public Player(Vector2 initPos, Collider collider, Vector2 initSize, PictureBox picture) : base(initPos, collider)
        {
            Size = initSize;
            pictureBox = picture;
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

        public async void Stretch()
        {
            float[] OgSize = { Size.x, Size.y };
            for (float i = OgSize[0]; i < OgSize[0]+100; i += 1)
            {
                await StrechDelay();
                pictureBox.Size = new System.Drawing.Size((int)i, (int)OgSize[1]);
            }
        }
    }
}

