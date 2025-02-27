﻿using System.Drawing;
using System;
using System.Windows;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code {
  /// <summary>
  /// This is the class for an enemy
  /// </summary>
  public class Enemy : BattleCharacter {
    /// <summary>
    /// THis is the image for an enemy
    /// </summary>
    public Image Img { get; set; }
    public PictureBox PictureBox { get; set; }

    /// <summary>
    /// this is the background color for the fight form for this enemy
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initPos">this is the initial position of the enemy</param>
    /// <param name="collider">this is the collider for the enemy</param>
    public Enemy(Vector2 initPos, Collider collider, PictureBox picturebox) : base(initPos, collider) {
            PictureBox = picturebox;
    }

    public override void Die()
    {
        DisableCollider();
        PictureBox.Dispose();
    }
  }
}
