﻿using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Tau.Judgements;
using osu.Game.Rulesets.Tau.Scoring;

namespace osu.Game.Rulesets.Tau.Objects
{
    public class TauHitObject : HitObject
    {
        public double TimePreempt = 600;
        public double TimeFadeIn = 100;

        protected override HitWindows CreateHitWindows() => new TauHitWindow();
        public override Judgement CreateJudgement() => new TauJudgement();

        protected override void ApplyDefaultsToSelf(ControlPointInfo controlPointInfo, IBeatmapDifficultyInfo difficulty)
        {
            base.ApplyDefaultsToSelf(controlPointInfo, difficulty);

            TimePreempt = IBeatmapDifficultyInfo.DifficultyRange(difficulty.ApproachRate, 1800, 1200, 450);
        }
    }
}
