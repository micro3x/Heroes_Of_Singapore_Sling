using System;
using System.Linq;
using System.Media;

namespace GameAssets
{
    public class BackgroundMusic
    {
        #region
        //WMPLib.WindowsMediaPlayer Player;

        //private void PlayFile(String url)
        //{
        //    Player = new WMPLib.WindowsMediaPlayer();
        //    Player.PlayStateChange +=
        //        new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
        //    Player.MediaError +=
        //        new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
        //    Player.URL = url;
        //    Player.controls.play();
        //}

        //private void Form1_Load(object sender, System.EventArgs e)
        //{
        //    // TODO  Insert a valid path in the line below.
        //    PlayFile(@"c:\someting.wma");
        //}

        //private void Player_PlayStateChange(int NewState)
        //{
        //    if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
        //    {
        //        //this.Close();
        //    }
        //}

        //private void Player_MediaError(object pMediaObject)
        //{
        //    //Show("Cannot play media file.");
        //    //this.Close();
        //}
        #endregion


        public static bool isPlayingMusic = true;

        private static SoundPlayer fonGameMusic = new SoundPlayer(@"..\..\ExternalSound\backgroundSound.wav");

        public static void PlayIngameMusic()
        {
            fonGameMusic.PlayLooping();
        }
        public static void StopfonGameMusic()
        {
            fonGameMusic.Stop();
        }
        public static void PausefonGameMusic()
        {
            fonGameMusic.Stop();
            isPlayingMusic = false;
        }

        // Fight Sounds Effects:
        #region

        private static SoundPlayer go = new SoundPlayer(@"..\..\ExternalFiles\Go.wav");
        private static SoundPlayer one = new SoundPlayer(@"..\..\ExternalFiles\One.wav");
        private static SoundPlayer two = new SoundPlayer(@"..\..\ExternalFiles\Two.wav");
        private static SoundPlayer three = new SoundPlayer(@"..\..\ExternalFiles\Three.wav");
        // Up - before starting battle
        // Down - during the battle
        private static SoundPlayer kik = new SoundPlayer(@"..\..\ExternalFiles\kik.wav");
        private static SoundPlayer steps = new SoundPlayer(@"..\..\ExternalFiles\steps.wav");
        private static SoundPlayer pain = new SoundPlayer(@"..\..\ExternalFiles\pain.wav");
        private static SoundPlayer sword = new SoundPlayer(@"..\..\ExternalFiles\sword.wav");
        private static SoundPlayer arrow = new SoundPlayer(@"..\..\ExternalFiles\arrow.wav");
        private static SoundPlayer magic = new SoundPlayer(@"..\..\ExternalFiles\vzriv_na_magiq.wav");
        private static SoundPlayer magic_throw = new SoundPlayer(@"..\..\ExternalFiles\magicthrow.wav");

        public static void PlayOne()
        {
            one.Play();
        }
        public static void PlayTwo()
        {
            two.Play();
        }
        public static void PlayThree()
        {
            three.Play();
        }
        public static void PlayGo()
        {
            go.Play();
        }
        public static void PlayKik()
        {
            kik.Play();
        }
        public static void PlayPain()
        {
            pain.Play();
        }
        public static void PlaySteps()
        {
            steps.Play();
        }
        public static void PlaySword()
        {
            sword.Play();
        }
        public static void PlayArrow()
        {
            arrow.Play();
        }
        public static void PlayMagic()
        {
            magic.Play();
        }
        public static void PlayMagic_throw()
        {
            magic_throw.Play();
        }

        #endregion
    }
}