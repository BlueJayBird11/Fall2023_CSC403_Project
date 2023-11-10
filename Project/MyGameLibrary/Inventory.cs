﻿using System;
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
        List <Item> items = new List<Item> ();

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
                HideItems();
            }
            else
            {
                ShowBox();
                ShowItems();
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ShowItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].ShowItem();
            }
        }

        public void HideItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].HideItem();
            }
        }

        public String[] DescribeItem(Item item)
        {
            String[] itemDescription = { item.GetName(), item.GetDescription() };
            return itemDescription;
        }
    }
}
