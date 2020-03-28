using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using System;
using System.Collections.Generic;
using System.Text;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Tau.Objects.Drawables
{
    public class DrawableBarLine : DrawableHitObject<HitObject>
    {
        /// <summary>
        /// The width of the line tracker.
        /// </summary>
        private const float tracker_width = 2f;

        /// <summary>
        /// Fade out time calibrated to a pre-empt of 1000ms.
        /// </summary>
        private const float base_fadeout_time = 100f;

        /// <summary>
        /// The visual Circle tracker.
        /// </summary>
        protected Circle Tracker;

        /// <summary>
        /// The bar line.
        /// </summary>
        protected readonly TauBarline BarLine;

        public DrawableBarLine(TauBarline barLine)
            : base(barLine)
        {
            BarLine = barLine;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            RelativeSizeAxes = Axes.Both;
        

            AddInternal(Tracker = new Circle
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Masking = true,
                FillMode = FillMode.Fit,
                FillAspectRatio = 1, // 1:1 Aspect ratio to get a perfect circle
                BorderThickness = tracker_width,
                BorderColour = Color4.White,
                Alpha = 0.75f,
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    AlwaysPresent = true,
                    Alpha = 0,
                }
            });
        }

        protected override void UpdateStateTransforms(ArmedState state) => this.FadeOut(150);
    }
}
