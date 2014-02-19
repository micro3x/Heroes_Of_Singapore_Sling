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

        private static SoundPlayer fonGameMusic = new SoundPlayer(@"..\..\ExternalSound\diablo - 02 - town.wav");

        public static void PlayIngameMusic()
        {
            //C:\Windows\System32\wmp.dll
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
    }
}