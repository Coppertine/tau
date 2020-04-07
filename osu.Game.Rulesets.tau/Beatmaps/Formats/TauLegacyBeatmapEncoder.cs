using System;
using System.Collections.Generic;
using System.Text;
using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.Tau.Beatmaps.Formats
{
    public class TauLegacyBeatmapEncoder
    {
        /// Beat = 1,
        /// BigBeat = 2,
        /// HardBeat = 4,
        /// Slider = 8,
        /// HardSlider = HardBeat | Slider // = 12

        public const int LATEST_VERSION = 1;

        private readonly IBeatmap beatmap;

    }
}
