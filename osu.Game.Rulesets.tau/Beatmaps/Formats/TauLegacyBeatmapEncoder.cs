using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Rulesets.Tau.Beatmaps.Formats
{
    public class TauLegacyBeatmapEncoder
    {
        /// Beat = 1,
        /// BigBeat = 2,
        /// HardBeat = 4,
        /// Slider = 8,
        /// HardSlider = HardBeat | Slider // = 12
    }
}
