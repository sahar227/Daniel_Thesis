using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AudioPlayer
    {
        /// <summary>
        /// At the moment can only play .wav files
        /// Throws InvalidOperationException
        /// </summary>
        /// <param name="soundPath"></param>
        public static void PlayAudio(string soundPath)
        {
            if (soundPath == null)
                return;
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath))
                player.Play();
        }
    }
}
