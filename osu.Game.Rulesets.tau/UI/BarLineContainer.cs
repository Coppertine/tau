using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.Objects.Drawables;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace osu.Game.Rulesets.Tau.UI
{
    public class BarLineContainer : BeatSyncedContainer
    {
        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, TrackAmplitudes amplitudes)
        {
            base.OnNewBeat(beatIndex, timingPoint, effectPoint, amplitudes);
            Add(new DrawableBarLine(new TauBarline()));
        }
    }
}
