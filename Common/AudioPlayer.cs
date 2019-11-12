using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AudioPlayer
    {
        private static System.Media.SoundPlayer player;
        /// <summary>
        /// At the moment can only play .wav files
        /// Throws InvalidOperationException
        /// </summary>
        /// <param name="soundPath"></param>
        public static void PlayAudio(string soundPath)
        {
            StopAudio();
            if (soundPath == null)
                return;

            player = new System.Media.SoundPlayer(soundPath);
            player.Play();
        }

        public static void StopAudio()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }
    }
}
