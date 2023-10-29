using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;


namespace Fall2020_CSC403_Project.code
{
    public class AudioManager
    {
        private static AudioManager instance;
        private Dictionary<string, SoundPlayer> soundPlayer;

        public SoundPlayer soundPlayer1 = new SoundPlayer("enemy_interact_1.wav");
        private SoundPlayer soundPlayer2 = new SoundPlayer();

        private AudioManager() { 
            soundPlayer = new Dictionary<string, SoundPlayer>();
            soundPlayer1.SoundLocation = "C:\\Users\\Ethan\\Documents\\!school\\CSC 403\\CSC-403-Project-g\\Fall2023_CSC403_Project\\Project\\Fall2020_CSC403_Project\\data\\enemy_interact_1.wav";
            soundPlayer2.SoundLocation = "C:\\Users\\Ethan\\Documents\\!school\\CSC 403\\CSC-403-Project-g\\Fall2023_CSC403_Project\\Project\\Fall2020_CSC403_Project\\data\\battle_music.wav";
        }


        public void AddSound(string soundName, System.Media.SoundPlayer soundPath)
        {
            if (!soundPlayer.ContainsKey(soundName))
            {
                soundPlayer.Add(soundName, soundPath);
            }
        }

        public void AsyncPlay(SoundPlayer soundPlayer)
        {
            Thread thread1 = new Thread(() =>
            {
                soundPlayer1.Play();
            });

            Thread thread2 = new Thread(() =>
            {
                soundPlayer2.Play();
            });

            thread1.Start();
            //thread2.Start();
        }
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }
                return instance;
            }
        }

        public void PlaySound(string soundName)
        {
            if (soundPlayer.ContainsKey(soundName))
            {
                soundPlayer[soundName].Play();
            }
        }

        public void PlaySoundLoop(string soundName)
        {
            if (soundPlayer.ContainsKey(soundName))
            {
                soundPlayer[soundName].PlayLooping();
            }
        }

        public void StopSound(string soundName)
        {
            if (soundPlayer.ContainsKey(soundName)) 
            {
                soundPlayer[soundName].Stop();
            }
        }

    }
}
