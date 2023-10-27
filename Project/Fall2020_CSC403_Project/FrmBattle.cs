﻿using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private AudioManager audioManager;
        private Player player;

        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
            audioManager = AudioManager.Instance;
            audioManager.AddSound("final_battle", new SoundPlayer(Resources.final_battle));
            audioManager.AddSound("battle_music", new SoundPlayer(Resources.battle_music));
            audioManager.AddSound("overworld_music", new SoundPlayer(Resources.overworld_music));
        }

        public void Setup()
        {
            audioManager.PlaySoundLoop("battle_music");
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;

            // show health
            UpdateHealthBars();
        }

        public void SetupForBossBattle()
        {
            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = true;
            tmrFinalBattle.Enabled = true;
            audioManager.PlaySound("battle_music");
        }

        public static FrmBattle GetInstance(Enemy enemy)
        {
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup();
            }
            return instance;
        }

        private void UpdateHealthBars()
        {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            player.OnAttack(-4);
            if (enemy.Health > 0)
            {
                enemy.OnAttack(-2);
            }

            UpdateHealthBars();
            if (enemy.Health <= 0)
            {
                enemy.Die();
                instance = null;
                audioManager.StopSound("battle_music");
                Close();
                audioManager.PlaySoundLoop("overworld_music");
            }
            else if (player.Health <= 0)
            {
                player.Die();
                instance = null;
                audioManager.StopSound("battle_music");
                Close();
                audioManager.PlaySoundLoop("overworld_music");
            }
        }

        private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }
    }
}
