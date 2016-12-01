using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MoLiFrameWork.Event
{


    public class EventDef
    {
        public const int ResLoadFinish = 1;
        public const int TableDataFinish = 2000;
        public const int LoadCardInfo = 6000;
        public const int VoiceEvent = 7000;
        public const int GameEvent = 8000;
        public const int PhotoButtonEvent = 9000;
        public const int TrackObjectHideEvent = 90001;
        public const int ListenterGameEvent = 9002;

        public const int ListenterResult = 9003;


        public const int RecognitionEvnet = 9004;
        public const int RecognitionLost = 9005;
        public const int ParticleSystemEvent = 9006;

        public const int ModelSwiteched = 9007;

    }
}