using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AudioPlayer
    {
        private static WMPLib.WindowsMediaPlayer wplayer;

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

            wplayer = new WMPLib.WindowsMediaPlayer
            {
                URL = soundPath
            };
            wplayer.controls.play();
        }

        public static void StopAudio()
        {
            if(wplayer != null)
            {
                wplayer.controls.stop();
                wplayer = null;
            }
        }
    }
}
