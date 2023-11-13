using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Threading;
using MyGameLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private AudioManager audioManager;
        private Player player;
        private Questions[] questionsArray;

        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
            audioManager = AudioManager.Instance;
            audioManager.AddSound("final_battle", new SoundPlayer(Resources.final_battle));
            audioManager.AddSound("battle_music", new SoundPlayer(Resources.battle_music));
            audioManager.AddSound("overworld_music", new SoundPlayer(Resources.overworld_music));
            audioManager.AddSound("enemy_interact_1", new SoundPlayer(Resources.enemy_interact_1));

            questionsArray = new Questions[7]
            {
                new Questions
                {
                    id = 1,
                    options = new[] { "Keeny Hall", "Bogard Hall", "Wyly Tower", "IESB" },
                    answer = "Keeny Hall",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Keeny_Hall,
                },
                new Questions
                {
                    id = 2,
                    options = new[] { "Seattle", "Portland", "Ruston", "New York" },
                    answer = "Portland",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Portland,  
                },
                new Questions
                {
                    id = 3,
                    options = new[] { "Keeny Hall", "IESB", "Nethkin Hall", "Bogard Hall" },
                    answer = "Bogard Hall",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Bogard_Hall,
                },
                new Questions
                {
                    id = 4,
                    options = new[] { "Ukraine", "Germany", "Belgium", "Poland" },
                    answer = "Poland",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Warsaw_Poland,
                },
                new Questions
                {
                    id = 5,
                    options = new[] { "USA", "Argentina", "Greenland", "Norway" },
                    answer = "Argentina",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Argentina,
                },
                new Questions
                {
                    id = 6,
                    options = new[] { "Busan", "Seoul", "Shanghai", "Tokyo" },
                    answer = "Tokyo",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Tokyo_Japan,
                },
                new Questions
                {
                    id = 7,
                    options = new[] { "Busan", "Seoul", "Shanghai", "Tokyo" },
                    answer = "Busan",
                    image = global::Fall2020_CSC403_Project.Properties.Resources.Question_GeoGuesser_Busan_South_Korea,
                }
            };
        }

        public void Setup()
        {
            audioManager.PlaySound("enemy_interact_1");
            Thread.Sleep(2000);
            audioManager.PlaySoundLoop("battle_music");

            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;
            enemy.BlockEvent += PlayerDamage;
            player.BlockEvent += EnemyDamage;

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

        public void UpdateHealthBars()
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

            healthCheck(sender, e);
        }

        public void healthCheck(object sender, EventArgs e)
        {
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

        private void btnBlock_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int roll = r.Next(-2, 1);
            Console.WriteLine(roll);
            player.OnBlock(roll);
            healthCheck(sender, e);
            if (enemy.Health > 0)
            {
                if (roll == 0)
                {
                    enemy.OnBlock(roll);
                }
                else 
                {
                    player.AlterHealth(roll);
                }
            }

        }

        private void btnParry_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Questions randomQuestion = questionsArray[random.Next(questionsArray.Length)];

            FrmSkillCheck screen = new FrmSkillCheck(randomQuestion, enemy, instance);
            screen.ShowDialog();  // Use ShowDialog to make it a modal dialog

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
