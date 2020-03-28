using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Rulesets.Tau.Objects
{
    public class TauBarline : TauHitObject, IBarLine
    {
        public bool Major { get; set; }
        public override Judgement CreateJudgement() => new IgnoreJudgement();
    }
}
